using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivo;

namespace ListaDeCompras.ConsoleApp.ModuloListaCompra;

public class RepositorioListaCompraEmArquivo : RepositorioBaseEmArquivo<ListaCompra>, IRepositorio<ListaCompra>
{
    public RepositorioListaCompraEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    public bool TemProdutosVinculados(string id)
    {
        throw new NotImplementedException();
    }

    public bool VerificarValoresIguais<T>(T novaEntidade) where T : EntidadeBase
    {
        throw new NotImplementedException();
    }

    protected override List<ListaCompra>? CarregarRegistros()
    {
        return contexto.ListaCompras;
    }
}
