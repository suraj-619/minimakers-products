using System;

namespace MiniMakers.Products.Application.Products.Common;

public class PagedResult<T>
{
    public int PageNumber { get; init; }
    public int PageSize { get; init; }
    public int TotalRecords { get; init; }
    public int TotalPages { get; init; }
    public IReadOnlyList<T> Data { get; init; } = Array.Empty<T>();
}
