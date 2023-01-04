using FluentValidation;
using Granito.Calculo.Api.Application.Calculos.Commands;

namespace Granito.Calculo.Api.Validations
{
    public class CalcularJurosCompostoCommandValidation : AbstractValidator<CalcularJurosCompostoCommand>
    {
        public CalcularJurosCompostoCommandValidation() 
        {
            RuleFor(r => r.Meses).GreaterThan(0).WithMessage("Meses tem que ser maior que 0 (zero).");
            RuleFor(r => r.ValorInicial).GreaterThan(0).WithMessage("Valor Inicial tem que ser maior que 0 (zero).");
        }
    }
}