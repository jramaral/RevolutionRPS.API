using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RevolutionRPS.API.Domain.Models;

namespace RevolutionRPS.API.Repositoy.Config;

public class JogadaConfig:IEntityTypeConfiguration<Jogada>
{
    public void Configure(EntityTypeBuilder<Jogada> builder)
    {
        builder.ToTable("Jogada");

        builder.HasKey(j => j.Id);
        builder.Property(_ => _.JogadorId);
        builder.Property((_ => _.QuemJogou));
        builder.Property(_ => _.DataHoraJogada);
       
        builder.HasOne(j => j.Jogador)
            .WithMany(j => j.Jogada)
            .HasForeignKey(f => f.JogadorId);
    }
}