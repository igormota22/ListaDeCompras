using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class TelaProduto : TelaBase<Produto>
{

    private IRepositorio<Categoria> repositorioCategoria;

    public TelaProduto(IRepositorio<Produto> repositorio, IRepositorio<Categoria> repositorioCategoria) : base("Produto", repositorio)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void Visualizar(bool deveApresentar)
    {
        if (deveApresentar)

            ObterCabecalho("visualizar produtos ");

        Console.WriteLine(
     "{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -15}",
     "Id", "Nome", "Unidade", "Preço", "Categoria"
 );

        List<Produto> produtos = repositorio.SelecionarTodos();


        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhuma produto cadastrado.");
            return;
        }

        foreach (Produto p in produtos)
        {
            Console.WriteLine("{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -15}", p.Id, p.Nome, p.Unidade, p.Preco, p.Categoria.Nome);
        }


        if (deveApresentar)
        {

            System.Console.WriteLine("--------------------------------------");
            System.Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }
    }

    protected override Produto ObterDadosCadastrais()
    {
        System.Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine() ?? string.Empty;

        System.Console.Write("Digite a unidade de medida [Un, Kg, Cx, L]: ");
        string unidade = Console.ReadLine().ToUpper() ?? string.Empty;

        System.Console.Write("Digite o preço: R$ ");
        decimal preco;
        while (!decimal.TryParse(Console.ReadLine(), out preco) || preco < 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Valor inválido. Digite o preço: R$ ");
            Console.ResetColor();
        }

        VisualizarTodosCategorias();

        string idCategoria;

        do
        {
            System.Console.Write("Informe o id da categoria que deseja guardar o produto: ");
            idCategoria = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idCategoria) && idCategoria.Length == 7)
            {
                break;
            }
        } while (true);

        Categoria categoriaSelecionada = repositorioCategoria.SelecionarPorId(idCategoria);

        return new Produto(nome, unidade, preco, categoriaSelecionada);
    }

    protected override string ExibirMensagemDeValorIgual()
    {
        return "Ja existe um produto com este nome nessa categoria";
    }

    private void VisualizarTodosCategorias()
    {
        var categorias = repositorioCategoria.SelecionarTodos();
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("{0, -5} | {1, -25} | {2, -20}", "Id", "Nome", "Cor");
        Console.WriteLine("-----------------------------------------------------");
        foreach (var c in categorias)
            Console.WriteLine("{0, -5} | {1, -25} | {2, -20}", c.Id, c.Nome, c.Cor);
        Console.WriteLine("-----------------------------------------------------");
    }
}
