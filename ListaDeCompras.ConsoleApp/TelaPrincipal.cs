using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp;

public class TelaPrincipal : ITela
{
    private TelaCategoria telaCategoria;

    public TelaPrincipal(TelaCategoria telaCategoria)
    {
        this.telaCategoria = telaCategoria;
    }

    public ITela ApresentarMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Lista De Compras");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos ");
        Console.WriteLine("3 - Gerenciar item de lista de compras");
        Console.WriteLine("4 - Gerenciar lista de compras ");
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
            return null;
        }
        else if (opcaoMenuPrincipal == "3")
        {
            return null;
        }
        else if (opcaoMenuPrincipal == "4")
        {
            return null;
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
