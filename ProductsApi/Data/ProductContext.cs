using Microsoft.EntityFrameworkCore;

namespace ProductsApi.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Product>().Property(x => x.isDeleted).HasDefaultValue(0);

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new() {Id = 1,ProductName = "Notebook",Price =4000,CategoryId=1},
                new() {Id = 2,ProductName = "Telephone",Price =1500,CategoryId=1}
            });
            modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);



            modelBuilder.Entity<Category>().HasKey(x => x.ProductCategoryId);
            modelBuilder.Entity<Category>().Property(x => x.ProductCategoryname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new() {ProductCategoryId = 1,ProductCategoryname ="Electronic"}
            }) ;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
