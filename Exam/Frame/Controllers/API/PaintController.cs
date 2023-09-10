//using Exam.Application.DTOs.ResponsDTO;
//using Exam.Application.IServices;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;

//namespace Exam.Controllers.API
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class PaintController : ControllerBase
//    {
//        public IPaintService _paintService;
//        public PaintController(IPaintService IPaintService)
//        {
//            _paintService = IPaintService;
//        }
//        //[HttpGet("GetAll")]
//        //public async Task<IActionResult> GetAll()
//        //{
//        //	var result = _paintService.GetAll(1,10);
//        //	return Ok(result);

//        //}
//        [HttpGet("GetAll")]
//        public async Task<IActionResult> GetAll([FromQuery] UrlQueryParameters urlQueryParameters)
//        {
//            BaseResult Response = new BaseResult();

//            #region Model is Valid
//            if (ModelState.IsValid)
//            {
//                var returnResultfromDb = _paintService.GetAll(urlQueryParameters.Page, urlQueryParameters.Limit); ;
//                if (returnResultfromDb == null)
//                {
//                    Response.ErrorMessage = new List<string>() { "Not found" };
//                    Response.Data = null;
//                    Response.Success = false;
//                    return BadRequest(Response);
//                }
//                Response.Data = returnResultfromDb;
//                Response.ErrorMessage = null;
//                Response.Success = true;
//                return Ok(Response);
//            }
//            #endregion

//            Response.ErrorMessage = new List<string>() { string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)) };
//            Response.Data = null;
//            Response.Success = false;
//            return BadRequest(Response);
//        }


//        public record UrlQueryParameters(int Limit = 50, int Page = 1);


//    }
//}
