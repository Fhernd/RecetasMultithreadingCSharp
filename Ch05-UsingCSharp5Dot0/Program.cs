using System;
using Ch05_UsingCSharp5Dot0.R0501;
using Ch05_UsingCSharp5Dot0.R0502;
using Ch05_UsingCSharp5Dot0.R0503;
using Ch05_UsingCSharp5Dot0.R0504;
using Ch05_UsingCSharp5Dot0.R0505;
using Ch05_UsingCSharp5Dot0.R0506;
using Ch05_UsingCSharp5Dot0.R0507;
using Ch05_UsingCSharp5Dot0.R0508;

namespace Ch05_UsingCSharp5Dot0
{
    public class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.TreatControlCAsInput = false;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(MenuConsola.CierreAplicacionHandler);
            Console.CursorVisible = false;

            // Muestra el menu mientras que el usuario no presione Ctrl-C o Ctrl-Break
            // o cierre la ventana de la consola: 
            while (true)
            {
                Console.Clear();
                Console.Title = "Recetas Multithreading en C# - R05 - Uso de C# 5.0";
                Console.CursorVisible = false;
                
                string[] recetas = {"R0501", "R0502", "R0503", "R0504", "R0505", "R0506", "R0507", "R0508", "R0509"};
                MenuConsola.DibujarTexto("Seleccione la receta a ejecutar", 25, 18, ConsoleColor.Black, ConsoleColor.White);
                MenuConsola.DibujarTexto("[Ctrl-C o Ctrl-Break para Cerrar la Aplicación]", 16, 22, ConsoleColor.Black, ConsoleColor.White);
                int seleccion = MenuConsola.SeleccionarReceta(recetas, 36, 3, ConsoleColor.Blue, ConsoleColor.White);

                Console.Beep();
                MenuConsola.Limpiar();
                Console.WriteLine();
                switch (seleccion)
                {
                    case 1:
                        Console.Title = "R0501: Uso Operador await";
                        new TplVsAwait().Ejecutar();
                        break;
                    case 2:
                        Console.Title = "R0502: Operador await en Expresión Lambda";
                        new AwaitExpresionLambda().Ejecutar();
                        break;
                    case 3:
                        Console.Title = "R0503: Operador await en Tareas Asincrónicas Consecutivas";
                        new TareasAsincronicasConsecutivas().Ejecutar();
                        break;
                    case 4:
                        Console.Title = "R0504: Ejecución en Paralelo de Tareas con await";
                        new EjecucionParalelaConAwait().Ejecutar();
                        break;
                    case 5:
                        Console.Title = "R0505: Manejo Excepciones en Operaciones Asincrónicas";
                        new ManejoExcepcionesAsync().Ejecutar();
                        break;
                    case 6:
                        Console.Title = "R0506: Control sobre el Cambio de Contexto de Sincronización";
                        new ContextoSincronizacion().Ejecutar();
                        break;
                    case 7:
                        Console.Title = "R0507: Manejo de void en Operaciones Asincrónicas";
                        new VoidAsync().Ejecutar();
                        break;
                    case 8:
                        Console.Title = "R0508: Diseño Tipo Awaitable Personalizado";
                        new PersonalizacionAwait().Ejecutar();
                        break;
                    case 9:
                        break;
                }

                Console.WriteLine("\n Presione Enter para continuar...");
                Console.ReadLine();

                MenuConsola.Limpiar();
            }
        }
    }
}
