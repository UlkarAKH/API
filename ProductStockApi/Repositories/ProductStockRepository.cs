using Microsoft.EntityFrameworkCore;
using ProductStockApi.Data;
using ProductStockApi.Interfaces;

namespace ProductStockApi.Repositories
{
    public class ProductStockRepository : IProductStockRepository
    {
        private readonly ProductStockContext _context;

        public ProductStockRepository(ProductStockContext context)
        {
            _context = context;
        }

        public async Task<ProductStock> GetByIdAsync(int id)
        {
            var data = await _context.ProductStocks.FindAsync(id);

            return data;

        }

        public async Task<ProductStock> updateStockAsync(ProductStock productStock)
        {
            var data = await _context.ProductStocks.FindAsync(productStock.Productid);
            data.Stock =data.Stock + productStock.Stock;
            await _context.SaveChangesAsync();

            return productStock;
        }

        public async Task<ProductStock> RemoveStockAsync(ProductStock productStock)
        {
            var data = await _context.ProductStocks.FindAsync(productStock.Productid);
            data.Stock = data.Stock -  productStock.Stock;
            await _context.SaveChangesAsync();

            return productStock;
        }

    }
}
