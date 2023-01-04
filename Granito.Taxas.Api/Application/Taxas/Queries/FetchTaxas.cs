using Granito.Taxas.Api.Core.Interfaces;

namespace Granito.Taxas.Api.Application.Taxas.Queries;

public sealed record FetchTaxas : IQuery<decimal>;