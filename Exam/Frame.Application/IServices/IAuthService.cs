using Exam.Application.DTOs.AuthDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.IServices
{
    public interface IAuthService
    {
        Task<AuthModels> RegisterAdminAsync(RegisterModel registerModel);

    }
}
