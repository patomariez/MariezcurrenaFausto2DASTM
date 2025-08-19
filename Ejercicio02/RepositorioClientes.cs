using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio02.Excepcion;

namespace Ejercicio02
{
    public class RepositorioClientes : IRepositorios<Cliente>
    {
        private List<Cliente> listaClientes;

        public RepositorioClientes()
        {
            listaClientes = new List<Cliente>();
        }

        public void Agregar(Cliente cliente)
        {
            try
            {
                var clienteAgregado = Buscar(cliente.Dni);

                if (clienteAgregado == null)
                {
                    listaClientes.Add(cliente);
                    Console.WriteLine($"Cliente {cliente.Dni} agregado correctamente");
                }
                else
                {
                    throw new IdRepetidoException($"El DNI {cliente.Dni} está asignado a otro cliente");
                }
            }
            catch (IdRepetidoException ex)
            {
                Console.WriteLine($"Error ID repetido: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }
        }

        public void Modificar(Cliente cliente)
        {
            var clienteRepetido = listaClientes.FirstOrDefault(c => c.Dni == cliente.Dni);
            if (clienteRepetido != null)
            {
                clienteRepetido = cliente;
                Console.WriteLine($"Cliente {cliente.Dni} modificado correctamente");
            }
            else
            {
                Console.WriteLine("No se encontró el cliente a modificar");
            }
        }

        public List<Cliente> ListarTodos()
        {
            return listaClientes.ToList();
        }

        public Cliente Buscar(int dni)
        {
            return listaClientes.FirstOrDefault(c => c.Dni == dni);
        }

        public void Eliminar(int dni)
        {
            var clienteAEliminar = Buscar(dni);
            listaClientes.Remove(clienteAEliminar);
            Console.WriteLine($"Cliente {clienteAEliminar.Dni} eliminado correctamente");
        }
    }
}
