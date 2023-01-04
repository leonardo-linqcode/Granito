using Microsoft.AspNetCore.Mvc;
using MediatR;
using Moq;
using Granito.Taxas.Api.Application.Taxas.Queries;

namespace Granito.Calculo.Api.Controllers.Tests
{
    public class TaxasControllerTests
    {
        [Fact(DisplayName = $"Método {nameof(TaxasController.Get)} em {nameof(TaxasController)} deve retornar {nameof(OkObjectResult)}.")]
        public async Task TaxasController_GetTaxas_ReturnOk()
        {
            // Arrange
            var controller = new TaxasController();

            decimal taxaAtual = 0.01M;

            var mockSender = new Mock<ISender>();
            mockSender.Setup(sender => sender.Send(It.IsAny<FetchTaxas>(), CancellationToken.None)).ReturnsAsync(await ValueTask.FromResult(taxaAtual));

            // Act
            var result = await controller.Get(mockSender.Object);

            // Assert

            mockSender.Verify(v => v.Send(It.IsAny<FetchTaxas>(), CancellationToken.None), Times.Once);

            var actionResult = Assert.IsType<ActionResult<decimal>>(result);

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            var value = Assert.IsType<decimal>(okResult.Value);

            Assert.Equal(taxaAtual, value);
        }
    }
}