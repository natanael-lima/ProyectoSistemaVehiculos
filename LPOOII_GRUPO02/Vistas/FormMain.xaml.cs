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
    /// Interaction logic for FormMain.xaml
    /// </summary>
    public partial class FormMain : Window
    {
        public FormMain()
        {
            InitializeComponent();
            //MessageBox.Show("Rol: " + App.UserGlobal);
            //txtBlockRol.Text = txtBlockRol.Text + " "+ App.UserGlobal;
            if (App.UserGlobal == "Administrador")
            {
                itemCli.IsEnabled = false;
                itemEst.IsEnabled = false;
            }
            else 
            {
                itemSec.IsEnabled = false;
                itemVehic.IsEnabled = false;
            }
        }

        private void itemEst_Click(object sender, RoutedEventArgs e)
        {
            Estacionamiento estacionamiento = new Estacionamiento();
            estacionamiento.Show();
            this.Hide();
        }

        

    }
}
