using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMakers.Prodicts.API.Contracts.Products
{
    public class GetProductsRequest
    {
        // Filtering
        public string? Category { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public bool? IsActive { get; set; }

        // Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
