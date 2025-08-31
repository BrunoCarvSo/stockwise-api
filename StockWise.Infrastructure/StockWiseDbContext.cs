using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockWise.Domain.Entities;

namespace StockWise.Infrastructure
{
    public class StockWiseDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public StockWiseDbContext(DbContextOptions<StockWiseDbContext> options)
            : base(options)
        {
        }

    }
}
