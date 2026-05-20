using RengerSolutionsAPI.Data;
using RengerSolutionsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RengerSolutionsAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
