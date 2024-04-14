using Gestor_de_Eventos.Controllers;
using Gestor_de_Eventos.Views;

namespace Gestor_de_Eventos;

public class Program
{
    static void Main(string[] args)
    {
        SingletonDataController sdc = SingletonDataController.GetInstancia();

        ViewMenus.ExibeMensagemBoasVindas();
        int opcao = int.MinValue;

        while (!opcao.Equals(0))
        {
            string statusExecucao = null!;
            opcao = ViewMenus.ObtemOpcoesMenuPrincipal();
            switch (opcao)
            {
                case 1:
                    statusExecucao = sdc.AdicionarEvento();
                    break;
                case 2:
                    Console.WriteLine("");
                    break;
                case 3:
                    statusExecucao = sdc.EditaEvento(ViewMenus.ObtemOpcoesIdEvento(), ViewMenus.ObtemOpcoesEditarEvento());
                    break;
                case 4:
                    sdc.ExcluiEventoPorId(ViewMenus.ObtemOpcoesIdEvento());
                    break;
                case 5:
                    Console.WriteLine("Em construção");
                    break;
                default:
                    Console.WriteLine("Opção digitada não é valida!");
                    break;
            }
        }
    }
}
