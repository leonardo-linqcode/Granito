using Granito.Taxas.Api.Core.Interfaces;

namespace Granito.Taxas.Api.Application.Taxas.Queries.Handlers;

public class FetchTaxasHandler : IQueryHandler<FetchTaxas, decimal>
{
    private static readonly decimal TaxaAtual = 0.01M;

    public async Task<decimal> Handle(FetchTaxas request, CancellationToken cancellationToken)
    {
        return await ValueTask.FromResult(TaxaAtual);
    }
}