using System;
using System.Collections;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloProduto;


namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class RepositorioCategoria : RepositorioBase<Categoria>
{
    public override bool VerificarValoresIguais(Categoria entidade)
    {
        Categoria novaCategoria = (Categoria)entidade;
        List<Categoria> categorias = SelecionarTodos();

        foreach (Categoria categoria in categorias)
        {
            if (categoria.Nome.Equals(novaCategoria.Nome, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }
}




