using Cibertec.Models;
using FluentValidation;

namespace Cibertec.WebApi.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotNull().NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.SupplierId).NotNull().NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.IsDiscontinued).NotNull().NotEmpty().WithMessage("This field is required");
        }
    }
}
