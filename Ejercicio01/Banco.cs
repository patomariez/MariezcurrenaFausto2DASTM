using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio01.Excepcion;

namespace Ejercicio01
{
    public class Banco
    {
        private RepositorioClientes repositorioClientes;
        private RepositorioCuentas repositorioCuentas;

        public Banco()
        {
            repositorioClientes = new RepositorioClientes();
            repositorioCuentas = new RepositorioCuentas();
        }

        public void RegistrarCliente(string dni, string nombreCompleto, string telefono, string email, string fechaNacimiento)
        {
            try
            {
                if (!int.TryParse(dni, out int dniCliente))
                    throw new DatosInvalidosException("El valor del dni no es válido");

                if (string.IsNullOrEmpty(nombreCompleto))
                    throw new DatosInvalidosException("El nombre no puede estar vacío");

                if (!long.TryParse(telefono, out long telefonoCliente))
                    throw new DatosInvalidosException("El valor del teléfono no es válido");

                if (string.IsNullOrEmpty(email))
                    throw new DatosInvalidosException("El email no puede estar vacío");

                if (!DateTime.TryParse(fechaNacimiento, out DateTime fechaNacimientoCliente))
                    throw new DatosInvalidosException("La fecha de nacimiento no es válido");

                Cliente cliente = new Cliente();
                cliente.Dni = dniCliente;
                cliente.NombreCompleto = nombreCompleto;
                cliente.Telefono = telefonoCliente;
                cliente.Email = email;
                cliente.FechaNacimiento = fechaNacimientoCliente;

                repositorioClientes.AgregarCliente(cliente);
                Console.WriteLine("Cliente registrado exitosamente");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar cliente: {ex.Message}");
            }
        }

        public void ModificarCliente(string dni, string nombreCompleto, string telefono, string email, string fechaNacimiento)
        {
            try
            {
                if (!int.TryParse(dni, out int dniCliente))
                    throw new DatosInvalidosException("El valor del dni no es válido");

                if (string.IsNullOrEmpty(nombreCompleto))
                    throw new DatosInvalidosException("El nombre no puede estar vacío");

                if (!long.TryParse(telefono, out long telefonoCliente))
                    throw new DatosInvalidosException("El valor del teléfono no es válido");

                if (string.IsNullOrEmpty(email))
                    throw new DatosInvalidosException("El email no puede estar vacío");

                if (!DateTime.TryParse(fechaNacimiento, out DateTime fechaNacimientoCliente))
                    throw new DatosInvalidosException("La fecha de nacimiento no es válida");

                repositorioClientes.ModificarCliente(dniCliente, nombreCompleto, telefonoCliente, email, fechaNacimientoCliente);
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al modificar cliente: {ex.Message}");
            }
        }

        public void EliminarCliente (string dni)
        {
            try
            {
                if (!int.TryParse(dni, out int dniCliente))
                    throw new DatosInvalidosException("El valor del dni no es válido");

                repositorioClientes.EliminarCliente(dniCliente);
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

        public void CrearCuentaCorriente(string cbu, string dniTitular, string saldo)
        {
            try
            {
                CuentaCorriente cuenta = new CuentaCorriente();
                cuenta.Cbu = cbu;

                if (!int.TryParse(dniTitular, out int dniCliente))
                    throw new DatosInvalidosException("El valor del dni no es válido");

                if (!repositorioClientes.ExisteCliente(dniCliente))
                    throw new ClienteNoRegistradoException("No se encontró ningún cliente con ese dni");

                var titular = repositorioClientes.BuscarClientePorDni(dniCliente);

                if (!decimal.TryParse(saldo, out decimal saldoInicial))
                    throw new DatosInvalidosException("Debe ingresar un saldo válido");

                cuenta.Titular = titular;
                cuenta.Saldo = saldoInicial;

                repositorioCuentas.AgregarCuenta(cuenta);
                Console.WriteLine("Cuenta corriente creada exitosamente");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la cuenta corriente: {ex.Message}");
            }
        }

        public void CrearCajaAhorro(string cbu, string dniTitular, string saldo)
        {
            try
            {
                CajaAhorro cuenta = new CajaAhorro();
                cuenta.Cbu = cbu;

                if (!int.TryParse(dniTitular, out int dniCliente))
                    throw new DatosInvalidosException("El valor del dni no es válido");

                if (!repositorioClientes.ExisteCliente(dniCliente))
                    throw new ClienteNoRegistradoException("No se encontró ningún cliente con ese dni");

                var titular = repositorioClientes.BuscarClientePorDni(dniCliente);

                if (!decimal.TryParse(saldo, out decimal saldoInicial))
                    throw new DatosInvalidosException("Debe ingresar un saldo válido");

                cuenta.Titular = titular;
                cuenta.Saldo = saldoInicial;

                repositorioCuentas.AgregarCuenta(cuenta);
                Console.WriteLine("Caja de ahorro creada exitosamente");
            }
            catch (ClienteNoRegistradoException ex)
            {
                Console.WriteLine($"Error buscando titular: {ex.Message}");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la caja de ahorro: {ex.Message}");
            }
        }

        public void RealizarDeposito(string cbu, decimal monto)
        {
            try
            {
                var cuenta = repositorioCuentas.BuscarCuenta(cbu);

                if (cuenta == null)
                    throw new DatosInvalidosException("Cuenta no encontrada");

                cuenta.Depositar(monto);
                Console.WriteLine($"Depósito de ${monto} realizado exitosamente.");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar depósito: {ex.Message}");
            }
        }

        public void RealizarRetiro(string cbu, decimal monto)
        {
            try
            {
                var cuenta = repositorioCuentas.BuscarCuenta(cbu);

                if (cuenta == null)
                    throw new DatosInvalidosException("Cuenta no encontrada");

                cuenta.Retirar(monto);
                Console.WriteLine($"Retiro de {monto} realizado exitosamente.");
            }
            catch (DatosInvalidosException ex)
            {
                Console.WriteLine($"Error de formato: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al realizar extracción: {ex.Message}");
            }
        }

        public List<Cuenta> ObtenerTodasLasCuentas()
        {
            return repositorioCuentas.ObtenerTodasLasCuentas();
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return repositorioClientes.ObtenerTodosLosClientes();
        }

        public decimal ConsultarSaldo(string cbuCuenta)
        {
            var cuenta = repositorioCuentas.BuscarCuenta(cbuCuenta);
            if (cuenta == null)
                throw new DatosInvalidosException("Cuenta no encontrada");

            return cuenta.Saldo;
        }

        public Cuenta ObtenerCuenta(string cbuCuenta)
        {
            return repositorioCuentas.BuscarCuenta(cbuCuenta);
        }

        public Cliente BuscarClientePorDni(int dni)
        {
            return repositorioClientes.BuscarClientePorDni(dni);
        }

        public Cliente BuscarClientePorNombre(string nombre)
        {
            return repositorioClientes.BuscarClientePorNombre(nombre);
        }
    }
}
