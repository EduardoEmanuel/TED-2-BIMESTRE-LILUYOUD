namespace Loja.Shared.Models;

public class Venda
{
    public object Produto;
    public object Valor;

    public int Id { get; set; }
    public DateTime Data { get; set; } = DateTime.Now;
    public Cliente? Cliente { get; set; }

    public Vendedor? Vendedor { get; set; }

    public List<ItemVenda> Items { get; set; } = new List<ItemVenda>();
}

