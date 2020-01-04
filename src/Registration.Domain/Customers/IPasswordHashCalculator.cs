using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Customers
{
    public interface IPasswordHashCalculator
    {
        public string Calculate(string password);
    }
}
