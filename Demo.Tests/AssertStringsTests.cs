using Xunit;

namespace Demo.Tests
{
    public class AssertStringsTests
    {
        [Fact]
        public void StringsTools_UnirNomes_RetornarNomeCompleto()
        {
            //Arrange
            var stringTools = new StringsTools();

            //Act
            var nomeCompleto = stringTools.Unir("Lucas", "Pereira");

            //Assert
            Assert.Equal("Lucas Pereira", nomeCompleto);
        }

        [Fact]
        public void StringsTools_UnirNomes_DeveIgnorarCase()
        {
            //Arrange
            var stringTools = new StringsTools();

            //Act
            var nomeCompleto = stringTools.Unir("Lucas", "Pereira");

            //Assert
            Assert.Equal("Lucas Pereira", nomeCompleto, ignoreCase: true);
        }

        [Fact]
        public void StringsTools_UnirNomes_DeveConterTrecho()
        {
            //Arrange
            var stringTools = new StringsTools();

            //Act
            var nomeCompleto = stringTools.Unir("Lucas", "Pereira");

            //Assert
            Assert.Contains("eira", nomeCompleto);
        }

        [Fact]
        public void StringsTools_UnirNomes_DeveComecarCom()
        {
            //Arrange
            var stringTools = new StringsTools();

            //Act
            var nomeCompleto = stringTools.Unir("Lucas", "Pereira");

            //Assert
            Assert.StartsWith("Luc", nomeCompleto);
        }

        [Fact]
        public void StringsTools_UnirNomes_ValidarExpressaoRegular()
        {
            //Arrange
            var stringTools = new StringsTools();

            //Act
            var nomeCompleto = stringTools.Unir("Lucas", "Pereira");

            //Assert
            Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", nomeCompleto);
        }
    }
}
