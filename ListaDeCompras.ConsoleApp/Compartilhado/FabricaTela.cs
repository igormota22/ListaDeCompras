using System;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivo;
using ListaDeCompras.ConsoleApp.ModuloCategoria;
using ListaDeCompras.ConsoleApp.ModuloItemLista;
using ListaDeCompras.ConsoleApp.ModuloListaCompra;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public static class FabricaTela
{
    public static TelaPrincipal CriarTelaPrincipal()
    {
        ContextoJson contexto = new ContextoJson();
        contexto.Carregar();

        IRepositorio<Categoria> repositorioCategoria = new RepositorioCategoriaEmArquivo(contexto);
        IRepositorio<Produto> repositorioProduto = new RepositorioProdutoEmArquivo(contexto);
        IRepositorio<ListaCompra> repositorioListaCompra = new RepositorioListaCompraEmArquivo(contexto);

        TelaCategoria telaCategoria = new TelaCategoria(repositorioCategoria, repositorioProduto);
        TelaProduto telaProduto = new TelaProduto(repositorioProduto, repositorioCategoria);
        TelaListaCompra telaListaCompra = new TelaListaCompra(repositorioListaCompra, repositorioProduto);

        return new TelaPrincipal(telaCategoria, telaProduto, telaListaCompra);

    }
}
