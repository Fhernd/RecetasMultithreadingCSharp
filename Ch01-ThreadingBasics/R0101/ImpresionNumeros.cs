using System;
using System.Threading;

namespace Recetas.Multithreading.Cap01.R0101
{
	public sealed class ImpresionNumeros
	{
		public static void Main()
		{
			Thread nuevoThread = new Thread (new ThreadStart (ImprimirNumeros));
			nuevoThread.Start();
			
			ImprimirNumeros();
		}
		
		// Método que se invocará por el thrad de Main, y
		// el nuevo que creamos dentro ese mismo método:
		public static void ImprimirNumeros()
		{
			Console.WriteLine ("Iniciando ejecución...");
			
			for (int i = 1; i < 10; ++i)
			{
				Console.WriteLine (i.ToString());
			}
		}
	}
}