﻿using Gestor_de_Eventos.Util.Input;
using Gestor_de_Eventos.Util.Output;

namespace Gestor_de_Eventos.Models;

public class Contato
{
    public Contato(string nome,  string cpf, string email, string telefone)
    {
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
    }

    private string? cpf;
    public string? Cpf
    {
        get { return cpf; }
        set
        {
            if (value == null) throw new ArgumentNullException("CPF não pode ser nulo");
            if (value.Length != 11) throw new ArgumentOutOfRangeException("CPF deve ter exatamente 11 caracteres");
            if (!InputValidator.ContemApenasNumerosInteiros(value)) throw new ArgumentException("CPF deve conter apenas números");
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
            if (!InputValidator.ContemApenasLetras(value)) throw new ArgumentException("Nome deve conter apenas caracteres de letras");
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
            if (value.Length != 11) throw new ArgumentOutOfRangeException("Telefone deve ter exatamente 11 caracteres");
            if (!InputValidator.ContemApenasNumerosInteiros(value)) throw new ArgumentException("Telefone deve conter apenas números");
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
            if (!InputValidator.ValidaFormatoEmail(value)) throw new ArgumentException("O email deve possuir o formato exemplo@dominio.com");
            email = value;
        }
    }

    public override string ToString()
    {
        return "Nome: " + Nome + ", CPF: " + OutputFormatter.FormatarCpf(Cpf!) + ", telefone: " + OutputFormatter.FormatarTelefoneBrasileiroSemCodigoInternacional(Telefone!) + ", email: " + Email;
    }
}
