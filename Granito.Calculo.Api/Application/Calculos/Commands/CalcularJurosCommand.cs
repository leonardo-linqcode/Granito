using Granito.Calculo.Api.Core.Interfaces;

namespace Granito.Calculo.Api.Application.Calculos.Commands;

public sealed record CalcularJurosCompostoCommand(double ValorInicial, double Meses) : ICommand<decimal>;