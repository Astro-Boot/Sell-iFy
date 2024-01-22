using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sellify.Application.Features.Countries.Queries.GetCountryList;
using Sellify.Application.Features.Countries.Vms;

namespace Sellify.Api.Controllers;



[ApiController]
[Route("api/v1/[controller]")]
public class CountryController : ControllerBase
{

    private readonly IMediator _mediator;

    public CountryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet(Name ="GetCountries")]
    [ProducesResponseType(typeof(IReadOnlyList<CountryVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IReadOnlyList<CountryVm>>> GetCountries()
    {
        var query = new GetCountryListQuery();
        return Ok(await _mediator.Send(query));
    }

}