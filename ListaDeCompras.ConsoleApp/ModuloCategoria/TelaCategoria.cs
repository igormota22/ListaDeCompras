
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class TelaCategoria : TelaBase<Categoria>
{
    private RepositorioProduto repoProduto;

    public TelaCategoria(RepositorioBase<Categoria> repositorio, RepositorioProduto repoProduto) : base("Categoria", repositorio)
    {
        this.repoProduto = repoProduto;
    }

    public override void Visualizar(bool deveApresentar)
    {
        if (deveApresentar)

            ObterCabecalho("visualizar categorias ");

        Console.WriteLine(
           "{0, -7} | {1, -20} | {2, -10}",
           "Id", "Nome", "Cor"
       );

        List<Categoria> categorias = repositorio.SelecionarTodos();


        if (categorias.Count == 0)
        {
            Console.WriteLine("Nenhuma categoria cadastrada.");
            return;
        }

        foreach (Categoria c in categorias)
        {
            Console.WriteLine("{0,-7} | {1,-20} | {2,-10}", c.Id, c.Nome, c.Cor);
        }


        if (deveApresentar)
        {

            System.Console.WriteLine("--------------------------------------");
            System.Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }


    }


    protected override Categoria ObterDadosCadastrais()
    {
        System.Console.Write("Digite o nome da categoria: ");
        string nome = Console.ReadLine() ?? string.Empty;

        System.Console.WriteLine("Selecione uma cor valida");
        System.Console.WriteLine("-------------------------------------------");
        System.Console.WriteLine("1 - Vermelho");
        System.Console.WriteLine("2 - Verde");
        System.Console.WriteLine("3 - Branco");
        System.Console.Write("Digite a opção:");
        string opcaoCor = Console.ReadLine() ?? string.Empty;

        string cor;

        if (opcaoCor == "1")
        {
            cor = "Vermelho";
        }
        else if (opcaoCor == "2")
        {
            cor = "Verde";
        }
        else
        {
            cor = "Branco";
        }

        return new Categoria(nome, cor);
    }

    protected override string ExibirMensagemDeValorIgual()
    {
        return "Ja existe uma categoria com esse nome";
    }

    protected override string ValidarExclusao(Categoria entidade)
    {
        if (repoProduto.TemProdutosVinculados(entidade.Id))
            return "Não é possível excluir. Categoria possui produtos!";

        return null;
    }



}
