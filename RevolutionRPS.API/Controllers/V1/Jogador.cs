using Microsoft.AspNetCore.Mvc;
using RevolutionRPS.API.Comunicacao;
using RevolutionRPS.API.Interfaces;

namespace RevolutionRPS.API.Controllers.V1;

[ApiController]
[Route("api/[controller]")]
public class JogadorController : ControllerBase
{

    private readonly IJogadorService _jogadorService;
    public JogadorController(IJogadorService jogadorService)
    {
        _jogadorService = jogadorService;
    }

    [HttpGet]
    public async Task<IEnumerable<JogadorResponse>>GetAll()
    {
        var res = await _jogadorService.GetAllGamers();
        return res;
    }

    [HttpPost]
    public async Task<IActionResult> AdicionarJogador([FromBody] JogadorRequest jogador)
    {
        await _jogadorService.Adicionar(jogador);
        return StatusCode(202);
    }
}