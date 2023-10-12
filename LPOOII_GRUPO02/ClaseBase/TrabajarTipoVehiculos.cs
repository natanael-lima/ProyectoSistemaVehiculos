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
                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                TipoVehiculo oTv = new TipoVehiculo();
                                oTv.Tv_Id = int.Parse(dr["tv_Id"].ToString());
                                oTv.Tv_Descripcion = dr["tv_Descripcion"].ToString();
                                oTv.Tv_Tarifa = decimal.Parse(dr["tv_Tarifa"].ToString());
                                lista_tv.Add(oTv);
                            }
                        }

                    }
                }
            }
            return lista_tv;
        }
    }
}
