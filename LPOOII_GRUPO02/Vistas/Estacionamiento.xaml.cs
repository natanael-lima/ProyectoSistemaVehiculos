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

namespace Vistas
{
    /// <summary>
    /// Interaction logic for Estacionamiento.xaml
    /// </summary>
    public partial class Estacionamiento : Window
    {
        public Estacionamiento()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            salir();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            salir();
        }

       private void salir()
        {
            FormMain menuPrincipal = new FormMain();
            menuPrincipal.Show();
            this.Close();
        }

    }
}
