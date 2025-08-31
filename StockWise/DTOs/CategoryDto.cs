using System.ComponentModel.DataAnnotations;

namespace StockWise.DTOs
{
    public class CategoryDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
    }
}