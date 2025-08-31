using System;
using System.Collections.Generic;

namespace StockWise.Domain.Entities;

public partial class StockMovement
{
    public int StockMovementId { get; set; }
    public int? ProductId { get; set; }
    public string? MovementType { get; set; }
    public int Quantity { get; set; }
    public DateTime? MovementDate { get; set; }
    public string? Description { get; set; }
    public string? RelatedEntityId { get; set; }
    public virtual Product? Product { get; set; }
}