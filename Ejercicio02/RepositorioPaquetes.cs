using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio02.Excepcion;

namespace Ejercicio02
{
    public class RepositorioPaquetes : IRepositorios<Paquete>
    {
        private List<Paquete> listaPaquetes;

        public RepositorioPaquetes()
        {
            listaPaquetes = new List<Paquete>();
        }

        public void Agregar(Paquete paquete)
        {
            try
            {
                var paqueteAgregado = Buscar(paquete.Id);

                if (paqueteAgregado == null)
                {
                    listaPaquetes.Add(paquete);
                    Console.WriteLine($"Paquete {paquete.Tipo()} agregado correctamente");
                }
                else
                {
                    throw new IdRepetidoException($"El ID {paquete.Id} está asignado a otro paquete");
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

        public void Modificar(Paquete paquete)
        {
            var paqueteRepetido = listaPaquetes.FirstOrDefault(p => p.Id == paquete.Id);
            if (paqueteRepetido != null)
            {
                paqueteRepetido.Canales = paquete.Canales;
                Console.WriteLine($"Paquete {paquete.Id} modificado correctamente");
            }
            else
            {
                Console.WriteLine("No se encontró el paquete a modificar");
            }
        }

        public List<Paquete> ListarTodos()
        {
            return listaPaquetes.ToList();
        }

        public Paquete Buscar(int id)
        {
            return listaPaquetes.FirstOrDefault(p => p.Id == id);
        }

        public void Eliminar(int id)
        {
            var paqueteAEliminar = Buscar(id);
            listaPaquetes.Remove(paqueteAEliminar);
            Console.WriteLine($"Paquete {paqueteAEliminar.Tipo()} eliminado correctamente");
        }
    }
}
