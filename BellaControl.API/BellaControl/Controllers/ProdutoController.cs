using BellaControl.API.BellaControl.Models;
using BellaControl.API.BellaControl.Services;
using Microsoft.AspNetCore.Mvc;

namespace BellaControl.API.BellaControl.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController(ProdutoService service) : ControllerBase
{
    private readonly ProdutoService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Produto>>> Listar()
    {
        var produtos = await _service.ListarAsync();

        return Ok(produtos);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> Salvar(Produto produto)
    {
        var resultado = await _service.SalvarAsync(produto);

        return Ok(resultado);
    }
}