using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ch05_UsingCSharp5Dot0.R0503
{
    public class TareasAsincronicasConsecutivas
    {
        /// <summary>
        /// Ejecución de la demostración de TPL vs operador asincrónica.
        /// </summary>
        public void Ejecutar()
        {
            Task t = AsincronismoConTpl();
            t.Wait();

            t = AsincronismoConAwait();
            t.Wait();
        }

        /// <summary>
        /// Implementación para la demostración del flujo de control de invocaciones 
        /// a través de elementos de programa de TPL.
        /// </summary>
        /// <returns>Resultado de la operación asincrónica.</returns>
        private Task AsincronismoConTpl()
        {
            var tareaCompuesta = new Task(() =>
            {
                Task<string> tarea1 = ObtenerInfoThreadAsync("TPL No. 1");
                tarea1.ContinueWith(tarea =>
                {
                    Console.WriteLine(tarea1.Result);

                    Task<string> tarea2 = ObtenerInfoThreadAsync("TPL No. 2");
                    tarea2.ContinueWith(tareaAnidada =>
                        Console.WriteLine(tareaAnidada.Result),
                        TaskContinuationOptions.NotOnFaulted |
                            TaskContinuationOptions.AttachedToParent);

                    tarea2.ContinueWith(tareaAnidada =>
                        Console.WriteLine(tareaAnidada.Exception.InnerException),
                        TaskContinuationOptions.OnlyOnFaulted |
                            TaskContinuationOptions.AttachedToParent);
                },
                    TaskContinuationOptions.NotOnFaulted |
                        TaskContinuationOptions.AttachedToParent);

                tarea1.ContinueWith(tarea =>
                    Console.WriteLine(tarea1.Exception.InnerException),
                    TaskContinuationOptions.OnlyOnFaulted |
                        TaskContinuationOptions.AttachedToParent);
            });

            tareaCompuesta.Start();

            return tareaCompuesta;
        }

        /// <summary>
        /// Implementación para demostración del flujo de control de invocaciones 
        /// con el operador asincrónico await.
        /// </summary>
        /// <returns>Resultado de la operación asincrónica.</returns>
        private async Task AsincronismoConAwait()
        {
            try
            {
                string resultado = await ObtenerInfoThreadAsync("Async No. 1");
                Console.WriteLine(resultado);
                resultado = await ObtenerInfoThreadAsync("Async No. 2");
                Console.WriteLine(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Operación para ejecución asincrónica desde implementación con TPL y 
        /// uso del operador asincrónico await.
        /// </summary>
        /// <param name="nombre">Nombre del mecanismo de invocación asincrónico.</param>
        /// <returns>Resultado de operación asincrónica.</returns>
        private async Task<String> ObtenerInfoThreadAsync(string nombre)
        {
            Console.WriteLine("Tarea `{0}` se ha iniciado.", nombre);

            /// Simula la ejecución de una operación de duración extendida: 
            await Task.Delay(TimeSpan.FromSeconds(2));

            if (nombre == "TPL No. 2")
            {
                throw new Exception("¡Algo salió mal!");
            }

            return String.Format("Tarea `{0}` se está ejecutando en el ID de thread {1}. "
                    + "¿Thread en el pool de threads?: {2}",
                nombre,
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}