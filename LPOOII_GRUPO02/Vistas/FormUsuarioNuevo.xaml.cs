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
using Microsoft.Win32;
using System.IO;


namespace Vistas
{
    /// <summary>
    /// Interaction logic for FormUsuarioNuevo.xaml
    /// </summary>
    public partial class FormUsuarioNuevo : Window
    {
        public FormUsuarioNuevo()
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
                FormUsuario form = new FormUsuario();
                form.Show();
                this.Close();
            }
        }
        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea guardar los datos?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Usuario newUser = new Usuario();
                newUser.User_Name = txtNombre.Text;
                newUser.User_Password = txtPassword.Text;
                newUser.User_Nombre = txtNombre.Text;
                newUser.User_Apellido = txtApellido.Text;
                string rolSeleccionado = (txtRol.SelectedItem as ComboBoxItem).Content.ToString();
                newUser.User_Rol = rolSeleccionado;
                newUser.User_Foto = txtUrl.Text;

                string destino = @"C:\FOTOS\";

                string recurso = imgFoto.Source.ToString().Replace("file:///", "");
                File.Copy(recurso, destino + txtUrl.Text, true);

                TrabajarUsuario.altaUsuario(newUser);
                MessageBox.Show("Usuario Guardado correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }

        private void btnCargarFoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage foto = new BitmapImage();
                    foto.BeginInit();
                    foto.UriSource = new Uri(openFileDialog.FileName);
                    foto.EndInit();
                    foto.Freeze();

                    imgFoto.Source = foto;
                    txtUrl.Text = txtNombre.Text + txtApellido.Text + ".jpg";
                }
                catch
                {
                }
            }
        }


    }
}
