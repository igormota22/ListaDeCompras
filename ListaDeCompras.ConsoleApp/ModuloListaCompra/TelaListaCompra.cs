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

        Console.WriteLine("{0,-7} | {1,-25} | {2,-12} | {3,-12} | {4,10} | {5, 10}",
       "ID", "Nome", "Data", "Status", "Qtd Itens", "Total");

        List<ListaCompra> listas = repositorio.SelecionarTodos();


        if (listas.Count == 0)
        {
            Console.WriteLine("Nenhuma lista cadastrada.");
            return;
        }

        foreach (ListaCompra l in listas)
        {
            Console.WriteLine("{0,-7} | {1,-25} | {2,-12} | {3,-12} | {4,10} | {5, 10}",
           l.Id,
           l.Nome,
           l.DataDeCriacao.ToShortDateString(),
           l.Status,
           l.ObterTotalItens(),
           l.CalcularValorTotal());
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

    protected override string ValidarExclusao(ListaCompra entidade)
    {
        if (entidade.Itens.Count > 0)
        {
            return "Não é possível excluir! Essa lista possui itens.";
        }
        return null;
    }
}
