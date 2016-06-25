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
		
		// M�todo que se invocar� por el thrad de Main, y
		// el nuevo que creamos dentro ese mismo m�todo:
		public static void ImprimirNumeros()
		{
			Console.WriteLine ("Iniciando ejecuci�n...");
			
			for (int i = 1; i < 10; ++i)
			{
				Console.WriteLine (i.ToString());
			}
		}
	}
}