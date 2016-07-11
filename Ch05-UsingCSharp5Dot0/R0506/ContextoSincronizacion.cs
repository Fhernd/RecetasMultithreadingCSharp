using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ch05_UsingCSharp5Dot0.R0506
{
    /// <summary>
    /// Aplicación de demostración del uso de un contexto de sincronización.
    /// </summary>
    public class ContextoSincronizacion
    {
        private static Label _lblResultado;
        
        // Inicia la ejecución de esta aplicación de demostración. 
        // Configura la interfaz gráfica de usuario.
        public void Ejecutar()
        {
            var app = new Application();
            var win = new Window();
            var panel = new StackPanel();
            var btnEjecutar = new Button();
            
            _lblResultado = new Label();
            _lblResultado.FontSize = 32;
            _lblResultado.Height = 200;

            btnEjecutar.Height = 100;
            btnEjecutar.FontSize = 32;
            btnEjecutar.Content = new TextBlock {Text = "Iniciar Operaciones Asincrónicas"};
            btnEjecutar.Click += Click;

            panel.Children.Add(_lblResultado);
            panel.Children.Add(btnEjecutar);

            win.Content = panel;

            app.Run(win);
        }

        /// <summary>
        /// Inicia la ejecución de operaciones asincrónicas con y sin contexto.
        /// </summary>
        /// <param name="sender">Objeto generador del evento.</param>
        /// <param name="e">Datos del evento.</param>
        private async void Click(object sender, EventArgs e)
        {
            // Valor inicial de la etiqueta de la aplicación gráfica: 
            _lblResultado.Content = new TextBlock {Text = "Calculando..."};

            // Inicia la ejecución de las operaciones asincrónicas con y sin contexto: 
            TimeSpan resultadoConContexto = await OperacionConContexto();
            TimeSpan resultadoSinContexto = await OperacionSinContexto();

            //TimeSpan resultadoSinContexto = await OperacionSinContexto()
            //    .ConfigureAwait(false);

            // Reúne la información del resultado de la ejecución de las tareas con y sin contexto: 
            var sb = new StringBuilder();
            sb.AppendLine(String.Format("Resultado con contexto: {0}", resultadoConContexto.ToString()));
            sb.AppendLine(String.Format("Resultado sin contexto: {0}", resultadoSinContexto.ToString()));
            sb.AppendLine(String.Format("Proporción {0:0.00}",
                resultadoConContexto.TotalMilliseconds/resultadoSinContexto.TotalMilliseconds));

            // Muestra en la interfaz gráfica la cadena de texto con la información de la ejecución de este evento: 
            _lblResultado.Content = new TextBlock {Text = sb.ToString()};
        }

        /// <summary>
        /// Ejecuta una tarea en un contexto de sincronización.
        /// </summary>
        /// <returns>Intervalo ocurrido en la ejecución de esta tarea.</returns>
        private async Task<TimeSpan> OperacionConContexto()
        {
            const int numeroIteraciones = 100000;
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i <= numeroIteraciones; ++i)
            {
                var t = Task.Run(() => { });
                await t;
            }

            sw.Stop();

            return sw.Elapsed;
        }

        /// <summary>
        /// Ejecuta una tarea sin el uso de un contexto de sincronización.
        /// </summary>
        /// <returns>Intervalo ocurrido en la ejecución de esta tarea.</returns>
        private async Task<TimeSpan> OperacionSinContexto()
        {
            const int numeroIteraciones = 100000;
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 1; i <= numeroIteraciones; ++i)
            {
                var t = Task.Run(() => { });
                await t.ConfigureAwait(
                    continueOnCapturedContext: false);
            }

            sw.Stop();

            return sw.Elapsed;
        }
    }
}
