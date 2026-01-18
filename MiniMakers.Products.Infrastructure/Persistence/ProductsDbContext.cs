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

        public void onModelCreating (ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Product>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            //    entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
            //    entity.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
            //    entity.Property(e => e.IsActive).IsRequired();
            //    entity.Property(e => e.CreatedDate).IsRequired();
            //});

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsDbContext).Assembly);
        }
    }
}
