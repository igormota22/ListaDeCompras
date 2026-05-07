using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloItemLista;

namespace ListaDeCompras.ConsoleApp.ModuloListaCompra;

public class RepositorioListaCompra : RepositorioBase<ListaCompra>, IRepositorio<ListaCompra>
{
    public bool TemProdutosVinculados(string id)
    {
        return false;
    }

    public bool VerificarValoresIguais<T>(T novaEntidade) where T : EntidadeBase
    {
        return false;
    }
}