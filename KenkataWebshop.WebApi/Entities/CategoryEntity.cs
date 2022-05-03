using System.ComponentModel.DataAnnotations;

namespace KenkataWebshop.WebApi.Entities
{
    public class CategoryEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public IEnumerable<ProductEntity> Products { get; set; }
    }
}