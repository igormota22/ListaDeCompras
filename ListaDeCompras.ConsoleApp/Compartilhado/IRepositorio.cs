using System;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public interface IRepositorio<T>
{
    public void Cadastrar(T novaEntidade);
    public bool Editar(string idSelecionado, T novaEntidade);
    public T? SelecionarPorId(string idSelecionado);
    public bool Excluir(string idSelecionado);
    public List<T> SelecionarTodos();
    bool TemProdutosVinculados(string id);
    bool VerificarValoresIguais(T novaEntidade);
}
