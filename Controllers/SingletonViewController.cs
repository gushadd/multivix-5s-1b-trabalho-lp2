using Gestor_de_Eventos.Views;
using Gestor_de_Eventos.Util;

namespace Gestor_de_Eventos.Controllers;

public class SingletonViewController
{
    private static SingletonViewController? _instanciaGlobal;
    private static readonly object lockObject = new();

    private SingletonDataController singletonDataController;

    private SingletonViewController()
    {
        singletonDataController = SingletonDataController.GetInstancia();
    }

    public static SingletonViewController GetInstancia()
    {
        lock (lockObject)
        {
            if (_instanciaGlobal == null)
            {
                _instanciaGlobal = new SingletonViewController();
            }
        }
        return _instanciaGlobal;
    }

    public void BuscaEExibeEventosPorPeriodo()
    {
        Console.Write("Digite a data inicial: ");
        DateTime dataInicial = Teclado.CapturaDataHoraDigitada();

        Console.Write("\nDigite a data final: ");
        DateTime dataFinal = Teclado.CapturaDataHoraDigitada();

        ViewData.ExibeEvento(singletonDataController.BuscaEventosPorPeriodo(dataInicial, dataFinal));
    }

    public void BuscaEExibeEventosPorData ()
    {
        Console.Write("Digite a data: ");
        DateTime data = Teclado.CapturaDataHoraDigitada();

        ViewData.ExibeEvento(singletonDataController.BuscaEventoPorData(data));
    }

    public void BuscaEExibeContato()
    {
        Console.Write("Digite o nome do contato a ser pesquisado: ");
        string nome = Teclado.CapturaStringDigitada();

        ViewData.ExibeContato(singletonDataController.BuscaContato(nome));  
    }
}
