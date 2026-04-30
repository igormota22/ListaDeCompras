
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloItemLista;
using ListaDeCompras.ConsoleApp.ModuloListaCompra;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp;

public class TelaPrincipal : ITela
{
    private TelaCategoria telaCategoria;

    private TelaProduto telaProduto;

    private TelaListaCompra telaListaCompra;

    private TelaItemLista<ItemLista> telaItemLista;

    public TelaPrincipal(TelaCategoria telaCategoria, TelaProduto telaProduto, TelaListaCompra telaListaCompra, TelaItemLista<ItemLista> telaItemLista)
    {
        this.telaCategoria = telaCategoria;
        this.telaProduto = telaProduto;
        this.telaListaCompra = telaListaCompra;
        this.telaItemLista = telaItemLista;
    }

    public ITela ApresentarMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista De Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos ");
        Console.WriteLine("3 - Gerenciar listas de compras");
        Console.WriteLine("4 - Gerenciar items de lista de compras ");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
        {
            return telaCategoria;
        }
        else if (opcaoMenuPrincipal == "2")
        {
            return telaProduto;
        }
        else if (opcaoMenuPrincipal == "3")
        {
            return telaListaCompra;
        }
        else if (opcaoMenuPrincipal == "4")
        {
            return telaItemLista;
        }
        else
        {
            return null;
        }

    }

    public void ExecutarOpcao(string opcao)
    {
        throw new NotImplementedException();
    }

    public string ObterOpcaoMenu()
    {
        throw new NotImplementedException();
    }
}
