using System.ComponentModel.DataAnnotations;

namespace KenkataWebshop.Data
{
    public class CategoryDto
    {
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
