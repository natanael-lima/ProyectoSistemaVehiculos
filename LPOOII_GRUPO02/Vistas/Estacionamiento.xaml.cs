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
using LibreriaRecursos;
using System.Globalization;
using System.Collections.ObjectModel;
using ClaseBase;
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
       /*private void btnE1_Click(object sender, RoutedEventArgs e)
       {          
           Button boton = (Button)sender;
           actualizarEstadoSector(boton);
           RegistrarEntrada frmRegistrar = new RegistrarEntrada();
           frmRegistrar.Show();
       }*/

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

       //entra al formulario para registrar una entrada
       private void btnE1_Click(object sender, RoutedEventArgs e)
       {
           RegistrarEntrada frmRegistrar = new RegistrarEntrada(this,btnE1.Content.ToString());
           frmRegistrar.Show();
       }

       //pinta el rectangulo segun el tiempo;
       public void pintar(int min,string cod)
       {
           ConversorDeEstados conversor = new ConversorDeEstados();
           Rectangle rectangulo = FindName(cod) as Rectangle;
           Object result = conversor.Convert(min, typeof(Brush), null, CultureInfo.CurrentCulture);
           Brush brush = result as Brush;
           rectangulo.Fill = brush;
       }

      //metodo que pinta cada rectangulo segun la situacion (ocupado, disponible)
       private void chekearPintar()
       {
           ObservableCollection<Sector> lista= new ObservableCollection<Sector>();
           lista = TrabajarSector.traerSectores();

           foreach (Sector sec in lista)
           {
               Ticket tiket = new Ticket();
               tiket = TrabajarTicket.traerTicket(TrabajarSector.traerSector(sec.Sec_Identificador));

               if (tiket != null)
               {   
                   //MessageBox.Show(tiket.ToString());
                   if (TrabajarSector.traerSector(sec.Sec_Identificador).Sec_Habilitado == 2)
                   {
                       pintar(Convert.ToInt32(tiket.T_Duracion), sec.Sec_Identificador);
                   }
                   else if (TrabajarSector.traerSector(sec.Sec_Identificador).Sec_Habilitado == 1)
                   {
                       pintar(0, sec.Sec_Identificador);
                   }
               }
               else if (TrabajarSector.traerSector(sec.Sec_Identificador).Sec_Habilitado == 0)
               {
                   pintar(200, sec.Sec_Identificador);
               }
               else{
                   pintar(0, sec.Sec_Identificador);
               }
               tiket = new Ticket();
           }
           
       }

       private void Window_Loaded(object sender, RoutedEventArgs e)
       {
           chekearPintar();
           
       }

       private void btnE2_Click_1(object sender, RoutedEventArgs e)
       {
           RegistrarEntrada frmRegistrar = new RegistrarEntrada(this, btnE2.Content.ToString());
           frmRegistrar.Show();
       }


       //tpf p2
       private void btnE1_MouseEnter(object sender, MouseEventArgs e)
       {
           btnE1.ToolTip = toolTipp("E1");
       }

       private void btnE3_Click_1(object sender, RoutedEventArgs e)
       {
           //Manda el formulario y el nombre del sector...
           if (TrabajarSector.traerSector("E3").Sec_Habilitado != 0)
           {
               RegistrarEntrada frmRegistrar = new RegistrarEntrada(this, btnE3.Content.ToString());
               frmRegistrar.Show();
           }
       }

       private void btnE3_MouseEnter(object sender, MouseEventArgs e)
       {
           btnE3.ToolTip = toolTipp("E3");
       }

       //tpf pt2 tooltip segun el sector
       private ToolTip toolTipp(string codSec)
       {
           Ticket tiket = new Ticket();
           tiket = TrabajarTicket.traerTicket(TrabajarSector.traerSector(codSec));

           string info = "";
           ToolTip toolTip = new ToolTip();


           if (tiket != null)
           {
               if (TrabajarSector.traerSector(codSec).Sec_Habilitado == 2)
               {
                   TimeSpan dif = tiket.T_FechaHoraEnt - DateTime.Now; 
 
                   string tiempoTrans = dif.ToString(@"hh\:mm\:ss");
                   info = "El sector esta ocupado \n Tiempo transcurrido: " + tiempoTrans + " \n Tipo de Vehiculo: " + tiket.Tv_Id.Tv_Descripcion + "\n Total: $" + tiket.T_Total;
                   toolTip.Content = info;
               }
               else if (TrabajarSector.traerSector(codSec).Sec_Habilitado == 1)
               {
                   DateTime ahora = DateTime.Now;

                   TimeSpan tiempoTranscurrido = tiket.T_FechaHoraSal - ahora; 
                   info = "Sector libre desde las: " + tiempoTranscurrido.ToString(@"hh\:mm\:ss");
                   toolTip.Content = info;
               }
               

           }
           else if (TrabajarSector.traerSector(codSec).Sec_Habilitado == 0)
           {
               info = "El sector no esta disponible";
               toolTip.Content = info;
           }
           else
           {
               DateTime ahora = DateTime.Now;
               DateTime horaInicio = new DateTime(ahora.Year, ahora.Month, ahora.Day, 8, 0, 0);
               TimeSpan tiempoTranscurrido = horaInicio - ahora; 
               info = "Sector libre desde las: " + tiempoTranscurrido.ToString(@"hh\:mm\:ss");
               toolTip.Content = info;
           }

           return toolTip;
       }

       private void btnE2_MouseEnter(object sender, MouseEventArgs e)
       {
           btnE2.ToolTip = toolTipp("E2");
       }


       
    }
}
