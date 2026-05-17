using BellaControl.API.BellaControl.Models;
using BellaControl.API.Data;
using Microsoft.EntityFrameworkCore;

namespace BellaControl.API.BellaControl.Services;

public class ProdutoService(AppDbContext context)
{
    private readonly AppDbContext _context = context;

    public async Task<List<Produto>> ListarAsync()
    {
        return await _context.Produtos
            .Include(p => p.Categoria)
            .ToListAsync();
    }

    public async Task<Produto> SalvarAsync(Produto produto)
    {
        var categoriaExiste = await _context.Categorias
            .AnyAsync(c => c.Id == produto.CategoriaId);

        if (!categoriaExiste)
        {
            throw new Exception("Categoria não encontrada");
        }

        _context.Produtos.Add(produto);

        await _context.SaveChangesAsync();

        return produto;
    }
}