using System.Globalization;
using System.Net;
using static Ejercicio01.Excepcion;

namespace Ejercicio01
{
    internal class Program
    {
        private static Banco banco;

        static void Main(string[] args)
        {
            banco = new Banco();
            Console.WriteLine("=== SISTEMA BANCARIO ===");

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
            Console.WriteLine("2. Modificar Cliente");
            Console.WriteLine("3. Eliminar Cliente");
            Console.WriteLine("4. Crear Cuenta Corriente");
            Console.WriteLine("5. Crear Caja de Ahorro");
            Console.WriteLine("6. Realizar Depósito");
            Console.WriteLine("7. Realizar Retiro");
            Console.WriteLine("8. Listar Todos los Clientes");
            Console.WriteLine("9. Listar Todas las Cuentas");
            Console.WriteLine("10. Buscar Cliente Por Dni");
            Console.WriteLine("11. Buscar Cliente Por Nombre");
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
                        ModificarCliente();
                        break;
                    case 3:
                        EliminarCliente();
                        break;
                    case 4:
                        CrearCuentaCorriente();
                        break;
                    case 5:
                        CrearCajaAhorro();
                        break;
                    case 6:
                        RealizarDeposito();
                        break;
                    case 7:
                        RealizarRetiro();
                        break;
                    case 8:
                        ListarClientes();
                        break;
                    case 9:
                        ListarCuentas();
                        break;
                    case 10:
                        BuscarClientePorDni();
                        break;
                    case 11:
                        BuscarClientePorNombre();
                        break;
                    case 0:
                        Console.WriteLine("Gracias por usar el sistema bancario");
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

            Console.Write("Nombre Completo: ");
            string nombreCliente = Console.ReadLine();

            Console.Write("Teléfono: ");
            string telefonoCliente = Console.ReadLine();

            Console.Write("Email: ");
            string emailCliente = Console.ReadLine();

            Console.Write("Fecha de Nacimiento (dd/MM/yyyy): ");
            string fechaNacimiento = Console.ReadLine();

            banco.RegistrarCliente(dniCliente, nombreCliente, telefonoCliente, emailCliente, fechaNacimiento);
        }

        static void ModificarCliente()
        {
            Console.WriteLine("\n=== MODIFICAR CLIENTE ===");
            Console.Write("DNI del cliente a modificar: ");
            string dniCliente = Console.ReadLine();

            Console.Write("Nuevo Nombre Completo: ");
            string nombreCliente = Console.ReadLine();

            Console.Write("Nuevo Teléfono: ");
            string telefonoCliente = Console.ReadLine();

            Console.Write("Nuevo Email: ");
            string emailCliente = Console.ReadLine();

            Console.Write("Nueva Fecha de Nacimiento (dd/MM/yyyy): ");
            string fechaNacimiento = Console.ReadLine();

            banco.ModificarCliente(dniCliente, nombreCliente, telefonoCliente, emailCliente, fechaNacimiento);
        }

        static void EliminarCliente()
        {
            Console.WriteLine("\n=== ELIMINAR CLIENTE ===");
            Console.Write("DNI del cliente: ");
            string dniCliente = Console.ReadLine();

            banco.EliminarCliente(dniCliente);
        }

        static void CrearCuentaCorriente()
        {
            Console.WriteLine("\n=== CREAR CUENTA CORRIENTE ===");
            Console.Write("Número de cuenta: ");
            string numeroCuenta = Console.ReadLine();

            Console.Write("Dni del titular: ");
            string dniTitular = Console.ReadLine();

            Console.Write("Ingrese el saldo inicial: ");
            string saldoInicial = Console.ReadLine();

            banco.CrearCuentaCorriente(numeroCuenta, dniTitular, saldoInicial);
        }

        static void CrearCajaAhorro()
        {
            Console.WriteLine("\n=== CREAR CAJA DE AHORRO ===");
            Console.Write("Número de cuenta: ");
            string cbuCuenta = Console.ReadLine();

            Console.Write("Dni del titular: ");
            string dniTitular = Console.ReadLine();

            Console.Write("Ingrese el saldo inicial: ");
            string saldoInicial = Console.ReadLine();

            banco.CrearCajaAhorro(cbuCuenta, dniTitular, saldoInicial);
        }

