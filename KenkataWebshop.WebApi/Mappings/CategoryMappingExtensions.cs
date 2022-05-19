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
                Name = dto.Category,
                Products = new List<ProductEntity>()
            };

            return entity;
        }

        public static CategoryDto MapToDto(this CategoryEntity entity)
        {
            var dto = new CategoryDto
            {
                Id = entity.Id,
                Category = entity.Name,
                Products = entity.Products.MapToDto()
            };

            return dto;
        }

        public static List<CategoryDto> MapToDto(this List<CategoryEntity> entities)
        {
            var dtos = new List<CategoryDto>();

            foreach (var entity in entities)
            {
                dtos.Add(entity.MapToDto());
            }

            return dtos;
        }
    }
}
