using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Data;
using ProductsApi.Interfaces;
using ProductsApi.Log;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<Product> _productValidator;

        public ProductsController(IProductRepository productRepository, IValidator<Product> productValidator)
        {
            _productRepository = productRepository;
            _productValidator = productValidator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _productRepository.GetByIdAsync(id);

            if (data == null)
            {
                Logs.AddLog($"{id}e uygun data yoxdur");
                return NotFound(id);
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var result = _productValidator.Validate(product);
            if (result.IsValid)
            {
                var addedProduct = await _productRepository.CreateAsync(product);
                return Created(string.Empty, addedProduct);
            }
            Logs.AddLog($"validation error");
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            var result = _productValidator.Validate(product);
            if (result.IsValid)
            {
                var checkData = await _productRepository.GetByIdAsync(product.Id);
                if (checkData == null)
                {
                    Logs.AddLog($"{product.Id} not found");
                    return NotFound(product.Id);
                }
                await _productRepository.UpdateAsync(product);
            }
            Logs.AddLog($"validation error");
            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            var result = _productValidator.Validate(product);
            if (result.IsValid)
            {
                var checkData = await _productRepository.GetByIdAsync(product.Id);
                if (checkData == null)
                {
                    Logs.AddLog($"{product.Id} not found");
                    return NotFound(product.Id);
                }
                await _productRepository.DeleteAsync(product);
            }
            Logs.AddLog($"validation error");
            return NoContent();
        }
    }
}
