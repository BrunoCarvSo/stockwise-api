using System;
using System.Collections.Generic;

namespace StockWise.Domain.Entities;

public partial class Supplier
{
    public int Supplierid { get; set; }

    public string Name { get; set; } = null!;

    public string? Contactname { get; set; }

    public string? Contactemail { get; set; }

    public string? Contactphone { get; set; }

    public string? Address { get; set; }

    public DateTime? Createdat { get; set; }

    public DateTime? Updatedat { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
