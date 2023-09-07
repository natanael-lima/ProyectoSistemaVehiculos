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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vistas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el nombre de usuario y la contraseña ingresados
            string usuario = txtUser.Text;
            string password = txtPassword.Password;

            // Validar las credenciales hardcoded
            if (usuario == "admin" && password == "admin")
            {
              
                MessageBox.Show("Bienvenido, Administrador!");
            }
            else if (usuario == "operador" && password == "operador")
            {
              
                MessageBox.Show("Bienvenido, Operador!");
            }
            else
            {
                // Credenciales incorrectas
                MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
