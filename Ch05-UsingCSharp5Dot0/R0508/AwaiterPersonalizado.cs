using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Ch05_UsingCSharp5Dot0.R0508
{
    /// <summary>
    /// Represnta la implementación del awaiter personalizado.
    /// Implementa la interfaz `INotifyCompletion`.
    /// </summary>
    public class AwaiterPersonalizado : INotifyCompletion
    {
        /// <summary>
        /// Resultado por defecto del modo de ejecución.
        /// </summary>
        private string _resultado = "Finalizado en Modo Asincrono.";
        /// <summary>
        /// Especifica el modo de ejecución.
        /// </summary>
        private readonly bool _completoSincronico;

        /// <summary>
        /// Determina si la ejecución se ha finalizado.
        /// </summary>
        public bool IsCompleted
        {
            get { return _completoSincronico; }
        }

        /// <summary>
        /// Crea un objeto `AwaiterPersonalizado`.
        /// </summary>
        /// <param name="completoSincronico">El modo de ejecución.</param>
        public AwaiterPersonalizado(bool completoSincronico)
        {
            _completoSincronico = completoSincronico;
        }

        /// <summary>
        /// Recupera el resultado de la operación asincrónica.
        /// </summary>
        /// <returns>Cadena con la representación del resultado de la operación.</returns>
        public string GetResult()
        {
            return _resultado;
        }

        /// <summary>
        /// Al completarse la operación asincrónica.
        /// </summary>
        /// <param name="continuation">Acción a ejecutarse una vez se completa la operación.</param>
        public void OnCompleted(Action continuation)
        {
            ThreadPool.QueueUserWorkItem(estado =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                _resultado = ObtenerInfoThread();

                if (continuation != null)
                {
                    continuation();
                }
            });
        }

        /// <summary>
        /// Obtiene la información del thread de ejecución del proceso.
        /// </summary>
        /// <returns>Información del thread de ejecución.</returns>
        private string ObtenerInfoThread()
        {
            return String.Format("Tarea ejecutándose en el ID de thread {0}. " +
                                 "¿El thread está en el pool de threads?: {1}",
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
