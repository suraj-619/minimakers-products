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
        // Apply defaults if not provided
        var pageNumber = query.PageNumber == 0 ? 1 : query.PageNumber;
        var pageSize = query.PageSize == 0 ? 25 : query.PageSize;

        var products = _repository.Query();
        var predicate = ProductFilterExpressionBuilder.Build(query);
        products = products.Where(predicate);
        
        // Execute count and get paginated data
        var totalRecords = products.Count();
        var data = products.OrderBy(x => x.CreatedDate)
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        
        return new PagedResult<Product>
        {
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalRecords = totalRecords,
            TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
            Data = data
        };
    }
}
