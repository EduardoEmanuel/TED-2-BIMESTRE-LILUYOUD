using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;

namespace Loja.Console.Helpers
{
    internal static class ClienteHelper
    {
        public static void Cadastrar()
        {
            var cliente = new Cliente();
            MenuHelper.CriarCabecalho("CADASTRO DE CLIENTES");

            cliente.Id = LerInteiro(" Codigo: ", " Código inválido. Digite um número: ");
            Write(" Nome:", "Nome deve conter apenas letras!");
            cliente.Nome = ReadLine();
            Write(" CPF:", "CPF deve conter apenas Números!");
            cliente.Cpf = ReadLine();
            Write(" Celular:", "Celular deve conter apenas Números!");
            cliente.Celular = ReadLine();
            Write(" E-mail:", "Endereço de E-mail invalido!");
            cliente.Email = ReadLine();

            MenuHelper.CriarLinha();
            if (LojaContext.Clientes == null) LojaContext.Clientes = new List<Cliente>();
            try
            {
                LojaContext.Clientes.Add(cliente);
                WriteLine("Cliente cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                WriteLine($"Erro ao cadastrar cliente: {ex.Message}");
            }
            PausarEVoltar();
        }

        public static void Listar()
        {
            MenuHelper.CriarCabecalho("LISTA DE CLIENTES");
            if (LojaContext.Clientes == null || LojaContext.Clientes.Count == 0)
                WriteLine(" Nenhum Cliente cadastrado.");
            else
                foreach (var cliente in LojaContext.Clientes)
                    WriteLine($" {cliente.Id} - {cliente.Nome} - {cliente.Cpf} - {cliente.Celular} - {cliente.Email}");
            MenuHelper.CriarLinha();
            PausarEVoltar();
        }

        internal static void Editar()
        {
            MenuHelper.CriarCabecalho("EDIÇÃO DE CLIENTES");
            if (LojaContext.Clientes == null || LojaContext.Clientes.Count == 0)
            {
                WriteLine(" Nenhum Cliente cadastrado.");
                PausarEVoltar();
                return;
            }

            foreach (var cliente0 in LojaContext.Clientes)
                WriteLine($" {cliente0.Id} - {cliente0.Nome} - {cliente0.Cpf} - {cliente0.Celular} - {cliente0.Email}");
            MenuHelper.CriarLinha();

            int id = LerInteiro(" Digite o código do cliente a editar: ", " Código inválido ou cliente não encontrado.");
            var cliente = LojaContext.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                WriteLine("Código inválido ou cliente não encontrado.");
                PausarEVoltar();
                return;
            }

            Write(" Novo Nome (deixe em branco para manter): ");
            string novoNome = ReadLine();
            if (!string.IsNullOrWhiteSpace(novoNome)) cliente.Nome = novoNome;

            Write(" Novo CPF (deixe em branco para manter): ");
            string novoCpf = ReadLine();
            if (!string.IsNullOrWhiteSpace(novoCpf)) cliente.Cpf = novoCpf;

            Write(" Novo Celular (deixe em branco para manter): ");
            string novoCelular = ReadLine();
            if (!string.IsNullOrWhiteSpace(novoCelular)) cliente.Celular = novoCelular;

            Write(" Novo Email (deixe em branco para manter): ");
            string novoEmail = ReadLine();
            if (!string.IsNullOrWhiteSpace(novoEmail)) cliente.Email = novoEmail;

            WriteLine("Cliente atualizado com sucesso!");
            PausarEVoltar();
        }

        internal static void Excluir()
        {
            MenuHelper.CriarCabecalho("EXCLUSÃO DE CLIENTES");
            if (LojaContext.Clientes == null || LojaContext.Clientes.Count == 0)
            {
                WriteLine(" Nenhum Cliente cadastrado.");
                PausarEVoltar();
                return;
            }

            foreach (var cliente1 in LojaContext.Clientes)
                WriteLine($" {cliente1.Id} - {cliente1.Nome} - {cliente1.Cpf} - {cliente1.Celular} - {cliente1.Email}");
            MenuHelper.CriarLinha();

            int id = LerInteiro(" Digite o código do cliente a excluir: ", " Código inválido ou cliente não encontrado.");
            var cliente = LojaContext.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
            {
                WriteLine("Código inválido ou cliente não encontrado.");
                PausarEVoltar();
                return;
            }

            LojaContext.Clientes.Remove(cliente);
            WriteLine("Cliente excluído com sucesso!");
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
            MenuHelper.MenuCliente();
        }
    }
}