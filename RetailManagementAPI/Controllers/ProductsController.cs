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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService) {
            _productsService = productsService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var data = await _productsService.GetAllProducts();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel() { Message = Message.Error, Status = APIStatus.Error, Data = null });
            }
        }
        
        [HttpGet("GetProductById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var data = await _productsService.GetPrdouctById(id);
                return Ok(new ResponseModel() { Message = Message.Successfully, Status = APIStatus.Successful, Data = data });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel() { Message = Message.Error, Status = APIStatus.Error, Data = null });
            }
        }

        [HttpPost("AddNewProduct")]
        public async Task<IActionResult> AddNewProduct(ProductDTO pd)
        {
            try
            {
                var data = await _productsService.AddNewPrdouct(pd);
                return Ok(new ResponseModel() { Message = Message.InsertedSuccessfully, Status = APIStatus.Successful, Data = data });
            }
            catch (Exception)
            {
                return BadRequest(new ResponseModel() { Message = Message.Error, Status = APIStatus.Error, Data = null });
            }
        }

        [HttpPut("UpdateProductById")]
        public async Task<IActionResult> UpdateProductById(Guid id, ProductDTO pd)
        {
            try
            {
                var data = await _productsService.UpdateProductById(id, pd);
                return Ok(new ResponseModel() { Message = Message.UpdatedSuccess, Status = APIStatus.Successful, Data = data });
            }
            catch (Exception)
            {
                return BadRequest(new ResponseModel() { Message = Message.Error, Status = APIStatus.Error, Data = null });
            }
        }


        [HttpDelete("DeleteProductById")]
        public async Task<IActionResult> DeleteProductById(Guid id)
        {
            try
            {
                var data = await _productsService.DeleteProductById(id);
                return Ok(new ResponseModel() { Message = Message.DeletedSuccess, Status = APIStatus.Successful, Data = data });
            }
            catch (Exception)
            {
                return BadRequest(new ResponseModel() { Message = Message.Error, Status = APIStatus.Error, Data = null });
            }
        }

        
    }
}
