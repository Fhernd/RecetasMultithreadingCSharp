using System;
using Ch05_UsingCSharp5Dot0.R0501;
using Ch05_UsingCSharp5Dot0.R0502;
using Ch05_UsingCSharp5Dot0.R0503;

namespace Ch05_UsingCSharp5Dot0
{
    public class Program
    {
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
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
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
