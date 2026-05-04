using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloListaCompra;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloItemLista;

public class TelaItemLista<T> : ITela where T : ItemLista
{
    private RepositorioProduto repositorioProduto;
    private RepositorioListaCompra repositorioListaCompra;

    public TelaItemLista(RepositorioProduto repositorioProduto, RepositorioListaCompra repositorioListaCompra)
    {
        this.repositorioProduto = repositorioProduto;
        this.repositorioListaCompra = repositorioListaCompra;
    }


    public void ExecutarOpcao(string opcao)
    {
        if (opcao == "1") Adicionar();
        else if (opcao == "2") Remover();
        else if (opcao == "3") Visualizar();
    }

    public string ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de itens");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Adicionar Item");
        Console.WriteLine("2 - Remover Item");
        Console.WriteLine("3 - Visualizar Itens");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write(">");
        return Console.ReadLine()?.ToUpper() ?? "";
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


    public void Visualizar()
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

    private ListaCompra SelecionarLista()
    {
        List<ListaCompra> listas = repositorioListaCompra.SelecionarTodos();

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

        ListaCompra lista = repositorioListaCompra.SelecionarPorId(idLista);
        if (lista == null)
            ExibirMensagem("Lista não encontrada!");

        return lista;
    }

    private void ObterCabecalho(string cabecalho)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine(cabecalho);
        Console.WriteLine("---------------------------------");
    }

    private void ExibirMensagem(string mensagem)
    {
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine(mensagem);
        System.Console.WriteLine("--------------------------------");
        System.Console.WriteLine("Digite ENTER para continuar");
        Console.ReadLine();
    }



}
