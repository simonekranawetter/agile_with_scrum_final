using System.ComponentModel.DataAnnotations;

namespace KenkataWebshop.WebApi.Entities
{
    public class CategoryEntity
    {
        [Required]
        public Guid Id { get; set; }
    }
}