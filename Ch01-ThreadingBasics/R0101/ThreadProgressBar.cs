using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Recetas.Multithreading.Cap01.R0101
{
	public partial class ThreadProgressBar : Form
	{
		private System.ComponentModel.Container components = null;
		
		private Button btnMostrarMensaje;
		private ProgressBar pbrProgreso;
		
		public ThreadProgressBar()
		{
			InitializeComponent();
		}
		
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose ();
				}
			}
			
			base.Dispose (disposing);
		}
		
		private void InitializeComponent ()
		{
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.Load += new EventHandler(frmThreadProgressBar_Load);
			this.MinimizeBox = false;
			this.Name = "FrmThreadProgressBar";
			this.Size = new Size(300, 300);
			this.StartPosition = FormStartPosition.CenterScreen;
			
			btnMostrarMensaje = new Button();
			btnMostrarMensaje.Click += new EventHandler (btnMostrarMensaje_Click);
			btnMostrarMensaje.Location = new Point (13, 13);
			btnMostrarMensaje.Name = "btnMostrarMensaje";			
			btnMostrarMensaje.Size = new Size (120,23);
			btnMostrarMensaje.Text = "Mostrar Mensaje";
			
			// Crea la barra de progreso:
			pbrProgreso = new ProgressBar();
			pbrProgreso.Location = new Point (13, 53);
			pbrProgreso.Name = "pbrProgreso";
			
			
			this.Controls.Add (btnMostrarMensaje);
			this.Controls.Add (pbrProgreso);
		}
		
		// Este método incrementa o decrementa la barra de progreso de 
		// forma aleatoria. El propósito es demostrar que podemos 
		// usar un thread para otros componentes y la interfaz no se bloquea:
		private void TareaThread()
		{
			int avance;
			int nuevoValor;
			Random aleatorio = new Random();
			
			while (true)
			{
				avance = pbrProgreso.Step * aleatorio.Next(-1, 2);
				nuevoValor = pbrProgreso.Value + avance;
				
				if (nuevoValor > pbrProgreso.Maximum)
				{
					nuevoValor = pbrProgreso.Maximum;
				}
				else if (nuevoValor < pbrProgreso.Minimum)
				{
					nuevoValor = pbrProgreso.Minimum;
				}
				
				pbrProgreso.Value = nuevoValor;
				
				Thread.Sleep (100);
			}
		}
		
		#region Eventos
		// Este método se encarga de mostrar un mensaje cada vez que el
		// botón `btnMostrarMensaje` es activado por parte del usuario.
		// Independiente de que se esté llevando una tarea simultánea en 
		// segundo plano el método podrá invocarse sin ninguna restricción:
		private void btnMostrarMensaje_Click(object sender, EventArgs e)
		{
			MessageBox.Show ("Este mensaje es mostrado desde el thread principal.");
		}
		// Cuando el formulario se carga, inmediatamente se crea una instancia 
		// de Thread para invocar de forma simultánea el método TareaThread:
		private void frmThreadProgressBar_Load(object sender, EventArgs e)
		{
			Thread thread = new Thread (new ThreadStart(TareaThread));
			thread.IsBackground = true;
			thread.Start();
		}
		#endregion
		public static void Main() 
		{
			Application.EnableVisualStyles();
			Application.Run (new ThreadProgressBar());
		}
	}
}