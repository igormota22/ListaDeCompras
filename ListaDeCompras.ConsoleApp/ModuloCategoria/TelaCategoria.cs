
using System.Collections;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class TelaCategoria : TelaBase
{
    public TelaCategoria(RepositorioCategoria repositorioCategoria) : base("Categoria", repositorioCategoria)
    {

    }

    

    public override void Visualizar(bool deveApresentar)
    {
        if (deveApresentar)

            ObterCabecalho("visualizar categorias ");

        Console.WriteLine(
           "{0, -7} | {1, -20} | {2, -10}",
           "Id", "Nome", "Cor"
       );

        ArrayList categorias = repositorio.SelecionarTodos();


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


    protected override EntidadeBase ObterDadosCadastrais()
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

    public override string ExibirMensagemDeValorIgual()
    {
        return "Ja existe uma categoria com esse nome";
    }

}
