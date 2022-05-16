using KenkataWebshop.Data;
using KenkataWebshop.WebApi.Entities;

namespace KenkataWebshop.WebApi.Mappings
{
    public static class ProductMappingExtensions
    {
        public static ProductEntity MapToEnitiy(this ProductDto dto)
        {
            var entity = new ProductEntity
            {
                Id = dto.Id,
                ArticleNumber = dto.ArticleNumber,
                Name = dto.Name,
                Description = dto.Description,
                Color = dto.Color,
                Brand = dto.Brand,
                Size = dto.Size,
                AmountInStock = dto.AmountInStock,
                Rating = dto.Rating,
                Price = dto.Price,
                IsOnSale = dto.IsOnSale,
                Category = new CategoryEntity
                {
                    Name = dto.Category,
                }
            };

            return entity;
        }

        public static ProductDto MapToDto(this ProductEntity entity)
        {
            var dto = new ProductDto
            {
                Id = entity.Id,
                ArticleNumber = entity.ArticleNumber,
                Name = entity.Name,
                Description = entity.Description,
                Color = entity.Color,
                Brand = entity.Brand,
                Size = entity.Size,
                AmountInStock = entity.AmountInStock,
                Rating = entity.Rating,
                Price = entity.Price,
                IsOnSale = entity.IsOnSale,
                Category = entity.Category.Name
            };

            return dto;
        }

        public static List<ProductDto> MapToDto(this List<ProductEntity> entities)
        {
            var dtos = new List<ProductDto>();
            foreach (var entity in entities)
            {
                dtos.Add(entity.MapToDto());
            }
            return dtos;
        }
    }
}
