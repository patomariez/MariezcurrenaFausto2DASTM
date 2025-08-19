using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio02.Excepcion;

namespace Ejercicio02
{
    public class Empresa
    {
        private RepositorioCanales repositorioCanales;
        private RepositorioClientes repositorioClientes;
        private RepositorioPaquetes repositorioPaquetes;
        private RepositorioSeries repositorioSeries;

        public Empresa()
        {
            repositorioCanales = new RepositorioCanales();
            repositorioClientes = new RepositorioClientes();
            repositorioPaquetes = new RepositorioPaquetes();
            repositorioSeries = new RepositorioSeries();
        }

        public void AgregarCanal(string id, string nombre, List<Serie> series)
        {
            try
            {
                if (!int.TryParse(id, out int idCanal))
                    throw new DatosInvalidosException("El valor del id no es válido");

                if (string.IsNullOrEmpty(nombre))
                    throw new DatosInvalidosException("El nombre no puede estar vacío");

                if (series.Count == 0)
                    throw new DatosInvalidosException("La lista de series no puede estar vacía");

                Canal canalNuevo = new Canal();
                canalNuevo.Id = idCanal;
                canalNuevo.Nombre = nombre;
                canalNuevo.Series = series;

                repositorioCanales.Agregar(canalNuevo);
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error agregando canal: {ex.Message}");
            }
        }

        public void AgregarCliente(string dni, string nombre, string apellido, string fechaNacimiento)
        {
            try
            {
                if (!int.TryParse(dni, out int dniCliente))
                    throw new DatosInvalidosException("El valor del dni no es válido");

                if (string.IsNullOrEmpty(nombre))
                    throw new DatosInvalidosException("El nombre no puede estar vacío");

                if (string.IsNullOrEmpty(apellido))
                    throw new DatosInvalidosException("El email no puede estar vacío");

                if (!DateTime.TryParse(fechaNacimiento, out DateTime fechaNacimientoCliente))
                    throw new DatosInvalidosException("La fecha de nacimiento no es válido");

                Cliente clienteNuevo = new Cliente();
                clienteNuevo.Dni = dniCliente;
                clienteNuevo.Nombre = nombre;
                clienteNuevo.Apellido = apellido;
                clienteNuevo.FechaNacimiento = fechaNacimientoCliente;

                repositorioClientes.Agregar(clienteNuevo);
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error agregando cliente: {ex.Message}");
            }
        }

        public void AgregarPaquetePremium(string id, List<Canal> canales)
        {
            try
            {
                if (!int.TryParse(id, out int idPaquete))
                    throw new DatosInvalidosException("El valor del id no es válido");

                if (canales.Count == 0)
                    throw new DatosInvalidosException("La lista de canales no puede estar vacía");

                PaquetePremium paqueteNuevo = new PaquetePremium();
                paqueteNuevo.Id = idPaquete;
                paqueteNuevo.Canales = canales;

                repositorioPaquetes.Agregar(paqueteNuevo);
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error agregando paquete premium: {ex.Message}");
            }
        }

        public void AgregarPaqueteSilver(string id, List<Canal> canales)
        {
            try
            {
                if (!int.TryParse(id, out int idPaquete))
                    throw new DatosInvalidosException("El valor del id no es válido");

                if (canales.Count == 0)
                    throw new DatosInvalidosException("La lista de canales no puede estar vacía");

                PaqueteSilver paqueteNuevo = new PaqueteSilver();
                paqueteNuevo.Id = idPaquete;
                paqueteNuevo.Canales = canales;

                repositorioPaquetes.Agregar(paqueteNuevo);
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error agregando paquete silver: {ex.Message}");
            }
        }

