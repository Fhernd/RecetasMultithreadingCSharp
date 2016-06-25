using System;
using System.Threading;

namespace Receta.Multithreading.Cap01.R0101
{
	public sealed class UsoThread
	{
		public static void Main()
		{
			Thread thread = new Thread (new ThreadStart (ImprimirY));
			thread.Start();
		
			// Esta sección se ejecuta en paralelo con la salida 
			// generada por el método encapsulado por el delegado 
			// ThreadStart en el nuevo thread `thread`:
			for (int i = 0; i < 1000; ++i)
			{
				Console.Write ("X");
			}
			
			Console.WriteLine();
		}
		
		// Se ejecuta de manera simultánea con la salida 
		// generada por la sección de `Main`:
		public static void ImprimirY()
		{
			for (int i = 0; i < 1000; ++i)
			{
				Console.Write ("Y");
			}
		}
	}
}