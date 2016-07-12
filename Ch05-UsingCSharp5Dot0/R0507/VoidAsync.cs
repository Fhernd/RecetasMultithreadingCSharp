using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ch05_UsingCSharp5Dot0.R0507
{
    /// <summary>
    /// Clase para demostrar el uso de void en una operación asincrónica.
    /// </summary>
    public class VoidAsync
    {
        /// <summary>
        /// Ejecuta la demostración de uso de void en operaciones asincrónicas.
        /// </summary>
        public void Ejecutar()
        {
            Task t = AsyncRetornoTask();
            t.Wait();

            AsyncRetornoVoid();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            t = AsyncRetornoTaskConErrores();

            while (!t.IsFaulted)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            Console.WriteLine(t.Exception);

            // Manipulación de excepciones en operaciones asincrónicas 
            // que retornan void: 
            //try
            //{
            //    AsyncRetornoVoidConErrores();
            //    Thread.Sleep(TimeSpan.FromSeconds(3));
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

            // Gestión de excepciones irregular en expresiones lambda: 
            //int[] numeros = new[] {1, 2, 3, 4, 5};
            //Array.ForEach(numeros, async numero =>
            //{
            //    await Task.Delay(TimeSpan.FromSeconds(1));

            //    if (numero == 3)
            //    {
            //        throw new Exception("¡Algo salió mal!");

            //        Console.WriteLine(numero);
            //    }
            //});

            Console.ReadLine();
        }

        /// <summary>
        /// Operación asincrónica que genera una excepción.
        /// </summary>
        /// <returns>Retorna una instancia de Task.</returns>
        private async Task AsyncRetornoTaskConErrores()
        {
            string resultado = await ObtenerInfoAsync("AsyncRetornoTaskException", 2);

            Console.WriteLine(resultado);
        }

        /// <summary>
        /// Operación asincrónica que genera una excepción.
        /// El tipo de retorno es void.
        /// </summary>
        private async void AsyncRetornoVoidConErrores()
        {
            string resultado = await ObtenerInfoAsync("AsyncRetornoVoidException", 2);

            Console.WriteLine(resultado);
        }

        /// <summary>
        /// Operación asincrónica que opera correctamente.
        /// </summary>
        /// <returns>Retorna objeto Task.</returns>
        private async Task AsyncRetornoTask()
        {
            string resultado = await ObtenerInfoAsync("AsyncRetornoTask", 2);

            Console.WriteLine(resultado);
        }

        /// <summary>
        /// Operación asincrónica que opera correctamente.
        /// Retorna void.
        /// </summary>
        private async void AsyncRetornoVoid()
        {
            string resultado = await ObtenerInfoAsync("AsyncRetornoVoid", 2);

            Console.WriteLine(resultado);
        }

        /// <summary>
        /// Operación asincrónica que obtiene la información del thread de ejecución.
        /// </summary>
        /// <param name="nombre">Nombre de la tarea a ejecutar.</param>
        /// <param name="duracion">Duración de la tarea.</param>
        /// <returns>Información del thread de ejecución.</returns>
        private async Task<string> ObtenerInfoAsync(string nombre, int duracion)
        {
            await Task.Delay(TimeSpan.FromSeconds(duracion));

            if (nombre.Contains("Exception"))
            {
                throw new Exception(String.Format("¡Algo salió mal: {0}!", nombre));
            }

            return String.Format("`{0}` se está ejecutando en el ID de Thread {1}. " +
                                                  "¿Thread en el pool de threads?: {2}",
                    nombre,
                    Thread.CurrentThread.ManagedThreadId,
                    Thread.CurrentThread.IsThreadPoolThread);
        }
    }
}
