using RevolutionRPS.API.Domain.Models;
using RevolutionRPS.API.Repositoy;

namespace RevolutionRPS.API.Domain;

public interface IJogadorRepository : IRepository<Jogador>
{
    Task AdicionarJogadorAsync(Jogador jogador);
    
    Task<IEnumerable<Jogador>> PesquisarTodosJogadoresAsync();

    Task<object> GetJogadorPorId(Guid jogadorId);
}