using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace RevolutionRPS.API.Repositoy;

public abstract class Repository<TContext, TEntity> : IDisposable, IRepository<TEntity>
    where TContext : DbContext where TEntity : class, new()
{
    protected readonly TContext Db;
    protected readonly DbSet<TEntity> DbSet;

    public Repository(TContext db)
    {
        Db = db;
        DbSet = db.Set<TEntity>();
    }

    public virtual void Dispose()
    {
        Db?.Dispose();
    }

    public virtual async Task AdicionarAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
    }

    //public virtual async Task<TEntity> ObterPorIdAsync(Guid id)
    //{
    //    //  return await DbSet.FindAsync(id);
    //}

    public virtual  async Task<List<TEntity>> ObterTodosAsync()
    {
        return await DbSet.ToListAsync();
    }

    //public virtual async Task<TEntity> PesquisarAsync(Expression<Func<TEntity, bool>> expression)
    //{
    //    return await DbSet.FindAsync(expression);
    //}

    public virtual async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await DbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        return await Db.SaveChangesAsync();
    }

    public virtual void Atualizar(TEntity entity)
    {
        DbSet.Update(entity);
    }

    public virtual void Remover(TEntity entity)
    {
        DbSet.Remove(entity);

    }

}