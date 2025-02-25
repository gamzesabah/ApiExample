using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProductsAsync()
        {
            var response = await _productService.GetAllAsync();
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProductAsync([FromBody] Product product)
        {
            var response = await _productService.CreateProductAsync(product);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult> UpdateProductAsync([FromBody] Product product)
        {           
             var response = await _productService.UpdateProductAsync(product);
            if (!response.Success)
            {
                return BadRequest(response.Message); 
            }
            return Ok(response.Data);  
        }

        [HttpDelete("DeleteProductAsync/{id}")]
        public async Task<ActionResult> DeleteProductAsync(Guid id)
        {
            var response = await _productService.DeleteProductAsync(id);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}

