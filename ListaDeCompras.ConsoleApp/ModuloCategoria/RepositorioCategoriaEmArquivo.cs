using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivo;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class RepositorioCategoriaEmArquivo : RepositorioBaseEmArquivo<Categoria>, IRepositorio<Categoria>
{
    public RepositorioCategoriaEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    public bool TemProdutosVinculados(string id)
    {
        return false;
    }

    public bool  VerificarValoresIguais(Categoria novaEntidade)
    {
         Categoria novaCategoria = (Categoria)novaEntidade;
        List<Categoria> categorias = SelecionarTodos();

        foreach (Categoria categoria in categorias)
        {
            if (categoria.Nome.Equals(novaCategoria.Nome, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    protected override List<Categoria>? CarregarRegistros()
    {
        return contexto.Categorias;
    }
}
