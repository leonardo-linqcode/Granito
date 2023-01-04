using System.Net.Http.Headers;

namespace Granito.Calculo.Api.Services.RequestProvider;

public class RequestProvider : IRequestProvider
{
    private readonly Lazy<HttpClient> _httpClient =
        new(() =>
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        },
            LazyThreadSafetyMode.ExecutionAndPublication);

    public async Task<TResult?> GetAsync<TResult>(string uri)
    {
        HttpClient httpClient = GetOrCreateHttpClient();
        HttpResponseMessage response = await httpClient.GetAsync(uri).ConfigureAwait(false);

        await HandleResponse(response).ConfigureAwait(false);

        TResult? result = await response.Content.ReadFromJsonAsync<TResult>();

        return result;
    }

    private HttpClient GetOrCreateHttpClient()
    {
        var httpClient = _httpClient.Value;
        return httpClient;
    }

    private static async Task HandleResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            throw new HttpRequestException(content, null, response.StatusCode);
        }
    }
}