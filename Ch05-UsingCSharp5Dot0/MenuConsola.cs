using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05_UsingCSharp5Dot0
{
    public class MenuConsola
    {
        public static int SeleccionarReceta(string[] recetas, int ucol, int urow, ConsoleColor colorFondo, ConsoleColor colorTexto)
        {
            int numeroRecetas = recetas.Length;
            int longitudMaxima = recetas[0].Length;
            for (int i = 1; i < numeroRecetas; i++)
            {
                if (recetas[i].Length > longitudMaxima)
                {
                    longitudMaxima = recetas[i].Length;
                }
            }

            int[] espacios = new int[numeroRecetas];
            for (int i = 0; i < numeroRecetas; i++)
            {
                espacios[i] = longitudMaxima - recetas[i].Length + 1;
            }

            int lcol = ucol + longitudMaxima + 3;
            int lrow = urow + numeroRecetas + 1;

            DibujarContenedor(ucol, urow, lcol, lrow, colorFondo, colorTexto, true);
            DibujarTexto(" " + recetas[0] + new string(' ', espacios[0]), ucol + 1, urow + 1, colorTexto, colorFondo);

            for (int i = 2; i <= numeroRecetas; i++)
            {
                DibujarTexto(recetas[i - 1], ucol + 2, urow + i, colorFondo, colorTexto);
            }

            ConsoleKeyInfo cki;
            char tecla;
            int seleccion = 1;

            while (true)
            {
                cki = Console.ReadKey(true);
                tecla = cki.KeyChar;
                if (tecla == '\r') // enter 
                {
                    return seleccion;
                }
                else if (cki.Key == ConsoleKey.DownArrow)
                {
                    DibujarTexto(" " + recetas[seleccion - 1] + new string(' ', espacios[seleccion - 1]), ucol + 1, urow + seleccion, colorFondo, colorTexto);
                    if (seleccion < numeroRecetas)
                    {
                        seleccion++;
                    }
                    else
                    {
                        seleccion = 1;
                    }
                    DibujarTexto(" " + recetas[seleccion - 1] + new string(' ', espacios[seleccion - 1]), ucol + 1, urow + seleccion, colorTexto, colorFondo);
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    DibujarTexto(" " + recetas[seleccion - 1] + new string(' ', espacios[seleccion - 1]), ucol + 1, urow + seleccion, colorFondo, colorTexto);
                    if (seleccion > 1)
                    {
                        seleccion--;
                    }
                    else
                    {
                        seleccion = numeroRecetas;
                    }
                    DibujarTexto(" " + recetas[seleccion - 1] + new string(' ', espacios[seleccion - 1]), ucol + 1, urow + seleccion, colorTexto, colorFondo);
                }
            }
        }

        public static void DibujarContenedor(int ucol, int urow, int lcol, int lrow, ConsoleColor colorFondo, ConsoleColor colorTexto, bool fill)
        {
            const char Horizontal = '\u2500';
            const char Vertical = '\u2502';
            const char EsquinaSuperiorIzquierda = '\u250c';
            const char EsquinaSuperiorDerecha = '\u2510';
            const char EsquinaInferiorIzquierda = '\u2514';
            const char EsquinaInferiorDerecha = '\u2518';

            string fillLine = fill ? new string(' ', lcol - ucol - 1) : "";
            SeleccionarColor(colorFondo, colorTexto);

            // Borde superior:  
            Console.SetCursorPosition(ucol, urow);
            Console.Write(EsquinaSuperiorIzquierda);

            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(Horizontal);
            }

            Console.Write(EsquinaSuperiorDerecha);

            // Dibujo lineas laterales:  
            for (int i = urow + 1; i < lrow; i++)
            {
                Console.SetCursorPosition(ucol, i);
                Console.Write(Vertical);
                if (fill) Console.Write(fillLine);
                Console.SetCursorPosition(lcol, i);
                Console.Write(Vertical);
            }

            // Dibujo borde inferior: 
            Console.SetCursorPosition(ucol, lrow);
            Console.Write(EsquinaInferiorIzquierda);
            for (int i = ucol + 1; i < lcol; i++)
            {
                Console.Write(Horizontal);
            }
            Console.Write(EsquinaInferiorDerecha);
        }
        public static void DibujarTexto(string texto, int col, int fila, ConsoleColor colorFondo, ConsoleColor colorTexto)
        {
            SeleccionarColor(colorFondo, colorTexto);
            Console.SetCursorPosition(col, fila);
            Console.Write(texto);
        }
        public static void SeleccionarColor(ConsoleColor colorFondo, ConsoleColor colorFrontal)
        {
            Console.BackgroundColor = colorFondo;
            Console.ForegroundColor = colorFrontal;
        }
        public static void Limpiar()
        {
            Console.ResetColor();
            Console.CursorVisible = true;
            Console.Clear();
        }
        public static void CierreAplicacionHandler(object sender, ConsoleCancelEventArgs args)
        {
            // Cierre con Control-C o Control-Break: 
            Limpiar();
        }

        public static void SeleccionarColoresEstandar()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
