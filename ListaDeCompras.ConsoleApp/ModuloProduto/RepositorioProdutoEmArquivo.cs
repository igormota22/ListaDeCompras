using System;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivo;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class RepositorioProdutoEmArquivo : RepositorioBaseEmArquivo<Produto>
{
    public RepositorioProdutoEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Produto>? CarregarRegistros()
    {
        return contexto.Produtos;
    }
}
