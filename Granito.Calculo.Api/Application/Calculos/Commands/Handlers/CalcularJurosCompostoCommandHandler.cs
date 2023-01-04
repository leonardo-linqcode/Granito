using Granito.Calculo.Api.Core.Interfaces;
using Granito.Calculo.Api.Services.RequestProvider;

namespace Granito.Calculo.Api.Application.Calculos.Commands.Handlers;

public class CalcularJurosCompostoCommandHandler : ICommandHandler<CalcularJurosCompostoCommand, decimal>
{
    private readonly string _taxaApiUrl;
    private readonly IRequestProvider _requestProvider;

    public CalcularJurosCompostoCommandHandler(ApiSettings settings, IRequestProvider requestProvider)
    {
        _taxaApiUrl = settings.TaxaApiUrl;
        _requestProvider = requestProvider;
    }

    public async Task<decimal> Handle(CalcularJurosCompostoCommand request, CancellationToken cancellationToken)
    {
        double taxaJuros = Convert.ToDouble(await _requestProvider.GetAsync<decimal>($"{_taxaApiUrl}/api/taxas"));

        double valorInicial = Convert.ToDouble(request.ValorInicial);
        double meses = Convert.ToDouble(request.Meses);
        double taxa = Convert.ToDouble(1 + taxaJuros);

        decimal resultado = Convert.ToDecimal((valorInicial * Math.Pow(taxa, meses)));

        return decimal.Truncate(resultado);
    }
}