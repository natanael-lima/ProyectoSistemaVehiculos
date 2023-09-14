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
        private Brush[] colores = { Brushes.Red,Brushes.Green,Brushes.Gray};
       
        private bool sectorDisponible = true;

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

       private void btnE1_Click(object sender, RoutedEventArgs e)
       {
           
           Button boton = (Button)sender;
           SolidColorBrush color = boton.Background as SolidColorBrush;
          
           if(color != null && color.Color == Colors.Green)
           {
               sectorDisponible = true;
               actualizarEstadoSector(boton);
           }
           else
           {
               sectorDisponible = false;
               actualizarEstadoSector(boton);
           }
           
       }

        private void actualizarEstadoSector(Button boton)
       {
           if(sectorDisponible)
           {

               MessageBoxResult resp = MessageBox.Show("Registrar Entrada", "Sector Disponible", MessageBoxButton.YesNo);
               if (resp == MessageBoxResult.Yes)
               {
                   boton.Background = colores[0];//rojo
               }
           }
           else
           {
               MessageBoxResult resp = MessageBox.Show("Registrar Salida", "Sector Ocupado", MessageBoxButton.YesNo);
               if (resp == MessageBoxResult.Yes)
               {
                   boton.Background = colores[1];//verde
               } 
           }
       }
    }
}
