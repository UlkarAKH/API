using FluentValidation;
using ProductStockApi.Data;

namespace ProductStockApi.Validations
{
    public class ProductStockValidator : AbstractValidator<ProductStock>
    {
        public ProductStockValidator()
        {
            RuleFor(x=>x.Productid).NotEmpty().WithMessage("not empty");
        }
    }
}
