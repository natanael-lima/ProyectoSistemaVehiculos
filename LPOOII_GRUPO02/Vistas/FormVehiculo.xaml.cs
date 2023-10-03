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
using ClaseBase;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for FormVehiculo.xaml
    /// </summary>
    public partial class FormVehiculo : Window
    {
        public FormVehiculo()
        {
            InitializeComponent();
        }

        private void txtUser_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                FormMain main = new FormMain();
                main.Show();
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtCodigo.Text != "" && txtDescripcion.Text != "" && txtTarifa.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea guardar los datos?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    TipoVehiculo oTipoVehiculo = new TipoVehiculo();
                    oTipoVehiculo.Tv_Id = int.Parse(txtCodigo.Text);
                    oTipoVehiculo.Tv_Descripcion = txtDescripcion.Text;
                    oTipoVehiculo.Tv_Tarifa = decimal.Parse(txtTarifa.Text);
                    string mensaje = "Código: " + oTipoVehiculo.Tv_Id + "\nTarifa: " + oTipoVehiculo.Tv_Tarifa + "\nDescripción: " + oTipoVehiculo.Tv_Descripcion;
                    MessageBoxResult result2 = MessageBox.Show(mensaje, "Valores Almacenados", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (result2 == MessageBoxResult.OK)
                    {
                        FormVehiculo formVehiculo = new FormVehiculo();
                        formVehiculo.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            FormMain fMain = new FormMain();
            fMain.Show();
            this.Close();
        }
    }
}
