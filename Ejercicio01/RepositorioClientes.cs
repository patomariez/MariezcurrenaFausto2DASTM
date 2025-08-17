using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio01.Excepcion;

namespace Ejercicio01
{
    public class RepositorioClientes
    {
        private List<Cliente> listaClientes;

        public RepositorioClientes()
        {
            listaClientes = new List<Cliente>();
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (cliente == null)
                throw new DatosInvalidosException("El cliente no puede ser nulo");

            if (string.IsNullOrWhiteSpace(cliente.NombreCompleto))
                throw new DatosInvalidosException("El nombre del cliente no puede estar vacío");

            if (string.IsNullOrWhiteSpace(cliente.Telefono.ToString()))
                throw new DatosInvalidosException("El teléfono no puede estar vacío");

            if (string.IsNullOrWhiteSpace(cliente.Email))
                throw new DatosInvalidosException("El email no puede estar vacío");

            if (string.IsNullOrWhiteSpace(cliente.FechaNacimiento.ToString()))
                throw new DatosInvalidosException("La fecha de nacimiento no puede estar vacía");

            if (ExisteCliente(cliente.Dni))
                throw new DatosInvalidosException("Ya existe un cliente con ese dni");

            listaClientes.Add(cliente);
        }

        public void ModificarCliente(int dni, string nombreCompleto, long telefono, string email, DateTime fechaNacimiento)
        {
            var clienteAModificar = BuscarClientePorDni(dni);

            if (clienteAModificar == null)
                throw new ClienteNoRegistradoException("No se encontró ningún cliente con ese dni");

            clienteAModificar.NombreCompleto = nombreCompleto;
            clienteAModificar.Telefono = telefono;
            clienteAModificar.Email = email;
            clienteAModificar.FechaNacimiento = fechaNacimiento;
        }

        public Cliente BuscarClientePorDni(int dni)
        {
            return listaClientes.FirstOrDefault(c => c.Dni == dni);
        }

        public Cliente BuscarClientePorNombre(string nombre)
        {
            return listaClientes.FirstOrDefault(c => c.NombreCompleto == nombre);
        }

        public bool ExisteCliente(int dni)
        {
            return listaClientes.Any(c => c.Dni == dni);
        }

        public List<Cliente> ObtenerTodosLosClientes()
        {
            return listaClientes.ToList();
        }

        public void EliminarCliente(int dni)
        {
            var cliente = BuscarClientePorDni(dni);

            if (cliente != null)
            {
                if (cliente.TieneCuenta)
                    throw new CuentaAsociadaException("No se puede eliminar el cliente porque tiene una cuenta asociada");

                listaClientes.Remove(cliente);
            }
        }
    }
}
