using Granito.Taxas.Api.Core.Interfaces;

namespace Granito.Taxas.Api.Application.Taxas.Queries.Handlers.Tests
{
    public class FetchTaxasHandlerTests
    {
        [Fact(DisplayName = $"{nameof(FetchTaxasHandler)} deve implementar {nameof(IQueryHandler<FetchTaxas, decimal>)}")]
        public void FetchTaxasHandlerTest()
        {
            // Arrange 

            var classType = typeof(FetchTaxasHandler);
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
                item => Assert.Equal(typeof(FetchTaxas), item),
                item => Assert.Equal(typeof(decimal), item));
        }

        [Fact(DisplayName = $"{nameof(FetchTaxasHandler)} deve retornar um valor decimal.")]
        public async Task HandleTest()
        {
            var expected = 0.01M;

            // Arrange
            
            var command = new FetchTaxas();

            var handler = new FetchTaxasHandler();

            // Act

            var response = await handler.Handle(command, CancellationToken.None);

            // Assert

            Assert.Equal(expected, response);
        }
    }
}