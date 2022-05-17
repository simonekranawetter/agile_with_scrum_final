using KenkataWebshop.Data;
using KenkataWebshop.WebApi.Entities;

namespace KenkataWebshop.WebApi.Mappings
{
    public static class CategoryMappingExtensions
    {
        public static CategoryEntity MapToEntity(this CategoryDto dto)
        {
            var entity = new CategoryEntity
            {
                Id = new Guid(),
                Name = dto.Category,
                Products = (IEnumerable<ProductEntity>)dto.Products
            };

            return entity;
        }

        public static CategoryDto MapToDto(this CategoryEntity entity)
        {
            var dto = new CategoryDto
            {
                Category = entity.Name,
                Products = (List<ProductDto>)entity.Products
            };

            return dto;
        }
    }
}
