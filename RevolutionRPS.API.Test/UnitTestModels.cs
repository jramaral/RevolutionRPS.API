using RevolutionRPS.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RevolutionRPS.API.Test
{
    public class UnitTestModels
    {

        [Fact]
        public void TestGetterAndSettersJogador()
        {
            var model = new Jogador();
            model.Id = Guid.NewGuid();
            model.Nome = "jogador 1";
            model.DataAtualizacao = DateTime.Now;
            model.DataCadastro = DateTime.Now;
            model.Jogada = new List<Jogada>();

            Guid id = model.Id;
            string nome = model.Nome;
            DateTime dt1 = model.DataCadastro;
            DateTime dt2 = model.DataAtualizacao;
            ICollection<Jogada> jogada = model.Jogada;

            Assert.Equal(nome, model.Nome);
            Assert.Equal(id, model.Id);
            Assert.Equal(dt1, model.DataCadastro);
            Assert.Equal(dt2, model.DataAtualizacao);
            Assert.Equal(jogada, model.Jogada);
        }
        [Fact]
        public void TestGetterAndSettersJogada()
        {
            var model = new Jogada();
            model.Id = Guid.NewGuid();
            model.JogadorId = Guid.NewGuid();
            model.DataAtualizacao = DateTime.Now;
            model.DataCadastro = DateTime.Now;
            model.QuemJogou = "jogador 1";
            model.DataHoraJogada = DateTime.Now;
            model.Jogador = new Jogador();

            Guid id = model.Id;
            Guid jogadorId = model.JogadorId;
            DateTime dt1 = model.DataCadastro;
            DateTime dt2 = model.DataAtualizacao;
            string jogou = model.QuemJogou;
            DateTime horaJogada = model.DataHoraJogada;
            Jogador jogador = model.Jogador;

            Assert.Equal(jogadorId, model.JogadorId);
            Assert.Equal(id, model.Id);
            Assert.Equal(dt1, model.DataCadastro);
            Assert.Equal(dt2, model.DataAtualizacao);
            Assert.Equal(jogou, model.QuemJogou);
            Assert.Equal(horaJogada, model.DataHoraJogada);
            Assert.Equal(jogador, model.Jogador);
        }
    }
}
