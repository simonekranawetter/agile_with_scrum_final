using KenkataWebshop.Data;
using KenkataWebshop.WebApi.Entities;
using KenkataWebshop.WebApi.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace KenKataWebshop.UnitTests
{
    public class CategoryApiTests
    {
        [Fact]
        public void Mapping_CategoryDto_To_CategoryEntity()
        {
            //Arrange
            var category = "Awesome Stuff";

            var dto = new CategoryDto
            {
                Category = category,
            };

            //Act
            var categoryEntity = dto.MapToEntity();

            //Assert
            Assert.Equal(category, categoryEntity.Name);
        }

        [Fact]
        public void Mapping_CategoryEntity_To_CategoryDto()
        {
            //Arrange
            var id = Guid.NewGuid();
            var name = "Awesome Stuff";
            var entity = new CategoryEntity
            {
                Id = id,
                Name = name,
                Products = new List<ProductEntity>()
            };

            //Act
            var dto = entity.MapToDto();

            //Assert
            Assert.Equal(id, dto.Id);
            Assert.Equal(name, dto.Category);
        }

        [Fact]
        public void Mapping_List_Of_CategoryEntities_To_List_Of_CategoryDtos()
        {
            //Arrange
            var id = Guid.NewGuid();
            var name = "Awesome Stuff";
            var entities = new List<CategoryEntity>
            {
               new CategoryEntity
               {
                Id = id,
                Name = name,
                Products = new List<ProductEntity>()
               }
            };

            //Act
            var dtos = entities.MapToDto();

            //Assert
            Assert.Equal(1, dtos.Count());
            
            var dto = dtos.First();
            Assert.Equal(id, dto.Id);
            Assert.Equal(name, dto.Category);
        }
    }
}
