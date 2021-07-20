using Features.Core;
using FluentAssertions;
using Xunit;

namespace Features.Tests
{
    public class CpfValidationTests
    {
        [Theory(DisplayName = "CPF Validos")]
        [Trait("Categoria", "CPF ValidationTests")]
        [InlineData("15231766607")]
        [InlineData("17806087729")]
        [InlineData("64184957307")]
        [InlineData("21681764423")]
        public void Cpf_ValidarMultiplosNumeros_TodosDevemSerValidos(string cpf)
        {
            //Arrange
            var cpfValidation = new CpfValidation();

            //Act & Assert
            cpfValidation.EhValido(cpf).Should().BeTrue();
        }

        [Theory(DisplayName = "CPF Validos")]
        [Trait("Categoria", "CPF ValidationTests")]
        [InlineData("49219842104921")]
        [InlineData("17806087")]
        [InlineData("92419421090421")]
        [InlineData("123421")]
        public void Cpf_ValidarMultiplosNumeros_TodosDevemSerInvalidos(string cpf)
        {
            //Arrange
            var cpfValidation = new CpfValidation();

            //Act & Assert
            cpfValidation.EhValido(cpf).Should().BeFalse();
        }
    }
}
