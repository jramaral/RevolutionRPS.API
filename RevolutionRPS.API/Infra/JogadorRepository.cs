
using Microsoft.EntityFrameworkCore;
using RevolutionRPS.API.Domain;
using RevolutionRPS.API.Domain.Models;
using RevolutionRPS.API.Repositoy;


namespace RevolutionRPS.API.Infra;

public class JogadorRepository<TContext> : Repository<TContext, Jogador>, IJogadorRepository where TContext : BaseContext
{
    public JogadorRepository(TContext db) : base(db)
    {
    }

    public async Task AdicionarJogadorAsync(Jogador jogador)
    {
        
        await Db.AddAsync(jogador);
        await SaveChangesAsync();
    }

    public Task<object> GetJogadorPorId(Guid jogadorId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Jogador>> PesquisarTodosJogadoresAsync()
    {
        return await Db.Jogadores.ToListAsync();
    }
}