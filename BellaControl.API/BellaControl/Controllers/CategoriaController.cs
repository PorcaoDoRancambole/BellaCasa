using BellaControl.API.BellaControl.Models;
using BellaControl.API.BellaControl.Services;
using Microsoft.AspNetCore.Mvc;

namespace BellaControl.API.BellaControl.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriaController(CategoriaService service) : ControllerBase
{

    private readonly CategoriaService _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Categoria>>> Listar()
    {
        var categoria = await _service.ListarAsync();

        return Ok(categoria);
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> Salvar(Categoria categoria)
    {
        try
        {
            var resultado = await _service.SalvarAsync(categoria);

            return Ok(resultado);
        }
        catch (Exception ex)
        {
            return BadRequest(new
            {
                mensagem = ex.Message
            });
        }
    }

    [HttpGet("/Buscar/{id:long}")]
    public async Task<ActionResult<Categoria>> Buscar(long id)
    {
        var categoria = await _service.BuscarPorIdAsync(id);

        if (categoria == null)
            return NotFound(new { mensagem = "Categoria não encontrada." });

        return Ok(categoria);
    }

    [HttpPut("/Atualizar/{id:long}")]
    public async Task<ActionResult<Categoria>> Atualizar(long id, Categoria categoria)
    {
        try
        {
            var atualizado = await _service.AtualizarAsync(id, categoria);
            return Ok(atualizado);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }

    [HttpDelete("/Deletar/{id:long}")]
    public async Task<IActionResult> Deletar(long id)
    {
        try
        {
            await _service.DeletarAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensagem = ex.Message });
        }
    }
}

