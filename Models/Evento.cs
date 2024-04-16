using Gestor_de_Eventos.Util.Input;
using Gestor_de_Eventos.Util.Output;
using Gestor_de_Eventos.Util.Patterns;

namespace Gestor_de_Eventos.Models;

public class Evento
{
    private static HashSet<string> idsGerados = new HashSet<string>();

    public Evento(string titulo, DateTime dataHoraInicio, DateTime dataHoraFinal,
        string descricao, int quantidadeAproximadaPessoas, int quantidadePrevistaPessoas, string publicoAlvo, Contato contato)
    {
        Id = GerarIdUnico();
        Titulo = titulo;
        DataHoraInicio = dataHoraInicio;
        DataHoraFinal = dataHoraFinal;
        Descricao = descricao;
        QuantidadeAproximadaPessoas = quantidadeAproximadaPessoas;
        QuantidadePrevistaPessoas = quantidadePrevistaPessoas;
        PublicoAlvo = publicoAlvo;
        Contato = contato;
    }

    private string? id;
    public string? Id 
    {
        get { return id; }
        private set { id = value; }
    }

    private string? titulo;
    public string? Titulo 
    { 
        get { return titulo; }

        set
        {
            if (value == null) throw new ArgumentNullException("Título não pode ser nulo");
            titulo = value;
        }  
    }

    private DateTime dataHoraInicio;
    public DateTime DataHoraInicio 
    { 
        get { return dataHoraInicio; }

        set
        {
            if (!InputValidator.ValidaFormatoDataHoraMinutoBrasileiro(value))
                throw new ArgumentException($"A data precisa estar no formato {ValidationPatterns.FormatoDataHoraMinutoBrasileiro}");

            if (value < DateTime.Now) throw new ArgumentException("A data/hora início não pode ser anterior ao dia de hoje");
            dataHoraInicio = value;
        }     
    }

    private DateTime dataHoraFinal;
    public DateTime DataHoraFinal 
    { 
        get { return dataHoraFinal; }

        set
        {
            if (!InputValidator.ValidaFormatoDataHoraMinutoBrasileiro(value))
                throw new ArgumentException($"A data precisa estar no formato {ValidationPatterns.FormatoDataHoraMinutoBrasileiro}");

            if (value < DataHoraInicio) throw new ArgumentException("A data/hora final não pode ser anterior a data/hora início");
            dataHoraFinal = value;
        } 
    }

    private string? descricao;
    public string? Descricao
    {
        get { return descricao; }
        set
        {
            if (value == null) throw new ArgumentNullException("Descrição não pode ser nula");
            descricao = value;
        }
    }

    private int quantidadeAproximadaPessoas;
    public int QuantidadeAproximadaPessoas 
    { 
        get { return quantidadeAproximadaPessoas; }
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException("A quantidade precisa ser maior que zero");
            if (!InputValidator.ContemApenasNumerosInteiros(value)) throw new ArgumentException("A quantidade precisa ser um número inteiro");
            quantidadeAproximadaPessoas = value;
        }
    }

    private int quantidadePrevistaPessoas;
    public int QuantidadePrevistaPessoas 
    { 
        get { return quantidadePrevistaPessoas; }
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException("A quantidade precisa ser maior que zero");
            if (!InputValidator.ContemApenasNumerosInteiros(value)) throw new ArgumentException("A quantidade precisa ser um número inteiro");
            quantidadePrevistaPessoas = value;
        }
    }

    private string? publicoAlvo;
    public string? PublicoAlvo 
    {
        get {return  publicoAlvo; }
        set
        {
            if (value == null) throw new ArgumentNullException("Público alvo não pode ser nulo");
            publicoAlvo = value;
        }
    }

    private Contato? contato;
    public Contato? Contato 
    { 
        get { return contato; }
        set
        {
            contato = value;
        }
    }

    private string GerarIdUnico()
    {
        var caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        string idUnico;
        do
        {
            char[] idArray = new char[6];
            for (int i = 0; i < idArray.Length; i++)
            {
                idArray[i] = caracteres[random.Next(caracteres.Length)];
            }
            idUnico = new String(idArray);
        } while (idsGerados.Contains(idUnico));
        idsGerados.Add(idUnico);
        return idUnico;
    }

    public override string ToString()
    {
        return "ID do Evento: " + Id
             + " Título: " + Titulo
             + " Data e Hora de Início: " + OutputFormatter.FormatarDataHoraMinutoBrasileiro(DataHoraInicio)
             + " Data e Hora de Encerramento: " + OutputFormatter.FormatarDataHoraMinutoBrasileiro(DataHoraFinal)
             + " Descrição: " + Descricao
             + " Quantidade Aproximada de Pessoas: " + QuantidadeAproximadaPessoas
             + " Quandidade Prevista de Pessoas: " + QuantidadePrevistaPessoas
             + " Público Alvo: " + PublicoAlvo
             + " Contato: " + Contato!.ToString();
    }
}
