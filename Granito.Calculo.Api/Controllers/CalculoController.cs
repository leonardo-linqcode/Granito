using Granito.Calculo.Api.Application.Calculos.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Granito.Calculo.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CalculoController : ControllerBase
    {
        [HttpPost(Name = "CalculaJuros")]
        public async Task<ActionResult<decimal>> CalculaJuros(ISender sender)
        {
            var calcularJurosComposto = new CalcularJurosCompostoCommand(100, 10);
            var resultado = await sender.Send(calcularJurosComposto);

            return Ok(resultado);
        }
    }
}