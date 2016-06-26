using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ch05_UsingCSharp5Dot0.R0501
{
    /// <summary>
    /// Clase para demostración de ejecución con TPL y await.
    /// </summary>
    public class TplVsAwait
    {
        /// <summary>
        /// Ejecuta las demostraciones de ejecuciones con TPL y await.
        /// </summary>
        public void Ejecutar()
        {
            Console.WriteLine();
            Task t = AsincronismoConTpl();
            t.Wait();

            Console.WriteLine();

            t = AsincronismoConAwait();
            t.Wait();
        }

        /// <summary>
        /// Demuestra el uso de TPL para llamada asincrónica.
        /// </summary>
        /// <returns></returns>
        private Task AsincronismoConTpl()
        {
            Task<string> tarea = ObtenerInfoAsincro("Tarea No. 1");

            Task tarea2 = tarea.ContinueWith(t => Console.WriteLine(t.Result),
                TaskContinuationOptions.NotOnFaulted);
            Task tarea3 = tarea.ContinueWith(t => Console.WriteLine(
                t.Exception.InnerException), TaskContinuationOptions.OnlyOnFaulted);

            return Task.WhenAny(tarea2, tarea3);
        }

        /// <summary>
        /// Demuestra el uso del operador await para llamada asincrónica.
        /// </summary>
        /// <returns>Objeto Task con información de la tarea ejecutada.</returns>
        private async Task AsincronismoConAwait()
        {
            try
            {
                string resultado = await ObtenerInfoAsincro("Tarea No. 2");
                Console.WriteLine(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Método asincrónico para demostrar la invocación desde TPL y await.
        /// </summary>
        /// <param name="nombre">Nombre de la tarea.</param>
        /// <returns>Información del thread del pool de threads.</returns>
        private async Task<string> ObtenerInfoAsincro(string nombre)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            return String.Format("`{0}` se está ejecutando en el ID de thread {1}. "
                                 + "¿Thread en el pool de threads?: {2}.", 
                nombre,
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
