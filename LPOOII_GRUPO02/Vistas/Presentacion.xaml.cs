using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Media;
using System.Windows.Media.Animation;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Presentacion.xaml
    /// </summary>
    public partial class Presentacion : Window
    {
        private MediaPlayer media;
        

        public Presentacion()
        {
            InitializeComponent();
            // Llama a la función para iniciar la animación cuando se carga la ventana
            Loaded += Window_Loaded;

            media = new MediaPlayer();
            string rutaAudio = @"C:\Users\admin\Documents\Visual Studio 2010\Projects\LPOOII_GRUPO02\Vistas\recursos\bienvenida.mp3";
            media.Open(new Uri(rutaAudio));
            media.Play();
            media.MediaEnded += Media_MediaEnded;
        }

        // metodo para mover la ventana con el mouse, se agrega en el inicio de Windows Form
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
            this.Close();
        }
        private void Media_MediaEnded(object sender, EventArgs e)  
        {
            FormLogin ventana = new FormLogin();
            ventana.Show(); 
            this.Close(); 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IniciarAnimacion();
        }
        private void IniciarAnimacion()
        {
            // Crea una animación de escala (zoom)
            DoubleAnimation animacion = new DoubleAnimation();
            animacion.From = 1; // Escala inicial
            animacion.To = 2.5; // Escala final
            animacion.Duration = TimeSpan.FromSeconds(2); // Duración de la animación (en segundos)

            // Asocia la animación al RenderTransform de la imagen
            image.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animacion);
            image.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animacion);
        }


        

    }
}
