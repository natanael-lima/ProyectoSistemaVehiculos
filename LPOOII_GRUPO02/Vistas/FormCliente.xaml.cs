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
using System.Data;

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
            // Asigna una instancia de Cliente al DataContext
            DataContext = new Cliente();
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
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            FormMain fMain = new FormMain();
            fMain.Show();
            this.Close();
            
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Asigna la lista de clientes al DataGrid
            dataGridClientes.DataContext = TrabajarClientes.traer_clientes(); ;

            // v2 para mostrar listado
            //TrabajarClientes trabajador = new TrabajarClientes();
            // Llama al método para obtener el DataTable con los datos de los clientes
            //DataTable dtClientes = TrabajarClientes.TraerClientes();
            // Asigna el DataTable al DataGrid como su origen de datos
            //dataGridClientes.ItemsSource = dtClientes.DefaultView;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea modificar los datos?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Cliente oCliente = new Cliente();
                //oCliente.Cli_Id = 1;
                oCliente.Cli_DNI = int.Parse(txtDNI.Text);
                oCliente.Cli_Apellido = txtApellido.Text;
                oCliente.Cli_Nombre = txtNombre.Text;
                oCliente.Cli_Telefono = long.Parse(txtTelefono.Text);

                TrabajarClientes.modificar_cliente(oCliente);

                string mensaje = "ID: " + oCliente.Cli_Id + "\nDNI: " + oCliente.Cli_DNI + "\nApellido: " + oCliente.Cli_Apellido + "\nNombre: " + oCliente.Cli_Nombre + "\nTeléfono: " + oCliente.Cli_Telefono;
                MessageBoxResult result2 = MessageBox.Show(mensaje, "Valores Almacenados", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result2 == MessageBoxResult.OK)
                {
                    FormCliente formCliente = new FormCliente();
                    formCliente.Show();
                    this.Close();
                }
            }

            else
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea eliminar los datos?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Cliente oCliente = new Cliente();
                oCliente.Cli_Id = int.Parse(txtId.Text);
                oCliente.Cli_DNI = int.Parse(txtDNI.Text);
                oCliente.Cli_Apellido = txtApellido.Text;
                oCliente.Cli_Nombre = txtNombre.Text;
                oCliente.Cli_Telefono = long.Parse(txtTelefono.Text);

                TrabajarClientes.eliminar_cliente(oCliente);

                string mensaje = "ID: " + oCliente.Cli_Id + "\nDNI: " + oCliente.Cli_DNI + "\nApellido: " + oCliente.Cli_Apellido + "\nNombre: " + oCliente.Cli_Nombre + "\nTeléfono: " + oCliente.Cli_Telefono;
                MessageBoxResult result2 = MessageBox.Show(mensaje, "Valores Eliminados", MessageBoxButton.OK, MessageBoxImage.Information);
                if (result2 == MessageBoxResult.OK)
                {
                    FormCliente formCliente = new FormCliente();
                    formCliente.Show();
                    this.Close();
                }
            }

            else
            {
                MessageBox.Show("Complete todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ActualizarDatosCliente()
        {   

            // Obtén el DNI ingresado en el TextBox.
             int dni = int.Parse(textBuscar.Text);
            // Llama al método para obtener un cliente por DNI.
            Cliente cliente = TrabajarClientes.traer_cliente_por_dni(dni);

            if (cliente != null)
            {
                // Se encontró un cliente con el DNI ingresado, actualiza todos los campos.
                txtApellido.Text = cliente.Cli_Apellido;
                txtNombre.Text = cliente.Cli_Nombre;
                txtTelefono.Text = cliente.Cli_Telefono.ToString();
                txtDNI.Text = cliente.Cli_DNI.ToString();
                txtId.Text = cliente.Cli_Id.ToString();

                
            }
            else
            {
                // No se encontró un cliente con el DNI ingresado, muestra un mensaje o limpia los campos.
                //MessageBox.Show("No se encontró ningún cliente con el DNI ingresado.");
                txtApellido.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtDNI.Text = "";
            }
            
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            FormClienteNuevo form = new FormClienteNuevo();
            form.Show();
        }

        private void textBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Cuando el texto del TextBox del DNI cambia, llamamos al método para actualizar los datos del cliente.
            ActualizarDatosCliente();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {

        }





    }
}