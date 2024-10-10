using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Mina.Core.Dtos.Products;
using Store.Mina.Core.Entities;
using Store.Mina.Core.Helper;
using Store.Mina.Core.Services.Contract;
using Store.Mina.Core.Specifications.Products;

namespace Store.Mina.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductSpecParams productSpec)// endpoint
        {
            var result = await _productService.GetAllProductAsync(productSpec);

            return Ok(result);
        }


        [HttpGet("Brands")]
        public async Task<IActionResult> GetAllBrands()// endpoint
        {
            var result = await _productService.GetAllBrandsAsync();

            return Ok(result);
        }


        [HttpGet("Types")]
        public async Task<IActionResult> GetAllTypes()// endpoint
        {
            var result = await _productService.GetAllTypesAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductById(int? id)
        {
            if (id == null) return BadRequest("Invalid id !!");
            var result = await _productService.GetProductByIdAsync(id.Value);

            if (result == null) return NotFound($"The Product With Id: {id} Not Found At DB :(");

            return Ok(result);
        }

    }
}
