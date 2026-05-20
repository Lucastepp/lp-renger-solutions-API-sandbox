using Microsoft.AspNetCore.Mvc;
using RengerSolutionsAPI.Data;
using RengerSolutionsAPI.Services;

namespace RengerSolutionsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound("Product not found.");
            }

            return Ok(product);
        }
    }
}