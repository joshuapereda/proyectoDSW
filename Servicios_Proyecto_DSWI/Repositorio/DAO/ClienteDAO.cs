using System.Data; 
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.Data.SqlClient;
using S05LaboratorioDSWI_01.Repositorio.Interfaces;
using Servicios_Proyecto_DSWI.Models;

namespace S05LaboratorioDSWI_01.Repositorio.DAO
{
    public class ClienteDAO : ICliente
    {
        private  readonly string cadena;
        public ClienteDAO()
        {
            cadena = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sql");
        }


        public IEnumerable<Cliente> obtenerClientes()
        {
            List<Cliente> lstClientes = new List<Cliente>();
            SqlConnection cn = new SqlConnection(cadena);

            //Definimos un SqlCommand y su CommandType 
            SqlCommand cmd = new SqlCommand("ListarClientes", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            //Abrimos conexión
            cn.Open();
            //Ejecutamos el SqlCommand
            SqlDataReader dr = cmd.ExecuteReader();
            //Recuperamos los valores del SqlDataReader
            while (dr.Read())
            {
                Cliente reg = new Cliente();

                reg.IdCliente = dr.GetInt32("ID_Cliente");
                reg.Nombre = dr.GetString("Nombre");
                reg.Apellido = dr.GetString("Apellido");
                reg.Email = dr.GetString("Email");
                reg.Telefono = dr.GetString("Telefono");

                lstClientes.Add(reg);
            }
            //Cerramos el SqlDataReader y la conexión a la BD
            dr.Close();
            cn.Close();

            return lstClientes;
        }

        public string actualizarCliente(Cliente reg)
        {
            SqlConnection cn = new SqlConnection(cadena);


            int resultado = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("ActualizarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agregamos parámetros
                cmd.Parameters.AddWithValue("@ID_Cliente", reg.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", reg.Apellido);
                cmd.Parameters.AddWithValue("@Email", reg.Email);
                cmd.Parameters.AddWithValue("@Telefono", reg.Telefono);

                //Ejecutamos el SqlCommand
                resultado = cmd.ExecuteNonQuery();

                mensaje = "actializacion exitosa - cantidad de filas actualizadas " + resultado;


            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;

            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }

        public string eliminarCliente(string id)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";

            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("EliminarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID_Cliente", id);

                resultado = cmd.ExecuteNonQuery();

                mensaje = "eliminacion exitosa - cantidad de filas eliminadas " + resultado;

            }
            catch (SqlException ex)
            {
                mensaje += ex.Message;
            }
            finally
            {
                cn.Close();
            }


            return mensaje;
        }


        public string registrarCliente(Cliente reg)
        {
            SqlConnection cn = new SqlConnection(cadena);

            int resultado = 0;
            string mensaje = "";
            cn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("InsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //Agregamos parámetros
                cmd.Parameters.AddWithValue("@ID_Cliente", reg.IdCliente);
                cmd.Parameters.AddWithValue("@Nombre", reg.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", reg.Apellido);
                cmd.Parameters.AddWithValue("@Email", reg.Email);
                cmd.Parameters.AddWithValue("@Telefono", reg.Telefono);

                //Ejecutamos el SqlCommand
                resultado = cmd.ExecuteNonQuery();

                mensaje = "registro exitosa - cantidad de filas registradas " + resultado;
            }
            catch (SqlException ex)
            {
                mensaje = ex.Message;

            }
            finally
            {
                cn.Close();
            }

            return mensaje;
        }
    }
}
