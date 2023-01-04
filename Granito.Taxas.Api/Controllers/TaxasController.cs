using Granito.Taxas.Api.Application.Taxas.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Granito.Calculo.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TaxasController : ControllerBase
    {
        [HttpGet("Taxas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        public async Task<ActionResult<decimal>> Get(ISender sender)
        {
            var fetchTaxas = new FetchTaxas();
            var response = await sender.Send(fetchTaxas);

            return Ok(response);
        }
    }
}