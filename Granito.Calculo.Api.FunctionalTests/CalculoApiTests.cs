using System.Net.Http.Json;

namespace Granito.Calculo.Api.FunctionalTests;

public class CalculoApiTests
    : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public CalculoApiTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/api/calculajuros?valorinicial=100&meses=5")]
    public async Task Get_CalculaJuros_Return_Success_And_Correct_Value(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        var value = await client.GetFromJsonAsync<decimal>(url);

        // Assert

        var expected = 105.10M;

        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal(expected, value);
    }

    [Theory]
    [InlineData("/api/showmethecode")]
    public async Task Get_ShowMeTheCode_Return_Success_And_Correct_Value(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        var value = await client.GetStringAsync(url);

        // Assert

        var expected = "https://github.com/leonardo-linqcode/Granito";

        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal(expected, value);
    }
}