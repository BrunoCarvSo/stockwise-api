using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using StockWise.Domain.Entities;
using StockWise.DTOs;
using StockWise.Infrastructure;

namespace StockWise.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StockMovementController : Controller
    {
        private readonly StockWiseDbContext _db;

        public StockMovementController(StockWiseDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [HttpGet]
        public async Task<IActionResult> GetStockMovements()
        {
            var movement = await _db.StockMovements.ToListAsync();
            return Ok(movement);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockMovementById(int id)
        {
            var movement = await _db.StockMovements.FindAsync(id);

            if(movement == null)
            {
                return NotFound();
            }

            return Ok(movement);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockMovement([FromBody] StockMovementDto stockMovement)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newStockMovement = new StockMovement
            {
                ProductId = stockMovement.ProductId,
                MovementType = stockMovement.MovementType,
                Quantity = stockMovement.Quantity,
                Description = stockMovement.Description,
                MovementDate = DateTime.UtcNow
            };

            _db.StockMovements.Add(newStockMovement);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStockMovementById), new {id = newStockMovement.StockMovementId}, newStockMovement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockMovement(int id)
        {
            var movementFromDb = await _db.StockMovements.FindAsync(id);

            if(movementFromDb == null)
            {
                return NotFound();
            }

            _db.StockMovements.Remove(movementFromDb);
            await _db.SaveChangesAsync();

            return NoContent();
        }

    }
}
