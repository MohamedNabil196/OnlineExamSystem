using Exam.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exam.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirstClassController : ControllerBase
    {
        public IFirstClassService _firstClassService;
        public FirstClassController(IFirstClassService firstClassService)
        {
            _firstClassService = firstClassService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = _firstClassService.GetAll();
            return Ok(result);

        }


    }
}
