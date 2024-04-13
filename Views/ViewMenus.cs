using Gestor_de_Eventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gestor_de_Eventos.Views
{
    internal class ViewMenus
    {
        private ViewMenus() { }

        public static int CapturaOpcaoDigitada()
        {
            int numero;
            string entrada;
            int quantidadeTentativas = 0;

            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    Console.WriteLine("Insira apenas números inteiros!");
                }
                Console.WriteLine("Escolha uma opção >>> ");
                entrada = Console.ReadLine()!;
                Console.WriteLine(" ");
            } while (!int.TryParse(entrada, out numero));

            return numero;
        }

        public static string CapturaValorDigitado()
        {
            string valor;
            int quantidadeTentativas = 0;
            Console.WriteLine("Digite o novo valor para a opção escolhida");
            do
            {
                quantidadeTentativas++;
                if (quantidadeTentativas > 1)
                {
                    Console.WriteLine("O valor não pode ficar vazio");
                }
                Console.Write("Digite o valor >>> ");
                valor = Console.ReadLine()!;

            } while (string.IsNullOrEmpty(valor));

            return valor;
        }

        public static void ExibeMensagemBoasVindas()
        {
            int larguraConsole = Console.WindowWidth;
            int mensagemPosicao = 0;
            bool direcao = true;
            string mensagem = "SEJA BEM VINDO AO GERENCIADOR DE EVENTOS";

            while (true)
            {
                Console.Clear(); Console.SetCursorPosition(mensagemPosicao, 0); Console.Write(mensagem);

                mensagemPosicao = direcao ? mensagemPosicao + 1 : mensagemPosicao - 1;
                direcao = (mensagemPosicao == 0 || mensagemPosicao == larguraConsole - mensagem.Length) ? !direcao : direcao;

                Thread.Sleep(100);
            }
        }

        public static int ObtemOpcoesMenuPrincipal()
        {
            Console.WriteLine("Escolha uma opção no menu abaixo");
            Console.WriteLine("1 - Cadastrar Evento");
            Console.WriteLine("2 - Pesquisar Itens Cadastrados");
            Console.WriteLine("3 - Editar Evento");
            Console.WriteLine("4 - Excluir Evento");
            Console.WriteLine("5 - Exportar Eventos");
            return CapturaOpcaoDigitada();
        }

        public static int ObtemOpcoesMenuListarEventos()
        {
            Console.WriteLine("Escolha umas das opções abaixo para pesquisar");
            Console.WriteLine("1 - Pesquisar Eventos Por Período");
            Console.WriteLine("2 - Pesquisar Eventos Em Uma Data Específica");
            Console.WriteLine("3 - Pesquisar Contato Cadastrado");
            return CapturaOpcaoDigitada();
        }

        public static Dictionary<int, string> ObtemOpcoesEditarEvento()
        {
            Console.WriteLine("Escolha o que deseja editar no evento");
            Console.WriteLine("1 - Título");
            Console.WriteLine("2 - Data Inicial");
            Console.WriteLine("3 - Data Final");
            Console.WriteLine("4 - Descrição");
            Console.WriteLine("5 - Quantidade Aproximada de Pessoas");
            Console.WriteLine("6 - Quantidade Prevista de Pessoas");
            Console.WriteLine("7 - Público Alvo");
            int numero = CapturaOpcaoDigitada();
            string valor = CapturaValorDigitado();

            Dictionary<int, string> dicionario = new Dictionary<int, string>();
            dicionario[numero] = valor;
            return dicionario;
        }

        public static Dictionary<int, string> ObtemOpcoesEditarContato()
        {
            Console.WriteLine("Escolha o que deseja editar no contato");
            Console.WriteLine("1 - Cpf");
            Console.WriteLine("2 - Nome");
            Console.WriteLine("3 - Telefone");
            Console.WriteLine("4 - Email");
            int numero = CapturaOpcaoDigitada();
            string valor = CapturaValorDigitado();

            Dictionary<int, string> dicionario = new Dictionary<int, string>();
            dicionario[numero]  = valor;
            return dicionario;
        }
    }
}
