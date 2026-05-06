using System;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloItemLista;
using ListaDeCompras.ConsoleApp.ModuloListaCompra;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public static class FabricaTela
{
    public static TelaPrincipal CriarTelaPrincipal()
    {
        RepositorioCategoria repositorioCategoria = new RepositorioCategoria();
        RepositorioProduto repositorioProduto = new RepositorioProduto();
        RepositorioListaCompra repositorioListaCompra = new RepositorioListaCompra();

        TelaCategoria telaCategoria = new TelaCategoria(repositorioCategoria, repositorioProduto);
        TelaProduto telaProduto = new TelaProduto(repositorioProduto, repositorioCategoria);
        TelaListaCompra telaListaCompra = new TelaListaCompra(repositorioListaCompra, repositorioProduto);

        return new TelaPrincipal(telaCategoria, telaProduto, telaListaCompra);

    }
}
