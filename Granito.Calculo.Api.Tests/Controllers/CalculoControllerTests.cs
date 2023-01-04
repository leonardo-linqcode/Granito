using Xunit;
using Granito.Calculo.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Granito.Calculo.Api.Application.Calculos.Commands;

namespace Granito.Calculo.Api.Controllers.Tests
{
    public class CalculoControllerTests
    {
        [Fact()]
        public void CalculaJurosTest()
        {
            
        }

        [Fact(DisplayName = $"Método {nameof(CalculoController.CalculaJuros)} em {nameof(CalculoController)} deve retornar {nameof(OkObjectResult)}.")]
        public async Task CalculoController_CalculaJuros_Should_Return_200Ok()
        {
            // Arrange
            var controller = new CalculoController();

            decimal fakeRetorno = 101.05M;

            var mockSender = new Mock<ISender>();
            mockSender.Setup(sender => sender.Send(It.IsAny<CalcularJurosCompostoCommand>(), CancellationToken.None)).ReturnsAsync(await ValueTask.FromResult(fakeRetorno));

            // Act
            var result = await controller.CalculaJuros(new CalcularJurosCompostoCommand(100, 5), mockSender.Object);

            // Assert

            mockSender.Verify(v => v.Send(It.IsAny<CalcularJurosCompostoCommand>(), CancellationToken.None), Times.Once);

            var actionResult = Assert.IsType<ActionResult<decimal>>(result);

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            var value = Assert.IsType<decimal>(okResult.Value);

            Assert.Equal(fakeRetorno, value);
        }
    }
}