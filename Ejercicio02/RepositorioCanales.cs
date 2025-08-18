using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class RepositorioCanales : IRepositorios<Canal>
    {
        private List<Canal> listaCanales;

        public RepositorioCanales()
        {
            listaCanales = new List<Canal>();
        }

        public void Agregar(Canal canal)
        {
            try
            {
                var canalAgregado = Buscar(canal.Id);

                if (canalAgregado == null)
                {
                    listaCanales.Add(canal);
                    Console.WriteLine($"Canal {canal.Nombre} agregado correctamente");
                }
                else
                {
                    throw new IdRepetidoException($"El ID {canal.Id} está asignado a otro canal");
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

        public void Modificar(Canal canal)
        {
            var canalRepetido = listaCanales.FirstOrDefault(c => c.Id == canal.Id);
            if (canal != null)
            {
                canalRepetido = canal;
                Console.WriteLine($"Canal {canal.Id} modificado correctamente");
            }
            else
            {
                Console.WriteLine("No se encontró el canal a modificar");
            }
        }

        public List<Canal> ListarTodos()
        {
            return listaCanales.ToList();
        }

        public Canal Buscar(int id)
        {
            return listaCanales.FirstOrDefault(c => c.Id == id);
        }

        public void Eliminar(int id)
        {
            var canalAEliminar = Buscar(id);
            listaCanales.Remove(canalAEliminar);
            Console.WriteLine($"Canal {canalAEliminar.Nombre} eliminado correctamente");
        }
    }
}
