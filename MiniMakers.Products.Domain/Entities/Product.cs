using System;

namespace MiniMakers.Products.Domain.Entities;
public class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Category { get; private set; }

    public decimal Price { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedDate { get; private set; }

    // Constructor for creating new product
    public Product(
        Guid id,
        string name,
        string category,
        decimal price,
        bool isActive,
        DateTime createdDate)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        IsActive = isActive;
        CreatedDate = createdDate;
    }

}
