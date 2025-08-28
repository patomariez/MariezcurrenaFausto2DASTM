using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TPN1_CRUD
{
    public class TrabajosDB
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

        public List<Trabajo> Obtener()
        {
            List<Trabajo> trabajos = new List<Trabajo>();

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
                        Trabajo trabajo = new Trabajo();
                        trabajo.Id = reader.GetInt32(0);
                        trabajo.Nombre = reader.GetString(1);
                        trabajo.Profesion = reader.GetString(2);

                        trabajos.Add(trabajo);
                    }

                    reader.Close();
                    conexion.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Ocurrió un error en la Base de Datos: {ex.Message}");
                }
            }

            return trabajos;
        }

        public Trabajo ObtenerId(int id)
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

                    Trabajo trabajo = new Trabajo();
                    trabajo.Id = reader.GetInt32(0);
                    trabajo.Nombre = reader.GetString(1);
                    trabajo.Profesion = reader.GetString(2);

                    reader.Close();
                    conexion.Close();

                    return trabajo;
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
