using BAL.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model;
using MODEL.DTO;
using MODEL.Entities;
using MODEL.Message;

namespace RetailManagementAPI.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    { 

    private readonly ISalesService _isalesService;
    public SalesController(ISalesService salesService)
    {
        _isalesService = salesService;
    }
    
        [HttpPost("BuyProducts")]
        public async Task<IActionResult> BuyProducts(Guid id, int quantity)
        {
            try
            {
                var data = await _isalesService.BuyProducts(id, quantity);
                return Ok(new ResponseModel() { Message = Message.Successfully, Status = APIStatus.Successful, Data = data });

            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel() { Message = Message.Error, Status = APIStatus.Error});
            }

        }

        [HttpGet("ViewSalesReport")]

        public async Task<IActionResult> ViewSalesReport()
        {
            try
            {
                var data = await _isalesService.ViewSalesReport();
                return Ok(new ResponseModel() { Message = Message.Successfully, Status= APIStatus.Successful, Data = data });
            }
            catch (Exception)
            {
                return BadRequest(new ResponseModel() { Message = Message.Error, Status = APIStatus.Error, Data = null });
            }
        }

        [HttpGet("TotalSummary")]

        public async Task<IActionResult> TotalSummary()
        {
            try
            {
                var data = await _isalesService.TotalSummary();
                return Ok(new ResponseModel() { Message = Message.Successfully, Status = APIStatus.Successful, Data = data});
            }
            catch (Exception)
            {
                return BadRequest(new ResponseModel() { Message = Message.Error, Status = APIStatus.Error, Data = null });
            }
        }

        [HttpGet("SalesByDate")]

        public async Task<IActionResult> SalesByDate(string inputDate)
        {
            try
            {
                var data = await _isalesService.SalesByDate(inputDate);
                return Ok(new ResponseModel() { Message = Message.Successfully, Status = APIStatus.Successful, Data=data});

            }
            catch(Exception)
            {
                return BadRequest(new ResponseModel() { Message = Message.Error, Status = APIStatus.Error, Data = null });
            }
        }
    }
}
