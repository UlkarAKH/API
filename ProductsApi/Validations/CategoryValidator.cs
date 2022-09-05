using FluentValidation;
using ProductsApi.Data;

namespace ProductsApi.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.ProductCategoryname).NotEmpty().WithMessage("not empty");
        }
    }
}
