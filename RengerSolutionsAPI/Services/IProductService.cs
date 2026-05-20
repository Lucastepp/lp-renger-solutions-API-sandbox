using RengerSolutionsAPI.Models;

namespace RengerSolutionsAPI.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}
