using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get()
        {
            var category = _db.Categories.ToList();
            return Ok(category);
        }



    }
}
