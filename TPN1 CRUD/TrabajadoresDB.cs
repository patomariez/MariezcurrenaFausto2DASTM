using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TPN1_CRUD
{
    public class TrabajadoresDB
    {
        private string conexionString = "Data Source=DESKTOP-7VVF8ST\\SQLEXPRESS;Initial Catalog=CrudTP02;Integrated Security=True";

        public bool Conectado()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(conexionString);
                conexion.Open();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public List<Trabajador> Obtener()
        {
            List<Trabajador> trabajadores = new List<Trabajador>();

            string consulta = "select ID,Nombre,Profesion from Trabajadores";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Trabajador trabajador = new Trabajador();
                        trabajador.Id = reader.GetInt32(0);
                        trabajador.Nombre = reader.GetString(1);
                        trabajador.Profesion = reader.GetString(2);

                        trabajadores.Add(trabajador);
                    }

                    reader.Close();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocurrió un error en la Base de Datos: {ex.Message}");
                }
            }

            return trabajadores;
        }

        public Trabajador ObtenerId(int id)
        {
            string consulta = "select ID,Nombre,Profesion from Trabajadores where ID=@ID";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@ID", id);

                try
                {
                    conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();

                    reader.Read();

                    Trabajador trabajador = new Trabajador();
                    trabajador.Id = reader.GetInt32(0);
                    trabajador.Nombre = reader.GetString(1);
                    trabajador.Profesion = reader.GetString(2);

                    reader.Close();
                    conexion.Close();

                    return trabajador;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocurrió un error en la Base de Datos: {ex.Message}");
                }
            }
        }

        public void Agregar(string nombre, string profesion)
        {
            string consulta = "insert into Trabajadores(Nombre, Profesion) values (@Nombre, @Profesion)";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Profesion", profesion);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocurrió un error en la Base de Datos: {ex.Message}");
                }
            }
        }

        public void Editar(string nombre, string profesion, int id)
        {
            string consulta = "update Trabajadores set Nombre=@Nombre, Profesion=@Profesion where ID=@ID";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Profesion", profesion);
                comando.Parameters.AddWithValue("@ID", id);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocurrió un error en la Base de Datos: {ex.Message}");
                }
            }
        }

        public void Eliminar(int id)
        {
            string consulta = "delete from Trabajadores where ID=@ID";

            using (SqlConnection conexion = new SqlConnection(conexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@ID", id);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocurrió un error en la Base de Datos: {ex.Message}");
                }
            }
        }

    }
}
