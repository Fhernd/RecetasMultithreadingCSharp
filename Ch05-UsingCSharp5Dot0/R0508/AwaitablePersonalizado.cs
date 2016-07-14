namespace Ch05_UsingCSharp5Dot0.R0508
{
    /// <summary>
    /// Representa la implementación del awaitable personalizado.
    /// </summary>
    public class AwaitablePersonalizado
    {
        /// <summary>
        /// Especifica el modo de ejecución.
        /// </summary>
        private readonly bool _completadoSincronico;

        /// <summary>
        /// Crea awaitable personalizado especificando el modo de ejecución.
        /// </summary>
        /// <param name="completoSincronico">true si es sincrónico, false si es asincrónico.</param>
        public AwaitablePersonalizado(bool completoSincronico)
        {
            _completadoSincronico = completoSincronico;
        }

        /// <summary>
        /// Obtiene el objeto awaiter personalizado especiazando el modo ejecución: 
        /// sincrónico (true) o asincrónico (false).
        /// </summary>
        /// <returns>Awaiter personalizado.</returns>
        public AwaiterPersonalizado GetAwaiter()
        {
            return new AwaiterPersonalizado(_completadoSincronico);
        }
    }
}
