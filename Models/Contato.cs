using System.Text.RegularExpressions;

namespace Gestor_de_Eventos.Models;

public class Contato
{
    private string? cpf;
    public string? Cpf
    {
        get { return cpf; }
        set
        {
            if (value == null) throw new ArgumentNullException("CPF não pode ser nulo");
            if (value.Length != 11) throw new ArgumentException("CPF deve ter exatamente 11 caracteres");
            if (!Regex.IsMatch(value, "^[0-9]+$")) throw new ArgumentException("CPF deve conter apenas números");
            cpf = value;
        }    
    }

    private string? nome;
    public string? Nome 
    {
        get { return nome; }
        set
        {
            if (value == null) throw new ArgumentNullException("Nome não pode ser nulo");
            if (!Regex.IsMatch(value, @"^[\p{L}\s]+$")) throw new ArgumentException("Nome deve conter apenas caracteres de letras");
            nome = value;
        }
    }

    private string? telefone;
    public string? Telefone 
    {
        get { return telefone; }
        set
        {
            if (value == null) throw new ArgumentNullException("Telefone não pode ser nulo");
            if (value.Length != 11) throw new ArgumentException("Telefone deve ter exatamente 11 caracteres");
            if (!Regex.IsMatch(value, @"^[0-9]+$")) throw new ArgumentException("Telefone deve conter apenas números");
            telefone = value;
        }
    }

    private string? email;
    public string? Email 
    {
        get { return email; }
        set
        {
            if (value == null) throw new ArgumentNullException("Email não pode ser nulo");
            if (!Regex.IsMatch(value, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")) throw new ArgumentException("O email deve possuir o formato exemplo@dominio.com");
            email = value;
        }
    }
}
