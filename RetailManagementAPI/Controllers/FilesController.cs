using BAL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODEL.Message;
using Model;

namespace RetailManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFilesService _filesService;   

        public FilesController(IFilesService filesService)
        {
            _filesService = filesService;
        }

        [HttpPost("UploadFile")]

        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var data = await _filesService.UploadFile(file);
                return Ok(new ResponseModel() { Message = Message.Successfully, Status = APIStatus.Successful, Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel() { Message = ex.InnerException.Message, Status = APIStatus.Error });
            }

        }
        
    }
}
