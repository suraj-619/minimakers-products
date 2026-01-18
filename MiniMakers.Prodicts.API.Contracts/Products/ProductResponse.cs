using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMakers.Prodicts.API.Contracts.Products
{
    public class ProductResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = default!;
        public string Category { get; init; } = default!;
        public decimal Price { get; init; }
        public bool IsActive { get; init; }
        public DateTime CreatedDate { get; init; }
    }
}
