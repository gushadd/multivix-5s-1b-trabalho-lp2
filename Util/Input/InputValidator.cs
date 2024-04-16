﻿using Gestor_de_Eventos.Util.Patterns;
using System.Text.RegularExpressions;

namespace Gestor_de_Eventos.Util.Input
{
    internal class InputValidator
    {
        private InputValidator() { }

        public static bool ValidaFormatoDataHoraMinutoBrasileiro(DateTime dataHora)
        {
            return Regex.IsMatch(dataHora.ToString(ValidationPatterns.MascaraDataHoraMinutoBrasileiro), ValidationPatterns.FormatoDataHoraMinutoBrasileiro);
        }

        public static bool ValidaFormatoDataHoraMinutoBrasileiro(string dataHora)
        {
            return Regex.IsMatch(dataHora, ValidationPatterns.FormatoDataHoraMinutoBrasileiro);
        }

        public static bool ValidaFormatoDataBrasileira(DateOnly data)
        {
            return Regex.IsMatch(data.ToString(ValidationPatterns.MascaraDataBrasileira), ValidationPatterns.FormatoDataHoraMinutoBrasileiro);
        }

        public static bool ValidaFormatoDataBrasileira(string data)
        {
            return Regex.IsMatch(data, ValidationPatterns.FormatoDataBrasileira);
        }

        public static bool ValidaFormatoEmail(string email)
        {
            return Regex.IsMatch(email, ValidationPatterns.FormatoEmail);
        }

        public static bool ContemApenasNumerosInteiros(int numeroInteiro)
        {
            return Regex.IsMatch(numeroInteiro.ToString(), ValidationPatterns.FormatoNumerosInteiros);
        }

        public static bool ContemApenasNumerosInteiros(string numeroInteiro)
        {
            return Regex.IsMatch(numeroInteiro.ToString(), ValidationPatterns.FormatoNumerosInteiros);
        }

        public static bool ContemApenasLetras(string texto)
        {
            return Regex.IsMatch(texto, ValidationPatterns.FormatoLetras);
        }

        public static bool ValidaFormatoCpf(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return false;
            }
            else if (cpf.Length != 11)
            {
                return false;
            } else if (!ContemApenasNumerosInteiros(cpf))
            {
                return false;
            }

            return true;
        }

        public static bool ValidaFormatoTelefoneBrasileiroSemCodigoInternacional(string telefone)
        {
            if (string.IsNullOrEmpty(telefone))
            {
                return false;
            } else if (telefone.Length != 11)
            {
                return false;
            } else  if (!Regex.IsMatch(telefone, ValidationPatterns.FormatoTelefoneBrasileiroSemCodigoInternacional))
            {
                return false;
            }

            return true;
        }
    }
}
