namespace Gestor_de_Eventos.Models;

public sealed class SingletonData
{
    private static SingletonData? _instanciaGlobal;

    //Esse objeto será usado para sincronizar o acesso à criação da instância do Singleton,
    //garantindo que apenas uma thread por vez possa executar a seção crítica do código.
    private static readonly object lockObject = new();

    private List<Evento> eventos;

    private SingletonData() 
    {
        if (eventos == null)
        {
            eventos = new();
        }
    }

    public static SingletonData GetInstancia()
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
        foreach (var e in eventos)
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
        eventos.Add(evento);
    }

    public void ExcluirEventoPorId(String idEvento)
    {
        foreach (var evento in eventos)
        {
            if (idEvento.Equals(evento.Id))
            {
                eventos.Remove(evento);
            }
        }
    }

    //public void EditarEvento(String idEvento, String titulo, DateTime dataHoraInicio, DateTime dataHoraFinal, String descricao, int quantidadeAproximadaPessoas, int quantidadePrevistaPessoas, String publicoAlvo)
    //{

    //}

    // 'novasInformacoes' é um Dictionary, cuja 'key' armazena o nome da informação a ser editada (Descrição, Data etc.) e 
    // 'value' armazena o novo valor dessa informação
    public void EditarEvento(string idEvento, Dictionary<string, string> novasInformacoes)
    {
        int indiceEvento = eventos.FindIndex(e => e.Id == idEvento);
        if (indiceEvento == -1) throw new ArgumentException("Evento não encontrado");

        foreach(var novaInformacao in novasInformacoes)
        {
            switch (novaInformacao.Key)
            {
                case "Titulo":
                    eventos[indiceEvento].Titulo = novaInformacao.Value;
                    break;

                case "Data Inicial":
                    eventos[indiceEvento].DataHoraInicio = DateTime.Parse(novaInformacao.Value);
                    break;

                case "Data Final":
                    eventos[indiceEvento].DataHoraFinal = DateTime.Parse(novaInformacao.Value);
                    break;

                case "Descricao":
                    eventos[indiceEvento].Descricao = novaInformacao.Value;
                    break;

                case "Qtd Aprox Pessoas":
                    eventos[indiceEvento].QuantidadeAproximadaPessoas = Convert.ToInt32(novaInformacao.Value);
                    break;

                case "Qtd Prevista Pessoas":
                    eventos[indiceEvento].QuantidadePrevistaPessoas = Convert.ToInt32(novaInformacao.Value);
                    break;

                case "Público Alvo":
                    eventos[indiceEvento].PublicoAlvo = novaInformacao.Value;
                    break;               
            }
        }
    }

    public void EditarContatoEvento(string idEvento, Dictionary<string, string> novasInformacoes)
    {
        int indiceEvento = eventos.FindIndex(e => e.Id == idEvento);
        if (indiceEvento == -1) throw new ArgumentException("Evento não encontrado");

        foreach(var novaInformacao in novasInformacoes)
        {
            switch(novaInformacao.Key)
            {
                case "Cpf":
                    eventos[indiceEvento].Contato.Cpf = novaInformacao.Value;
                    break;
                case "Nome":
                    eventos[indiceEvento].Contato.Nome = novaInformacao.Value;
                    break;
                case "Telefone":
                    eventos[indiceEvento].Contato.Telefone = novaInformacao.Value;
                    break;
                case "Email":
                    eventos[indiceEvento].Contato.Email = novaInformacao.Value;
                    break;
            }
        }
    }
  
    public List<Evento> ObterEventos()
    {
        // Retorna uma cópia da lista original
        return new List<Evento>(eventos);
    }
}
