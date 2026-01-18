using MediatR;
using MiniMakers.Products.Application.Products.Common;
using MiniMakers.Products.Application.Products.Expressions;
using MiniMakers.Products.Application.Products.Interfaces;
using MiniMakers.Products.Domain.Entities;

namespace MiniMakers.Products.Application.Products.Queries;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PagedResult<Product>>
{
    private readonly IProductRepository _repository;
    public GetProductsQueryHandler(IProductRepository repository)
    {
      _repository = repository;
    }
     public async Task<PagedResult<Product>> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = _repository.Query();
        var predicate = ProductFilterExpressionBuilder.Build(query);
        products = products.Where(predicate);
        var totalRecords = products.Count();
        products = products.OrderBy(x=>x.CreatedDate)
                           .Skip((query.PageNumber - 1) * query.PageSize)
                           .Take(query.PageSize);
        var data = products.ToList();
        return new PagedResult<Product>
        {
            PageNumber = query.PageNumber,
            PageSize = query.PageSize,
            TotalRecords = totalRecords,
            TotalPages = (int)Math.Ceiling(totalRecords / (double)query.PageSize),
            Data = data
        };
    }
}
