using Cibertec.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cibertec.WebApi.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("This field is required");
            RuleFor(x => x.Roles).NotNull().NotEmpty().WithMessage("This field is required");
        }
    }
}
