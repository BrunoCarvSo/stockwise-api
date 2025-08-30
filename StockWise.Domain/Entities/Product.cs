using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockWise.Domain.Entities;

public partial class Product
{
    [Key]
    public int product_id { get; set; }

    public string name { get; set; } = null!;

    public string? description { get; set; }

    public string? sku { get; set; }

    public decimal price { get; set; }

    public int quantity_in_stock { get; set; }

    public int? category_id { get; set; }

    public int? supplier_id { get; set; }

    public bool? is_active { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual Category? category { get; set; }

    public virtual ICollection<Stockmovement> stockmovements { get; set; } = new List<Stockmovement>();

    public virtual Supplier? supplier { get; set; }
}
