using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ch05_UsingCSharp5Dot0.R0504
{
    /// <summary>
    /// Clase demostración para la ejecución de tareas en paralelo.
    /// </summary>
    public class EjecucionParalelaConAwait
    {
        /// <summary>
        /// Inicia la ejecución de las tareas.
        /// </summary>
        public void Ejecutar()
        {
            Task tarea = ProcesamientoAsincronico();
            tarea.Wait();
        }

        /// <summary>
        /// Configura la ejecución de tareas para procesamiento asincrónico.
        /// </summary>
        /// <returns>Tarea de procesamiento asincrónico.</returns>
        private async Task ProcesamientoAsincronico()
        {
            Task<string> tarea1 = ObtenerInfoAsync("Tarea No. 1", 3);
            Task<string> tarea2 = ObtenerInfoAsync("Tarea No. 2", 5);

            string[] resultados = await Task.WhenAll(tarea1, tarea2);

            // Visualización de resultados después de la ejecución de las 
            // de las dos tareas: 
            foreach (string resultado in resultados)
            {
                Console.WriteLine(resultado);
            }
        }

        /// <summary>
        /// Método para ejecución asincrónica.
        /// </summary>
        /// <param name="nombreTarea">Nombre de la tarea a ejecutar.</param>
        /// <param name="duracion">Duración de la simulación de tarea extendida.</param>
        /// <returns>Estado del thread de ejecución asincrónica.</returns>
        private async Task<string> ObtenerInfoAsync(string nombreTarea, int duracion)
        {
            await Task.Delay(TimeSpan.FromSeconds(duracion));

            return String.Format("`{0}` se está ejecutando en el ID de thread {1}. ¿Thread en el pool de threads?: {2}",
                nombreTarea,
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
