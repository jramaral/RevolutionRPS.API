using Microsoft.EntityFrameworkCore;
using RevolutionRPS.API.Domain.Models;
using RevolutionRPS.API.Infra;
using RevolutionRPS.API.Repositoy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevolutionRPS.API.Test
{
    public class Teste
    {
        [Fact]
        public async Task TesteDoMetodo()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new BaseContextTest(options))
            {
                var jogador = new Jogador { Nome = "John Doe" };
                context.Jogadores.Add(jogador);
                await context.SaveChangesAsync();

                jogador.Nome = "Jane Doe";
                await context.SaveChangesAsync();

                // Assert
                Assert.NotNull(jogador.DataCadastro);
                Assert.NotNull(jogador.DataAtualizacao);
                Assert.NotEqual(jogador.DataCadastro, jogador.DataAtualizacao);
            }
        }
        [Fact]
        public async Task TesteDo()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ContextRps>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ContextRps(options))
            {
                // Assert
                Assert.NotNull(context);
            }
        }
    }
}
