using MiniMakers.Products.Domain.Entities;

namespace MiniMakers.Products.Application.Products.Interfaces;

public interface IProductRepository
{
     IQueryable<Product> Query();
}
