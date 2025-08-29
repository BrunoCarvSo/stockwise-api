using System;
using System.Collections.Generic;

namespace StockWise.Domain.Entities;

public partial class Stockmovement
{
    public int Movementid { get; set; }

    public int? Productid { get; set; }

    public string? Movementtype { get; set; }

    public int Quantity { get; set; }

    public DateTime? Movementdate { get; set; }

    public string? Description { get; set; }

    public string? Relatedentityid { get; set; }

    public DateTime? Createdat { get; set; }

    public virtual Product? Product { get; set; }
}
