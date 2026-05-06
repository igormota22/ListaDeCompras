using System;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivo;

namespace ListaDeCompras.ConsoleApp.ModuloListaCompra;

public class RepositorioListaCompraEmArquivo : RepositorioBaseEmArquivo<ListaCompra>
{
    public RepositorioListaCompraEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<ListaCompra>? CarregarRegistros()
    {
        return contexto.ListaCompras;
    }
}
