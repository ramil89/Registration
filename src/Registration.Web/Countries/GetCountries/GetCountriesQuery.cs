using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Web.Countries.GetCountries
{
    internal class GetCountriesQuery : IRequest<List<CountriesDto>>
    {
        public int? ParentId { get; } 

        public GetCountriesQuery(int? parentId)
        {
            this.ParentId = parentId;
        }
    }
}
