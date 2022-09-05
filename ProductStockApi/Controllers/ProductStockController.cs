using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductStockApi.Data;
using ProductStockApi.Interfaces;
using ProductStockApi.Log;
using ProductStockApi.Repositories;
using System.Net.Http;

namespace ProductStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStockController : ControllerBase
    {
        private readonly IProductStockRepository _productStock;
        private readonly IValidator<ProductStock> _productStockValidator;
        private readonly IHttpClientFactory _client;

        public ProductStockController(IProductStockRepository productStock, IHttpClientFactory client, IValidator<ProductStock> productStockValidator)
        {
            _productStock = productStock;
            _client = client;
            _productStockValidator = productStockValidator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = _client.CreateClient();
            var message = await client.GetAsync($"http://localhost:5098/api/Products/{id}");
            if (message.IsSuccessStatusCode)
            {
                var hasData = _productStock.GetByIdAsync(id);
                return Ok(hasData);
            }
            Logs.AddLog($"{id}e uygun data yoxdur");
            throw new Exception("invalid productId");
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> AddStock(ProductStock productStock)
        {
            var result = _productStockValidator.Validate(productStock);
            if (result.IsValid)
            {
                var client = _client.CreateClient();
                var message = await client.GetAsync($"http://localhost:5098/api/Products/{productStock.Productid}");
                if (message.IsSuccessStatusCode)
                {
                    await _productStock.updateStockAsync(productStock);
                    return NoContent();
                }
                Logs.AddLog($"{productStock.Productid}e uygun data yoxdur");
                throw new Exception("invalid productId");
            }
            Logs.AddLog($"validation error");
            return NoContent();
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> RemoveStock(ProductStock productStock)
        {
            var result = _productStockValidator.Validate(productStock);
            if (result.IsValid)
            {
                var client = _client.CreateClient();
                var message = await client.GetAsync($"http://localhost:5098/api/Products/{productStock.Productid}");
                if (message.IsSuccessStatusCode)
                {
                    if (productStock.Stock == 0)
                        throw new Exception("out of Stock");
                    await _productStock.RemoveStockAsync(productStock);

                    return NoContent();
                }
                Logs.AddLog($"{productStock.Productid}e uygun data yoxdur");
                throw new Exception("invalid productId");
            }
            Logs.AddLog($"validation error");
            return NoContent();
        }
    }
}
