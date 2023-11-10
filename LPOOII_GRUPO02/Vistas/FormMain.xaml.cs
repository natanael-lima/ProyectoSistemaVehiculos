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
using System.Windows.Threading;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FormMain.xaml
    /// </summary>
    public partial class FormMain : Window
    {
        private DispatcherTimer timer;


        private void Timer_Tick(object sender, EventArgs e)
        {
            // Actualiza el TextBlock con la fecha y hora actual
            txtFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        public FormMain()
        {
            InitializeComponent();

            // Crea el DispatcherTimer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Intervalo de 1 segundo
            timer.Tick += Timer_Tick;

            // Inicia el timer
            timer.Start();

            // Llama al evento Tick una vez para mostrar la fecha y hora actual de inmediato
            Timer_Tick(null, null);

            //MessageBox.Show("Rol: " + App.UserGlobal);
            //txtBlockRol.Text = txtBlockRol.Text + " "+ App.UserGlobal;
            if (App.UserGlobal == "Administrador")
            {
                btnClientes.IsEnabled = false;
                btnEstacionamientos.IsEnabled = false;
                btnEstacionamientos.Foreground = Brushes.Gray;
                btnClientes.Foreground = Brushes.Gray;
            }
            else
            {
                btnSector.IsEnabled = false;
                btnVehiculos.IsEnabled = false;
                btnSector.Foreground = Brushes.Gray;
                btnVehiculos.Foreground = Brushes.Gray;
            }
        }


        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnSector_Checked(object sender, RoutedEventArgs e)
        {
            EstadoSector estacionamiento = new EstadoSector();
            estacionamiento.Show();
            this.Hide();
        }

        private void btnVehiculos_Checked(object sender, RoutedEventArgs e)
        {
            FormVehiculo fVehiculo = new FormVehiculo();
            fVehiculo.Show();
            this.Close();
        }

        private void btnClientes_Checked(object sender, RoutedEventArgs e)
        {
            FormCliente fCliente = new FormCliente();
            fCliente.Show();
            this.Close();
        }

        private void btnEstacionamientos_Checked(object sender, RoutedEventArgs e)
        {
            Estacionamiento estacionamiento = new Estacionamiento();
            estacionamiento.Show();
            this.Hide();
        }

        private void btnCerrar_Checked(object sender, RoutedEventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }

        private void btnUsuarios_Checked(object sender, RoutedEventArgs e)
        {
            FormUsuario frmUsuario = new FormUsuario();
            frmUsuario.Show();
            this.Close();
        }

       

 


        

    }
}
