using Registration.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Web.Customers.DomainServices
{
    public class PasswordHashCalculator : IPasswordHashCalculator
    {
        public string Calculate(string password)
        {
            var sha1 = new SHA1CryptoServiceProvider();
            var passwordData = Encoding.ASCII.GetBytes(password);
            var hashedData = sha1.ComputeHash(passwordData);

            return Encoding.ASCII.GetString(hashedData);
        }
    }
}
