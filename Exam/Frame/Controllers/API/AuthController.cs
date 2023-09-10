using Exam.Application.DTOs.AuthDTO_s;
using Exam.Application.DTOs.ResponsDTO;
using Exam.Application.IServices;
using Exam.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Exam.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _AuthRepo;


        public AuthController(ILogger<AuthController> logger, IAuthService AuthRepo)
        {
            _logger = logger;
            _AuthRepo = AuthRepo;

        }

        [HttpPost("RegisterAsyncAdmin")]
        public async Task<IActionResult> RegisterAsyncAdmin([FromBody] RegisterModel registerModel)
        {
            _logger.LogInformation($"RegisterAsyncAdmin {MethodBase.GetCurrentMethod()?.Name}");
            BaseResult Response = new BaseResult();
            #region Model is Valid
            if (ModelState.IsValid)
            {
                var returnResultfromDb = await _AuthRepo.RegisterAdminAsync(registerModel);

                if (!returnResultfromDb.IsAuthenticated)
                {
                    Response.ErrorMessage = new List<string>() { returnResultfromDb.Message };
                    Response.Data = null;
                    Response.Success = false;
                    return BadRequest(Response);
                }

                Response.Data = returnResultfromDb;
                Response.ErrorMessage = null;
                Response.Success = true;
                return Ok(Response);
            }
            #endregion

            _logger.LogError($"Error {MethodBase.GetCurrentMethod()?.Name}");
            Response.ErrorMessage = new List<string>() { string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)) };
            Response.Data = null;
            Response.Success = false;
            return BadRequest(Response);

        }
    }
}
