using Dapper;
using MediatR;
using Registration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Web.Countries.GetCountries
{
    internal class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, List<CountriesDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnection;

        public GetCountriesQueryHandler(ISqlConnectionFactory sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }

        public async Task<List<CountriesDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var connection = this._sqlConnection.GetOpenConnection();

            const string sqlProducts = "SELECT " +
                               "[Country].[Id] AS [Id], " +
                               "[Country].[ParentId], " +
                               "[Country].[Name] " +
                               "FROM [dbo].[Countries] AS [Country] " +
                               "WHERE [Country].ParentId = @ParentId OR [Country].ParentId IS NULL AND @ParentId is NULL";

            var countries = await connection.QueryAsync<CountriesDto>(sqlProducts, new { request.ParentId });

            return countries.ToList();
        }
    }
}
