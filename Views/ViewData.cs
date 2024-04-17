using Gestor_de_Eventos.Models;
using System.Text;

namespace Gestor_de_Eventos.Views
{
    internal class ViewData
    {
        private ViewData() { }

        public static void ExibeListaDeEventos (List<Evento> eventos)
        {
            Console.WriteLine(ListaDeEventosAsString(eventos));
        }

        public static string ListaDeEventosAsString (List<Evento> listaDeEventos)
        {
            StringBuilder sb = new StringBuilder();
            int numeroDeVoltas = 0;

            foreach (var evento in listaDeEventos)
            {
                numeroDeVoltas++;

                sb.Append(evento.ToString());

                if (!numeroDeVoltas.Equals(listaDeEventos.Count))
                {
                    sb.AppendLine();
                }
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
