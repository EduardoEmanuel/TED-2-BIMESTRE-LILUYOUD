using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;

namespace Loja.Console.Helpers
{
    internal static class VendedorHelper
    {
        public static void Cadastrar()
        {
            var vendedor = new Vendedor();
            MenuHelper.CriarCabecalho("CADASTRO DE VENDEDORES");

            vendedor.Id = LerInteiro(" Codigo: ", " Código inválido. Digite um número: ");
            Write(" Nome:", "Nome deve conter apenas letras!");
            vendedor.Name = ReadLine();
            Write(" CPF:", "CPF deve conter apenas Números!");
            vendedor.Cpf = ReadLine();
            Write(" E-mail:", "Endereço de E-mail invalido!");
            vendedor.Email = ReadLine();

            MenuHelper.CriarLinha();
            if (LojaContext.Vendedores == null) LojaContext.Vendedores = new List<Vendedor>();
            try
            {
                LojaContext.Vendedores.Add(vendedor);
                WriteLine("Vendedor cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                WriteLine($"Erro ao cadastrar vendedor: {ex.Message}");
            }
            PausarEVoltar();
        }

        public static void Listar()
        {
            MenuHelper.CriarCabecalho("LISTA DE VENDEDORES");
            if (LojaContext.Vendedores == null || LojaContext.Vendedores.Count == 0)
                WriteLine(" Nenhum vendedor cadastrado.");
            else
                foreach (var vendedor in LojaContext.Vendedores)
                    WriteLine($" {vendedor}");
            MenuHelper.CriarLinha();
            PausarEVoltar();
        }

        internal static void Editar()
        {
            MenuHelper.CriarCabecalho("EDIÇÃO DE VENDEDORES");
            if (LojaContext.Vendedores == null || LojaContext.Vendedores.Count == 0)
            {
                WriteLine(" Nenhum vendedor cadastrado.");
                PausarEVoltar();
                return;
            }

            foreach (var vendedor0 in LojaContext.Vendedores)
                WriteLine($" {vendedor0}");
            MenuHelper.CriarLinha();

            int id = LerInteiro(" Digite o código do vendedor a editar: ", " Código inválido ou vendedor não encontrado.");
            var vendedor = LojaContext.Vendedores.FirstOrDefault(c => c.Id == id);
            if (vendedor == null)
            {
                WriteLine("Código inválido ou vendedor não encontrado.");
                PausarEVoltar();
                return;
            }

            Write(" Novo Nome (deixe em branco para manter): ");
            string novoNome = ReadLine();
            if (!string.IsNullOrWhiteSpace(novoNome)) vendedor.Name = novoNome;

            Write(" Novo CPF (deixe em branco para manter): ");
            string novoCpf = ReadLine();
            if (!string.IsNullOrWhiteSpace(novoCpf)) vendedor.Cpf = novoCpf;

            Write(" Novo Email (deixe em branco para manter): ");
            string novoEmail = ReadLine();
            if (!string.IsNullOrWhiteSpace(novoEmail)) vendedor.Email = novoEmail;

            WriteLine("Vendedor atualizado com sucesso!");
            PausarEVoltar();
        }

        internal static void Excluir()
        {
            MenuHelper.CriarCabecalho("EXCLUSÃO DE VENDEDORES");
            if (LojaContext.Vendedores == null || LojaContext.Vendedores.Count == 0)
            {
                WriteLine(" Nenhum vendedor cadastrado.");
                PausarEVoltar();
                return;
            }

            foreach (var vendedor1 in LojaContext.Vendedores)
                WriteLine($" {vendedor1}");
            MenuHelper.CriarLinha();

            int id = LerInteiro(" Digite o código do vendedor a excluir: ", " Código inválido ou vendedor não encontrado.");
            var vendedor = LojaContext.Vendedores.FirstOrDefault(c => c.Id == id);
            if (vendedor == null)
            {
                WriteLine("Código inválido ou vendedor não encontrado.");
                PausarEVoltar();
                return;
            }

            LojaContext.Vendedores.Remove(vendedor);
            WriteLine("Vendedor excluído com sucesso!");
            PausarEVoltar();
        }

        private static int LerInteiro(string prompt, string erro)
        {
            int valor;
            Write(prompt);
            while (!int.TryParse(ReadLine(), out valor))
            {
                Write(erro);
            }
            return valor;
        }

        private static void PausarEVoltar()
        {
            Write(" [Enter] para continuar... ");
            ReadLine();
            MenuHelper.MenuVendedor();
        }
    }
}