using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MiniMakers.Products.Infrastructure.Persistence;

public class ProductsDbContextFactory
    : IDesignTimeDbContextFactory<ProductsDbContext>
{
    public ProductsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ProductsDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=localhost\\SQLEXPRESS;Database=Products;Trusted_Connection=true;TrustServerCertificate=true");

        return new ProductsDbContext(optionsBuilder.Options);
    }
}
