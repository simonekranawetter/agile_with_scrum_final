using KenkataWebshop.Data;
using KenkataWebshop.WebApi.Entities;
using KenkataWebshop.WebApi.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KenKataWebshop.UnitTests
{
    public class ProductApiTests
    {
        [Fact]
        public void Mapping_ProductDto_To_ProductEntity()
        {
            //Arrange
            var id = Guid.NewGuid();
            var articleNumber = "13e37";
            var name = "Batmobile";
            var description = "Fast car goes vroom vroom!";
            var color = "Black and yellow";
            var brand = "Alfred Inc.";
            var size = "Huuuuge";
            var amountInStock = 2;
            var rating = "Excellent";
            var price = 13337.1337m;
            var isOnSale = true;
            var category = "Awesome Stuff";

            var dto = new ProductDto
            {
                Id = id,
                ArticleNumber = articleNumber,
                Name = name,
                Description = description,
                Color = color,
                Brand = brand,
                Size = size,
                AmountInStock = amountInStock,
                Rating = rating,
                Price = price,
                IsOnSale = isOnSale,
                Category = category
            };

            //Act
            var productEntity = dto.MapToEnitiy();

            //Assert
            Assert.Equal(articleNumber, productEntity.ArticleNumber);
            Assert.Equal(name, productEntity.Name);
            Assert.Equal(description, productEntity.Description);
            Assert.Equal(color, productEntity.Color);
            Assert.Equal(brand, productEntity.Brand);
            Assert.Equal(size, productEntity.Size);
            Assert.Equal(amountInStock, productEntity.AmountInStock);
            Assert.Equal(rating, productEntity.Rating);
            Assert.Equal(price, productEntity.Price);
            Assert.Equal(isOnSale, productEntity.IsOnSale);
            Assert.Equal(category, productEntity.Category.Name);
        }

        [Fact]
        public void ProductEntity_To_ProductDto()
        {
            //Arrange
            var productId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var articleNumber = "1234dfg";
            var name = "Post-its";
            var description = "Deluxe sticky post it notes";
            var color = "blue";
            var brand = "Biltema";
            var size = "Medium";
            var amountInStock = 20;
            var rating = "Excellent";
            var price = 3713m;
            var isOnSale = false;
            var category = "Drama Llama";

            var entity = new ProductEntity
            {
                Id = productId,
                ArticleNumber = articleNumber,
                Name = name,
                Description = description,
                Color = color,
                Brand = brand,
                Size = size,
                AmountInStock = amountInStock,
                Rating = rating,
                Price = price,
                IsOnSale = isOnSale,
                Category = new CategoryEntity
                {
                    Id = categoryId,
                    Name = category
                }
            };

            //Act
            var dto = entity.MapToDto();

            //Assert
            Assert.Equal(productId, dto.Id);
            Assert.Equal(articleNumber, dto.ArticleNumber);
            Assert.Equal(name, dto.Name);
            Assert.Equal(description, dto.Description);
            Assert.Equal(color, dto.Color);
            Assert.Equal(brand, dto.Brand);
            Assert.Equal(size, dto.Size);
            Assert.Equal(amountInStock, dto.AmountInStock);
            Assert.Equal(rating, dto.Rating);
            Assert.Equal(price, dto.Price);
            Assert.Equal(isOnSale, dto.IsOnSale);
            Assert.Equal(category, dto.Category);
        }

        [Fact]
        public void Mapping_List_Of_ProductEntites_To_List_Of_ProductDtos()
        {
            //Arrange
            var productId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var articleNumber = "13e37";
            var name = "Batmobile";
            var description = "Fast car goes vroom vroom!";
            var color = "Black and yellow";
            var brand = "Alfred Inc.";
            var size = "Huuuuge";
            var amountInStock = 2;
            var rating = "Excellent";
            var price = 13337.1337m;
            var isOnSale = true;
            var category = "Awesome Stuff";

            var entities = new List<ProductEntity>
            {
                new ProductEntity
                {
                    Id = productId,
                    ArticleNumber = articleNumber,
                    Name = name,
                    Description = description,
                    Color = color,
                    Brand = brand,
                    Size = size,
                    AmountInStock = amountInStock,
                    Rating = rating,
                    Price = price,
                    IsOnSale = isOnSale,
                    Category = new CategoryEntity
                    {
                        Id = categoryId,
                        Name = category
                    }
                }
            };

            //Act

            var dtos = entities.MapToDto();

            //Assert
            Assert.Equal(1, dtos.Count());

            var dto = dtos.First();
            Assert.Equal(productId, dto.Id);
            Assert.Equal(articleNumber, dto.ArticleNumber);
            Assert.Equal(name, dto.Name);
            Assert.Equal(description, dto.Description);
            Assert.Equal(color, dto.Color);
            Assert.Equal(brand, dto.Brand);
            Assert.Equal(size, dto.Size);
            Assert.Equal(amountInStock,dto.AmountInStock);
            Assert.Equal(rating, dto.Rating);
            Assert.Equal(price, dto.Price);
            Assert.Equal(isOnSale, dto.IsOnSale);
            Assert.Equal(category, dto.Category);

        }
    }
}