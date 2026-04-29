using System;
using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.ModuloCategoria;

namespace ListaDeCompras.ConsoleApp.ModuloProduto;

public class Produto : EntidadeBase
{

    public string Nome { get; private set; }
    public Categoria Categoria { get; set; }
    public string Unidade { get; set; }
    public decimal Preco { get; set; }

    public Produto(string nome, string unidade, decimal preco, Categoria categoria)
    {
        Nome = nome;
        Categoria = categoria;
        Unidade = unidade;
        Preco = preco;
    }

    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Produto produtoAtualizado = (Produto)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Unidade = produtoAtualizado.Unidade;
        Preco = produtoAtualizado.Preco;
        Categoria = produtoAtualizado.Categoria;


    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length == 0 || Nome.Length > 100)
        {
            erros += "O campo '/Nome/' deve conter entre 0 e 100 caracteres;";
        }

        if (Categoria == null)
        {
            erros += "O campo '/Categoria/' é obrigatório;";
        }

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }
}
