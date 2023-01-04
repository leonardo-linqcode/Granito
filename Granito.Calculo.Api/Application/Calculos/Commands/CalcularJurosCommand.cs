using Granito.Calculo.Api.Core.Interfaces;

namespace Granito.Calculo.Api.Application.Calculos.Commands;

public sealed record CalcularJurosCompostoCommand(decimal ValorInicial, int Meses) : ICommand<decimal>;