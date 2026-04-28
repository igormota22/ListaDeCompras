using System;
using System.Collections;
using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.ModuloCategoria;

public class Categoria : EntidadeBase
{

    public string Nome { get; private set; }
    public string Cor { get; private set; }

    public Categoria(string nome, string cor)
    {
        Nome = nome;
        Cor = cor;
    }


    public override void AtualizarDados(EntidadeBase entidadeAtualizada)
    {
        Categoria categoriaAtualizada = (Categoria)entidadeAtualizada;

        Nome = categoriaAtualizada.Nome;
        Cor = categoriaAtualizada.Cor;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (Nome.Length == 0 || Nome.Length > 50)
        {
            erros += "O campo '/Nome/' deve conter entre 0 e 50 caracteres;";
        }
        if (string.IsNullOrWhiteSpace(Cor))
        {
            erros += "O campo '/Cor/' deve ser preenchida;";
        }
        else if (Cor != "Vermelho" && Cor != "Verde" && Cor != "Branco")
        {
            erros += "A cor deve ser valida dentre as opcoes;";
        }

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }

    public static explicit operator Categoria(ArrayList v)
    {
        throw new NotImplementedException();
    }
}
