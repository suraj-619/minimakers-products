using MediatR;
using MiniMakers.Products.Application.Products.Common;
using MiniMakers.Products.Domain.Entities;
using System;

namespace MiniMakers.Products.Application.Products.Queries;

public class GetProductsQuery : IRequest<PagedResult<Product>>
{
    // Filtering
    public string? Category { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public bool? IsActive { get; init; }

    // Pagination
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
}
