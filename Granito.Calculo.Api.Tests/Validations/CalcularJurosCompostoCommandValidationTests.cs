using Granito.Calculo.Api.Application.Calculos.Commands;
using FluentValidation.TestHelper;

namespace Granito.Calculo.Api.Validations.Tests
{
    public class CalcularJurosCompostoCommandValidationTests
    {
        private readonly CalcularJurosCompostoCommandValidation validator;

        public CalcularJurosCompostoCommandValidationTests()
        {
            validator = new CalcularJurosCompostoCommandValidation();
        }

        [Fact]
        public void Should_have_error_when_Values_is_null()
        {
            var model = new CalcularJurosCompostoCommand(ValorInicial: -10, Meses: 0);
            
            var result = validator.TestValidate(model);
            
            result.ShouldHaveValidationErrorFor(x => x.Meses).WithErrorMessage("Meses tem que ser maior que 0 (zero).");
            result.ShouldHaveValidationErrorFor(x => x.ValorInicial).WithErrorMessage("Valor Inicial tem que ser maior que 0 (zero).");
        }

        [Fact]
        public void Should_not_have_error_when_Values_is_specified()
        {
            var model = new CalcularJurosCompostoCommand(ValorInicial: 10, Meses: 1);

            var result = validator.TestValidate(model);

            result.ShouldNotHaveValidationErrorFor(x => x.Meses);
            result.ShouldNotHaveValidationErrorFor(x => x.ValorInicial);
        }
    }
}