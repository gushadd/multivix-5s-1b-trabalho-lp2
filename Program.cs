using Gestor_de_Eventos.Controllers;
using Gestor_de_Eventos.Views;

namespace Gestor_de_Eventos;

public class Program
{
    static void Main(string[] args)
    {
        SingletonDataController sdc = SingletonDataController.GetInstancia();
        SingletonViewController svc = SingletonViewController.GetInstancia();

        ViewMenus.ExibeMensagemBoasVindas();
        int opcao = int.MinValue;

        while (!opcao.Equals(0))
        {
            string statusExecucao = null!;
            opcao = ViewMenus.ObtemOpcoesMenuPrincipal();
            switch (opcao)
            {
                case 0:
                    Console.WriteLine("Obrigado por usar nosso gerenciador de eventos!");
                    Console.Write("Pressione qualquer tecla para sair ...");
                    Console.ReadKey();
                    break;
                case 1:
                    statusExecucao = sdc.AdicionarEvento();
                    Console.WriteLine(statusExecucao);
                    break;
                case 2:
                    svc.ObtemMenuPesquisa();
                    break;
                case 3:
                    statusExecucao = svc.ObtemMenuEditarEvento();
                    Console.WriteLine(statusExecucao);
                    break;
                case 4:
                    statusExecucao = sdc.ExcluiEventoPorId(ViewMenus.ObtemOpcoesIdEvento());
                    Console.WriteLine(statusExecucao);
                    break;
                case 5:
                    statusExecucao = svc.ObtemMenuExportarEvento();
                    Console.WriteLine(statusExecucao);
                    break;
                default:
                    Console.WriteLine("Opção digitada não é valida!");
                    break;
            }
        }
    }
}
