using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Granito.Taxas.Api.FunctionalTests;

public class TaxasApiTests
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TaxasApiTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/api/taxas")]
    public async Task Get_Taxas_Return_Success_And_Correct_Value(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        var value = await client.GetFromJsonAsync<decimal>(url);

        // Assert

        var taxa = 0.01M;

        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.NotNull(client);
        Assert.Equal(taxa, value);
    }
}