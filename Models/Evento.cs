using System.Globalization;
using System.Text.RegularExpressions;

namespace Gestor_de_Eventos.Models;

public class Evento
{
    public Evento(string titulo, DateTime dataHoraInicio, DateTime dataHoraFinal,
        string descricao, int quantidadeAproximadaPessoas, int quantidadePrevistaPessoas, string publicoAlvo, Contato contato)
    {
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
            if (!DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                throw new ArgumentException("A data precisa estar no formato dd/MM/yyyy HH:mm");

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
            if (!DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                throw new ArgumentException("A data precisa estar no formato dd/MM/yyyy HH:mm");

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
            if (!int.TryParse(value.ToString(), out int valor)) throw new ArgumentException("A quantidade precisa ser um número inteiro");
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
            if (!int.TryParse(value.ToString(), out int valor)) throw new ArgumentException("A quantidade precisa ser um número inteiro");
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
}
