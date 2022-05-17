﻿using KenkataWebshop.Data;
using KenkataWebshop.WebApi.Mappings;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            var entities = await _sqlContext.Categories.ToListAsync();
            var dtos = entities.MapToDto();
            return Ok(dtos);
        }
    }
}
