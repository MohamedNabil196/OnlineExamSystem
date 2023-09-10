using Exam.Application.IRepository;
using Exam.Application.IServices;
using Exam.Application.Services;
using Exam.Domain.Entities;
using Exam.Infrastructure.Data.Context;
using Exam.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
#region DatabaseCreation
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

#region Add AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region Password 

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => {

	options.Password.RequireNonAlphanumeric = true;
	options.Password.RequiredLength = 8;
	options.Password.RequireUppercase = true;
	options.Password.RequireLowercase = true;
	options.Password.RequireDigit = true;

	options.User.RequireUniqueEmail = true;


}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
#endregion

#endregion

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddTransient<IDbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    return new SqlConnection(connectionString);
});
// Add services to the container.
builder.Services.AddScoped<IFirstClassService, FirstClassService>();
builder.Services.AddScoped<IFirstClassRepo, FirstClassRepo>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
		name: "default",
		pattern: "{controller=Home}/{action=Index}/{id?}");
	endpoints.MapControllers(); // Add this line to handle API routes
});

app.Run();
