
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KenkataWebshop.WebApi.Entities
{
    public class ProductEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ArticleNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(2000)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Color { get; set; }
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
        [Required]
        [StringLength(50)]
        public string Size { get; set; }
        [Required]
        public int AmountInStock { get; set; }
        [StringLength(50)]
        public string Rating { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Required]
        public bool IsOnSale { get; set; }

        public CategoryEntity Category { get; set; }
        public Guid CategoryEntityId { get; set; } 
    }
}
