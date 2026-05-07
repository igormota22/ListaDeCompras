using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivo;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class RepositorioProdutoEmArquivo : RepositorioBaseEmArquivo<Produto>, IRepositorio<Produto>
{
    public RepositorioProdutoEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    public bool TemProdutosVinculados(string id)
    {
        List<Produto> produtos = SelecionarTodos();

        foreach (Produto p in produtos)
        {
            if (p.Categoria != null && p.Categoria.Id == id)
            {
                return true;
            }
        }

        return false;
    }

    public bool VerificarValoresIguais(Produto novaEntidade)
    {
        Produto novoProduto = (Produto)novaEntidade;
        List<Produto> produtos = SelecionarTodos();

        foreach (Produto produto in produtos)
        {
            if (produto.Nome.Equals(novoProduto.Nome, StringComparison.OrdinalIgnoreCase) && produto.Categoria == novoProduto.Categoria)
                return true;
        }
        return false;
    }

    protected override List<Produto>? CarregarRegistros()
    {
        return contexto.Produtos;
    }
}
