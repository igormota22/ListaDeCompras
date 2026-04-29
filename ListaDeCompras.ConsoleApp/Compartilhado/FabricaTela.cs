using System;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
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


        Categoria categoria = new Categoria("Higiene", "Vermelho");
        repositorioCategoria.Cadastrar(categoria);

        Produto produto = new Produto("Sabao", "Kg", 30, categoria);
        repositorioProduto.Cadastrar(produto);

        ListaCompra listaCompra = new ListaCompra("Rancho");
        repositorioListaCompra.Cadastrar(listaCompra);

        TelaCategoria telaCategoria = new TelaCategoria(repositorioCategoria, repositorioProduto);
        TelaProduto telaProduto = new TelaProduto(repositorioProduto, repositorioCategoria);
        TelaListaCompra telaListaCompra = new TelaListaCompra(repositorioListaCompra);

        return new TelaPrincipal(telaCategoria, telaProduto, telaListaCompra);

    }
}
