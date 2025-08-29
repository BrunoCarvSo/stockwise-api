using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StockWise.Infrastructure
{
    public class StockWiseDbContext : DbContext
    {
        private IConfiguration _configuration;

        public StockWiseDbContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            var typeDatabase = _configuration["TypeDatabase"];
            var connectionsString = _configuration.GetConnectionString(typeDatabase);

            optionsBuilder.UseNpgsql(connectionsString);
        }
    }
}
