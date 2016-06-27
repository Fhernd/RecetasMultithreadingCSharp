using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ch05_UsingCSharp5Dot0.R0502
{
    /// <summary>
    /// 
    /// </summary>
    public class AwaitExpresionLambda
    {
        /// <summary>
        /// Inicio ejecución de la demostración de expresión lambda con operador await.
        /// </summary>
        public void Ejecutar()
        {
            Task tarea = ProcesamientoAsincronico();

            tarea.Wait();
        }

        /// <summary>
        /// Procesamiento asincrónico usando una expresión lambda y el operador await.
        /// </summary>
        /// <returns></returns>
        private async static Task ProcesamientoAsincronico()
        {
            // Definición de expresión lambda con uso de operador await: 
            Func<string, Task<string>> lambdaAsync = async nombre =>
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                return String.Format("`{0}` se está ejecutando en el ID de thread {1}. "
                                 + "¿Thread en el pool de threads?: {2}.", 
                    nombre,
                    Thread.CurrentThread.ManagedThreadId,
                    Thread.CurrentThread.IsThreadPoolThread);
            };

            string resultado = await lambdaAsync("Expresión lambda asincrónica");

            Console.WriteLine(resultado);
        }
    }
}
