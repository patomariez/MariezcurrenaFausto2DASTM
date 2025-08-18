using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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

        public void EliminarCanal(int idCanal)
        {
            repositorioCanales.Eliminar(idCanal);
        }

        public void EliminarCliente(int dniCliente)
        {
            repositorioClientes.Eliminar(dniCliente);
        }

        public void EliminarPaquete(int idPaquete)
        {
            repositorioPaquetes.Eliminar(idPaquete);
        }

        public void EliminarSerie(int idSerie)
        {
            repositorioSeries.Eliminar(idSerie);
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

        public Canal BuscarCanalPorId(int idCanal)
        {
            return repositorioCanales.Buscar(idCanal);
        }

        public Serie BuscarSeriePorId(int idSerie)
        {
            return repositorioSeries.Buscar(idSerie);
        }

        public Producto BuscarProductoPorId(int id)
        {
            return repositorioProductos.Buscar(id);
        }

        public List<Producto> FiltrarProductosPorRubro(string nombreRubro)
        {
            return repositorioProductos.FiltrarProductosPorRubro(nombreRubro);
        }

        public Proveedor BuscarProveedorPorNombre(string nombre)
        {
            return repositorioProveedores.BuscarProveedorPorNombre(nombre);
        }

        public Proveedor BuscarProveedorPorId(int id)
        {
            return repositorioProveedores.Buscar(id);
        }

        public Rubro BuscarRubroPorId(int id)
        {
            return repositorioRubros.Buscar(id);
        }

        public List<Movimiento> ListarMovimientos()
        {
            return repositorioMovimientos.ListarTodos();
        }
    }
}
