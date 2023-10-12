using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace ClaseBase
{
    public class TrabajarTipoVehiculos
    {
        // Guarda información de un nuevo tipo de vehiculo
        public static void guardar_tipo_vehiculo(TipoVehiculo tipo_vehiculo)
        {

            SqlConnection cnn = new SqlConnection(ClaseBase.Properties.Settings.Default.playaConnectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO TipoVehiculo(tv_Descripcion,tv_Tarifa) values (@descripcion,@tarifa)";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cnn;
            cmd.Parameters.AddWithValue("@descripcion", tipo_vehiculo.Tv_Descripcion);
            cmd.Parameters.AddWithValue("@tarifa", tipo_vehiculo.Tv_Tarifa);
            cnn.Open();
            cmd.ExecuteNonQuery();
        }

        //Muestra contenido de la bs de la tabla tipo vehiculo en el datagrid
        public static List<TipoVehiculo> traer_tipos_vehiculos()
        {
            List<TipoVehiculo> lista_tv = new List<TipoVehiculo>(); //lista de tipo de vehiculos

            using (SqlConnection conexion = new SqlConnection(ClaseBase.Properties.Settings.Default.playaConnectionString))
            {
                string consulta = "SELECT * FROM TipoVehiculo";
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    conexion.Open();
                    //Recorre la base de datos y los carga a la lista_tv
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            TipoVehiculo tv = new TipoVehiculo();
                            tv.Tv_Id = lector.GetInt32(0);
                            tv.Tv_Descripcion = lector.GetString(1);
                            tv.Tv_Tarifa = (decimal)lector.GetFloat(2);// Error de casteo.
                            lista_tv.Add(tv);
                        }
                    }
                }
            }
            return lista_tv;
        }
    }
}
