namespace RevolutionRPS.API.Domain.Models;

public class Jogada : Entity
{
  
    public Guid JogadorId { get; set; }
    public string? QuemJogou { get; set; }
    public DateTime DataHoraJogada { get; set; }
    public virtual Jogador?  Jogador { get; set; }
}