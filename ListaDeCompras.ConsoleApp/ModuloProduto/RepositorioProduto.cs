using System;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class RepositorioProduto : RepositorioBase<Produto>
{
    public override bool VerificarValoresIguais(Produto entidade)
    {
        Produto novoProduto = (Produto)entidade;
        List<Produto> produtos = SelecionarTodos();

        foreach (Produto produto in produtos)
        {
            if (produto.Nome.Equals(novoProduto.Nome, StringComparison.OrdinalIgnoreCase) && produto.Categoria == novoProduto.Categoria)
                return true;
        }
        return false;
    }

    public bool TemProdutosVinculados(string idCategoria)
    {
        List<Produto> produtos = SelecionarTodos();

        foreach (Produto p in produtos)
        {
            if (p.Categoria != null && p.Categoria.Id == idCategoria)
            {
                return true;
            }
        }

        return false;
    }
}
