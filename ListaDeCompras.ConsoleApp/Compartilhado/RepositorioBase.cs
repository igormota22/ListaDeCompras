using System.Collections;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase
{
    protected ArrayList registros = new ArrayList();

    public void Cadastrar(EntidadeBase novaEntidade)
    {
       registros.Add(novaEntidade);
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
        foreach (EntidadeBase registro in registros)
        {
            if(registro.Id == idSelecionado)
            {
                return registro;
            }
        }
        return null;

    }

    public bool Excluir(string idSelecionado)
    {

       EntidadeBase? registroSelecionado = SelecionarPorId(idSelecionado);

       if(registroSelecionado.Id == idSelecionado)
        {
            registros.Remove(registroSelecionado);
            return true;
        }

        return false;
    }
    public ArrayList SelecionarTodos()
    {
        return registros;
    }

     public abstract bool VerificarValoresIguais(EntidadeBase entidade);

}
