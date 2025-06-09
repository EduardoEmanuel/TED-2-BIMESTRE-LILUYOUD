using Loja.Shared.Contexts;
using Loja.Shared.Models;
using static System.Console;

namespace Loja.Console.Helpers;

internal static class ProdutoHelper
{
    public static void Cadastrar()
    {
        var produto = new Produto();
        MenuHelper.CriarCabecalho("CADASTRO DE PRODUTOS");
        Write(" Codigo: ");
        produto.Id = Convert.ToInt32(ReadLine());
        Write(" Nome:   ");
        produto.Nome = ReadLine();
        Write(" Valor:  ");
        produto.Valor = Convert.ToDecimal(ReadLine());
        MenuHelper.CriarLinha();
        LojaContext.Produtos.Add(produto);
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuProduto();
    }

    public static void Listar()
    {
        MenuHelper.CriarCabecalho("LISTA DE PRODUTOS");
        if (LojaContext.Produtos.Count == 0)
        {
            WriteLine(" Nenhum produto cadastrado.");
        }
        else
        {
            foreach (var produto in LojaContext.Produtos)
            {
                WriteLine(" " + produto);
            }
        }
        MenuHelper.CriarLinha();
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuProduto();
    }

    public static void Editar()
    {
        MenuHelper.CriarCabecalho("EDITAR PRODUTO");
        Write(" Informe o código do produto: ");
        int codigo = Convert.ToInt32(ReadLine());
        var produto = LojaContext.Produtos.FirstOrDefault(p => p.Id == codigo);

        if (produto == null)
        {
            WriteLine(" Produto não encontrado.");
        }
        else
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Nome Atual: {produto.Nome}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo Nome:  ");
            var nome = ReadLine();
            if (!string.IsNullOrEmpty(nome))
                produto.Nome = nome;

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Valor Atual: {produto.Valor}");
            ForegroundColor = ConsoleColor.White;
            Write(" Novo Valor:  ");
            var valor = ReadLine();
            if (!string.IsNullOrEmpty(valor))
                produto.Valor = Convert.ToDecimal(valor);

            ForegroundColor = ConsoleColor.Yellow;
            WriteLine($"\n Quantidade Atual: {produto.Quantidade}");
            ForegroundColor = ConsoleColor.White;
            Write(" Nova Quantidade:  ");
            var quantidade = ReadLine();
            if (!string.IsNullOrEmpty(quantidade))
                produto.Quantidade = Convert.ToInt32(quantidade);

            WriteLine("\n Produto atualizado com sucesso.");
        }
        MenuHelper.CriarLinha();
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuProduto();
    }

    public static void Excluir()
    {
        MenuHelper.CriarCabecalho("EXCLUIR PRODUTO");
        Write(" Informe o código do produto: ");
        int codigo = Convert.ToInt32(ReadLine());
        var produto = LojaContext.Produtos.FirstOrDefault(p => p.Id == codigo);

        if (produto == null)
        {
            WriteLine(" Produto não encontrado.");
        }
        else
        {
            WriteLine(" \n Deseja realmente excluir");
            WriteLine(" " + produto);
            Write(" [S] Sim / [N] Não: ");
            var opcao = ReadLine()?.ToUpper();
            if (opcao == "S")
            {
                LojaContext.Produtos.Remove(produto);
                WriteLine(" Produto excluído com sucesso.");
            }
        }
        MenuHelper.CriarLinha();
        Write(" [Enter] para continuar... ");
        ReadLine();
        MenuHelper.MenuProduto();
    }
}
