using System;

namespace ListaDeCompras.ConsoleApp.Compartilhado.Arquivo;

public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase
{
    protected List<T> registros;
    protected ContextoJson contexto;

    public RepositorioBaseEmArquivo(ContextoJson contexto)
    {
        this.contexto = contexto;
        this.registros = CarregarRegistros();
    }

    protected abstract List<T>? CarregarRegistros();

    public void Cadastrar(T novaEntidade)
    {
        registros.Add(novaEntidade);
        contexto.Salvar();
    }

    public bool Editar(string idSelecionado, T novaEntidade)
    {
        T? EntidadeSelecionada = SelecionarPorId(idSelecionado);

        if (EntidadeSelecionada == null)
        {
            return false;

        }


        EntidadeSelecionada.AtualizarDados(novaEntidade);

        contexto.Salvar();


        return true;

    }


    public T? SelecionarPorId(string idSelecionado)
    {
        foreach (T registro in registros)
        {
            if (registro.Id == idSelecionado)
            {
                return registro;
            }
        }
        return null;

    }

    public bool Excluir(string idSelecionado)
    {

        T? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
        {
            return false;
        }
        registros.Remove(registroSelecionado);

        contexto.Salvar();

        return true;
    }
    public List<T> SelecionarTodos()
    {
        return registros;
    }

    public virtual bool VerificarValoresIguais(T entidade)
    {
        return false;
    }

}
