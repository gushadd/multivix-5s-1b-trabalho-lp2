namespace Gestor_de_Eventos.Models;

public class Evento
{
    public string? Id { get; set; }
    public string? Titulo { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFinal { get; set; }
    public string? Descricao { get; set; }
    public int QuantidadeAproximadaPessoas { get; set; }
    public int QuantidadePrevistaPessoas { get; set; }
    public string? PublicoAlvo { get; set; }
    public Contato? Contato { get; set; }
}
