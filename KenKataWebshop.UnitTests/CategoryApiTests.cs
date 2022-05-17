using KenkataWebshop.Data;
using KenkataWebshop.WebApi.Entities;
using KenkataWebshop.WebApi.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            var name = "Awesome Stuff";
            var entity = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            //Act
            var dto = entity.MapToDto();

            //Assert
            Assert.Equal(name, dto.Category);
        }
    }
}
