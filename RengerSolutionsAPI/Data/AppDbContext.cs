using Microsoft.EntityFrameworkCore;
using RengerSolutionsAPI.Models;

namespace RengerSolutionsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        // Define your DbSets here, for example:
        public DbSet<Order> Orders { get; set; }
    }
}
