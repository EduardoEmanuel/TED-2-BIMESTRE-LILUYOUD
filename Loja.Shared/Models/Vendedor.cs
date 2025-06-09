namespace Loja.Shared.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Cpf { get; set; }
        public string? Email { get; set; }

        public override string ToString()
        {
            return $"C{Id.ToString("D3")} {Name} - CPF {Cpf} - E-mail {Email}";
        }
    }
}