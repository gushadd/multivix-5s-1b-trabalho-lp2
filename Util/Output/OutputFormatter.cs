using Gestor_de_Eventos.Util.Patterns;
using System.Text.RegularExpressions;

namespace Gestor_de_Eventos.Util.Output
{
    internal class OutputFormatter
    {
        private OutputFormatter() { }

        public static string FormatarDataHoraMinutoBrasileiro(DateTime dataHora)
        {
            return dataHora.Equals(null) ? "Data/hora não informada" : dataHora.ToString(ValidationPatterns.MascaraDataHoraMinutoBrasileiro);
        }

        public static string FormatarDataHoraMinutoBrasileiro(string dataHora)
        {
            return dataHora.Equals(null) ? "Data/hora não informada" : string.Format(dataHora, ValidationPatterns.MascaraDataHoraMinutoBrasileiro);
        }

        public static string FormatarDataBrasileira(DateOnly data)
        {
            return data.Equals(null) ? "Data não informada" : data.ToString(ValidationPatterns.MascaraDataBrasileira);
        }

        public static string FormatarDataBrasileira(string data)
        {
            return data.Equals(null) ? "Data não informada" : string.Format(data, ValidationPatterns.MascaraDataBrasileira);
        }

        public static string FormatarCpf(string cpf)
        {
            return cpf.Equals(null) ? "CPF não informado" : $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
        }

        public static string FormatarTelefoneBrasileiroSemCodigoInternacional(string telefone)
        {
            return telefone.Equals(null) ? "Telefone não informado" : $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 5)}-{telefone.Substring(7, 4)}";
        }
    }
}
