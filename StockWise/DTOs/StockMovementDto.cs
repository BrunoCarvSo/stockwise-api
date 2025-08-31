using StockWise.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace StockWise.DTOs
{
    public class StockMovementDto
    {
        [Required]
        public int? ProductId { get; set; }
        [Required]
        public string? MovementType { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
