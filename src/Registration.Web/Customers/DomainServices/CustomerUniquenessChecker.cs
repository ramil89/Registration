using Dapper;
using Registration.Domain.Customers;
using Registration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Web.Customers.DomainServices
{
    public class CustomerUniquenessChecker : ICustomerUniquenessChecker
    {
        private readonly ISqlConnectionFactory _sqlConnection;

        public CustomerUniquenessChecker(ISqlConnectionFactory sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public bool IsUnique(Customer customer)
        {
            var connection = this._sqlConnection.GetOpenConnection();

            const string sql = "SELECT 1 " +
                               "FROM [dbo].[Customers] AS [Customer] " +
                               "WHERE [Customer].[Login] = @Login";
            var customersNumber = connection.QuerySingleOrDefault<int?>(sql,
                            new
                            {
                                customer.Login
                            });
            
            return !customersNumber.HasValue;
        }
    }
}
