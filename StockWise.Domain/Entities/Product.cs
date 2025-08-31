using System;
using System.Collections.Generic;

namespace StockWise.Domain.Entities;

public partial class Product
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? Sku { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public int? CategoryId { get; set; }
    public int? SupplierId { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public virtual Category? Category { get; set; }
    public virtual ICollection<StockMovement> StockMovements { get; set; } = new List<StockMovement>();
    public virtual Supplier? Supplier { get; set; }
}
