using System;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public static class FabricaTela
{
    public static TelaPrincipal CriarTelaPrincipal()
    {
        RepositorioCategoria repositorioCategoria = new RepositorioCategoria();
        RepositorioProduto repositorioProduto = new RepositorioProduto();

        Categoria categoria = new Categoria("Higiene", "Vermelho");
        repositorioCategoria.Cadastrar(categoria);

        Produto produto = new Produto("Sabao", "Kg", 30, categoria);
        repositorioProduto.Cadastrar(produto);

        TelaCategoria telaCategoria = new TelaCategoria(repositorioCategoria, repositorioProduto);
        TelaProduto telaProduto = new TelaProduto(repositorioProduto, repositorioCategoria);

        return new TelaPrincipal(telaCategoria, telaProduto);

    }
}
