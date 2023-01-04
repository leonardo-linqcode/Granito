using FluentValidation;
using Granito.Calculo.Api.Application.Calculos.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Granito.Calculo.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CalculoController : ControllerBase
    {
        [HttpGet("CalculaJuros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(decimal))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        public async Task<ActionResult<decimal>> CalculaJuros([FromQuery] CalcularJurosCompostoCommand request, ISender sender)
        {
            try
            {
                var resultado = await sender.Send(request);
                return Ok(resultado);
            }
            catch (ValidationException validationException)
            {
                HttpContext.Features.Set(validationException);
                return BadRequest();
            }
        }
    }
}