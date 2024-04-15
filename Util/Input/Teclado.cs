using Gestor_de_Eventos.Util.Patterns;

namespace Gestor_de_Eventos.Util.Input
{
    internal class Teclado
    {
        private Teclado() { }
        public static int CapturaInteiroDigitado()
        {
            string entrada;
            int quantidadeTentativas = 0;

            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    Console.WriteLine("Insira apenas números inteiros!");
                }
                Console.Write("Escolha uma opção >>> ");
                entrada = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (!InputValidator.ContemApenasNumerosInteiros(entrada));

            return Int32.Parse(entrada);
        }

        public static string CapturaStringDigitada()
        {
            string valor;
            int quantidadeTentativas = 0;
            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    Console.WriteLine("Esta opção não pode ficar vazia");
                }
                Console.Write("Digite o valor >>> ");
                valor = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (string.IsNullOrEmpty(valor));

            return valor;
        }

        public static DateTime CapturaDataHoraDigitada()
        {
            string entrada;
            int quantidadeTentativas = 0;
            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    Console.WriteLine("Data e hora não podem ficar vazios");
                }
                Console.Write("Digite a data com a hora >>> ");
                entrada = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (!InputValidator.ValidaFormatoDataHoraMinutoBrasileiro(entrada));

            return DateTime.ParseExact(entrada, ValidationPatterns.MascaraDataHoraMinutoBrasileiro, null);
        }
    }
}
