using Microsoft.AspNetCore.Mvc;
using RengerSolutionsAPI.Data;

namespace RengerSolutionsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok();
        }
    }
}