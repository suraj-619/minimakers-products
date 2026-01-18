using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMakers.Prodicts.API.Contracts.Common
{
    public class PagedResponse<T>
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalRecords { get; init; }
        public int TotalPages { get; init; }
        public IReadOnlyList<T> Data { get; init; } = Array.Empty<T>();
    }
}
