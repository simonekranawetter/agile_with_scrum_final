using KenkataWebshop.Data;
using KenkataWebshop.WebApi.Entities;
using KenkataWebshop.WebApi.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KenkataWebshop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly SqlContext _sqlContext;

        public ProductsController(ILogger<ProductsController> logger, SqlContext sqlContext)
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

        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetAllProducts()
        {
            var entities = await _sqlContext.Products.Include(p => p.Category).ToListAsync();

            var dtos = entities.MapToDto();

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(Guid id)
        {
            var entity = await _sqlContext.Products.Include(p => p.Category).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (entity is null)
            {
                return NotFound();
            }

            var dto = entity.MapToDto();
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(Guid id, ProductDto productDto)
        {
            var entity = await _sqlContext.Products.Include(p => p.Category).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (entity is null)
            {
                return BadRequest();
            }
            entity.ArticleNumber = productDto.ArticleNumber;
            entity.Name = productDto.Name;
            entity.Description = productDto.Description;
            entity.Color = productDto.Color;
            entity.Brand = productDto.Brand;
            entity.Size = productDto.Size;
            entity.AmountInStock = productDto.AmountInStock;
            entity.Rating = productDto.Rating;
            entity.Price = productDto.Price;
            entity.IsOnSale = productDto.IsOnSale;

            if (entity.Category.Name != productDto.Category)
            {
                var categoryEntity = await _sqlContext.Categories.Where(c => c.Name == productDto.Category).FirstOrDefaultAsync();

                if (categoryEntity is null)
                {
                    categoryEntity = new CategoryEntity
                    {
                        Name = productDto.Category,
                    };

                    _sqlContext.Categories.Add(categoryEntity);
                    await _sqlContext.SaveChangesAsync();
                }                    
                entity.CategoryId = categoryEntity.Id;

            }

            await _sqlContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var entity = await _sqlContext.Products.Include(p => p.Category).Where(p => p.Id == id).FirstOrDefaultAsync();

            if (entity is null)
            {
                return NotFound();
            }

            _sqlContext.Products.Remove(entity);
            await _sqlContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
