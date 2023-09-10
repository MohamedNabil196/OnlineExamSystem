using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs.AuthDTO_s
{
    public class AuthModels
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string? UserIdentityId { get; set; }
        public int? UserId { get; set; }
        public List<string> Roles { get; set; }
        public IList<Claim> Claims { get; set; }
        public string UserStatus { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
