using Cibertec.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cibertec.WebApi.Validators
{
    public class SupplierValidator: AbstractValidator<Supplier>
    {
        public SupplierValidator()
        {
            RuleFor(x => x.CompanyName).NotNull().NotEmpty().WithMessage("This field is required");
        }
    }
}
