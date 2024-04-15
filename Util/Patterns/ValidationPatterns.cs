namespace Gestor_de_Eventos.Util.Patterns
{
    internal class ValidationPatterns
    {
        public const string FormatoDataHoraMinutoBrasileiro = "dd/MM/yyyy HH:mm";

        public const string FormatoEmail = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public const string FormatoNumerosInteiros = @"^[0-9]+$";

        public const string FormatoLetras = @"^[\p{L}\s]+$";
    }
}