        public void AgregarSerie(string id, string nombre, string cantidadTemporadas, string episodios, string duracion, string ranking, string idGenero, string director)
        {
            try
            {
                if (!int.TryParse(id, out int idSerie))
                    throw new DatosInvalidosException("El valor del id no es válido");

                if (idSerie == 0)
                    throw new DatosInvalidosException("El id de la serie no puede ser cero");

                if (string.IsNullOrEmpty(nombre))
                    throw new DatosInvalidosException("El nombre no puede estar vacío");

                if (!int.TryParse(cantidadTemporadas, out int cantidadTemporadasSerie))
                    throw new DatosInvalidosException("La cantidad de temporadas no es válida");

                if (!int.TryParse(episodios, out int cantidadEpisodios))
                    throw new DatosInvalidosException("La cantidad de episodios no es válida");

                if (!decimal.TryParse(duracion, out decimal duracionSerie))
                    throw new DatosInvalidosException("La duración no es válida");

                if (!decimal.TryParse(ranking, out decimal rankingSerie))
                    throw new DatosInvalidosException("El ranking no es válido");

                if (rankingSerie < 1 || rankingSerie > 5)
                    throw new DatosInvalidosException("El ranking debe estar entre 1 y 5");

                if (!int.TryParse(idGenero, out int idGeneroSerie))
                    throw new DatosInvalidosException("El id del género no es válido");

                if (string.IsNullOrEmpty(director))
                    throw new DatosInvalidosException("El director no puede estar vacío");

                Serie serieNueva = new Serie();
                serieNueva.Id = idSerie;
                serieNueva.Nombre = nombre;
                serieNueva.CantidadTemporadas = cantidadTemporadasSerie;
                serieNueva.Episodios = cantidadEpisodios;
                serieNueva.Duracion = duracionSerie;
                serieNueva.Ranking = rankingSerie;
                serieNueva.Director = director;

                if (idGeneroSerie == 1)
                {
                    serieNueva.TipoGenero = Serie.Genero.Accion;
                }
                else if (idGeneroSerie == 2)
                {
                    serieNueva.TipoGenero = Serie.Genero.Comedia;
                }
                else if (idGeneroSerie == 3)
                {
                    serieNueva.TipoGenero = Serie.Genero.Romance;
                }
                else if (idGeneroSerie == 4)
                {
                    serieNueva.TipoGenero = Serie.Genero.Drama;
                }
                else if (idGeneroSerie == 5)
                {
                    serieNueva.TipoGenero = Serie.Genero.Terror;
                }
                else if (idGeneroSerie == 6)
                {
                    serieNueva.TipoGenero = Serie.Genero.CienciaFiccion;
                }
                else
                {
                    throw new DatosInvalidosException("El id del género debe estar entre 1 y 6");
                }
                    repositorioSeries.Agregar(serieNueva);
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error agregando serie: {ex.Message}");
            }
        }

        public void ModificarCliente(string dni, string nombre, string apellido, string fechaNacimiento)
        {
            try
            {
                if (!int.TryParse(dni, out int dniCliente))
                    throw new DatosInvalidosException("El valor del dni no es válido");

                if (string.IsNullOrEmpty(nombre))
                    throw new DatosInvalidosException("El nombre no puede estar vacío");

                if (string.IsNullOrEmpty(apellido))
                    throw new DatosInvalidosException("El email no puede estar vacío");

                if (!DateTime.TryParse(fechaNacimiento, out DateTime fechaNacimientoCliente))
                    throw new DatosInvalidosException("La fecha de nacimiento no es válido");

                Cliente clienteNuevo = new Cliente();
                clienteNuevo.Dni = dniCliente;
                clienteNuevo.Nombre = nombre;
                clienteNuevo.Apellido = apellido;
                clienteNuevo.FechaNacimiento = fechaNacimientoCliente;

                repositorioClientes.Modificar(clienteNuevo);
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error modificando cliente: {ex.Message}");
            }
        }

