using System;
using System.Threading.Tasks;

namespace Ch05_UsingCSharp5Dot0.R0508
{
    /// <summary>
    /// Prueba el tipo awaitable personalizado.
    /// </summary>
    public class PersonalizacionAwait
    {
        /// <summary>
        /// Inicia la ejecución de la prueba.
        /// </summary>
        public void Ejecutar()
        {
            Task t = ProcesamientoAsincronico();
            t.Wait();
        }

        /// <summary>
        /// Procesamiento asincrónico de la prueba del tipo awaitable personalizado.
        /// </summary>
        /// <returns>Instancia Task con la información de la ejecución de la operación.</returns>
        private async Task ProcesamientoAsincronico()
        {
            var sincronico = new AwaitablePersonalizado(true);
            string resultado = await sincronico;
            Console.WriteLine(resultado);

            var asincronico = new AwaitablePersonalizado(false);
            resultado = await asincronico;
            Console.WriteLine(resultado);
        }
    }
}