using Microsoft.AspNetCore.Mvc;
using RengerSolutionsAPI.Data;
using RengerSolutionsAPI.Models;
using Microsoft.EntityFrameworkCore;
using RengerSolutionsAPI.DTOs;

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
        public async Task<ActionResult<Order>> CreateOrder(CreateOrderRequest request)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                OrderNumber = request.OrderNumber,
                OrderDate = DateTime.UtcNow,
                Items = request.Items.Select(i => new OrderItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetOrderById),
                new { id = order.Id },
                order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(Guid id, CreateOrderRequest request)
        {
            var orderToUpdate = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (orderToUpdate == null)
            {
                return NotFound();
            }

            orderToUpdate.CustomerId = request.CustomerId;
            orderToUpdate.OrderNumber = request.OrderNumber;

            await _context.SaveChangesAsync();

            return Ok(orderToUpdate);
        }
    }
}
