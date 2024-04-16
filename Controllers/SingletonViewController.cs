using Gestor_de_Eventos.Views;
using Gestor_de_Eventos.Util.Input;
using Gestor_de_Eventos.Util.Patterns;

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

    public void ObtemOpcoesMenuPesquisa()
    {
        int opcao = int.MinValue;

        while (!opcao.Equals(0))
        {
            opcao = ViewMenus.ObtemOpcoesMenuListarEventos();
            switch (opcao)
            {
                case 0:
                    break;
                case 1:
                    BuscaEExibeEventosPorPeriodo();
                    break;
                case 2:
                    BuscaEExibeEventosPorData();
                    break;
                case 3:
                    BuscaEExibeContato();
                    break;
                default:
                    Console.WriteLine("Opção digitada não é valida!");
                    break;
            }
        }
    }

    public void BuscaEExibeEventosPorPeriodo()
    {
        Console.WriteLine("Digite a data inicial");
        DateTime dataInicial = DateTime.ParseExact(Teclado.CapturaDataDigitada().ToString(), ValidationPatterns.MascaraDataBrasileira, null);

        Console.WriteLine("Digite a data final");
        DateTime dataFinal = DateTime.ParseExact(Teclado.CapturaDataDigitada().ToString(), ValidationPatterns.MascaraDataBrasileira, null);

        ViewData.ExibeListaDeEventos(singletonDataController.BuscaEventosPorPeriodo(dataInicial, dataFinal));
    }

    public void BuscaEExibeEventosPorData ()
    {
        Console.WriteLine("Digite a data");
        DateTime data = DateTime.ParseExact(Teclado.CapturaDataDigitada().ToString(), ValidationPatterns.MascaraDataBrasileira, null);

        ViewData.ExibeListaDeEventos(singletonDataController.BuscaEventoPorData(data));
    }

    public void BuscaEExibeContato()
    {
        Console.WriteLine("Digite o nome do contato a ser pesquisado");
        string nome = Teclado.CapturaStringDigitada();
        string nomeEncontrado = singletonDataController.BuscaContato(nome).ToString();

        Console.WriteLine(nomeEncontrado == null ? "Nenhum contato encontrado!" : nomeEncontrado);
    }
}
