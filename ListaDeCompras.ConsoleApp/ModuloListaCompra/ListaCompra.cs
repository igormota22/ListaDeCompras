using System;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloListaCompra;

public class ListaCompra : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataDeCriacao { get; } = DateTime.Now;
    public StatusLista Status { get; set; }

    public ListaCompra(string nome)
    {
        Nome = nome;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        ListaCompra listaCompraSelecionada = (ListaCompra)entidadeAtualizada;

        Nome = listaCompraSelecionada.Nome;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome))
        {
            erros += "O campo '/Nome/' é obrigatorio;";
        }
        else if (Nome.Length < 3 || Nome.Length > 100)
        {
            erros += "O nome deve ter entre 3 e 100 caracteres;";
        }

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }
}
