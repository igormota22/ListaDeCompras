using System;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloListaCompra;

public class TelaListaCompra : TelaBase<ListaCompra>
{
    public TelaListaCompra(RepositorioBase<ListaCompra> repositorio) : base("Lista de Compra", repositorio)
    {
    }

    public override void Visualizar(bool deveApresentar)
    {
        if (deveApresentar)

            ObterCabecalho("visualizar listas ");

        Console.WriteLine(
           "{0, -7} | {1, -20} | {2, -10} | {3, -10}",
           "Id", "Nome", "Abertura", "Status"
       );

        List<ListaCompra> listas = repositorio.SelecionarTodos();


        if (listas.Count == 0)
        {
            Console.WriteLine("Nenhuma lista cadastrada.");
            return;
        }

        foreach (ListaCompra l in listas)
        {
            Console.WriteLine("{0,-7} | {1,-20} | {2,-10} | {3, -10}", l.Id, l.Nome, l.DataDeCriacao.ToShortDateString(), l.Status);
        }


        if (deveApresentar)
        {

            System.Console.WriteLine("--------------------------------------");
            System.Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadLine();
        }

    }

    protected override ListaCompra ObterDadosCadastrais()
    {
        System.Console.Write("Informe o nome da lista: ");
        string nome = Console.ReadLine() ?? string.Empty;

        return new ListaCompra(nome);
    }
}
