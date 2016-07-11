using System;
using System.Threading.Tasks;

namespace Ch05_UsingCSharp5Dot0.R0505
{
    public class ManejoExcepcionesAsync
    {
        /// <summary>
        /// Ejecución de las tareas asincrónicas.
        /// </summary>
        public void Ejecutar()
        {
            Task tarea = ProcesamientoAsincronico();
            tarea.Wait();
        }

        /// <summary>
        /// Procesamiento asincrónico de excepciones.
        /// </summary>
        /// <returns>Tarea asincrónica.</returns>
        private async Task ProcesamientoAsincronico()
        {
            Console.WriteLine("\n1. Excepción Única");

            try
            {
                string resultado = await ObtenerInfoAsync("Tarea No. 1", 2);
                Console.WriteLine(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Detalles de la excepción: {0}", ex.Message);
            }

            Console.WriteLine("\n2. Múltiples Excepciones");

            Task<string> tarea2 = ObtenerInfoAsync("Tarea No. 2", 3);
            Task<string> tarea3 = ObtenerInfoAsync("Tarea No. 3", 2);

            try
            {
                string[] resultados = await Task.WhenAll(tarea2, tarea3);
                Console.WriteLine(resultados.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Detalles de la excepción: {0}", ex.Message);
            }

            Console.WriteLine("\n3. Múltiples Excepciones con AggregateException");

            Task<string> tarea4 = ObtenerInfoAsync("Tarea No. 4", 3);
            Task<string> tarea5 = ObtenerInfoAsync("Tarea No. 5", 2);
            Task<string[]> tarea6 = Task.WhenAll(tarea4, tarea5);

            try
            {
                string[] resultados = await tarea6;
                Console.WriteLine(resultados.Length);
            }
            catch (Exception)
            {
                var ae = tarea6.Exception.Flatten();
                var excepciones = ae.InnerExceptions;
                Console.WriteLine("Excepciones atrapadas: {0}", excepciones.Count);

                foreach (var e in excepciones)
                {
                    Console.WriteLine("Detalles de la excepción: {0}\n", e.Message);
                }
            }
        }

        /// <summary>
        /// Operación asincrónica que simula la ejecución de un tarea extendida.
        /// </summary>
        /// <param name="nombre">Nombre de la tarea.</param>
        /// <param name="duracion">Duración de la tarea.</param>
        /// <returns>Cadena con la información de la excepción.</returns>
        private async Task<string> ObtenerInfoAsync(string nombre, int duracion)
        {
            await Task.Delay(TimeSpan.FromSeconds(duracion));

            throw new Exception(String.Format("Algo salió mal en {0}", nombre));
        }
    }
}
