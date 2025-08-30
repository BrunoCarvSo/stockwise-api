using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockWise.Domain.Entities;

public partial class Stockmovement
{
    [Key]
    public int movement_id { get; set; }

    public int? product_id { get; set; }

    public string? movement_type { get; set; }

    public int quantity { get; set; }

    public DateTime? movement_date { get; set; }

    public string? description { get; set; }

    public string? related_entity_id { get; set; }

    public DateTime? created_at { get; set; }

    public virtual Product? product { get; set; }
}
