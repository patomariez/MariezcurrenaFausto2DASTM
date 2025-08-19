using System.Globalization;
using static Ejercicio02.Excepcion;

namespace Ejercicio02
{
    internal class Program
    {
        private static Empresa empresa;
        static void Main(string[] args)
        {
            empresa = new Empresa();

            bool continuar = true;

            while (continuar)
            {
                try
                {
                    MostrarMenu();
                    int opcion = LeerOpcion();
                    continuar = ProcesarOpcion(opcion);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inesperado: {ex.Message}");
                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Registrar Cliente");
            Console.WriteLine("2. Agregar Paquete Premium");
            Console.WriteLine("3. Agregar Paquete Silver");
            Console.WriteLine("4. Agregar Serie");
            Console.WriteLine("5. Agregar Canal");
            Console.WriteLine("6. Modificar Cliente");
            Console.WriteLine("7. Modificar Paquete");
            Console.WriteLine("8. Modificar Serie");
            Console.WriteLine("9. Modificar Canal");
            Console.WriteLine("10. Eliminar Cliente");
            Console.WriteLine("11. Eliminar Paquete");
            Console.WriteLine("12. Eliminar Serie");
            Console.WriteLine("13. Eliminar Canal");
            Console.WriteLine("14. Listar Paquetes");
            Console.WriteLine("15. Listar Clientes");
            Console.WriteLine("16. Listar Series");
            Console.WriteLine("17. Listar Canales");
            Console.WriteLine("18. Contratar Paquete (cliente)");
            Console.WriteLine("19. Mostrar Total Recaudado Mensualmente");
            Console.WriteLine("20. Mostrar Paquete Más Vendido");
            Console.WriteLine("21. Mostrar Series de Ranking Mayor a 3.5");
            Console.WriteLine("0. Salir");
            Console.WriteLine();
            Console.Write("Seleccione una opción: ");
        }

        static int LeerOpcion()
        {
            try
            {
                return int.Parse(Console.ReadLine());
            }
            catch
            {
                throw new DatosInvalidosException("Debe ingresar un número válido");
            }
        }

        static bool ProcesarOpcion(int opcion)
        {
            try
            {
                switch (opcion)
                {
                    case 1:
                        RegistrarCliente();
                        break;
                    case 2:
                        AgregarPaquetePremium();
                        break;
                    case 3:
                        AgregarPaqueteSilver();
                        break;
                    case 4:
                        AgregarSerie();
                        break;
                    case 5:
                        AgregarCanal();
                        break;
                    case 6:
                        ModificarCliente();
                        break;
                    case 7:
                        ModificarPaquete();
                        break;
                    case 8:
                        ModificarSerie();
                        break;
                    case 9:
                        ModificarCanal();
                        break;
                    case 10:
                        EliminarCliente();
                        break;
                    case 11:
                        EliminarPaquete();
                        break;
                    case 12:
                        EliminarSerie();
                        break;
                    case 13:
                        EliminarCanal();
                        break;
                    case 14:
                        ListarPaquetes();
                        break;
                    case 15:
                        ListarClientes();
                        break;
                    case 16:
                        ListarSeries();
                        break;
                    case 17:
                        ListarCanales();
                        break;
                    case 18:
                        ContratarPaquete();
                        break;
                    case 19:
                        MostrarTotalRecaudadoMensualmente();
                        break;
                    case 20:
                        MostrarPaqueteMasVendido();
                        break;
                    case 21:
                        MostrarSeriesRankingMayor();
                        break;
                    case 0:
                        Console.WriteLine("Gracias por usar el sistema de paquetes de cable");
                        return false;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente");
                        break;
                }
            }
            catch (ClienteNoRegistradoException ex)
            {
                Console.WriteLine($"Error cliente no registrado: {ex.Message}");
            }
            catch (IdRepetidoException ex)
            {
                Console.WriteLine($"Error ID repetido: {ex.Message}");
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
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            return true;
        }

        static void RegistrarCliente()
        {
            Console.WriteLine("\n=== REGISTRAR CLIENTE ===");
            Console.Write("DNI del cliente: ");
            string dniCliente = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombreCliente = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellidoCliente = Console.ReadLine();

            Console.Write("Fecha de Nacimiento (dd/MM/yyyy): ");
            string fechaNacimiento = Console.ReadLine();

            empresa.AgregarCliente(dniCliente, nombreCliente, apellidoCliente, fechaNacimiento);
        }

        static void AgregarPaquetePremium()
        {
            Console.WriteLine("\n=== AGREGAR PAQUETE PREMIUM ===");
            Console.Write("ID del paquete: ");
            string idPaquete = Console.ReadLine();

            List<Canal> canalesSeleccionados = new List<Canal>();
            int idCanal;

            do
            {
                Console.Write("Indique el Id del canal que incluye (0 para salir): ");
                idCanal = int.Parse(Console.ReadLine());

                if (idCanal != 0)
                {
                    var canal = empresa.BuscarCanalPorId(idCanal);
                    if (canal != null)
                    {
                        canalesSeleccionados.Add(canal);
                        Console.WriteLine($"Canal {canal.Nombre.ToString()} agregado");
                    }
                    else
                    {
                        Console.WriteLine("Canal no encontrado");
                    }
                }

            } while (idCanal != 0);

            empresa.AgregarPaquetePremium(idPaquete, canalesSeleccionados);
        }

        static void AgregarPaqueteSilver()
        {
            Console.WriteLine("\n=== AGREGAR PAQUETE SILVER ===");
            Console.Write("ID del paquete: ");
            string idPaquete = Console.ReadLine();

            List<Canal> canalesSeleccionados = new List<Canal>();
            int idCanal;

            do
            {
                Console.Write("Indique el Id del canal que incluye (0 para salir): ");
                idCanal = int.Parse(Console.ReadLine());

                if (idCanal != 0)
                {
                    var canal = empresa.BuscarCanalPorId(idCanal);
                    if (canal != null)
                    {
                        canalesSeleccionados.Add(canal);
                        Console.WriteLine($"Canal {canal.Nombre} agregado");
                    }
                    else
                    {
                        Console.WriteLine("Canal no encontrado");
                    }
                }

            } while (idCanal != 0);

            empresa.AgregarPaqueteSilver(idPaquete, canalesSeleccionados);
        }

        static void AgregarSerie()
        {
            Console.WriteLine("\n=== AGREGAR SERIE ===");
            Console.Write("ID de la serie: ");
            string idSerie = Console.ReadLine();

            Console.Write("Nombre: ");
            string nombreSerie = Console.ReadLine();

            Console.Write("Cantidad de Temporadas: ");
            string cantTemporadasSerie = Console.ReadLine();

            Console.Write("Cantidad de Episodios: ");
            string cantEpisodiosSerie = Console.ReadLine();

            Console.Write("Duración: ");
            string duracionSerie = Console.ReadLine();

            Console.Write("Ranking (1 - 5): ");
            string rankingSerie = Console.ReadLine();

            Console.Write("Director: ");
            string directorSerie = Console.ReadLine();

            Console.WriteLine("Géneros: " +
                          "1. Accion,\r\n" +
                          "2. Comedia,\r\n            " +
                          "3. Romance,\r\n            " +
                          "4. Drama,\r\n            " +
                          "5. Terror,\r\n            " +
                          "6. Ciencia Ficcion");
            Console.Write("Seleccione el id del género: ");
            string idGenero = Console.ReadLine();

            empresa.AgregarSerie(idSerie, nombreSerie, cantTemporadasSerie, cantEpisodiosSerie, duracionSerie, rankingSerie, idGenero, directorSerie);
        }

        static void AgregarCanal()
        {
            Console.WriteLine("\n=== AGREGAR CANAL ===");
            Console.Write("ID del canal: ");
            string idCanal = Console.ReadLine();

            Console.Write("Nombre del canal: ");
            string nombreCanal = Console.ReadLine();

            List<Serie> seriesSeleccionadas = new List<Serie>();
            int idSerie;

            do
            {
                Console.Write("Indique el Id de la serie que incluye (0 para salir): ");
                idSerie = int.Parse(Console.ReadLine());

                if (idSerie != 0)
                {
                    var serie = empresa.BuscarSeriePorId(idSerie);
                    if (serie != null)
                    {
                        seriesSeleccionadas.Add(serie);
                        Console.WriteLine($"Serie {serie.Nombre} agregada");
                    }
                    else
                    {
                        Console.WriteLine("Serie no encontrada");
                    }
                }

            } while (idSerie != 0);

            empresa.AgregarCanal(idCanal, nombreCanal, seriesSeleccionadas);
        }

        static void ModificarCliente()
        {
            Console.WriteLine("\n=== MODIFICAR CLIENTE ===");
            Console.Write("DNI del cliente a modificar: ");
            string dniCliente = Console.ReadLine();

            Console.Write("Nuevo Nombre: ");
            string nombreCliente = Console.ReadLine();

            Console.Write("Nuevo Apellido: ");
            string apellidoCliente = Console.ReadLine();

            Console.Write("Nueva Fecha de Nacimiento (dd/MM/yyyy): ");
            string fechaNacimiento = Console.ReadLine();

            empresa.ModificarCliente(dniCliente, nombreCliente, apellidoCliente, fechaNacimiento);
        }

        static void ModificarPaquete()
        {
            Console.WriteLine("\n=== MODIFICAR PAQUETE ===");
            Console.Write("ID del paquete a modificar: ");
            string idPaquete = Console.ReadLine();

            List<Canal> canalesSeleccionados = new List<Canal>();
            int idCanal;

            do
            {
                Console.Write("Indique el Id del canal nuevo (0 para salir): ");
                idCanal = int.Parse(Console.ReadLine());

                if (idCanal != 0)
                {
                    var canal = empresa.BuscarCanalPorId(idCanal);
                    if (canal != null)
                    {
                        canalesSeleccionados.Add(canal);
                        Console.WriteLine($"Canal {canal.Nombre} agregado");
                    }
                    else
                    {
                        Console.WriteLine("Canal no encontrado");
                    }
                }

            } while (idCanal != 0);

            empresa.ModificarPaquete(idPaquete, canalesSeleccionados);
        }

        static void ModificarSerie()
        {
            Console.WriteLine("\n=== MODIFICAR SERIE ===");
            Console.Write("ID de la serie a modificar: ");
            string idSerie = Console.ReadLine();

            Console.Write("Nuevo Nombre: ");
            string nombreSerie = Console.ReadLine();

            Console.Write("Nueva Cantidad de Temporadas: ");
            string cantTemporadasSerie = Console.ReadLine();

            Console.Write("Nueva Cantidad de Episodios: ");
            string cantEpisodiosSerie = Console.ReadLine();

            Console.Write("Nueva Duración: ");
            string duracionSerie = Console.ReadLine();

            Console.Write("Nuevo Ranking (1 - 5): ");
            string rankingSerie = Console.ReadLine();

            Console.Write("Nuevo Director: ");
            string directorSerie = Console.ReadLine();

            Console.WriteLine("Géneros: " +
                          "1. Accion,\r\n" +
                          "2. Comedia,\r\n            " +
                          "3. Romance,\r\n            " +
                          "4. Drama,\r\n            " +
                          "5. Terror,\r\n            " +
                          "6. Ciencia Ficcion");
            Console.Write("Seleccione el id del género: ");
            string idGenero = Console.ReadLine();

            empresa.ModificarSerie(idSerie, nombreSerie, cantTemporadasSerie, cantEpisodiosSerie, duracionSerie, rankingSerie, idGenero, directorSerie);
        }

        static void ModificarCanal()
        {
            Console.WriteLine("\n=== MODIFICAR CANAL ===");
            Console.Write("ID del canal a modificar: ");
            string idCanal = Console.ReadLine();

            Console.Write("Nuevo Nombre del canal: ");
            string nombreCanal = Console.ReadLine();

            List<Serie> seriesSeleccionadas = new List<Serie>();
            int idSerie;

            do
            {
                Console.Write("Indique el Id de la serie nueva (0 para salir): ");
                idSerie = int.Parse(Console.ReadLine());

                if (idSerie != 0)
                {
                    var serie = empresa.BuscarSeriePorId(idSerie);
                    if (serie != null)
                    {
                        seriesSeleccionadas.Add(serie);
                        Console.WriteLine($"Serie {serie.Nombre} agregada");
                    }
                    else
                    {
                        Console.WriteLine("Serie no encontrada");
                    }
                }

            } while (idSerie != 0);

            empresa.ModificarCanal(idCanal, nombreCanal, seriesSeleccionadas);
        }

        static void EliminarCliente()
        {
            Console.WriteLine("\n=== ELIMINAR CLIENTE ===");
            Console.Write("DNI del cliente: ");
            string dniCliente = Console.ReadLine();

            empresa.EliminarCliente(dniCliente);
        }

        static void EliminarPaquete()
        {
            Console.WriteLine("\n=== ELIMINAR PAQUETE ===");
            Console.Write("ID del paquete: ");
            string idPaquete = Console.ReadLine();

            empresa.EliminarPaquete(idPaquete);
        }

        static void EliminarSerie()
        {
            Console.WriteLine("\n=== ELIMINAR SERIE ===");
            Console.Write("ID de la serie: ");
            string idSerie = Console.ReadLine();

            empresa.EliminarSerie(idSerie);
        }

        static void EliminarCanal()
        {
            Console.WriteLine("\n=== ELIMINAR CANAL ===");
            Console.Write("ID del canal: ");
            string idCanal = Console.ReadLine();

            empresa.EliminarCanal(idCanal);
        }

        static void ListarPaquetes()
        {
            Console.WriteLine("\n=== LISTAR PAQUETES ===");

            var paquetes = empresa.ListarPaquetes();

            if (paquetes.Count == 0)
            {
                Console.WriteLine("No hay paquetes registrados");
                return;
            }

            foreach (var paquete in paquetes)
            {
                Console.WriteLine($"Paquete ID {paquete.Id} - Tipo: {paquete.Tipo()} - Precio: {paquete.CalcularPrecio().ToString()}" +
                    $"  Canales incluidos: ");

                foreach (var canal in paquete.Canales)
                {
                    Console.WriteLine($"        Canal {canal.Id} - {canal.Nombre}" +
                        $"          Series incluidas: ");

                    foreach (var serie in canal.Series)
                    {
                        Console.WriteLine($"                Serie {serie.Id} - {serie.Nombre} - Temporadas: {serie.CantidadTemporadas} - Episodios: {serie.Episodios}");
                    }
                  
                }
            }
        }

        static void ListarClientes()
        {
            Console.WriteLine("\n=== LISTAR CLIENTES ===");
            var clientes = empresa.ListarClientes();

            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados");
                return;
            }

            foreach (var cliente in clientes)
            {
                Console.WriteLine($"DNI: {cliente.Dni}");
                Console.WriteLine($"Nombre: {cliente.Nombre}");
                Console.WriteLine($"Apellido: {cliente.Apellido}");
                Console.WriteLine($"Fecha de nacimiento: {cliente.FechaNacimiento.ToShortDateString()}");

                if (cliente.PaqueteContratado != null)
                {
                    Console.WriteLine($"Paquete Contratado: {cliente.PaqueteContratado.Tipo}");
                }

                Console.WriteLine("-----------------------------------------------");
            }
        }

        static void ListarSeries()
        {
            Console.WriteLine("\n=== LISTAR SERIES ===");
            var series = empresa.ListarSeries();

            if (series.Count == 0)
            {
                Console.WriteLine("No hay series registradas");
                return;
            }

            foreach (var serie in series)
            {
                Console.WriteLine($"ID: {serie.Id}");
                Console.WriteLine($"Nombre: {serie.Nombre}");
                Console.WriteLine($"Temporadas: {serie.CantidadTemporadas}");
                Console.WriteLine($"Episodios: {serie.Episodios}");
                Console.WriteLine($"Duración: {serie.Duracion}");
                Console.WriteLine($"Ranking: {serie.Ranking}");
                Console.WriteLine($"Director: {serie.Director}");
                Console.WriteLine($"Género: {serie.TipoGenero}");
                Console.WriteLine("-----------------------------------------------");
            }
        }

        static void ListarCanales()
        {
            Console.WriteLine("\n=== LISTAR CANALES ===");
            var canales = empresa.ListarCanales();

            if (canales.Count == 0)
            {
                Console.WriteLine("No hay canales registrados");
                return;
            }

            foreach (var canal in canales)
            {
                Console.WriteLine($"ID: {canal.Id}");
                Console.WriteLine($"Nombre: {canal.Nombre}");
                Console.WriteLine($"Series Incluidas: ");

                foreach (var serie in canal.Series)
                {
                    Console.WriteLine($"    Serie {serie.Id} - {serie.Nombre} - Temporadas: {serie.CantidadTemporadas} - Episodios: {serie.Episodios}");
                }
                Console.WriteLine("-----------------------------------------------");
            }
        }

        static void ContratarPaquete()
        {
            Console.WriteLine("\n=== CONTRATAR PAQUETE ===");
            Console.Write("DNI del cliente: ");
            string dniCliente = Console.ReadLine();

            Console.Write("ID del paquete a contratar: ");
            string idPaquete = Console.ReadLine();

            empresa.ContratarPaquete(dniCliente, idPaquete);
        }

        static void MostrarTotalRecaudadoMensualmente()
        {
            Console.WriteLine("\n=== TOTAL RECAUDADO MENSUALMENTE ===");
            empresa.MostrarTotalRecaudadoPorMes();
        }

        static void MostrarPaqueteMasVendido()
        {
            Console.WriteLine("\n=== PAQUETE MAS VENDIDO ===");
            empresa.MostrarPaqueteMasVendido();
        }

        static void MostrarSeriesRankingMayor()
        {
            Console.WriteLine("\n=== SERIES CON RANKING MAYOR A 3.5 ===");
            var seriesRankingMayor = empresa.MostrarSeriesRankingMayor();

            foreach (var serie in seriesRankingMayor)
            {
                Console.WriteLine($"ID: {serie.Id}");
                Console.WriteLine($"Nombre: {serie.Nombre}");
                Console.WriteLine($"Serie: {serie.CantidadTemporadas}");
                Console.WriteLine($"Episodios: {serie.Episodios}");
                Console.WriteLine($"Duración: {serie.Duracion}");
                Console.WriteLine($"Ranking: {serie.Ranking}");
                Console.WriteLine($"Director: {serie.Director}");
                Console.WriteLine($"Género: {serie.TipoGenero}");
                Console.WriteLine("-----------------------------------------------");
            }
        }

    }
}
