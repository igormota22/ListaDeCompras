using System;
using System.Reflection;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloItemLista;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloListaCompra;

public class TelaListaCompra : TelaBase<ListaCompra>
{
    private IRepositorio<Produto> repositorioProduto;
    public TelaListaCompra(IRepositorio<ListaCompra> repositorio, IRepositorio<Produto> repositorioProduto) : base("Lista de Compra", repositorio)
    {
        this.repositorioProduto = repositorioProduto;
    }

    public override void ExecutarOpcao(string opcao)
    {
        if (opcao == "1") Cadastrar();
        else if (opcao == "2") Editar();
        else if (opcao == "3") Excluir();
        else if (opcao == "4") Visualizar(true);
        else if (opcao == "5") Adicionar();
        else if (opcao == "6") Remover();

    }

    public override string ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão da lista de compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar lista de compras");
        Console.WriteLine("2 - Editar lista de compras");
        Console.WriteLine("3 - Excluir lista de compras");
        Console.WriteLine("4 - Visualizar listas de compras");
        Console.WriteLine("5 - Adicionar Item");
        Console.WriteLine("6 - Remover Item");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write(">");
        return Console.ReadLine()?.ToUpper() ?? "";
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
           l.CalcularValorTotal().ToString("C"));
        }

        System.Console.WriteLine("--------------------------------------------------------");


        if (deveApresentar)
        {
            Console.Write("Deseja visualizar os itens da lista [ENTER] Sim / [N] Não: ");
            ConsoleKeyInfo tecla = Console.ReadKey();

            if (tecla.Key == ConsoleKey.Enter)
            {
                VisualizarItems();
            }
        }
    }

    public void Adicionar()
    {
        ObterCabecalho("adicionar item a lista");

        ListaCompra listaSelecionada = SelecionarLista();
        if (listaSelecionada == null) return;

        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        if (produtos.Count == 0)
        {
            ExibirMensagem("Nenhum produto cadastrado!");
            return;
        }

        Console.WriteLine();


        Console.WriteLine("{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -15}",
     "Id", "Nome", "Unidade", "Preço", "Categoria");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var p in produtos)
        {
            Console.WriteLine("{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -15}",
                p.Id, p.Nome, p.Unidade, p.Preco, p.Categoria?.Nome);
        }
        Console.WriteLine("--------------------------------------------------------------------------");

        string? idProduto;

        do
        {
            System.Console.Write("Informe o id do produto ou pressione 'S' para sair : ");
            idProduto = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idProduto) && idProduto.Length == 7)
            {
                break;
            }

            if (idProduto.ToUpper() == "S")
            {
                return;
            }
        } while (true);

        Produto produtoSelecionado = repositorioProduto.SelecionarPorId(idProduto);
        if (produtoSelecionado == null)
        {
            ExibirMensagem("Produto não encontrado!");
            return;
        }

        Console.Write("Digite a quantidade: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade)) return;

        bool itemJaExiste = listaSelecionada.VerificarItemRepetido(produtoSelecionado);

        if (itemJaExiste == true)
        {
            ExibirMensagem("Item ja está na lista");
            return;
        }

        listaSelecionada.AdicionarItem(produtoSelecionado, quantidade);


        ExibirMensagem("Item adicionado!");


    }

    public void Remover()
    {
        ObterCabecalho("remover item a lista");

        ListaCompra listaSelecionada = SelecionarLista();
        if (listaSelecionada == null) return;

        List<Produto> produtos = repositorioProduto.SelecionarTodos();

        if (produtos.Count == 0)
        {
            ExibirMensagem("Nenhum produto cadastrado!");
            return;
        }

        Console.WriteLine();

        Console.WriteLine("{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -15}",
     "Id", "Nome", "Unidade", "Preço", "Categoria");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var p in produtos)
        {
            Console.WriteLine("{0, -7} | {1, -20} | {2, -10} | {3, -10} | {4, -15}",
                p.Id, p.Nome, p.Unidade, p.Preco, p.Categoria?.Nome);
        }
        Console.WriteLine("--------------------------------------------------------------------------");

        string idSelecionado;


        do
        {
            System.Console.Write("Informe o id do produto que deseja remover ou pressione 'S' para sair : ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            {
                break;
            }

            if (idSelecionado.ToUpper() == "S")
            {
                return;
            }
        } while (true);

        Produto produtoSelecionado = repositorioProduto.SelecionarPorId(idSelecionado);
        if (produtoSelecionado == null)
        {
            ExibirMensagem("Produto não encontrado!");
            return;
        }

        if (produtoSelecionado.Id == idSelecionado)
        {
            listaSelecionada.RemoverProduto(idSelecionado);

            ExibirMensagem("Item removido!");
        }
    }

    private void VisualizarItems()
    {
        ObterCabecalho("Visualizar items da lista");

        ListaCompra listaSelecionada = SelecionarLista();
        if (listaSelecionada == null) return;

        if (listaSelecionada.Itens.Count == 0)
        {
            Console.WriteLine("Lista vazia.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine();

        Console.WriteLine("{0, -8} | {1, -25} | {2, -20} | {3, -5} | {4, -12}",
            "Id", "Produto", "Categoria", "Qtd", "Preço Un", "Subtotal");
        Console.WriteLine("-------------------------------------------------------------------------------------------");

        foreach (var item in listaSelecionada.Itens)
        {
            decimal subtotal = item.CalcularSubtotal();
            Console.WriteLine("{0, -8} | {1, -25} | {2, -20} | {3, -5} | {4, -12:C2}",
                item.Id,
                item.Produto.Nome,
                item.Produto.Categoria?.Nome,
                item.Quantidade,
                item.Produto.Preco,
                subtotal);

        }

        Console.WriteLine("Pressione ENTER para continuar");
        Console.ReadLine();
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

    private ListaCompra SelecionarLista()
    {
        List<ListaCompra> listas = repositorio.SelecionarTodos();

        if (listas.Count == 0)
        {
            ExibirMensagem("Nenhuma lista de compras cadastrada! Crie uma primeiro.");
            return null;
        }

        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine("{0, -8} | {1, -25} | {2, -12} | {3, -12}", "Id", "Nome", "Abertura", "Status");
        Console.WriteLine("--------------------------------------------------------------");

        foreach (var l in listas)
        {
            Console.WriteLine("{0, -8} | {1, -25} | {2, -12} | {3, 12}", l.Id, l.Nome, l.DataDeCriacao.ToShortDateString(), l.Status);
        }
        Console.WriteLine("---------------------------------------------");

        Console.Write("Digite o ID da lista: ");
        string idLista = Console.ReadLine() ?? "";

        ListaCompra lista = repositorio.SelecionarPorId(idLista);
        if (lista == null)
            ExibirMensagem("Lista não encontrada!");

        return lista;
    }
}
