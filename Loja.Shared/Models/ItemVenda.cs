namespace Loja.Shared.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }
        public Produto? Produto { get; set; }
        public int? Quantidade { get; set; }
        public decimal valor { get; set; }
    }
}