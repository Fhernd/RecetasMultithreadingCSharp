using System;
using System.Security.Permissions;

namespace Ch05_UsingCSharp5Dot0.R0507
{
    /// <summary>
    /// Demostración del uso de AppDomain.UnhandledException.
    /// </summary>
    public class UsoUnhandledException
    {
        /// <summary>
        /// Punto de inicio de la aplicación.
        /// </summary>
        [SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.ControlAppDomain)]
        public static void Main()
        {
            AppDomain appDomain = AppDomain.CurrentDomain;
            appDomain.UnhandledException += new UnhandledExceptionEventHandler(ManejadorExcepciones);

            try
            {
                throw new Exception("Desde bloque try-catch");
            }
            catch (Exception e)
            {
                Console.WriteLine("Excepción gestionada en bloque catch: {0}", e.Message);
            }

            throw new Exception("Excepción no gestionada.");
        }

        /// <summary>
        /// Manejador de excepciones no gestionadas.
        /// </summary>
        /// <param name="sender">Objeto generador del evento.</param>
        /// <param name="args">Datos del evento.</param>
        public static void ManejadorExcepciones(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception) args.ExceptionObject;
            Console.WriteLine("`ManejadorExcepciones` capturó la excepción: {0}", e.Message);
            Console.WriteLine("¿Finalización de la aplicación?: {0}", args.IsTerminating);
        }
    }
}
