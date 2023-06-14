using Microsoft.Identity.Client;
using Moq;
using RevolutionRPS.API.Comunicacao;
using RevolutionRPS.API.Domain;
using RevolutionRPS.API.Domain.Models;
using RevolutionRPS.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace RevolutionRPS.API.Test
{
    public class UnitTestJogadorService
    {
        private readonly Mock<IJogadorRepository> _mockRepository;
        private readonly JogadorService _jogadorService;
        public UnitTestJogadorService()
        {
            _mockRepository = new Mock<IJogadorRepository>();
            _jogadorService = new JogadorService(_mockRepository.Object);
            

        }

        [Fact]
        public async Task GetAllGamers_ReturnsListOfJogadorResponse()
        {
            //arg
            var jogadores = new List<Jogador>
            {
                new Jogador {Id = new Guid(), Nome="Jogador 1"},
                new Jogador {Id = new Guid(), Nome="Jogador 2"}
            };

            _mockRepository.Setup(_=>_.PesquisarTodosJogadoresAsync()).ReturnsAsync(jogadores);


            //act
            var result = await _jogadorService.GetAllGamers();


            //assert
            Assert.Equal(jogadores.Count(), result.Count());

            for (int i = 0; i < result.Count(); i++)
            {
                Assert.Equal(jogadores[i].Id, result.ElementAt(i).Id);
                Assert.Equal(jogadores[i].Nome, result.ElementAt(i).Nome);
            }

        }
        [Fact]
        public async Task GetJogadorById_ReturnOfJogadorResponse()
        {
            //arg
            var jogador = new Jogador { Id = new Guid(), Nome = "Jogador 1" };
              
            _mockRepository.Setup(_ => _.GetJogadorPorId(jogador.Id)).ReturnsAsync(jogador);


            //act
            var result = await _jogadorService.GetJogadorById(jogador.Id);


            //assert
            Assert.True(object.Equals(jogador,result));

           
        }
        [Fact]
        public void ToJogador_ReturnsJogadorWithSameProperties()
        {
            // Arrange
            var jogadorRequest = new JogadorRequest { Id = new Guid(), Nome = "Jogador 1" };

            // Act
            var result = _jogadorService.ToJogador(jogadorRequest);

            // Assert
            Assert.Equal(jogadorRequest.Id, result.Id);
            Assert.Equal(jogadorRequest.Nome, result.Nome);
        }
    }
}
