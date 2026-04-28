using ListaDeCompras.ConsoleApp;
using ListaDeCompras.ConsoleApp.Compartilhado;

static class Program
{

    static void Main(string[] args)
    {
        Executar();
    }

    private static void Executar()
    {
        TelaPrincipal telaPrincipal = FabricaTela.CriarTelaPrincipal();
        while (true)
        {
            ITela telaSelecionada = telaPrincipal.ApresentarMenuPrincipal();
            if (telaSelecionada == null) break;

            while (true)
            {
                string opcao = telaSelecionada.ObterOpcaoMenu();
                if (opcao == "S") break;
                telaSelecionada.ExecutarOpcao(opcao);
            }
        }
    }

}