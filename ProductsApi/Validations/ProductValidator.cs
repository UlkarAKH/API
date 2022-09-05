using FluentValidation;
using ProductsApi.Data;

namespace ProductsApi.Validations
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.Price).NotEmpty().WithMessage("not empty");
            RuleFor(x=>x.ProductName).NotEmpty().WithMessage("not empty");
            RuleFor(x=>x.CategoryId).NotEmpty().WithMessage("not empty");
        }
    }
}
