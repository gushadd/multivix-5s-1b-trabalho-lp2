using Gestor_de_Eventos.Models;

namespace Gestor_de_Eventos.Controllers;

public class SingletonDataController
{
    private static SingletonDataController? _instanciaGlobal;
    private static readonly object lockObject = new();

    private SingletonData singletonData = SingletonData.GetInstancia();
    private List<Evento> listaDeEventos;
    
    public SingletonDataController()
    {
        listaDeEventos = singletonData.ObterEventos();
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

    public void AdicionarEvento(Evento evento)
    {
        singletonData.AdicionarEvento(evento);
    }

    public List<Evento> BuscarEventosPorPeriodo(DateTime dataInicial, DateTime dataFinal) 
    {       
        List<Evento> eventosNoPeriodo = new();

        foreach (Evento evento in listaDeEventos)
        {
            if (evento.DataHoraInicio >= dataInicial && evento.DataHoraFinal <= dataFinal)
            {
                eventosNoPeriodo.Add(evento);
            }
        }
        return eventosNoPeriodo;
    }

    // Aqui, apenas a porção 'dd/MM/yyyy' das datas serão usadas
    public List<Evento> BuscarEventoPorData(DateTime data)
    {
        List<Evento> eventosNaData = new();

        foreach (Evento evento in listaDeEventos)
        {
            if (evento.DataHoraInicio.Date == data.Date)
            {
                eventosNaData.Add(evento);
            }
        }        
        return eventosNaData;
    }
}