using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockWise.Domain.Entities;

public partial class Supplier
{
    [Key]
    public int supplier_id { get; set; }

    public string name { get; set; } = null!;

    public string? contact_name { get; set; }

    public string? contact_email { get; set; }

    public string? contact_phone { get; set; }

    public string? address { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<Product> products { get; set; } = new List<Product>();
}
