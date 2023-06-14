using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevolutionRPS.API.Domain.Models;

namespace RevolutionRPS.API.Repositoy.Config;

public class JogadorConfig : IEntityTypeConfiguration<Jogador>
{
    public void Configure(EntityTypeBuilder<Jogador> builder)
    {
        builder.ToTable("Jogador");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Nome)
            .HasColumnType("varchar(100)");
        
    }
}
