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
    /// Interaction logic for FormVehiculoNuevo.xaml
    /// </summary>
    public partial class FormVehiculoNuevo : Window
    {
        public FormVehiculoNuevo()
        {
            InitializeComponent();
            //DataContext = new Vehiculo();
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
                this.Close();
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtDescripcion.Text != "" && txtTarifa.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea guardar los datos?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    TipoVehiculo oTipoVehiculo = new TipoVehiculo();

                    oTipoVehiculo.Tv_Descripcion = txtDescripcion.Text;
                    oTipoVehiculo.Tv_Tarifa = decimal.Parse(txtTarifa.Text);
                    string mensaje = "Tarifa: " + oTipoVehiculo.Tv_Tarifa + "\nDescripción: " + oTipoVehiculo.Tv_Descripcion;
                    MessageBoxResult result2 = MessageBox.Show(mensaje, "Valores Almacenados", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (result2 == MessageBoxResult.OK)
                    {
                        TrabajarTipoVehiculos.guardar_tipo_vehiculo(oTipoVehiculo);//Guarda en la bd
                        FormVehiculo formVehiculo = new FormVehiculo();
                        formVehiculo.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
