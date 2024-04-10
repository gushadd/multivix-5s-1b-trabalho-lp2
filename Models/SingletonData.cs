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

    public Evento GetEvento(string id)
    {
        Evento? evento = null;
        foreach (var e in eventos)
        {
            if (id.Equals(e.Id))
            {
                evento = e;
                break;
            }
        }

        return evento == null ? throw new Exception ("Nenhum evento encontrado com o id fornecido") : evento;
    }

    public void AdicionarEvento(Evento evento)
    {
        eventos.Add(evento);
    }

    public void ExcluirEventoPorId(string id)
    {
        eventos.Remove(GetEvento(id));
    }

    // 'novasInformacoes' é um Dictionary, cuja 'key' armazena o nome da informação a ser editada (Descrição, Data etc.) e 
    // 'value' armazena o novo valor dessa informação
    /// <summary>
    /// Edita as informações de um evento. Segue a lista de opções para cada valor:
    /// <list type="bullet">
    /// <item><description>1 = Título</description></item>
    /// <item><description>2 = Data Inicial</description></item>
    /// <item><description>3 = Data Final</description></item>
    /// <item><description>4 = Descrição</description></item>
    /// <item><description>5 = Quantidade Aproximada de Pessoas</description></item>
    /// <item><description>6 = Quantidade Prevista de Pessoas</description></item>
    /// <item><description>7 = Público Alvo</description></item>
    /// <item><description>8 = Contato</description></item>
    /// </list>
    /// </summary>
    public void EditarEvento(string idEvento, Dictionary<int, string> novasInformacoes)
    {
        int indiceEvento = eventos.FindIndex(e => e.Id == idEvento);
        if (indiceEvento == -1) throw new ArgumentException("Evento não encontrado");

        foreach(var novaInformacao in novasInformacoes)
        {
            switch (novaInformacao.Key)
            {
                case 1:
                    eventos[indiceEvento].Titulo = novaInformacao.Value;
                    break;

                case 2:
                    eventos[indiceEvento].DataHoraInicio = DateTime.Parse(novaInformacao.Value);
                    break;

                case 3:
                    eventos[indiceEvento].DataHoraFinal = DateTime.Parse(novaInformacao.Value);
                    break;

                case 4:
                    eventos[indiceEvento].Descricao = novaInformacao.Value;
                    break;

                case 5:
                    eventos[indiceEvento].QuantidadeAproximadaPessoas = Convert.ToInt32(novaInformacao.Value);
                    break;

                case 6:
                    eventos[indiceEvento].QuantidadePrevistaPessoas = Convert.ToInt32(novaInformacao.Value);
                    break;

                case 7:
                    eventos[indiceEvento].PublicoAlvo = novaInformacao.Value;
                    break;

                case 8:
                    EditarContatoEvento(indiceEvento);
                    break;
            }
        }
    }

    public void EditarContatoEvento(int indiceEventoNaLista)
    {
        //Implementar Lógica puxando pelo indice do evento na lista

        //int indiceEvento = eventos.FindIndex(e => e.Id == idEvento);
        //if (indiceEvento == -1) throw new ArgumentException("Evento não encontrado");

        //foreach(var novaInformacao in novasInformacoes)
        //{
        //    switch(novaInformacao.Key)
        //    {
        //        case "Cpf":
        //            eventos[indiceEvento].Contato.Cpf = novaInformacao.Value;
        //            break;
        //        case "Nome":
        //            eventos[indiceEvento].Contato.Nome = novaInformacao.Value;
        //            break;
        //        case "Telefone":
        //            eventos[indiceEvento].Contato.Telefone = novaInformacao.Value;
        //            break;
        //        case "Email":
        //            eventos[indiceEvento].Contato.Email = novaInformacao.Value;
        //            break;
        //    }
        //}
    }
  
    public List<Evento> ObterEventos()
    {
        // Retorna uma cópia da lista original
        return new List<Evento>(eventos);
    }
}
