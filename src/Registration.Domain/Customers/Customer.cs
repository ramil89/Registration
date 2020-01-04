using Registration.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.Customers
{
    public class Customer: Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }

        public string Login { get; private set; }

        public int CountryId { get; private set; }

        public int ProvinceId { get; private set; }

        public string PasswordHash { get; private set; }

        private Customer()
        {

        }

        public Customer(
            string login, 
            string password, 
            int provinceId,
            int countryId, 
            ICustomerUniquenessChecker customerUniquenessChecker,
            IPasswordHashCalculator passwordHashCalculator)
        {
            Id = Guid.NewGuid();
            Login = login;
            ProvinceId = provinceId;
            CountryId = countryId;
            PasswordHash = passwordHashCalculator.Calculate(password);

            if(!customerUniquenessChecker.IsUnique(this))
            {
                throw new BusinessRuleValidationException("Customer with this login already exists.");
            }

            AddDomainEvent(new CustomerRegisteredEvent(this));
        }

    }
}
