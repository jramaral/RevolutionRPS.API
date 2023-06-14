using Microsoft.AspNetCore.Mvc;
using Moq;
using RevolutionRPS.API.Comunicacao;
using RevolutionRPS.API.Controllers.V1;
using RevolutionRPS.API.Domain.Models;
using RevolutionRPS.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevolutionRPS.API.Test
{
    public class UnitTestController
    {
        private readonly Mock<IJogadorService> jogadorService;

        public UnitTestController()
        {
            jogadorService = new Mock<IJogadorService>();

        }
        [Fact]
        public void GetJogadorList_JogadorList()
        {
            //arrange
            var jogadores = GetData();

            jogadorService.Setup(_ => _.GetAllGamers())
                .ReturnsAsync(jogadores);

            var jogadorController = new JogadorController(jogadorService.Object);

            //act
            var jogadorResult = jogadorController.GetAll();

            //assert
            Assert.NotNull(jogadorResult);
            Assert.Equal(GetData().Count(), jogadorResult.Result.Count());
            Assert.True(jogadores.Equals(jogadorResult.Result));


        }

        [Fact]
        public async Task AdicionarJogador_ReturnStatusCode202()
        {
            //arrange
            var jogadorRequest = new JogadorRequest { Nome = "Jogador 1" };
            var jogadorServiceMock = new Mock<IJogadorService>();

            jogadorServiceMock.Setup(_ => _.Adicionar(jogadorRequest)).Returns(Task.CompletedTask);
            var controller = new JogadorController(jogadorServiceMock.Object);

            //act
            var result = await controller.AdicionarJogador(jogadorRequest);

            //assert
            Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(202,((StatusCodeResult)result).StatusCode);    

        }

        private IEnumerable<JogadorResponse> GetData()
        {
            var lista = new List<JogadorResponse>
            {
                new JogadorResponse
                {
                    Id = new Guid(),
                    Nome = "jogador 1",
                  

                },
                new JogadorResponse
                {
                    Id = new Guid(),
                    Nome = "jogador 2",
                   

                }
            };

            return lista;
        }

    }
}
