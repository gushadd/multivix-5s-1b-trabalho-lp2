using Gestor_de_Eventos.Models;

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

    public string AdicionaEvento(string id, string titulo, DateTime dataHoraInicio, DateTime dataHoraFinal, 
        string descricao, int quantidadeAproximadaPessoas, int quantidadePrevistaPessoas, string publicoAlvo, Contato contato)
    {
        try
        {
            Evento evento = new Evento(id, titulo, dataHoraInicio, dataHoraFinal, descricao, quantidadeAproximadaPessoas, quantidadePrevistaPessoas, publicoAlvo, contato);
            singletonData.AdicionarEvento(evento);

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

    public Contato BuscaContato(string nome)
    {
        Contato? contato = new();

        foreach (Evento evento in singletonData.ObterEventos())
        {
            if (evento.Contato.Nome == nome)
            {
                contato = evento.Contato;
                break;
            }
        }

        return contato;
    }


    public string EditaEvento(string idEvento, Dictionary<int, string> novasInformacoes)
    {
        try
        {
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
            singletonData.EditarContatoEvento(idEvento, novasInformacoes);
            return "Contato editado com sucesso";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}