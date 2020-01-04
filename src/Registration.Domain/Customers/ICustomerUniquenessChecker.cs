using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Customers
{
    public interface ICustomerUniquenessChecker
    {
        bool IsUnique(Customer customer);
    }
}
