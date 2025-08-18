using System.Globalization;

namespace Ejercicio02
{
    internal class Program
    {
        private static Empresa empresa;
        static void Main(string[] args)
        {
            empresa = new Empresa();
            Console.WriteLine("=== SISTEMA DE PAQUETES DE CABLE ===");

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
            Console.WriteLine("18. Mostrar Paquete Por Cliente");
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
                        MostrarPaquetePorCliente();
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
            catch (FondosInsuficientesException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (LimiteRetirosExcedidoException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
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
                        Console.WriteLine($"Canal {canal.Nombre} agregado");
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
                          "1. Accion," +
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
            //el id no puede ser 0
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
                        Console.WriteLine($"Serie {serie.Nombre} agregado");
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

        }

        static void ModificarPaquete()
        {

        }

        static void ModificarSerie()
        {

        }

        static void ModificarCanal()
        {

        }

        static void EliminarCliente()
        {

        }

        static void EliminarPaquete()
        {

        }

        static void EliminarSerie()
        {

        }

        static void EliminarCanal()
        {

        }

        static void ListarPaquetes()
        {

        }

        static void ListarClientes()
        {
            Console.WriteLine("\n=== LISTAR CLIENTES ===");
            var clientes = banco.ObtenerTodosLosClientes();

            if (clientes.Count == 0)
            {
                Console.WriteLine("No hay clientes registrados");
                return;
            }

            foreach (var cliente in clientes)
            {
                Console.WriteLine($"DNI: {cliente.Dni}");
                Console.WriteLine($"Nombre completo: {cliente.NombreCompleto}");
                Console.WriteLine($"Teléfono: {cliente.Telefono}");
                Console.WriteLine($"Email: {cliente.Email}");
                Console.WriteLine($"Fecha de nacimiento: {cliente.FechaNacimiento.ToShortDateString()}");
                Console.WriteLine("-----------------------------------------------");
            }
        }

        static void ListarSeries()
        {

        }

        static void ListarCanales()
        {

        }

        static void MostrarPaquetePorCliente()
        {

        }

        static void MostrarTotalRecaudadoMensualmente()
        {

        }

        static void MostrarPaqueteMasVendido()
        {

        }

        static void MostrarSeriesRankingMayor()
        {

        }

    }
}
