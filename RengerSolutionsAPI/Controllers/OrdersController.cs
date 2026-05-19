using Microsoft.AspNetCore.Mvc;
using RengerSolutionsAPI.Data;
using RengerSolutionsAPI.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(Guid id)
        {
            var orderById = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (orderById == null)
            {
                return NotFound();
            }

            return Ok(orderById);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            order.Id = Guid.NewGuid();

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetOrderById),
                new { id = order.Id },
                order);
        }
    } 
}
