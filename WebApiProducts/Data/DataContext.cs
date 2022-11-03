using Microsoft.EntityFrameworkCore;
using WebApiProducts.Models;

namespace WebApiProducts.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet <ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>().ToContainer("Products").HasPartitionKey(x=>x.Id);
        }
    }
}
