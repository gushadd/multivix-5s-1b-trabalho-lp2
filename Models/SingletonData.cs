namespace Gestor_de_Eventos.Models;

public sealed class SingletonData
{
    private static SingletonData? _instanciaGlobal;

    //Esse objeto será usado para sincronizar o acesso à criação da instância do Singleton,
    //garantindo que apenas uma thread por vez possa executar a seção crítica do código.
    private static readonly object lockObject = new();

    private List<Evento> Eventos;

    private SingletonData() 
    {
        if (Eventos == null)
        {
            Eventos = new();
        }
    }

    public static SingletonData GetInstance()
    {
        lock (lockObject)
        {
            if (_instanciaGlobal == null)
            {
                _instanciaGlobal = new SingletonData();
            }
        }
        return _instanciaGlobal;
    }

    public Evento GetEvento(String idEvento)
    {
        Evento evento = null;
        foreach (var e in Eventos)
        {
            if (idEvento.Equals(e.Id))
            {
                evento = e;
            }
            break;
        }

        return evento == null ? throw new Exception ("Nenhum evento encontrado com o id fornecido") : evento;
    }

    public void AdicionarEvento(Evento evento)
    {
        Eventos.Add(evento);
    }

    public void ExcluirEventoPorId(String idEvento)
    {
        foreach (var evento in Eventos)
        {
            if (idEvento.Equals(evento.Id))
            {
                Eventos.Remove(evento);
            }
        }
    }

    public void EditarEvento(String idEvento, String titulo, DateTime dataHoraInicio, DateTime dataHoraFinal, String descricao, int quantidadeAproximadaPessoas, int quantidadePrevistaPessoas, String publicoAlvo)
    {

    }

    public void EditarContatoEvento(String idEvento)
    {

    }
}
