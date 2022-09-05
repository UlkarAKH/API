using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Interfaces;

namespace ProductsApi.Repositiories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _context;

        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            var unchangedData = await _context.Products.FindAsync(product.Id);
            product.isDeleted = true;
            _context.Entry(unchangedData).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Include(x=>x.Category).AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var data = await _context.Products.Include(x => x.Category).AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return data;

        }

        public async Task UpdateAsync(Product product)
        {
            var unchangedData = await _context.Products.FindAsync(product.Id);
            _context.Entry(unchangedData).CurrentValues.SetValues(product);
            await _context.SaveChangesAsync();
        }
    }
}
