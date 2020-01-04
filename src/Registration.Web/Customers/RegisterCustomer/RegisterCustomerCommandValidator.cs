using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Registration.Web.Customers.RegisterCustomer
{
    public class RegisterCustomerCommandValidator : AbstractValidator<RegisterCustomerCommand>
    {
        public RegisterCustomerCommandValidator()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage("Login is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Password is required")
                .Equal(f => f.Password).WithMessage("ConfirmPassword doesn't match to Password.");

            RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId is required");
            RuleFor(x => x.ProvinceId).NotEmpty().WithMessage("ProvinceId is required");
        }
    }
}
