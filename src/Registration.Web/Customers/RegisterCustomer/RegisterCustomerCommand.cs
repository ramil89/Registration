using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Web.Customers.RegisterCustomer
{
    public class RegisterCustomerCommand: IRequest<CustomerDto>
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public int CountryId { get; set; }

        public int ProvinceId { get; set; }
    }
}
