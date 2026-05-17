using System.ComponentModel.DataAnnotations;

namespace BellaControl.API.BellaControl.Models;

public class Categoria
{
    public long Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

}