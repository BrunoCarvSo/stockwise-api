using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWise.Domain.Entities;
using StockWise.Infrastructure;
using StockWise.API.DTOs;

namespace StockWise.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : Controller
    {
        private readonly StockWiseDbContext _db;

        public ProductController(StockWiseDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(); 
            }

            return Ok(product);
        }


        [HttpPost]
            public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newProduct = new Product
                {
                    Name = productDto.Name,
                    Description = productDto.Description,
                    Sku = productDto.Sku,
                    Price = productDto.Price,
                    QuantityInStock = productDto.QuantityInStock,
                    CategoryId = productDto.CategoryId,
                    SupplierId = productDto.SupplierId,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow 
                };

                _db.Products.Add(newProduct);
                await _db.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProductById), new { id = newProduct.ProductId }, newProduct);
            }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productFromDb = await _db.Products.FindAsync(id);

            if (productFromDb == null)
            {
                return NotFound(); 
            }

            productFromDb.Name = productDto.Name;
            productFromDb.Description = productDto.Description;
            productFromDb.Sku = productDto.Sku;
            productFromDb.Price = productDto.Price;
            productFromDb.QuantityInStock = productDto.QuantityInStock;
            productFromDb.CategoryId = productDto.CategoryId;
            productFromDb.SupplierId = productDto.SupplierId;
            productFromDb.IsActive = productDto.IsActive;
            productFromDb.UpdatedAt = DateTime.UtcNow; 

            await _db.SaveChangesAsync();
 

            return NoContent();
        }

        [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteProduct(int id)
            {
                var productFromDb = await _db.Products.FindAsync(id);

                if (productFromDb == null)
                {
                    return NotFound();
                }

                _db.Products.Remove(productFromDb);
                await _db.SaveChangesAsync();

                return NoContent(); 
            }


    }
}
