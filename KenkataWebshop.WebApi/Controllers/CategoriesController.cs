using KenkataWebshop.Data;
using KenkataWebshop.WebApi.Mappings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KenkataWebshop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly SqlContext _sqlContext;

        public CategoriesController(ILogger<CategoriesController> logger, SqlContext sqlContext)
        {
            _logger = logger;
            _sqlContext = sqlContext;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> CreateCategory(CategoryDto categoryDto)
        {
            var categoryEntity = categoryDto.MapToEntity();

            _sqlContext.Categories.Add(categoryEntity);
            await _sqlContext.SaveChangesAsync();

            return CreatedAtAction("GetCategoryById", new { id = categoryEntity.Id }, categoryEntity.MapToDto());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(Guid id)
        {
            var entity = await _sqlContext.Categories
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                return NotFound();
            }

            var dto = entity.MapToDto();

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            var entities = await _sqlContext.Categories
                .Include(c => c.Products)
                .ToListAsync();

            var dtos = entities.MapToDto();

            return Ok(dtos);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategory(Guid id, CategoryDto categoryDto)
        {
            var entity = await _sqlContext.Categories
                .Where(c=> c.Id == id)
                .FirstOrDefaultAsync();

            if(entity is null)
            {
                return NotFound();
            }

            entity.Name = categoryDto.Category;
            await _sqlContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var entity = await _sqlContext.Categories
                .Include(c => c.Products)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            if(entity is null)
            {
                return NotFound();
            }

            if (entity.Products.Count() > 0)
            {
                return BadRequest();
            }

            _sqlContext.Categories.Remove(entity);
            await _sqlContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
