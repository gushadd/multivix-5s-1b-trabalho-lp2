using Gestor_de_Eventos.Models;
using Gestor_de_Eventos.Util.Input;

internal class ViewMenus
{
    private ViewMenus() { }

        public static void ExibeMensagemBoasVindas()
        {
            Console.WriteLine("SEJA BEM VINDO AO GERENCIADOR DE EVENTOS");
        }

        public static int ObtemOpcoesMenuPrincipal()
        {
            Console.WriteLine("Escolha uma opção no menu abaixo");
            Console.WriteLine("1 - Cadastrar Evento");
            Console.WriteLine("2 - Pesquisar Itens Cadastrados");
            Console.WriteLine("3 - Editar Evento");
            Console.WriteLine("4 - Excluir Evento");
            Console.WriteLine("5 - Exportar Eventos");
            Console.WriteLine("0 - Sair do Programa");
            return Teclado.CapturaInteiroDigitado();
        }

        public static int ObtemOpcoesMenuListarEventos()
        {
            Console.WriteLine("Escolha umas das opções abaixo para pesquisar");
            Console.WriteLine("1 - Pesquisar Eventos Por Período");
            Console.WriteLine("2 - Pesquisar Eventos Em Uma Data Específica");
            Console.WriteLine("3 - Pesquisar Contato Cadastrado");
            return Teclado.CapturaInteiroDigitado();
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
            int numero = Teclado.CapturaInteiroDigitado();
            string valor = Teclado.CapturaStringDigitada();

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
            int numero = Teclado.CapturaInteiroDigitado();
            string valor = Teclado.CapturaStringDigitada();

            Dictionary<int, string> dicionario = new Dictionary<int, string>();
            dicionario[numero] = valor;
            return dicionario;
        }

        public static Evento ObtemOpcoesAdicionarEvento()
        {
            Console.WriteLine("Informe o título do evento");
            string titulo = Teclado.CapturaStringDigitada();
            Console.WriteLine("Informe a Data Inicial");
            DateTime dataInicial = Teclado.CapturaDataHoraDigitada();
            Console.WriteLine("Informe a Data Final");
            DateTime dataFinal = Teclado.CapturaDataHoraDigitada();
            Console.WriteLine("Informe a Descrição");
            string descricao = Teclado.CapturaStringDigitada();
            Console.WriteLine("Informe a Quantidade Aproximada de Pessoas");
            int quantidadeAproximadaDePessoas = Teclado.CapturaInteiroDigitado();
            Console.WriteLine("Informe a Quantidade Prevista de Pessoas");
            int quantidadePrevistaDePessoas = Teclado.CapturaInteiroDigitado();
            Console.WriteLine("Informe o Público Alvo");
            string publicoAlvo = Teclado.CapturaStringDigitada();
            Console.WriteLine("Agora preencha as informações do contato");
            Contato contato = ObtemOpcoesAdicionarContato();
            Evento evento = new Evento ( titulo, dataInicial, dataFinal, descricao, quantidadeAproximadaDePessoas, quantidadePrevistaDePessoas, publicoAlvo , contato);
            return evento;
        }

        public static Contato ObtemOpcoesAdicionarContato()
        {
            Console.WriteLine("Informe o nome do contato");
            string nome = Teclado.CapturaStringDigitada();
            Console.WriteLine("Informe o CPF do contato");
            string cpf = Teclado.CapturaStringDigitada();
            Console.WriteLine("Informe o email do contato");
            string email = Teclado.CapturaStringDigitada();
            Console.WriteLine("Informe o número de telefone do contato");
            string telefone = Teclado.CapturaStringDigitada();

            Contato contato = new Contato(nome, cpf, email, telefone);
            return contato;
        }

        public static string ObtemOpcoesIdEvento()
        {
            Console.WriteLine("Informe o Id do evento");
            return Teclado.CapturaStringDigitada();
        }
    }
}
