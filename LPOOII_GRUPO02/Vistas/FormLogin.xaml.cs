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
    public partial class FormLogin : Window
    {
        
        public FormLogin()
        {
            InitializeComponent();
            userControlLoginn.botonClick += UserControlLogin_botonClick;
        }
        //nuevo evento agregado en vez del click del boton, ya que este maneja el evento del userControl
        private void UserControlLogin_botonClick(object sender,EventArgs e)
        {
            string usuario = userControlLoginn.txtUser.Text;
            string password = userControlLoginn.txtPassword.Password;

            // Validar las credenciales hardcoded
            if (usuario == "admin" && password == "admin")
            {
                MessageBox.Show("Bienvenido, Administrador!");
                App.UserGlobal = "Administrador";
                irMenuPrincipal();
            }
            else if (usuario == "operador" && password == "operador")
            {

                MessageBox.Show("Bienvenido, Operador!");
                App.UserGlobal = "Operador";
                irMenuPrincipal();
            }
            else
            {
                // Credenciales incorrectas
                MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Error de Inicio de Sesión", MessageBoxButton.OK, MessageBoxImage.Error);
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


        private void irMenuPrincipal(){
            FormMain fMain = new FormMain();
            fMain.Show();
            this.Close();
        }
    }
}
