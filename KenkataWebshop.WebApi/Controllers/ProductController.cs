using KenkataWebshop.Data;
using KenkataWebshop.WebApi.Entities;
using KenkataWebshop.WebApi.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KenkataWebshop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly SqlContext _sqlContext;

        public ProductController(ILogger<ProductController> logger, SqlContext sqlContext)
        {
            _logger = logger;
            _sqlContext = sqlContext;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto productDto)
        {
            var productEntity = productDto.MapToEnitiy();

            var categoryEntity = await _sqlContext.Categories.Where(c => c.Name == productDto.Category).FirstOrDefaultAsync();

            if (categoryEntity is null)
            {
                categoryEntity = new CategoryEntity
                {
                    Name = productDto.Name,
                };

                _sqlContext.Categories.Add(categoryEntity);
                await _sqlContext.SaveChangesAsync();
            }

            productEntity.CategoryId = categoryEntity.Id;
            _sqlContext.Products.Add(productEntity);

            await _sqlContext.SaveChangesAsync();

            return CreatedAtAction("GetProductById", new { id = productEntity.Id}, productEntity.MapToDto());
        }
    }
}
