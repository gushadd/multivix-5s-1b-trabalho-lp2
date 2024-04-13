using Gestor_de_Eventos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Eventos.Views
{
    internal class ViewData
    {
        private ViewData() { }

        public static void ExibeEvento (List<Evento> evento)
        {
            Console.WriteLine(EventoAsString(evento));
        }

        public static void ExibeContato (Contato contato)
        {
            Console.WriteLine(ContatoAsString(contato));
        }

        public static string EventoAsString (List<Evento> listaDeEventos)
        {
            StringBuilder sb = new StringBuilder();
            int numeroDeVoltas = 0;

            foreach (var e in listaDeEventos)
            {
                numeroDeVoltas++;

                sb.Append("ID do Evento: " + e.Id);
                sb.Append("Título: " + e.Titulo);
                sb.Append("Data e Hora de Início: " + e.DataHoraInicio);
                sb.Append("Data e Hora de Encerramento: " + e.DataHoraFinal);
                sb.Append("Descrição: " + e.Descricao);
                sb.Append("Quantidade Aproximada de Pessoas: " + e.QuantidadeAproximadaPessoas);
                sb.Append("Quandidade Prevista de Pessoas: " + e.QuantidadePrevistaPessoas);
                sb.Append("Público Alvo: " + e.PublicoAlvo);
                sb.Append("Contato do Evento: " + ContatoAsString(e.Contato!));

                if (!numeroDeVoltas.Equals(listaDeEventos.Count))
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        public static string ContatoAsString (Contato contato)
        {
            if (contato == null) return "Nenhum contato existente";
            return "Nome: " + contato.Nome + ", CPF: " + contato.Cpf + ", telefone: " + contato.Telefone + ", email: " + contato.Email;
        }
    }
}
