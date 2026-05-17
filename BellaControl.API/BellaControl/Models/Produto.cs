namespace BellaControl.API.BellaControl.Models;

public class Produto
{
    public long Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public decimal Preco { get; set; }

    public long CategoriaId { get; set; }

    public Categoria Categoria { get; set; } = null!;
}