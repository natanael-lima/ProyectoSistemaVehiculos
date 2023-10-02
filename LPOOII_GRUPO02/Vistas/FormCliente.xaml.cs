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
    /// Interaction logic for FormCliente.xaml
    /// </summary>
    public partial class FormCliente : Window
    {
        public FormCliente()
        {
            InitializeComponent();
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
            if (txtDNI.Text != "" && txtApellido.Text != "" && txtNombre.Text != "" && txtTelefono.Text != "")
            {
                MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea guardar los datos?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Cli_Id = 1;
                    oCliente.Cli_DNI = int.Parse(txtDNI.Text);
                    oCliente.Cli_Apellido = txtApellido.Text;
                    oCliente.Cli_Nombre = txtNombre.Text;
                    oCliente.Cli_Telefono = txtTelefono.Text;

                    string mensaje = "ID: " + oCliente.Cli_Id + "\nDNI: " + oCliente.Cli_DNI + "\nApellido: " + oCliente.Cli_Apellido + "\nNombre: " + oCliente.Cli_Nombre + "\nTeléfono: " + oCliente.Cli_Telefono;
                    MessageBoxResult result2 = MessageBox.Show(mensaje, "Valores Almacenados", MessageBoxButton.OK, MessageBoxImage.Information);
                    if (result2 == MessageBoxResult.OK)
                    {
                        FormCliente formCliente = new FormCliente();
                        formCliente.Show();
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
