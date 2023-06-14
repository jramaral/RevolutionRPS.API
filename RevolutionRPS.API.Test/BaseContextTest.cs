using Microsoft.EntityFrameworkCore;
using RevolutionRPS.API.Domain.Models;
using RevolutionRPS.API.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevolutionRPS.API.Test
{
    public class BaseContextTest : BaseContext
    {
        private DbContextOptions<BaseContext> options;

        public BaseContextTest(DbContextOptions<BaseContext> options) : base(options)
        {
        }


        //[Fact]
        //public async Task SaveChangesAsync_ShouldSetDataCadastroAndDataAtualizacao_OnAddedEntities()
        //{
        //    // Arrange
        //    var options = new DbContextOptionsBuilder<BaseContext>()
        //        .UseInMemoryDatabase(databaseName: "test_database")
        //        .Options;

        //    using (BaseContext context = new BaseContext(options))
        //    {
        //        var jogador = new Jogador { Nome = "John Doe" };
        //        context.Jogadores.Add(jogador);
        //        await context.SaveChangesAsync();

        //        // Assert
        //        Assert.NotNull(jogador.DataCadastro);
        //        Assert.NotNull(jogador.DataAtualizacao);
        //    }
        //}
    }


}
