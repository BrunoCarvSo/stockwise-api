using System.ComponentModel.DataAnnotations;

namespace StockWise.DTOs
{
    public class SupplierDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string? ContactName { get; set; }
        [Required]
        public string? ContactEmail { get; set; }
        [Required]
        [StringLength(11)]
        public string? ContactPhone { get; set; }
        [Required]
        public string? Address { get; set; }

    }
}
