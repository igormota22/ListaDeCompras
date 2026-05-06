using System;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivo;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class RepositorioCategoriaEmArquivo : RepositorioBaseEmArquivo<Categoria>
{
    public RepositorioCategoriaEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Categoria>? CarregarRegistros()
    {
        return contexto.Categorias;
    }
}
