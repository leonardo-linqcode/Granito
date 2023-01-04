using Granito.Calculo.Api.Core.Interfaces;
using Granito.Calculo.Api.Services.RequestProvider;
using Moq;

namespace Granito.Calculo.Api.Application.Calculos.Commands.Handlers.Tests
{
    public class CalcularJurosCompostoCommandHandlerTests
    {
        [Fact(DisplayName = $"{nameof(CalcularJurosCompostoCommandHandler)} deve implementar {nameof(ICommandHandler<CalcularJurosCompostoCommand, decimal>)}")]
        public void FetchTaxasHandlerTest()
        {
            // Arrange 

            var classType = typeof(CalcularJurosCompostoCommandHandler);
            var interfaceType = typeof(IQueryHandler<,>);

            // Act

            var implementInterfaces = classType
                .GetInterfaces()
                .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);

            // Assert

            if (implementInterfaces == null)
                Assert.Fail($"{interfaceType.Name} Interface não implementada.");

            var arguments = implementInterfaces.GetGenericArguments();

            Assert.Collection(arguments,
                item => Assert.Equal(typeof(CalcularJurosCompostoCommand), item),
                item => Assert.Equal(typeof(decimal), item));
        }

        [Theory(DisplayName = $"{nameof(CalcularJurosCompostoCommandHandler.Handle)} deve retornar um valor decimal.")]
        [InlineData(101.00, 100, 1, 0.01)]
        [InlineData(520.20, 500, 2, 0.02)]
        [InlineData(1639.09, 1500, 3, 0.03)]
        [InlineData(2925.23, 2500.50, 4, 0.04)]
        [InlineData(127.62, 100, 5, 0.05)]
        [InlineData(141852.05, 100000.10, 6, 0.06)]
        [InlineData(1605781.47, 1000000.00, 7, 0.07)]
        [InlineData(92546510.51, 50000000.00, 8, 0.08)]
        [InlineData(21718932794.42, 10000000000.00, 9, 0.09)]
        [InlineData(259.37, 100, 10, 0.10)]
        [InlineData(315.17, 100, 11, 0.11)]
        [InlineData(389.59, 100, 12, 0.12)]
        public async Task HandleTest(decimal esperado, decimal valorInicial, int meses, decimal taxa)
        {
            // Arrange

            var apiSettings = new ApiSettings { TaxaApiUrl = "https://granito.com.br/api/taxas" };

            var mockRequestProvider = new Mock<IRequestProvider>();
            mockRequestProvider
                .Setup(s => s.GetAsync<decimal>(It.IsAny<string>()))
                .Returns(Task.FromResult(taxa));

            var command = new CalcularJurosCompostoCommand(valorInicial, meses);
            var handler = new CalcularJurosCompostoCommandHandler(apiSettings, mockRequestProvider.Object);

            // Act

            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(esperado, result);
        }
    }
}