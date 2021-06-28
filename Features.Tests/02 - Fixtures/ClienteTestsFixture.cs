using Features.Clientes;
using System;
using Xunit;

namespace Features.Tests._02___Fixtures
{
    [CollectionDefinition(nameof(ClienteCollection))]
    public class ClienteCollection : ICollectionFixture<ClienteTestsFixture> { }

    public class ClienteTestsFixture : IDisposable
    {
        public Cliente GerarClienteValido()
        {
            return new Cliente(
                Guid.NewGuid(),
                "Lucas",
                "Pereira",
                DateTime.Now.AddYears(-30),
                "lucas@gmail.com",
                true,
                DateTime.Now);
        }

        public Cliente GerarClienteInvalido()
        {
            return new Cliente(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                "lucas2gmail.com",
                true,
                DateTime.Now);
        }

        public void Dispose()
        {

        }
    }
}
