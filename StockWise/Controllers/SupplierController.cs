using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockWise.Domain.Entities;
using StockWise.DTOs;
using StockWise.Infrastructure;

namespace StockWise.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SupplierController : Controller
    {
        private readonly StockWiseDbContext _db;

        public SupplierController(StockWiseDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        [HttpGet]
        public async Task<IActionResult> GetSuppliers()
        {
            var supplier = await _db.Suppliers.ToListAsync();
            return Ok(supplier);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplierById(int id)
        {
            var supplier = await _db.Suppliers.FindAsync(id);

            if(supplier == null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromBody] SupplierDto supplier)
        {
            var newSupplier = new Supplier
            {
                Name = supplier.Name,
                ContactName = supplier.ContactName,
                ContactEmail = supplier.ContactEmail,
                ContactPhone = supplier.ContactPhone,
                Address = supplier.Address,
                CreatedAt = DateTime.UtcNow
            };

            _db.Suppliers.Add(newSupplier);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSupplierById), new {id = newSupplier.SupplierId }, newSupplier);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, [FromBody] SupplierDto supplier)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var supplierFromDb = await _db.Suppliers.FindAsync(id);

            if(supplierFromDb == null)
            {
                return NotFound();
            }

            supplierFromDb.Name = supplier.Name;
            supplierFromDb.ContactName = supplier.ContactName;
            supplierFromDb.ContactEmail = supplier.ContactEmail;
            supplierFromDb.ContactPhone = supplier.ContactPhone;
            supplierFromDb.Address = supplier.Address;
            supplierFromDb.UpdatedAt= DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplierFromDb = await _db.Suppliers.FindAsync(id);

            if(supplierFromDb == null)
            {
                return NotFound();
            }

            _db.Suppliers.Remove(supplierFromDb);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
