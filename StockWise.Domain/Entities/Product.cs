using System;
using System.Collections.Generic;

namespace StockWise.Domain.Entities;

public partial class Product
{
    public int Productid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Sku { get; set; }

    public decimal Price { get; set; }

    public int Quantityinstock { get; set; }

    public int? Categoryid { get; set; }

    public int? Supplierid { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Stockmovement> Stockmovements { get; set; } = new List<Stockmovement>();

    public virtual Supplier? Supplier { get; set; }
}
