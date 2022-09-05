using Microsoft.EntityFrameworkCore;

namespace ProductStockApi.Data
{
    public class ProductStockContext : DbContext
    {
        public ProductStockContext(DbContextOptions<ProductStockContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductStock>().HasKey(x => x.Productid);
            modelBuilder.Entity<ProductStock>().Property(x => x.Stock).IsRequired();

            modelBuilder.Entity<ProductStock>().HasData(new ProductStock[]
            {
                new(){Productid = 1,Stock = 100},
                new(){Productid = 2,Stock = 200},
            });
        }
        public DbSet<ProductStock> ProductStocks { get; set; }
    }
}
