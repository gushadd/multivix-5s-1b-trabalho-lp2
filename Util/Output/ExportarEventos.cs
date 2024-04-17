using Gestor_de_Eventos.Models;

namespace Gestor_de_Eventos.Util.Output
{
    internal class ExportarEventos
    {
        private ExportarEventos() { }

        public static void SalvarArquivoTxt(Evento evento)
        {
            string diretorioExportacao = "C:\\gerenciador-eventos-mega-blaster-power-2000";

            if (!Directory.Exists(diretorioExportacao))
            {
                Directory.CreateDirectory(diretorioExportacao);
            }

            string caminhoDoArquivo = Path.Combine(diretorioExportacao, "evento-" + evento.Id + ".txt");
            StreamWriter sw = new StreamWriter(caminhoDoArquivo, true);

            try
            {
                sw.WriteLine(evento.ToString());
            }
            catch (Exception)
            {
                Console.WriteLine("Não foi possível exportar os eventos para o arquivo .txt!");
            }
            finally
            {
                sw.Close();
            }
        }
    }
}
