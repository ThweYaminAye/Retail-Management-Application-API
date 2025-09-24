using BAL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using MODEL.Entities;
using MODEL.Message;
using MODEL.DTO;
using BAL;
using Microsoft.AspNetCore.Authorization;

namespace RetailManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetEmployeeByCompanyID")]

        public async Task<IActionResult> GetEmployeeByCompanyID(Guid id)
        {
            try
            {
                var data = _employeeService.GetEmployeeByCompanyID(id);
                return Ok(data);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost("AddNewUser")]

        public async Task<IActionResult> AddNewUser(UserInfoDTO newuser)
        {
            try
            {
                var data = await _employeeService.AddNewUser(newuser);
                return Ok(new ResponseModel() { Message = Message.UpdatedSuccess, Status = APIStatus.Successful, Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginInput)
        {
           

            var token = await _employeeService.Login(loginInput);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(new JwtTokenResponse { Token = token });

            //if (authModel.UserName == "admin" && authModel.UserPassword == "admin")
            //{
            //    var token = tokenGenerator.GenerateToken(authModel.UserName, "admin");
            //    return Ok(new JwtTokenResponse { Token = token });
            //}
            //else if (authModel.UserName == loginInput.UserName && authModel.UserPassword == loginInput.UserPassword)
            //{
            //    var token = tokenGenerator.GenerateToken(authModel.UserName, "user");
            //    return Ok(new JwtTokenResponse { Token = token });
            //}

           
        }
    }


}