        public void ModificarPaquete(string id, List<Canal> canales)
        {
            try
            {
                if (!int.TryParse(id, out int idPaquete))
                    throw new DatosInvalidosException("El valor del id no es válido");

                if (canales.Count == 0)
                    throw new DatosInvalidosException("La lista de canales no puede estar vacía");

                PaquetePremium paqueteNuevo = new PaquetePremium();
                paqueteNuevo.Id = idPaquete;
                paqueteNuevo.Canales = canales;

                repositorioPaquetes.Modificar(paqueteNuevo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error modificando paquete: {ex.Message}");
            }
        }

        public void ModificarSerie(string id, string nombre, string cantidadTemporadas, string episodios, string duracion, string ranking, string idGenero, string director)
        {
            try
            {
                if (!int.TryParse(id, out int idSerie))
                    throw new DatosInvalidosException("El valor del id no es válido");

                if (idSerie == 0)
                    throw new DatosInvalidosException("El id de la serie no puede ser cero");

                if (string.IsNullOrEmpty(nombre))
                    throw new DatosInvalidosException("El nombre no puede estar vacío");

                if (!int.TryParse(cantidadTemporadas, out int cantidadTemporadasSerie))
                    throw new DatosInvalidosException("La cantidad de temporadas no es válida");

                if (!int.TryParse(episodios, out int cantidadEpisodios))
                    throw new DatosInvalidosException("La cantidad de episodios no es válida");

                if (!decimal.TryParse(duracion, out decimal duracionSerie))
                    throw new DatosInvalidosException("La duración no es válida");

                if (!decimal.TryParse(ranking, out decimal rankingSerie))
                    throw new DatosInvalidosException("El ranking no es válido");

                if (rankingSerie < 1 || rankingSerie > 5)
                    throw new DatosInvalidosException("El ranking debe estar entre 1 y 5");

                if (!int.TryParse(idGenero, out int idGeneroSerie))
                    throw new DatosInvalidosException("El id del género no es válido");

                if (string.IsNullOrEmpty(director))
                    throw new DatosInvalidosException("El director no puede estar vacío");

                Serie serieNueva = new Serie();
                serieNueva.Id = idSerie;
                serieNueva.Nombre = nombre;
                serieNueva.CantidadTemporadas = cantidadTemporadasSerie;
                serieNueva.Episodios = cantidadEpisodios;
                serieNueva.Duracion = duracionSerie;
                serieNueva.Ranking = rankingSerie;
                serieNueva.Director = director;

                if (idGeneroSerie == 1)
                {
                    serieNueva.TipoGenero = Serie.Genero.Accion;
                }
                else if (idGeneroSerie == 2)
                {
                    serieNueva.TipoGenero = Serie.Genero.Comedia;
                }
                else if (idGeneroSerie == 3)
                {
                    serieNueva.TipoGenero = Serie.Genero.Romance;
                }
                else if (idGeneroSerie == 4)
                {
                    serieNueva.TipoGenero = Serie.Genero.Drama;
                }
                else if (idGeneroSerie == 5)
                {
                    serieNueva.TipoGenero = Serie.Genero.Terror;
                }
                else if (idGeneroSerie == 6)
                {
                    serieNueva.TipoGenero = Serie.Genero.CienciaFiccion;
                }
                else
                {
                    throw new DatosInvalidosException("El id del género debe estar entre 1 y 6");
                }
                repositorioSeries.Modificar(serieNueva);
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error modificando serie: {ex.Message}");
            }
        }

        public void ModificarCanal(string id, string nombre, List<Serie> series)
        {
            try
            {
                if (!int.TryParse(id, out int idCanal))
                    throw new DatosInvalidosException("El valor del id no es válido");

                if (string.IsNullOrEmpty(nombre))
                    throw new DatosInvalidosException("El nombre no puede estar vacío");

                if (series.Count == 0)
                    throw new DatosInvalidosException("La lista de series no puede estar vacía");

                Canal canalNuevo = new Canal();
                canalNuevo.Id = idCanal;
                canalNuevo.Nombre = nombre;
                canalNuevo.Series = series;

                repositorioCanales.Modificar(canalNuevo);
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error modificando canal: {ex.Message}");
            }
        }
        
        public void EliminarCanal(string idCanal)
        {
            try
            {
                if (!int.TryParse(idCanal, out int idCanalInt))
                    throw new DatosInvalidosException("El valor del id no es válido");

                var canal = repositorioCanales.Buscar(idCanalInt);

                if (canal == null)
                {
                    throw new ObjetoNoEncontradoException("No se encontró ningún canal con ese ID");
                }

                repositorioCanales.Eliminar(idCanalInt);
            }
            catch (ObjetoNoEncontradoException ex)
            {
                Console.WriteLine($"Error de objeto no encontrado: {ex.Message}");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar canal: {ex.Message}");
            }
        }

        public void EliminarCliente(string dniCliente)
        {
            try
            {
                if (!int.TryParse(dniCliente, out int dniClienteInt))
                    throw new DatosInvalidosException("El valor del dni no es válido");

                var cliente = repositorioClientes.Buscar(dniClienteInt);

                if (cliente == null)
                    throw new ObjetoNoEncontradoException("No se encontró ningún cliente con ese DNI");

                repositorioClientes.Eliminar(dniClienteInt);
            }
            catch (ObjetoNoEncontradoException ex)
            {
                Console.WriteLine($"Error de objeto no encontrado: {ex.Message}");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar cliente: {ex.Message}");
            }
        }

        public void EliminarPaquete(string idPaquete)
        {
            try
            {
                if (!int.TryParse(idPaquete, out int idPaqueteInt))
                    throw new DatosInvalidosException("El valor del id no es válido");

                var paquete = repositorioPaquetes.Buscar(idPaqueteInt);

                if (paquete == null)
                    throw new ObjetoNoEncontradoException("No se encontró ningún paquete con ese ID");

                repositorioPaquetes.Eliminar(idPaqueteInt);
            }
            catch (ObjetoNoEncontradoException ex)
            {
                Console.WriteLine($"Error de objeto no encontrado: {ex.Message}");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar paquete: {ex.Message}");
            }
        }

        public void EliminarSerie(string idSerie)
        {
            try
            {
                if (!int.TryParse(idSerie, out int idSerieInt))
                    throw new DatosInvalidosException("El valor del id no es válido");

                var serie = repositorioSeries.Buscar(idSerieInt);

                if (serie == null)
                    throw new ObjetoNoEncontradoException("No se encontró ninguna serie con ese ID");

                repositorioSeries.Eliminar(idSerieInt);
            }
            catch (ObjetoNoEncontradoException ex)
            {
                Console.WriteLine($"Error de objeto no encontrado: {ex.Message}");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar serie: {ex.Message}");
            }
        }

        public List<Canal> ListarCanales()
        {
            return repositorioCanales.ListarTodos();
        }

        public List<Cliente> ListarClientes()
        {
            return repositorioClientes.ListarTodos();
        }

        public List<Paquete> ListarPaquetes()
        {
            return repositorioPaquetes.ListarTodos();
        }

        public List<Serie> ListarSeries()
        {
            return repositorioSeries.ListarTodos();
        }

        public void ContratarPaquete(string dniCliente, string idPaquete)
        {
            try
            {
                if (!int.TryParse(dniCliente, out int dniClienteInt))
                    throw new DatosInvalidosException("El valor del dni no es válido");

                if (!int.TryParse(idPaquete, out int idPaqueteInt))
                    throw new DatosInvalidosException("El valor del id de paquete no es válido");

                var paquete = repositorioPaquetes.Buscar(idPaqueteInt);

                if (paquete == null)
                {
                    throw new ObjetoNoEncontradoException("No se encontró ningún paquete con ese ID");
                }

                var cliente = repositorioClientes.Buscar(dniClienteInt);

                if (cliente == null)
                {
                    throw new ObjetoNoEncontradoException("No se encontró ningún cliente con ese DNI");
                }

                cliente.PaqueteContratado = paquete;
                paquete.ContadorVentas++;

                Console.WriteLine($"Paquete {paquete.Id} contratado exitosamente por {cliente.Nombre} {cliente.Apellido}");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (ObjetoNoEncontradoException ex)
            {
                Console.WriteLine($"Error objeto no encontrado: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error contratando paquete: {ex.Message}");
            }
        }

        public Canal BuscarCanalPorId(int idCanal)
        {
            return repositorioCanales.Buscar(idCanal);
        }

        public Serie BuscarSeriePorId(int idSerie)
        {
            return repositorioSeries.Buscar(idSerie);
        }
        
        public void MostrarTotalRecaudadoPorMes()
        {
            var clientes = repositorioClientes.ListarTodos();

            decimal totalRecaudado = 0;

            foreach (var cliente in clientes)
            {
                totalRecaudado += cliente.PaqueteContratado.CalcularPrecio();
            }

            Console.WriteLine($"El total recaudado este mes por la empresa fue de ${totalRecaudado}");
        }

        public void MostrarPaqueteMasVendido()
        {
            var paquetes = repositorioPaquetes.ListarTodos();

            if (paquetes.Count == 0)
            {
                Console.WriteLine("No hay paquetes para mostrar");
                return;
            }

            var paqueteMasVendido = paquetes[0];

            foreach (var paquete in paquetes)
            {
                if (paquete.ContadorVentas > paqueteMasVendido.ContadorVentas)
                {
                    paqueteMasVendido = paquete;
                }
            }

            Console.WriteLine($"El paquete más vendido es el ID {paqueteMasVendido.Id} con {paqueteMasVendido.ContadorVentas} ventas");
        }

        public List<Serie> MostrarSeriesRankingMayor()
        {
            var series = repositorioSeries.ListarTodos();

            List<Serie> seriesRankingMayor = new List<Serie>();
            
            foreach (var serie in series)
            {
                if (serie.Ranking > 3.5m)
                {
                    seriesRankingMayor.Add(serie);
                }
            }

            return seriesRankingMayor;
        }
    }
}
