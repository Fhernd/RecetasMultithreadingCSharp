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
		
			// Esta secci�n se ejecuta en paralelo con la salida 
			// generada por el m�todo encapsulado por el delegado 
			// ThreadStart en el nuevo thread `thread`:
			for (int i = 0; i < 1000; ++i)
			{
				Console.Write ("X");
			}
			
			Console.WriteLine();
		}
		
		// Se ejecuta de manera simult�nea con la salida 
		// generada por la secci�n de `Main`:
		public static void ImprimirY()
		{
			for (int i = 0; i < 1000; ++i)
			{
				Console.Write ("Y");
			}
		}
	}
}