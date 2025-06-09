using Loja.Shared.Models;
using System.Text.Json;

namespace Loja.Shared.Contexts;

public static class LojaContext
{
    public static List<Produto> Produtos { get; set; } = new();
    public static List<Cliente> Clientes { get; set; } = new();

    public static List<Vendedor> Vendedores { get; set; } = new();
    public static List<Venda> Vendas { get; set; } = new();


    public static void Inicializar()
    {
        // cria o diretório "Loja" dentro da pasta Documentos do usuário, se não existir
        Produtos.Recuperar();
        Clientes.Recuperar();
        Vendedores.Recuperar();
        Vendas.Recuperar();

    }

    public static void Finalizar()
    {
        // cria o diretório "Loja" dentro da pasta Documentos do usuário, se não existir
        Produtos.Salvar();
        Clientes.Salvar();
        Vendedores.Salvar();
        Vendas.Salvar();

    }

    public static void Listar()
    {
        // cria o diretório "Loja" dentro da pasta Documentos do usuário, se não existir
        Produtos.Recuperar();
        Clientes.Recuperar();
        Vendedores.Recuperar();
        Vendas.Recuperar();

    }


    public static void Salvar<T>(this List<T> lista)
    {
        // retorna o nome do tipo genérico T
        var tipo = typeof(T).Name;

        // diretório onde os arquivos serão salvos
        var pasta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // cria o diretório "Loja" dentro da pasta Documentos do usuário, se não existir
        if (!Directory.Exists(Path.Combine(pasta, "Loja")))
        {
            Directory.CreateDirectory(Path.Combine(pasta, "Loja"));
        }

        // o nome e caminho do arquivo que será salvo
        var arquivo = Path.Combine(pasta, "Loja", $"{tipo}.json");
        var opcoes = new JsonSerializerOptions { WriteIndented = true };

        // salvar o dados em json no arquivo
        var json = JsonSerializer.Serialize(lista, opcoes);
        File.WriteAllText(arquivo, json);

        // exibir mensagem de sucesso
        Console.WriteLine($"lista de {tipo} salvo com sucesso em {arquivo}");
    }

    public static void Recuperar<T>(this List<T> lista)
    {
        // retorna o nome do tipo genérico T
        var tipo = typeof(T).Name;

        // diretório onde os arquivos serão salvos
        var pasta = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // cria o diretório "Loja" dentro da pasta Documentos do usuário, se não existir
        if (!Directory.Exists(Path.Combine(pasta, "Loja")))
        {
            Directory.CreateDirectory(Path.Combine(pasta, "Loja"));
        }


        // o nome e caminho do arquivo que será salvo
        var arquivo = Path.Combine(pasta, "Loja", $"{tipo}.json");

       if (File.Exists(arquivo))
        {
            // ler o arquivo json e desserializar para a lista
            var json = File.ReadAllText(arquivo);
            var listaRecuperada = JsonSerializer.Deserialize<List<T>>(json);
            if (listaRecuperada != null)
            {
                lista.AddRange(listaRecuperada);
            }
        }

        // exibir mensagem de sucesso
        Console.WriteLine($"lista de {tipo} recuperada com sucesso de {arquivo}");
    }
}
