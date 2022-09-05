﻿using ProductsApi.Data;

namespace ProductsApi.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(int id);
        public Task<Product> CreateAsync(Product product);
        public Task UpdateAsync(Product product);
        public Task DeleteAsync(Product product);
    }
}
