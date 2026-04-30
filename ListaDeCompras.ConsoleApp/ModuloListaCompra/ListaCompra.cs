using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloItemLista;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloListaCompra;

public class ListaCompra : EntidadeBase
{
    public string Nome { get; private set; }
    public DateTime DataDeCriacao { get; } = DateTime.Now;
    public StatusLista Status { get; set; }
    public List<ItemLista> Itens { get; set; } = new List<ItemLista>();

    public ListaCompra(string nome)
    {
        Nome = nome;
    }

    public void AdicionarItem(Produto produto, int quantidade)
    {
        for (int i = 0; i < Itens.Count; i++)
        {
            if (Itens[i].Produto.Id == produto.Id)
            {
                Itens[i].Quantidade += quantidade;
                return;
            }
        }

        ItemLista novoItem = new ItemLista(produto, quantidade);
        Itens.Add(novoItem);
    }

    public void RemoverProduto(string idProduto)
    {
        for (int i = Itens.Count - 1; i >= 0; i--)
        {
            if (Itens[i].Produto.Id == idProduto)
            {
                Itens.RemoveAt(i);
                return;
            }
        }
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
