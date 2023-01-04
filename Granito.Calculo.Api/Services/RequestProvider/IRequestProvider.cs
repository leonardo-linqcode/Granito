namespace Granito.Calculo.Api.Services.RequestProvider;

public interface IRequestProvider
{
    Task<TResult> GetAsync<TResult>(string uri);
}