using MiniMakers.Products.Application.Products.Interfaces;
using MiniMakers.Products.Domain.Entities;
using MiniMakers.Products.Infrastructure.Persistence;

namespace MiniMakers.Products.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductsDbContext _context;

    public ProductRepository(ProductsDbContext context)
    {
        _context = context;
    }

    public IQueryable<Product> Query()
    {
        return _context.Products.AsQueryable();
    }
}
