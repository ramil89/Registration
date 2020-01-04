using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Registration.Web.Countries
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("")]
        [Route("{parentId}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<CountriesDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCountries(int? parentId) 
        {
            var countries = await _mediator.Send(new GetCountries.GetCountriesQuery(parentId));
            
            return Ok(countries);
        }
    }
}