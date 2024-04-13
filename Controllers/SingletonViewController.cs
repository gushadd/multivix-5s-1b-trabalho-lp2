using Gestor_de_Eventos.Views;

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
        string entradaDataInicial = Console.ReadLine()!;

        Console.Write("\nDigite a data final: ");
        string entradaDataFinal = Console.ReadLine()!;

        DateTime dataInicial = DateTime.Parse(entradaDataInicial);
        DateTime dataFinal = DateTime.Parse(entradaDataFinal);

        ViewData.ExibeEvento(singletonDataController.BuscaEventosPorPeriodo(dataInicial, dataFinal));
    }

    public void BuscaEExibeEventosPorData ()
    {
        Console.Write("Digite a data: ");
        string entradaData = Console.ReadLine()!;

        DateTime data = DateTime.Parse(entradaData);

        ViewData.ExibeEvento(singletonDataController.BuscaEventoPorData(data));
    }

    public void BuscaEExibeContato()
    {
        Console.Write("Digite o nome do contato a ser pesquisado: ");
        string nome = Console.ReadLine()!;

        ViewData.ExibeContato(singletonDataController.BuscaContato(nome));  
    }
}
