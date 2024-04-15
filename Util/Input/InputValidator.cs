using Gestor_de_Eventos.Util.Patterns;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Gestor_de_Eventos.Util.Input
{
    internal class InputValidator
    {
        private InputValidator() { }

        public static bool ValidaFormatoDataHoraMinutoBrasileiro(DateTime dataHora)
        {
            return DateTime.TryParseExact(dataHora.ToString(ValidationPatterns.FormatoDataHoraMinutoBrasileiro), ValidationPatterns.FormatoDataHoraMinutoBrasileiro, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data);
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
    }
}
