using Gestor_de_Eventos.Models;
using Gestor_de_Eventos.Util.Input;
using Gestor_de_Eventos.Util.Patterns;

namespace Gestor_de_Eventos.Views;

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
        Console.WriteLine("4 - Listar Todos Os Eventos Cadastrados");
        Console.WriteLine("0 - Sair da Pesquisa");
        return Teclado.CapturaInteiroDigitado();
    }

    public static Dictionary<int, string> ObtemOpcoesEditarEvento()
    {
        int numero = int.MinValue;
        int quantidadeDeTentativas = 0;

        while (numero < 0 || numero > 7)
        {
            quantidadeDeTentativas++;

            if (quantidadeDeTentativas > 1)
            {
                Console.WriteLine("Opção digitada não é valida!");
            }

            Console.WriteLine("Escolha o que deseja editar no evento");
            Console.WriteLine("0 - Sair do modo de edição");
            Console.WriteLine("1 - Título");
            Console.WriteLine("2 - Data Inicial");
            Console.WriteLine("3 - Data Final");
            Console.WriteLine("4 - Descrição");
            Console.WriteLine("5 - Quantidade Aproximada de Pessoas");
            Console.WriteLine("6 - Quantidade Prevista de Pessoas");
            Console.WriteLine("7 - Público Alvo");
            numero = Teclado.CapturaInteiroDigitado();
        }

        string valor = null!;
        Dictionary<int, string> dicionario = new Dictionary<int, string>();
        switch (numero)
        {
            case 0:
                return dicionario;
            case 1:
                Console.WriteLine("Digite novo título para o evento: ");
                valor = Teclado.CapturaStringDigitada();
                break;
            case 2:
                Console.WriteLine("Digite nova data e hora iniciais para o evento: ");
                valor = null!;
                break;
            case 3:
                Console.WriteLine("Digite nova data e hora finais para o evento: ");
                valor = null!;
                break;
            case 4:
                Console.WriteLine("Digite nova descrição para o evento: ");
                valor = Teclado.CapturaStringDigitada();
                break;
            case 5:
                Console.WriteLine("Digite nova quantidade aproximada de pessoas: ");
                valor = Teclado.CapturaInteiroDigitado().ToString();
                break;
            case 6:
                Console.WriteLine("Digite nova quantidade prevista de pessoas: ");
                valor = Teclado.CapturaInteiroDigitado().ToString();
                break;
            case 7:
                Console.WriteLine("Digite novo público alvo para o evento: ");
                valor = Teclado.CapturaStringDigitada();
                break;
        }

        dicionario[numero] = valor;
        return dicionario;
    }

    public static Dictionary<int, string> ObtemOpcoesEditarContato()
    {
        int numero = int.MinValue;
        int quantidadeDeTentativas = 0;

        while (numero < 0 || numero > 4)
        {
            quantidadeDeTentativas++;

            if (quantidadeDeTentativas > 1)
            {
                Console.WriteLine("Opção digitada não é valida!");
            }

            Console.WriteLine("Escolha o que deseja editar no contato");
            Console.WriteLine("0 - Sair do modo de edição");
            Console.WriteLine("1 - Cpf");
            Console.WriteLine("2 - Nome");
            Console.WriteLine("3 - Telefone");
            Console.WriteLine("4 - Email");
            numero = Teclado.CapturaInteiroDigitado();
        }

        string valor = null!;
        Dictionary<int, string> dicionario = new Dictionary<int, string>();
        switch (numero)
        {
            case 0:
                return dicionario;
            case 1:
                Console.WriteLine("Digite novo CPF para o contato: ");
                valor = Teclado.CapturaCpfDigitado().ToString();
                break;
            case 2:
                Console.WriteLine("Digite novo nome para o contato: ");
                valor = Teclado.CapturaNomeDigitado();
                break;
            case 3:
                Console.WriteLine("Digite novo telefone para o contato: ");
                valor = Teclado.CapturaTelefoneDigitado().ToString();
                break;
            case 4:
                Console.WriteLine("Digite nova  para o evento: ");
                valor = Teclado.CapturaEmailDigitado();
                break;
        }

        dicionario[numero] = valor;
        return dicionario;
    }

    public static Evento ObtemOpcoesAdicionarEvento()
    {
        Console.WriteLine("Informe o título do evento");
        string titulo = Teclado.CapturaStringDigitada();
        //Console.WriteLine("Informe a Data Inicial");
        //DateTime dataInicial = Teclado.CapturaDataHoraDigitada();
        Console.WriteLine("Informe a Data Inicial");
        DateTime dataInicial = Teclado.CapturaDataHoraDigitadaMaiorQueDataEspecifica(DateTime.Now);
        Console.WriteLine("Informe a Data Final");
        DateTime dataFinal = Teclado.CapturaDataHoraDigitadaMaiorQueDataEspecifica(dataInicial);
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
        string nome = Teclado.CapturaNomeDigitado();
        Console.WriteLine("Informe o CPF do contato");
        string cpf = Teclado.CapturaCpfDigitado();
        Console.WriteLine("Informe o email do contato");
        string email = Teclado.CapturaEmailDigitado();
        Console.WriteLine("Informe o número de telefone do contato");
        string telefone = Teclado.CapturaTelefoneDigitado();

        Contato contato = new Contato(nome, cpf, email, telefone);
        return contato;
    }

    public static string ObtemOpcoesIdEvento()
    {
        Console.WriteLine("Informe o Id do evento");
        return Teclado.CapturaStringDigitada();
    }

    public static int ObtemOpcoesMenuEditarEvento()
    {
        Console.WriteLine("Escolha uma opção no menu abaixo");
        Console.WriteLine("1 - Editar Evento");
        Console.WriteLine("2 - Editar Contato de Evento");
        Console.WriteLine("0 - Sair do Menu de Edição");
        return Teclado.CapturaInteiroDigitado();
    }
}

