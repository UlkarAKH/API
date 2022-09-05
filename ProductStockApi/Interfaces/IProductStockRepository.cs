using ProductStockApi.Data;

namespace ProductStockApi.Interfaces
{
    public interface IProductStockRepository
    {
        public Task<ProductStock> GetByIdAsync(int id);
        public Task<ProductStock> updateStockAsync(ProductStock product); 
        public Task<ProductStock> RemoveStockAsync(ProductStock product); 
    }
}
