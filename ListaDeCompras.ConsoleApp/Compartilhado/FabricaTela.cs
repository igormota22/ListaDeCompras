using System;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public static class FabricaTela
{
    public static TelaPrincipal CriarTelaPrincipal()
    {
        RepositorioCategoria repositorioCategoria = new RepositorioCategoria();

        Categoria categoria = new Categoria("Higiene", "Vermelho");
        repositorioCategoria.Cadastrar(categoria);

        TelaCategoria telaCategoria = new TelaCategoria(repositorioCategoria);

        return new TelaPrincipal(telaCategoria);

    }
}
