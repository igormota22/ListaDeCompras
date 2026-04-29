
namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<T> where T : EntidadeBase
{
    protected List<T> registros = new List<T>();
    public void Cadastrar(T novaEntidade)
    {
        registros.Add(novaEntidade);
    }

    public bool Editar(string idSelecionado, T novaEntidade)
    {
        T? EntidadeSelecionada = SelecionarPorId(idSelecionado);

        if (EntidadeSelecionada == null)
        {
            return false;

        }


        EntidadeSelecionada.AtualizarDados(novaEntidade);

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

        return true;
    }
    public List<T> SelecionarTodos()
    {
        return registros;
    }

    public abstract bool VerificarValoresIguais(T entidade);

   
}
