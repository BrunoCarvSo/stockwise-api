using System.ComponentModel.DataAnnotations;

namespace StockWise.API.DTOs
{
    public class ProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public string Sku { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantityInStock { get; set; }
        [Required]
        public bool IsActive { get; set; }

        //só IDs das entidades relacionadas são necessários
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
    }
}