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
                Console.Write("Digite aqui >>> ");
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
                Console.Write("Digite aqui >>> ");
                valor = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (string.IsNullOrEmpty(valor));

            return valor;
        }

        public static DateTime CapturaDataHoraDigitada()
        {
            string entrada = null!;
            int quantidadeTentativas = 0;
            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    if (string.IsNullOrEmpty(entrada))
                    {
                        Console.WriteLine("Data e hora não podem ficar vazios!");
                    } else
                    {
                        Console.WriteLine("Date e hora devem possuir o formato dd/MM/yyyy HH:mm");
                    }
                }
                Console.Write("Digite aqui >>> ");
                entrada = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (!InputValidator.ValidaFormatoDataHoraMinutoBrasileiro(entrada));

            return DateTime.ParseExact(entrada, ValidationPatterns.MascaraDataHoraMinutoBrasileiro, null);
        }

        public static DateOnly CapturaDataDigitada()
        {
            string entrada = null!;
            int quantidadeTentativas = 0;
            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    if (string.IsNullOrEmpty(entrada))
                    {
                        Console.WriteLine("Data não pode ficar vazia!");
                    } else if (entrada.Contains(" "))
                    {
                        Console.WriteLine("Data não pode ter espaços vazios!");
                    } else
                    {
                        Console.WriteLine("Data deve possuir o formato dd/MM/yyyy!");
                    }
                }
                Console.Write("Digite aqui >>> ");
                entrada = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (!InputValidator.ValidaFormatoDataBrasileira(entrada));

            return DateOnly.ParseExact(entrada, ValidationPatterns.MascaraDataBrasileira, null);
        }

        public static string CapturaCpfDigitado()
        {
            string entrada =  null!;
            int quantidadeTentativas = 0;
            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    if (string.IsNullOrEmpty(entrada))
                    {
                        Console.WriteLine("CPF não pode ficar vazio!");
                    } else if (entrada.Contains(" "))
                    {
                        Console.WriteLine("CPF não pode ter espaços vazios!");
                    } else if (entrada.Length != 11)
                    {
                        Console.WriteLine("CPF deve possuir exatamente 11 caracteres!");
                    } else
                    {
                        Console.WriteLine("CPF deve possuir apenas números inteiros!");
                    }
                }
                Console.Write("Digite aqui >>> ");
                entrada = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (!InputValidator.ValidaFormatoCpf(entrada));

            return entrada;
        }

        public static string CapturaEmailDigitado()
        {
            string entrada = null!;
            int quantidadeTentativas = 0;
            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    if (string.IsNullOrEmpty(entrada))
                    {
                        Console.WriteLine("Email não pode ficar vazio!");
                    } else if (entrada.Contains(" "))
                    {
                        Console.WriteLine("Email não pode ter espaços vazios!");
                    } else
                    {
                        Console.WriteLine("Email deve possuir o formato email@dominio.com!");
                    }
                }
                Console.Write("Digite aqui >>> ");
                entrada = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (!InputValidator.ValidaFormatoEmail(entrada));

            return entrada;
        }

        public static string CapturaTelefoneDigitado()
        {
            string entrada = null!;
            int quantidadeTentativas = 0;
            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    if (string.IsNullOrEmpty(entrada))
                    {
                        Console.WriteLine("Telefone não pode ficar vazio!");
                    } else if (entrada.Contains(" "))
                    {
                        Console.WriteLine("Telefone não pode ter espaços vazios!");
                    } else if (entrada.Length != 11)
                    {
                        Console.WriteLine("Telefone deve possuir exatamente 11 números inteiros!");
                    } else
                    {
                        Console.WriteLine("Telefone deve estar no formato DDD+Número (sem espaços)! Exemplo: 11987654321.");
                    }
                }
                Console.Write("Digite aqui >>> ");
                entrada = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (!InputValidator.ValidaFormatoTelefoneBrasileiroSemCodigoInternacional(entrada));

            return entrada;
        }
    }
}
