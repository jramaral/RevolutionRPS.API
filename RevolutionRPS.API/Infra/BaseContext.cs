using Microsoft.EntityFrameworkCore;
using RevolutionRPS.API.Domain.Models;
using RevolutionRPS.API.Repositoy;

namespace RevolutionRPS.API.Infra
{
    public abstract class BaseContext : DbContext
    {
        public DbSet<Jogador> Jogadores { get; set; }
        public DbSet<Jogada> Jogadas { get; set; }


        protected BaseContext(DbContextOptions options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry=>
                entry.Entity.GetType().GetProperty("DataCadastro")!=null &&
                entry.Entity.GetType().GetProperty("DataAtualizacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
