using System;
using System.Collections;
using ListaDeCompras.ConsoleApp.Compartilhado;


namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class RepositorioCategoria : RepositorioBase
{
    public override bool VerificarValoresIguais(EntidadeBase entidade)
    {
        Categoria novaCategoria = (Categoria)entidade;
        ArrayList categorias = SelecionarTodos();

        foreach (Categoria categoria in categorias)
        {
            if (categoria.Nome.Equals(novaCategoria.Nome, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }
}
