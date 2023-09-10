using Exam.Application.DTOs.AuthDTO_s;
using Exam.Application.Helpers.AuthHelpers;
using Exam.Application.IRepository;
using Exam.Application.IServices;
using Exam.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Exam.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRepository<Admin> _AdminsRepo;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        public AuthService(UserManager<ApplicationUser> userManager, IRepository<Admin> AdminsRepo,  RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _AdminsRepo = AdminsRepo;
            _jwt = jwt.Value;
            _roleManager = roleManager;


        }
            private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
            {
                var userClaims = await _userManager.GetClaimsAsync(user);
                var roles = await _userManager.GetRolesAsync(user);
                var roleClaims = new List<Claim>();

                foreach (var role in roles)
                    roleClaims.Add(new Claim("roles", role));

                string DecryptUserName = user.UserName;
                string DecryptEamil = (user.Email);
                var claimss = new List<Claim>
            {
              new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("useridentityid", user.Id),
                new Claim("uid", user.Id.ToString())

            }
                .Union(userClaims)
               .Union(roleClaims);

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                    audience: _jwt.Audience,
                    claims: claimss,
                    expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                    signingCredentials: signingCredentials);

                return jwtSecurityToken;
            }


            public async Task<AuthModels> RegisterAdminAsync(RegisterModel registerModel)
            {
                //string EncryptedUserName = adminUser.Username;
                //string EncryptedEmail = adminUser.Email;
                //string EncryptedPassword = adminUser.Password;

                if (await _userManager.FindByEmailAsync(registerModel.EmailAddress) != null)
                {
                    throw new Exception($"Email is already registered!");
                }
                if (await _userManager.FindByNameAsync(registerModel.Username) != null)
                {
                    throw new Exception($"Username is already registered!");
                }

                try
                {
                    // Create a new ApplicationUser representing the admin user
                    var user = new ApplicationUser
                    {
                        UserName = registerModel.Username,
                        Email = registerModel.EmailAddress,
                        PasswordHash = registerModel.HashPassword
                    };
                    // Create the ApplicationUser using UserManager
                    var AdminCreation = await _userManager.CreateAsync(user, registerModel.HashPassword);

                    if (!AdminCreation.Succeeded)
                    {

                        var errors = string.Empty;

                        foreach (var error in AdminCreation.Errors)
                            errors += $"{error.Description},";

                        return new AuthModels { Message = errors };
                    }
                    // Create a new Admin entity and associate it with the ApplicationUser
                    var admin = new Admin
                    {
                        IsActive = true,
                        NameAr = registerModel.FirstNameAr,
                        NameEn = registerModel.FirstNameEn,
                        CancelBy = registerModel.Username,
                        CreatedBy = registerModel.Username,
                        CancelDate = DateTime.Now,
                        IsCanceled = true,
                        LastModifiedDate = DateTime.Now,
                        ModifyBy = registerModel.Username,
                        Path = registerModel.EmailAddress

                    };

                    // Set the UserId of the Admin entity to match the ApplicationUser's Id
                    admin.UserId = user.Id;

                    // Add the Admin entity to the repository and save changes
                    _AdminsRepo.Insert(admin);
                    _AdminsRepo.Save();

                    // Associate the Admin entity with the ApplicationUser
                    admin.User = user;
                    _AdminsRepo.Update(admin);
                    _AdminsRepo.Save();

                //await _userManager.AddToRoleAsync(user, UserRole.Admin.ToString());
                //await _userManager.AddClaimAsync(user, new Claim(UserStatus.Pending.ToString(), UserStatus.Pending.ToString()));

                // Get user information and return the AuthModel
                var Roles = await _userManager.GetRolesAsync(user);
                    var JwtToken = await CreateJwtToken(user);
                    var Claims = await _userManager.GetClaimsAsync(user);

                    return new AuthModels
                    {
                        Email = user.Email,
                        ExpiresOn = JwtToken.ValidTo,
                        Roles = Roles.ToList(),
                        IsAuthenticated = true,
                        UserIdentityId = user.Id,
                        UserId = admin.Id,
                        Username = user.UserName,
                        Token = new JwtSecurityTokenHandler().WriteToken(JwtToken),
                        UserStatus = Claims.FirstOrDefault()?.Type
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return new AuthModels { Message = "An error occurred during registration." };
                }
            }
        }

    }

