using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RengerSolutionsAPI.Data;
using RengerSolutionsAPI.DTOs;
using RengerSolutionsAPI.Models;

namespace RengerSolutionsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(Guid id)
        {
            var customerById = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if (customerById == null)
            {
                return NotFound();
            }

            return Ok(customerById);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer(CreateCustomerRequest request)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
            };

            _context.Customers.Add(customer);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetCustomerById), 
                new { id = customer.Id }, 
                customer);
        }
    }
}
