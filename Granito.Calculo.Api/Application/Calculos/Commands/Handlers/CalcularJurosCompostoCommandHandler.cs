using FluentValidation;
using Granito.Calculo.Api.Core.Interfaces;
using Granito.Calculo.Api.Services.RequestProvider;

namespace Granito.Calculo.Api.Application.Calculos.Commands.Handlers;

public class CalcularJurosCompostoCommandHandler : ICommandHandler<CalcularJurosCompostoCommand, decimal>
{
    private readonly string _taxaApiUrl;
    private readonly IRequestProvider _requestProvider;
    private readonly IValidator<CalcularJurosCompostoCommand> _validator;

    public CalcularJurosCompostoCommandHandler(ApiSettings settings, IRequestProvider requestProvider, IValidator<CalcularJurosCompostoCommand> validator)
    {
        _taxaApiUrl = settings.TaxaApiUrl;
        _requestProvider = requestProvider;
        _validator = validator;
    }

    public async Task<decimal> Handle(CalcularJurosCompostoCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        double taxaJuros = Convert.ToDouble(await _requestProvider.GetAsync<decimal>($"{_taxaApiUrl}/api/taxas"));

        double valorInicial = Convert.ToDouble(request.ValorInicial);
        double meses = Convert.ToDouble(request.Meses);
        double taxa = Convert.ToDouble(1 + taxaJuros);

        decimal resultado = Convert.ToDecimal((valorInicial * Math.Pow(taxa, meses)));

        // Truncamento casas decimais, sem arredondamento.

        var divisor = (decimal)Math.Pow(10, -1 * 2);
        var resultadoTruncado = resultado - (resultado % divisor);

        return Math.Round(resultadoTruncado, 2);
    }
}