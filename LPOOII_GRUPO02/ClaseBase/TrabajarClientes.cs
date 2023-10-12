using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace ClaseBase
{
    public class TrabajarClientes
    {

        //Metodo para listar todos los clientes de la base de datos
        public static List<Cliente> traer_clientes()
        {
            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection cn = new SqlConnection(ClaseBase.Properties.Settings.Default.playaConnectionString))
            {
                cn.Open();
                using(var cmd = cn.CreateCommand())
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.CommandText="listar_clientes";
                
                    using (DbDataReader dr = cmd.ExecuteReader())
                    {
                        if(dr.HasRows){
                            while(dr.Read()){
                                Cliente oCliente = new Cliente();
                                oCliente.Cli_Id = int.Parse(dr["cli_Id"].ToString());
                                oCliente.Cli_Apellido = dr["cli_Apellido"].ToString();
                                oCliente.Cli_Nombre = dr["cli_Nombre"].ToString();
                                oCliente.Cli_DNI = long.Parse(dr["cli_DNI"].ToString());
                                oCliente.Cli_Telefono = long.Parse(dr["cli_Telefono"].ToString());
                                clientes.Add(oCliente);
                            }
                        }

                    }
                  
                }
                
            }

          return clientes;
        }
        // otra forma v2 de listar datos
        public DataTable TraerClientes()
        {
            using (DataTable dt = new DataTable())
            {
                using (SqlConnection cn = new SqlConnection(ClaseBase.Properties.Settings.Default.playaConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listar_clientes", cn)) // Nombre del procedimiento almacenado
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // Establece el tipo de comando como procedimiento almacenado

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return dt;
            }
        }

        public static void alta_cliente(Cliente cliente)
        {
            using (SqlConnection cn = new SqlConnection(ClaseBase.Properties.Settings.Default.playaConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("alta_cliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", cliente.Cli_Nombre);
                    cmd.Parameters.AddWithValue("@apellido", cliente.Cli_Apellido);
                    cmd.Parameters.AddWithValue("@dni", cliente.Cli_DNI);
                    cmd.Parameters.AddWithValue("@telefono", cliente.Cli_Telefono);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        public static void modificar_cliente(Cliente cliente)
        {
            using (SqlConnection cn = new SqlConnection(ClaseBase.Properties.Settings.Default.playaConnectionString))
            {
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("modificar_cliente", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", cliente.Cli_Id);
                    cmd.Parameters.AddWithValue("@NuevoApellido", cliente.Cli_Apellido);
                    cmd.Parameters.AddWithValue("@NuevoNombre", cliente.Cli_Nombre);
                    cmd.Parameters.AddWithValue("@NuevoDNI", cliente.Cli_DNI);
                    cmd.Parameters.AddWithValue("@NuevoTelefono", cliente.Cli_Telefono);
                    cmd.ExecuteNonQuery();
                }
            }
        }


         
    }
}
