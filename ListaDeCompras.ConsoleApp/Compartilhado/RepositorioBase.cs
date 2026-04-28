using System;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase
{
    protected EntidadeBase?[] registros = new EntidadeBase[100];

    public void Cadastrar(EntidadeBase novaEntidade)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaEntidade;
                break;
            }
        }
    }

    public bool Editar(string idSelecionado, EntidadeBase novaEntidade)
    {
        EntidadeBase? EntidadeSelecionada = SelecionarPorId(idSelecionado);

        if (EntidadeSelecionada == null)
        {
            return false;

        }


        EntidadeSelecionada.AtualizarDados(novaEntidade);

        return true;
    }


    public EntidadeBase? SelecionarPorId(string idSelecionado)
    {
        EntidadeBase? EntidadeSelecionada = null;

        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase? c = registros[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                EntidadeSelecionada = c;
                break;
            }
        }

        return EntidadeSelecionada;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase? c = registros[i];

            if (c == null)
            {
                continue;
            }

            if (c.Id == idSelecionado)
            {
                registros[i] = null;
                return true;
            }
        }

        return false;
    }

    public EntidadeBase[]? SelecionarTodos()
    {
        return registros;
    }

    public abstract bool VerificarValoresIguais(EntidadeBase entidade);
}
