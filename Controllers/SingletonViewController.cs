using Gestor_de_Eventos.Views;
using Gestor_de_Eventos.Util.Input;
using Gestor_de_Eventos.Util.Patterns;
using Gestor_de_Eventos.Util.Output;

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

    public void ObtemMenuPesquisa()
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

    public string ObtemMenuEditarEvento()
    {
        int opcao = int.MinValue;
        string statusExecucao = null!;

        while (!opcao.Equals(0))
        {
            string idEvento = null!;
            opcao = ViewMenus.ObtemOpcoesMenuEditarEvento();
            switch (opcao)
            {
                case 0:
                    statusExecucao = "Nenhum item foi editado";
                    break;
                case 1:
                    idEvento = ViewMenus.ObtemOpcoesIdEvento();
                    if (singletonDataController.VerificaExistenciaId(idEvento))
                    {
                        statusExecucao = singletonDataController.EditaEvento(idEvento, ViewMenus.ObtemOpcoesEditarEvento());
                    } else
                    {
                        Console.WriteLine($"Nenhum evento encontrado com o id {idEvento}");
                    }
                    break;
                case 2:
                    idEvento = ViewMenus.ObtemOpcoesIdEvento();
                    if (singletonDataController.VerificaExistenciaId(idEvento))
                    {
                        statusExecucao = singletonDataController.EditaContatoEvento(idEvento, ViewMenus.ObtemOpcoesEditarContato());
                    }
                    else
                    {
                        Console.WriteLine($"Nenhum evento encontrado com o id {idEvento}");
                    }
                    break;
                default:
                    Console.WriteLine("Opção digitada não é valida");
                    break;
            }
        }

        return statusExecucao;
    }

    public string ObtemMenuExportarEvento()
    {
        string idEvento = ViewMenus.ObtemOpcoesIdEvento();

        if (!singletonDataController.VerificaExistenciaId(idEvento))
        {
            return $"Nenhum evento encontrado com o id {idEvento}";
        }

        ExportarEventos.SalvarArquivoTxt(singletonDataController.GetEvento(idEvento));

        return "Evento exportado com sucesso!";
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
