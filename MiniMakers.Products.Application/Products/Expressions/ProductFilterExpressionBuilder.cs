using System.Linq.Expressions;
using MiniMakers.Products.Domain.Entities;
using MiniMakers.Products.Application.Products.Queries;

namespace MiniMakers.Products.Application.Products.Expressions;

public class ProductFilterExpressionBuilder
{
    public static Expression<Func<Product, bool>> Build(GetProductsQuery query)
    {
        Expression<Func<Product, bool>> expression = p => true;
         
        return product =>
            (string.IsNullOrEmpty(query.Category) || product.Category == query.Category) &&
            (!query.MinPrice.HasValue || product.Price >= query.MinPrice.Value) &&
            (!query.MaxPrice.HasValue || product.Price <= query.MaxPrice.Value) &&
            (!query.IsActive.HasValue || product.IsActive == query.IsActive.Value);
    }
}
