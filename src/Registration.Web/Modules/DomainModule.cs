using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Registration.Domain.Customers;
using Registration.Web.Customers.DomainServices;

namespace Registration.Web.Modules
{
    public class DomainModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordHashCalculator>()
                .As<IPasswordHashCalculator>()
                .SingleInstance();

            builder.RegisterType<CustomerUniquenessChecker>()
                .As<ICustomerUniquenessChecker>()
                .InstancePerLifetimeScope();
        }
    }
}
