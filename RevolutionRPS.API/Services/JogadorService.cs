using RevolutionRPS.API.Comunicacao;
using RevolutionRPS.API.Domain;
using RevolutionRPS.API.Domain.Models;
using RevolutionRPS.API.Interfaces;
using RevolutionRPS.API.Repositoy;
using System.Formats.Asn1;

namespace RevolutionRPS.API.Services;

public class JogadorService :  IJogadorService
{
    private readonly IJogadorRepository _jogadorRepository;
    public JogadorService(IJogadorRepository jogadorRepository) 
    {
        _jogadorRepository = jogadorRepository;
    }

    public Jogador ToJogador(JogadorRequest request)
    {
        var entity = new Jogador()
        {
            Id = request.Id,
            Nome = request.Nome
        };
        return entity;
    }
    public IEnumerable<JogadorResponse> ToResponse(IEnumerable<Jogador> request)
    {
        var lista = new List<JogadorResponse>();
        
        foreach (var item in request)
        {
            var entity = new JogadorResponse()
            {
                Id = item!.Id,
                Nome = item.Nome
            };
            lista.Add(entity);
        }
       
        return lista;
    }

    public async Task<IEnumerable<JogadorResponse>> GetAllGamers()
    {
      var data = await _jogadorRepository.PesquisarTodosJogadoresAsync();
      return ToResponse(data);
    }

    public async Task Adicionar(JogadorRequest jogador)
    {
        await _jogadorRepository.AdicionarJogadorAsync(ToJogador(jogador));
        await _jogadorRepository.SaveChangesAsync();
    }

    public async Task<object> GetJogadorById(Guid jogadorId)
    {
        return await _jogadorRepository.GetJogadorPorId(jogadorId);
    }
}