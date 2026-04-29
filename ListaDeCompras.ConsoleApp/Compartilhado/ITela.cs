using System;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public interface ITela
{
    string ObterOpcaoMenu();
    void ExecutarOpcao(string opcao);
   
}