        static void RealizarDeposito()
        {
            Console.WriteLine("\n=== REALIZAR DEPÓSITO ===");
            Console.Write("CBU de cuenta: ");
            string cbuCuenta = Console.ReadLine();

            Console.Write("Monto a depositar: ");
            decimal monto = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            banco.RealizarDeposito(cbuCuenta, monto);
        }

        static void RealizarRetiro()
        {
            Console.WriteLine("\n=== REALIZAR RETIRO ===");
            Console.Write("CBU de cuenta: ");
            string cbuCuenta = Console.ReadLine();

            Console.Write("Monto a retirar: ");
            decimal monto = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            banco.RealizarRetiro(cbuCuenta, monto);
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

            foreach ( var cliente in clientes)
            {
                Console.WriteLine($"DNI: {cliente.Dni}");
                Console.WriteLine($"Nombre completo: {cliente.NombreCompleto}");
                Console.WriteLine($"Teléfono: {cliente.Telefono}");
                Console.WriteLine($"Email: {cliente.Email}");
                Console.WriteLine($"Fecha de nacimiento: {cliente.FechaNacimiento.ToShortDateString()}");
                Console.WriteLine("-----------------------------------------------");
            }
        }

        static void ListarCuentas()
        {
            Console.WriteLine("\n=== LISTAR CUENTAS ===");
            var cuentas = banco.ObtenerTodasLasCuentas();

            if (cuentas.Count == 0)
            {
                Console.WriteLine("No hay cuentas registradas");
                return;
            }

            foreach (var cuenta in cuentas)
            {
                Console.WriteLine($"Cuenta: {cuenta.Cbu}");
                Console.WriteLine($"Titular: {cuenta.Titular.NombreCompleto}");
                Console.WriteLine($"Saldo: ${cuenta.Saldo:N2}");

                if (cuenta is CajaAhorro ca)
                {
                    Console.WriteLine("Tipo: Caja de Ahorro");
                }
                else if (cuenta is CuentaCorriente cc)
                {
                    Console.WriteLine("Tipo: Cuenta Corriente");
                }

                Console.WriteLine("-----------------------------------------");
            }
        }

        static void BuscarClientePorDni()
        {
            Console.WriteLine("\n=== BUSCAR CLIENTE POR DNI ===");
            Console.Write("DNI de cliente: ");
            string dniCliente = Console.ReadLine();

            if (int.TryParse(dniCliente, out int dni))
                throw new DatosInvalidosException("El valor del dni no es válido");

            var cliente = banco.BuscarClientePorDni(dni);

            Console.WriteLine($"DNI: {cliente.Dni}");
            Console.WriteLine($"Nombre completo: {cliente.NombreCompleto}");
            Console.WriteLine($"Teléfono: {cliente.Telefono}");
            Console.WriteLine($"Email: {cliente.Email}");
            Console.WriteLine($"Fecha de nacimiento: {cliente.FechaNacimiento.ToShortDateString()}");
        }

        static void BuscarClientePorNombre()
        {
            Console.WriteLine("\n=== BUSCAR CLIENTE POR NOMBRE ===");
            Console.Write("Nombre completo de cliente: ");
            string nombreCliente = Console.ReadLine();

            if (string.IsNullOrEmpty(nombreCliente))
                throw new DatosInvalidosException("Ingrese un nombre válido");

            var cliente = banco.BuscarClientePorNombre(nombreCliente);

            if (cliente == null)
            {
                throw new ClienteNoRegistradoException("No se encontró ningún cliente con ese nombre");
            }

            Console.WriteLine($"DNI: {cliente.Dni}");
            Console.WriteLine($"Nombre completo: {cliente.NombreCompleto}");
            Console.WriteLine($"Teléfono: {cliente.Telefono}");
            Console.WriteLine($"Email: {cliente.Email}");
            Console.WriteLine($"Fecha de nacimiento: {cliente.FechaNacimiento.ToShortDateString()}");
        }
    }
}
