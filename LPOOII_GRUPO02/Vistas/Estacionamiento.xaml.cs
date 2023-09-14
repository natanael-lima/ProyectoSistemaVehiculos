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
        //Actualizacion de Botones
       private void actualizarEstadoSector(Button boton)
       {
           SolidColorBrush colorBoton = boton.Background as SolidColorBrush;

           if (colorBoton != null && colorBoton.Color == Colors.Green)
           {
               sectorDisponible = true;
               actualizarColorSector(boton);
           }
           else
           {
               sectorDisponible = false;
               actualizarColorSector(boton);
           }
       }

       private void actualizarColorSector(Button boton)
       {
           if (sectorDisponible)
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

        //Botones E
       private void btnE1_Click(object sender, RoutedEventArgs e)
       {          
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
       }

       private void btnE2_Click(object sender, RoutedEventArgs e)
       {
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
       }

       private void btnE3_Click(object sender, RoutedEventArgs e)
       {
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
       }

       private void btnE4_Click(object sender, RoutedEventArgs e)
       {
           MessageBox.Show("Sector Deshabilitado", "Advertencia", MessageBoxButton.OK);
       }

       private void btnE5_Click(object sender, RoutedEventArgs e)
       {
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
       }

       private void btnE6_Click(object sender, RoutedEventArgs e)
       {
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
       }

       private void btnE7_Click(object sender, RoutedEventArgs e)
       {
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
       }

       private void btnE8_Click(object sender, RoutedEventArgs e)
       {
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
       }

       private void btnE9_Click(object sender, RoutedEventArgs e)
       {
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
       }

       private void btnE10_Click(object sender, RoutedEventArgs e)
       {
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
       }

       
    }
}
