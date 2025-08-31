using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWise.Domain.Entities;
using StockWise.DTOs;
using StockWise.Infrastructure;

namespace StockWise.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly StockWiseDbContext _db;

        public CategoryController(StockWiseDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }


        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var category = await _db.Categories.ToListAsync();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _db.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategory = new Category
            {
                Name = category.Name,
                Description = category.Description,
                CreatedAt = DateTime.UtcNow
            };

            _db.Categories.Add(newCategory);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.CategoryId }, newCategory);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDto category)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryFromDb = await _db.Categories.FindAsync(id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }

            categoryFromDb.Name = category.Name;
            categoryFromDb.Description = category.Description;
            categoryFromDb.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoryFromDb = await _db.Categories.FindAsync(id);

            if(categoryFromDb == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(categoryFromDb);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
