namespace BellaControl.API.BellaControl.Models;

public class Cliente
{
    public long Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Cpf { get; set; } = string.Empty;
}