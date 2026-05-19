using Microsoft.AspNetCore.Mvc;
using RengerSolutionsAPI.Data;

namespace RengerSolutionsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task <IActionResult> GetAllOrders()
        {
            return Ok();
        }
    }
}
