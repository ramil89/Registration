using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
    }
}
