using Features.Clientes;
using MediatR;
using Moq;
using Moq.AutoMock;
using System.Linq;
using System.Threading;
using Xunit;

namespace Features.Tests
{
    [Collection(nameof(ClienteBogusCollection))]
    public class ClienteServiceAutoMockerTests
    {
        private readonly ClienteTestsBogusFixture _clienteTestsBogus;
        public ClienteServiceAutoMockerTests(ClienteTestsBogusFixture clienteTestsFixture)
        {
            _clienteTestsBogus = clienteTestsFixture;
        }

        [Fact(DisplayName = "Adicionar Cliente com Sucesso")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_Adicionar_DeveExecutarComSucesso()
        {
            // Arrange
            var cliente = _clienteTestsBogus.GerarClienteValido();
            var mocker = new AutoMocker();

            var clienteService = mocker.CreateInstance<ClienteService>();


            var clienteRepository = new Mock<IClienteRepository>();
            var mediator = new Mock<IMediator>();

            // Act
            clienteService.Adicionar(cliente);

            // Assert
            Assert.True(cliente.EhValido());
            mocker.GetMock<IClienteRepository>().Verify(p => p.Adicionar(cliente), Times.Once);
            mocker.GetMock<IMediator>().Verify(p => p.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Once);
        }

        [Fact(DisplayName = "Adicionar Cliente com Falha")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_Adicionar_DeveFalharDevidoClienteInvalido()
        {
            // Arrange
            var cliente = _clienteTestsBogus.GerarClienteInvalido();
            var mocker = new AutoMocker();

            var clienteService = mocker.CreateInstance<ClienteService>();

            // Act
            clienteService.Adicionar(cliente);

            // Assert
            Assert.False(cliente.EhValido());
            mocker.GetMock<IClienteRepository>().Verify(p => p.Adicionar(cliente), Times.Never);
            mocker.GetMock<IMediator>().Verify(p => p.Publish(It.IsAny<INotification>(), CancellationToken.None), Times.Never);
        }

        [Fact(DisplayName = "Obter Clientes Ativos")]
        [Trait("Categoria", "Cliente Service AutoMock Tests")]
        public void ClienteService_ObterTodosAtivos_DeveRetornarApenasClientesAtivos()
        {
            // Arrange
            var mocker = new AutoMocker();

            var clienteService = mocker.CreateInstance<ClienteService>();
            var clienteRepository = mocker.GetMock<IClienteRepository>();

            clienteRepository.Setup(c => c.ObterTodos()).Returns(_clienteTestsBogus.ObterClientesVariados());

            //Act
            var clientes = clienteService.ObterTodosAtivos();

            //Assert
            clienteRepository.Verify(p => p.ObterTodos(), Times.Once);
            Assert.True(clientes.Any());
            Assert.False(clientes.Count(c => !c.Ativo) > 0);
        }
    }
}
