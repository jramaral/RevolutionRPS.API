using System.Linq.Expressions;

namespace RevolutionRPS.API.Repositoy;

public interface IRepository<TEntity> : IDisposable where TEntity : class
{
    Task AdicionarAsync(TEntity entity);
    
  //  Task<TEntity> ObterPorIdAsync(Guid id);
    
    Task<List<TEntity>> ObterTodosAsync();
    
   // Task<TEntity> PesquisarAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);
    
    Task<int> SaveChangesAsync();
    
    void Atualizar(TEntity entity);
    
    void Remover(TEntity entity);

}