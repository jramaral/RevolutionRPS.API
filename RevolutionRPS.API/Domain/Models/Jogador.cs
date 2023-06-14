namespace RevolutionRPS.API.Domain.Models;

public class Jogador : Entity
{
    public string? Nome { get; set; }
    public ICollection<Jogada>? Jogada { get; set; }
}