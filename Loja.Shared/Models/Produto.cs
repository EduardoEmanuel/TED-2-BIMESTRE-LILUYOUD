
namespace Loja.Shared.Models;

public class Produto
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public decimal Valor { get; set; }
    public int Quantidade { get; set; }

    public override string ToString()
    {
        return $"P{Id.ToString("D3")} {Nome}: {Quantidade} unidades à R$ {Valor.ToString("N2")}";
    }

}
