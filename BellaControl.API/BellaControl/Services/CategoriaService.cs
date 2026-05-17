using BellaControl.API.BellaControl.Models;
using BellaControl.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BellaControl.API.BellaControl.Services;

public class CategoriaService
{
    private readonly AppDbContext _context;

    public CategoriaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Categoria>> ListarAsync()
    {
        return await _context.Categorias
            .ToListAsync();
    }

    public async Task<Categoria?> BuscarPorIdAsync(long id)
    {
        return await _context.Categorias.FindAsync(id);
    }

    public async Task<Categoria> SalvarAsync(Categoria categoria)
    {
        var categoriaExiste = await _context.Categorias
            .AnyAsync(c => c.Nome == categoria.Nome);

        if (categoriaExiste)
        {
            throw new Exception("Já existe uma categoria com esse nome.");
        }

        _context.Categorias.Add(categoria);

        await _context.SaveChangesAsync();

        return categoria;
    }

    public async Task<Categoria> AtualizarAsync(long id, Categoria categoria)
    {
        var existente = await _context.Categorias.FindAsync(id);

        if (existente == null)
            throw new Exception("Categoria não encontrada.");

        var nomeEmUso = await _context.Categorias
            .AnyAsync(c => c.Nome == categoria.Nome && c.Id != id);

        if (nomeEmUso)
            throw new Exception("Já existe uma categoria com esse nome.");

        existente.Nome = categoria.Nome;

        await _context.SaveChangesAsync();

        return existente;
    }

    public async Task DeletarAsync(long id)
    {
        var existente = await _context.Categorias.FindAsync(id);

        if (existente == null)
            throw new Exception("Categoria não encontrada.");

        _context.Categorias.Remove(existente);

        await _context.SaveChangesAsync();
    }
}
