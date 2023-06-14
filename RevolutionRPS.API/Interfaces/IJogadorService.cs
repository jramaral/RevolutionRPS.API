using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RevolutionRPS.API.Comunicacao;

namespace RevolutionRPS.API.Interfaces;

public interface IJogadorService
{
    Task<object> GetJogadorById(Guid jogadorId);

    Task<IEnumerable<JogadorResponse>> GetAllGamers();

    Task Adicionar(JogadorRequest jogador);

}