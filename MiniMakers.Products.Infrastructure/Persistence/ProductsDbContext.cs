using Microsoft.EntityFrameworkCore;
using MiniMakers.Products.Domain.Entities;

namespace MiniMakers.Products.Infrastructure.Persistence
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
           
        }
        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsDbContext).Assembly);
        }
    }
}
