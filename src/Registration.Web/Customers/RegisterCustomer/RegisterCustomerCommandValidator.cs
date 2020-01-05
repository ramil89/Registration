using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Registration.Web.Customers.RegisterCustomer
{
    public class RegisterCustomerCommandValidator : AbstractValidator<RegisterCustomerCommand>
    {
        private const string PASSWORD_PATTERN = @"([a-zA-Z]+\d+|\d+[a-zA-Z]+)[0-9a-zA-Z]*";

        public RegisterCustomerCommandValidator()
        {
            RuleFor(x => x.Login).NotEmpty().WithMessage("Login is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .Matches(PASSWORD_PATTERN).WithMessage("Password - must contain min 1 digit and min 1 letter.");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Password is required")
                .Equal(f => f.Password).WithMessage("ConfirmPassword doesn't match to Password.");

            RuleFor(x => x.CountryId).NotEmpty().WithMessage("CountryId is required");
            RuleFor(x => x.ProvinceId).NotEmpty().WithMessage("ProvinceId is required");
        }
    }
}
