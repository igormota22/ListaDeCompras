using System;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloListaCompra;

public class RepositorioListaCompra : RepositorioBase<ListaCompra>
{
    public override bool VerificarValoresIguais(ListaCompra entidade)
    {
        throw new NotImplementedException();
    }
}
