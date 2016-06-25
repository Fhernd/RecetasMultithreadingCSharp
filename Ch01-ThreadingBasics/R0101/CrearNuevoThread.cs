using System;
using System.Threading;

namespace Recetas.Multithreading.Cap01.R0101
{
	public sealed class NuevoThread
	{
		private int valor;
		
		public NuevoThread (int v)
		{
			valor = v;
		}
		
		// Método que será ejecutado en un nuevo thread:
		public void MetodoThread()
		{
			Console.WriteLine ("El valor de la variable `valor` es: {0}", valor.ToString());
		}
		
		public static void Main()
		{
			// Creamos una instancia de `NuevoThread` e inicializamos en 7 
			// el campo `valor`:
			NuevoThread nt = new NuevoThread(7);
			
			// Creamos un nuevo `Thread` y pasamos como argumento al constructor 
			// una instancia del delegado `ThreadStart`, el cual encapsula 
			// al método de instancia `MetodoThread`:
			Thread thread = new Thread( new ThreadStart(nt.MetodoThread));
			
			// Se inicia la ejecución del thread:
			thread.Start();
			
			Console.WriteLine( "El método `Main` ha terminado. Presione Enter para terminar...");
			Console.ReadLine ();
		}
	}
}