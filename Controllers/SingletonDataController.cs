using Gestor_de_Eventos.Models;
using Gestor_de_Eventos.Views;

namespace Gestor_de_Eventos.Controllers;

public class SingletonDataController
{
    private static SingletonDataController? _instanciaGlobal;
    private static readonly object lockObject = new();

    private SingletonData singletonData;

    private SingletonDataController()
    {
        singletonData = SingletonData.GetInstancia();
    }

    public static SingletonDataController GetInstancia()
    {
        lock (lockObject)
        {
            if (_instanciaGlobal == null)
            {
                _instanciaGlobal = new SingletonDataController();
            }
        }
        return _instanciaGlobal;
    }

    public string AdicionarEvento()
    {
        try
        {
            singletonData.AdicionarEvento(ViewMenus.ObtemOpcoesAdicionarEvento());

            return "Evento adicionado com sucesso!";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string ExcluiEventoPorId(string id)
    {
        try
        {
            singletonData.ExcluirEventoPorId(id);
            return "Evento excluido com sucesso!";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    // Aqui, apenas a porção 'dd/MM/yyyy' das datas serão usadas
    public List<Evento> BuscaEventosPorPeriodo(DateTime dataInicial, DateTime dataFinal)
    {
        List<Evento> eventosNoPeriodo = new();

        foreach (Evento evento in singletonData.ObterEventos())
        {
            if (evento.DataHoraInicio.Date >= dataInicial && evento.DataHoraFinal.Date <= dataFinal)
            {
                eventosNoPeriodo.Add(evento);
            }
        }
        return eventosNoPeriodo;
    }

    // Aqui, apenas a porção 'dd/MM/yyyy' das datas serão usadas
    public List<Evento> BuscaEventoPorData(DateTime data)
    {
        List<Evento> eventosNaData = new();

        foreach (Evento evento in singletonData.ObterEventos())
        {
            if (evento.DataHoraInicio.Date == data.Date)
            {
                eventosNaData.Add(evento);
            }
        }
        return eventosNaData;
    }

    public List<Evento> BuscaListaDeEventos()
    {
        return singletonData.ObterEventos();
    }

    public Contato BuscaContato(string nome)
    {
        Contato? contato = null;

        foreach (Evento evento in singletonData.ObterEventos())
        {
            if (evento.Contato!.Nome == nome)
            {
                contato = evento.Contato;
                break;
            }
        }

        return contato!;
    }

    public string EditaEvento(string idEvento, Dictionary<int, string> novasInformacoes)
    {
        try
        {
            if (novasInformacoes.Count == 0)
            {
                return "Saindo do modo de edição de evento ...";
            }

            singletonData.EditarEvento(idEvento, novasInformacoes);
            return "Evento editado com sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public string EditaContatoEvento(string idEvento, Dictionary<int, string> novasInformacoes)
    {
        try
        {
            if (novasInformacoes.Count == 0)
            {
                return "Saindo do modo de edição de contato ...";
            }

            singletonData.EditarContatoEvento(idEvento, novasInformacoes);
            return "Contato editado com sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public bool VerificaExistenciaId(string id)
    {
        return singletonData.GetIdsGerados().Contains(id);
    }

    public Evento GetEvento (string id)
    {
        return singletonData.GetEvento(id);
    }
    
    public bool VerificaListaDeEventosVazia()
    {
        if (singletonData.ObterEventos().Count == 0)
        {
            return true;
        }

        return false;
    }
}