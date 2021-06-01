using Microsoft.EntityFrameworkCore;
using SimpleCrudOnDocker.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SimpleCrudOnDocker.MyDBContext
{
    public class ProductDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public ProductDBContext(IConfiguration configuration, ILogger<ProductDBContext> logger)
        {
            _configuration = configuration;
            _logger = logger;

        }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}