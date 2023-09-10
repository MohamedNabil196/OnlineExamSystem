using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.DTOs.AuthDTO_s
{
    public class RegisterModel
    {

        [Required, StringLength(100)]
        public string? Username { get; set; }
        [Required, StringLength(100)]
        public string FirstNameAr { get; set; }
        [Required, StringLength(100)]
        public string FirstNameEn { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        public string HashPassword { get; set; }
    }
}
