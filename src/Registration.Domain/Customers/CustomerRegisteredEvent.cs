using System;
using System.Collections.Generic;
using System.Text;
using Registration.Domain.SeedWork;

namespace Registration.Domain.Customers
{
    public class CustomerRegisteredEvent : DomainEventBase
    {
        public Customer Customer { get; }

        public CustomerRegisteredEvent(Customer customer)
        {
            this.Customer = customer;
        }
    }
}
