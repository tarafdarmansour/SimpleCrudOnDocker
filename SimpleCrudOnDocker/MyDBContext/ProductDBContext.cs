using Microsoft.EntityFrameworkCore;
using SimpleCrudOnDocker.Models;

namespace SimpleCrudOnDocker.MyDBContext
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products{get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}