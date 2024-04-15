namespace Gestor_de_Eventos.Util.Patterns
{
    internal class ValidationPatterns
    {
        public const string MascaraDataBrasileira = "dd/MM/yyyy";

        public const string MascaraDataHoraMinutoBrasileiro = "dd/MM/yyyy HH:mm";

        public const string FormatoDataBrasileira = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/((19|20)\d\d)$";

        public const string FormatoDataHoraMinutoBrasileiro = @"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[012])/((19|20)\d\d) ([01][0-9]|2[0-3]):[0-5][0-9]$";

        public const string FormatoEmail = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public const string FormatoNumerosInteiros = @"^[0-9]+$";

        public const string FormatoLetras = @"^[\p{L}\s]+$";
    }
}
