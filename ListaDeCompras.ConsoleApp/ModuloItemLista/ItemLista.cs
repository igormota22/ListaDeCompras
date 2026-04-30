using System;
using System.Security.Cryptography;
using ListaDeCompras.ConsoleApp.ModuloListaCompra;
using ListaDeCompras.ConsoleApp.ModuloProduto;

namespace ListaDeCompras.ConsoleApp.ModuloItemLista;

public class ItemLista
{
    public string Id {get;set;} = string.Empty;
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public ItemLista( Produto produto, int quantidade)
    {
         Id = Convert
       .ToHexString(RandomNumberGenerator.GetBytes(20))
       .ToLower()
       .Substring(0, 7);

        Produto = produto;
        Quantidade = quantidade;
    }

    public decimal CalcularValorDaLista()
    {
        if(Produto == null) return 0;

        
        decimal valorDaLista = Produto.Preco * Quantidade;
        return valorDaLista;
    }

    public string[] ValidarDados()
    {
        string erros = string.Empty;

        if(Produto == null)
        {
            erros += "O campo '/Produto/' é obrigatório;";
        }

        if(Quantidade <= 0)
        {
            erros += "Informe uma quantidade valida (postivo);";
        }

        return erros.Split(";", StringSplitOptions.RemoveEmptyEntries);
    }
}
