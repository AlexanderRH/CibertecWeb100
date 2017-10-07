using Cibertec.Models;
using FluentValidation;

namespace Cibertec.WebApi.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x.OrderDate).NotNull().NotEmpty().WithMessage("This field is equired");
            RuleFor(x => x.CustomerId).NotNull().NotEmpty().WithMessage("This field is required");
        }
    }
}
