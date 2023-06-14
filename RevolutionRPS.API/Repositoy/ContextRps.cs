using Microsoft.EntityFrameworkCore;
using RevolutionRPS.API.Infra;
using RevolutionRPS.API.Repositoy.Config;

namespace RevolutionRPS.API.Repositoy;

public class ContextRps : BaseContext
{
    public ContextRps(DbContextOptions<ContextRps> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextRps).Assembly);
        modelBuilder.ApplyConfiguration(new JogadorConfig());
        modelBuilder.ApplyConfiguration(new JogadaConfig());
        base.OnModelCreating(modelBuilder);
    }
}