using System.ComponentModel.DataAnnotations;

namespace KenkataWebshop.Data
{
    public class CategoryDto
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
