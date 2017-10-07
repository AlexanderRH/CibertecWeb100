using Cibertec.Models;
using FluentValidation;

namespace Cibertec.WebApi.Validators
{
    public class OrderItemValidator: AbstractValidator<OrderItem>
    {
        public OrderItemValidator()
        {
            RuleFor(x => x.OrderId).NotNull().NotEmpty().WithMessage("This field is equired");
            RuleFor(x => x.ProductId).NotNull().NotEmpty().WithMessage("This field is equired");
            RuleFor(x => x.UnitPrice).NotNull().NotEmpty().WithMessage("This field is equired");
            RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("This field is equired");
        }
    }
}
