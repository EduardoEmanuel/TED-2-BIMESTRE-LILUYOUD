using Loja.Shared.Contexts;
using static System.Console;

namespace Loja.Console.Helpers;

internal class MenuHelper
{
    public static void CriarLinha()
    {
        WriteLine("--------------------------------------------------------------");
    }

    public static void CriarCabecalho(string titulo)
    {
        ForegroundColor = ConsoleColor.White;
        Clear();
        CriarLinha();
        ForegroundColor = ConsoleColor.Blue;
        WriteLine($" {titulo.ToUpper()}");
        ForegroundColor = ConsoleColor.White;
        CriarLinha();
    }

    public static void MenuPrincipal()
    {
        while (true) // Loop controlado para evitar recursão excessiva
        {
            CriarCabecalho("Loja Sapiens");
            WriteLine(" [1] Vendas");
            WriteLine(" [2] Clientes");
            WriteLine(" [3] Vendedores");
            WriteLine(" [4] Produtos");
            WriteLine("\n [9] Sair");
            CriarLinha();
            Write(" Escolha uma opção: ");
            var opcao = ReadLine();

            switch (opcao)
            {
                case "1":
                    MenuVenda();
                    break;
                case "2":
                    MenuCliente();
                    break;
                case "3":
                    MenuVendedor();
                    break;
                case "4":
                    MenuProduto();
                    break;
                case "9":
                    CriarCabecalho("Confirmar Saída");
                    WriteLine(" Deseja realmente sair? (S/N): ");
                    if (ReadLine()?.ToUpper() == "S")
                    {
                        LojaContext.Finalizar();
                        Clear();
                        CriarCabecalho("Obrigado por usar nosso sistema");
                        ReadKey();
                        Environment.Exit(0);
                    }
                    break;
                default:
                    WriteLine(" Opção inválida. Tente novamente.");
                    Write(" [Enter] para continuar... ");
                    ReadLine();
                    break;
            }
        }
    }

    public static void MenuVendedor()
    {
        while (true)
        {
            CriarCabecalho("Loja Sapiens - Vendedores");
            WriteLine(" [1] Cadastrar");
            WriteLine(" [2] Listar");
            WriteLine(" [3] Editar");
            WriteLine(" [4] Excluir");
            WriteLine("\n [Enter] Menu Principal");
            CriarLinha();
            Write(" Escolha uma opção: ");
            var opcao = ReadLine();

            switch (opcao)
            {
                case "1":
                    try { VendedorHelper.Cadastrar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "2":
                    try { VendedorHelper.Listar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "3":
                    try { VendedorHelper.Editar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "4":
                    try { VendedorHelper.Excluir(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "":
                    return; // Volta ao MenuPrincipal
                default:
                    WriteLine(" Opção inválida. Tente novamente.");
                    Write(" [Enter] para continuar... ");
                    ReadLine();
                    break;
            }
        }
    }

    public static void MenuVenda()
    {
        while (true)
        {
            CriarCabecalho("Loja Sapiens - Vendas");
            WriteLine(" [1] Cadastrar");
            WriteLine(" [2] Listar");
            WriteLine(" [3] Editar");
            WriteLine(" [4] Excluir");
            WriteLine("\n [Enter] Menu Principal");
            CriarLinha();
            Write(" Escolha uma opção: ");
            var opcao = ReadLine();

            switch (opcao)
            {
                case "1":
                    try { VendaHelper.Cadastrar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "2":
                    try { VendaHelper.Listar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "3":
                    try { VendaHelper.Editar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "4":
                    try { VendaHelper.Excluir(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "":
                    return; // Volta ao MenuPrincipal
                default:
                    WriteLine(" Opção inválida. Tente novamente.");
                    Write(" [Enter] para continuar... ");
                    ReadLine();
                    break;
            }
        }
    }

    public static void MenuProduto()
    {
        while (true)
        {
            CriarCabecalho("Loja Sapiens - Produtos");
            WriteLine(" [1] Cadastrar");
            WriteLine(" [2] Listar");
            WriteLine(" [3] Editar");
            WriteLine(" [4] Excluir");
            WriteLine("\n [Enter] Menu Principal");
            CriarLinha();
            Write(" Escolha uma opção: ");
            var opcao = ReadLine();

            switch (opcao)
            {
                case "1":
                    try { ProdutoHelper.Cadastrar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "2":
                    try { ProdutoHelper.Listar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "3":
                    try { ProdutoHelper.Editar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "4":
                    try { ProdutoHelper.Excluir(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "":
                    return; // Volta ao MenuPrincipal
                default:
                    WriteLine(" Opção inválida. Tente novamente.");
                    Write(" [Enter] para continuar... ");
                    ReadLine();
                    break;
            }
        }
    }

    public static void MenuCliente()
    {
        while (true)
        {
            CriarCabecalho("Loja Sapiens - Clientes");
            WriteLine(" [1] Cadastrar");
            WriteLine(" [2] Listar");
            WriteLine(" [3] Editar");
            WriteLine(" [4] Excluir");
            WriteLine("\n [Enter] Menu Principal");
            CriarLinha();
            Write(" Escolha uma opção: ");
            var opcao = ReadLine();

            switch (opcao)
            {
                case "1":
                    try { ClienteHelper.Cadastrar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "2":
                    try { ClienteHelper.Listar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "3":
                    try { ClienteHelper.Editar(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "4":
                    try { ClienteHelper.Excluir(); } catch (Exception ex) { WriteLine($"Erro: {ex.Message}"); }
                    break;
                case "":
                    return; // Volta ao MenuPrincipal
                default:
                    WriteLine(" Opção inválida. Tente novamente.");
                    Write(" [Enter] para continuar... ");
                    ReadLine();
                    break;
            }
        }
    }
}