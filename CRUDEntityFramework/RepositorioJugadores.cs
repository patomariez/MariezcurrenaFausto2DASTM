using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace CRUDEntityFramework
{
    public class RepositorioJugadores
    {
        private List<Jugador> listaJugadores;
        private string cadena = "Data Source=DESKTOP-7VVF8ST\\SQLEXPRESS;Initial Catalog = CrudTP02; Integrated Security = True; Persist Security Info=False;Pooling=False; Encrypt=False;";

        public RepositorioJugadores()
        {
            listaJugadores = new List<Jugador>();
        }

        public List<Jugador> Listar()
        {
            string query = "select * from Jugadores";

            try
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    SqlCommand comando = new SqlCommand(query, conexion);
                    conexion.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Jugador j = new Jugador();
                        j.Id = reader["Id"];
                        j.Nombre = reader["Nombre"];
                        j.Dorsal = reader["Dorsal"];
                        j.Equipo = reader["Equipo"];

                        listaJugadores.Add(j);
                    }
                    conexion.Close();

                    return listaJugadores;
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error inesperado en la BD: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inesperado: {ex.Message}");
            }
        }

        public string Agregar(Jugador jugador)
        {
            string query = "INSERT INTO Jugadores(Nombre, Dorsal, Equipo) values" + "(@Nombre, @Dorsal, @Equipo)"; //Lo del arroba es la informacion que tengo en el programa, los primeros son de sql
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", jugador.Nombre);
                comando.Parameters.AddWithValue("@Dorsal", jugador.Dorsal);
                comando.Parameters.AddWithValue("@Equipo", jugador.Equipo);

                try
                {
                    conexion.Open();
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    return "Jugador agregado correctamente";
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error inesperado en la BD: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error inesperado: {ex.Message}");
                }
            }
        }

        public string Modificar(Jugador jugador)
        {
            string query = "UPDATE Jugadores SET Nombre = @Nombre, Dorsal = @Dorsal, Equipo = @Equipo WHERE Id = @Id"; ;
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                SqlCommand comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", jugador.Nombre);
                comando.Parameters.AddWithValue("@Dorsal", jugador.Dorsal);
                comando.Parameters.AddWithValue("@Equipo", jugador.Equipo);

                try
                {
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (filasAfectadas > 0)
                        return "Jugador modificado correctamente";
                    else
                        return "No se encontró el jugador a modificar";
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Error inesperado en la BD: {ex.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error inesperado: {ex.Message}");
                }
            }
        }
    }
}
