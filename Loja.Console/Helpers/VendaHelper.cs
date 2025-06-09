using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;

namespace Loja.Console.Helpers
{
    internal static class VendaHelper
    {
        public static void Cadastrar()
        {
            var venda = new Venda();
            MenuHelper.CriarCabecalho("CADASTRO DE VENDAS");

            venda.Id = LerInteiro("Codigo: ", "Código inválido. Digite um número: ");
            venda.Data = LerData("Data (dd/MM/yyyy): ", "Data inválida. Use o formato dd/MM/yyyy: ");

            Write("Codigo do Cliente (0 para nenhum): ");
            int idCliente = LerInteiro("Código inválido. Digite um número: ", "Código inválido. Digite um número: ");
            venda.Cliente = idCliente == 0 ? null : new Cliente { Id = idCliente };

            Write("Codigo do Vendedor (0 para nenhum): ");
            int idVendedor = LerInteiro("Código inválido. Digite um número: ", "Código inválido. Digite um número: ");
            venda.Vendedor = idVendedor == 0 ? null : new Vendedor { Id = idVendedor };

            AdicionarItem(venda);

            MenuHelper.CriarLinha();
            if (LojaContext.Vendas == null) LojaContext.Vendas = new List<Venda>();
            try
            {
                LojaContext.Vendas.Add(venda);
                WriteLine("Venda cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                WriteLine($"Erro ao cadastrar venda: {ex.Message}");
            }
            PausarEVoltar();
        }

        public static void Listar()
        {
            MenuHelper.CriarCabecalho("LISTA DE VENDAS");
            if (LojaContext.Vendas == null || LojaContext.Vendas.Count == 0)
                WriteLine("Nenhuma venda cadastrada.");
            else
                foreach (var venda in LojaContext.Vendas)
                    WriteLine($" {venda.Id} - {venda.Data:dd/MM/yyyy} - Cliente: {(venda.Cliente?.Id ?? 0)} - Vendedor: {(venda.Vendedor?.Id ?? 0)} - Itens: {venda.Items.Count}");
            MenuHelper.CriarLinha();
            PausarEVoltar();
        }

        public static void Editar()
        {
            MenuHelper.CriarCabecalho("EDIÇÃO DE VENDAS");
            if (LojaContext.Vendas == null || LojaContext.Vendas.Count == 0)
            {
                WriteLine("Nenhuma venda cadastrada.");
                PausarEVoltar();
                return;
            }

            foreach (var venda1 in LojaContext.Vendas)
                WriteLine($" {venda1.Id} - {venda1.Data:dd/MM/yyyy} - Cliente: {(venda1.Cliente?.Id ?? 0)} - Vendedor: {(venda1.Vendedor?.Id ?? 0)} - Itens: {venda1.Items.Count}");
            MenuHelper.CriarLinha();

            int id = LerInteiro("Digite o código da venda a editar: ", "Código inválido ou venda não encontrada.");
            var venda = LojaContext.Vendas.FirstOrDefault(v => v.Id == id);
            if (venda == null)
            {
                WriteLine("Código inválido ou venda não encontrada.");
                PausarEVoltar();
                return;
            }

            venda.Data = LerDataOpcional("Nova Data (dd/MM/yyyy, deixe em branco para manter): ", venda.Data);
            Write("Novo Código do Cliente (0 para nenhum, deixe em branco para manter): ");
            int novoIdCliente = (int)LerInteiroOpcional("Código inválido. Digite um número: ", venda.Cliente?.Id ?? 0);
            venda.Cliente = novoIdCliente == 0 ? null : new Cliente { Id = novoIdCliente };

            Write("Novo Código do Vendedor (0 para nenhum, deixe em branco para manter): ");
            int novoIdVendedor = (int)LerInteiroOpcional("Código inválido. Digite um número: ", venda.Vendedor?.Id ?? 0);
            venda.Vendedor = novoIdVendedor == 0 ? null : new Vendedor { Id = novoIdVendedor };

            WriteLine("Deseja adicionar ou editar um item? (S/N): ");
            if (ReadLine()?.ToUpper() == "S")
                AdicionarItem(venda);

            WriteLine("Venda atualizada com sucesso!");
            PausarEVoltar();
        }

        public static void Excluir()
        {
            MenuHelper.CriarCabecalho("EXCLUSÃO DE VENDAS");
            if (LojaContext.Vendas == null || LojaContext.Vendas.Count == 0)
            {
                WriteLine("Nenhuma venda cadastrada.");
                PausarEVoltar();
                return;
            }

            foreach (var venda2 in LojaContext.Vendas)
                WriteLine($" {venda2.Id} - {venda2.Data:dd/MM/yyyy} - Cliente: {(venda2.Cliente?.Id ?? 0)} - Vendedor: {(venda2.Vendedor?.Id ?? 0)} - Itens: {venda2.Items.Count}");
            MenuHelper.CriarLinha();

            int id = LerInteiro("Digite o código da venda a excluir: ", "Código inválido ou venda não encontrada.");
            var venda = LojaContext.Vendas.FirstOrDefault(v => v.Id == id);
            if (venda == null)
            {
                WriteLine("Código inválido ou venda não encontrada.");
                PausarEVoltar();
                return;
            }

            WriteLine("Deseja realmente excluir esta venda? (S/N): ");
            if (ReadLine()?.ToUpper() == "S")
            {
                LojaContext.Vendas.Remove(venda);
                WriteLine("Venda excluída com sucesso!");
            }
            PausarEVoltar();
        }

        private static void AdicionarItem(Venda venda)
        {
            var item = new ItemVenda();
            item.Id = venda.Items.Count + 1; // ID simples baseado na contagem de itens
            Write("Código do Produto para o item: ");
            int idProduto = LerInteiro("Código inválido. Digite um número: ", "Código inválido. Digite um número: ");
            item.Produto = new Produto { Id = idProduto }; // Simplificação

            Write("Quantidade (deixe em branco para omitir): ");
            int? quantidade = LerInteiroOpcional("Quantidade inválida. Digite um número: ", null);
            item.Quantidade = quantidade.HasValue ? quantidade : null;

            Write("Valor: ");
            item.valor = LerDecimal("Valor inválido. Digite um número decimal: ", "Valor inválido. Digite um número decimal: ");

            venda.Items.Add(item);
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

        private static DateTime LerData(string prompt, string erro)
        {
            DateTime data;
            Write(prompt);
            while (!DateTime.TryParse(ReadLine(), out data))
            {
                Write(erro);
            }
            return data;
        }

        private static decimal LerDecimal(string prompt, string erro)
        {
            decimal valor;
            Write(prompt);
            while (!decimal.TryParse(ReadLine(), out valor))
            {
                Write(erro);
            }
            return valor;
        }

        private static int? LerInteiroOpcional(string prompt, int? valorAtual)
        {
            Write(prompt);
            string input = ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                return valorAtual;
            int valor;
            while (!int.TryParse(input, out valor))
            {
                Write("Valor inválido. Digite um número: ");
                input = ReadLine();
            }
            return valor;
        }

        private static DateTime LerDataOpcional(string prompt, DateTime valorAtual)
        {
            Write(prompt);
            string input = ReadLine();
            return string.IsNullOrWhiteSpace(input) ? valorAtual : LerData(prompt, "Data inválida. Use o formato dd/MM/yyyy: ");
        }

        private static void PausarEVoltar()
        {
            Write(" [Enter] para continuar... ");
            ReadLine();
            MenuHelper.MenuVenda();
        }
    }
}