using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio02.Excepcion;

namespace Ejercicio02
{
    public class RepositorioSeries : IRepositorios<Serie>
    {
        private List<Serie> listaSeries;

        public RepositorioSeries()
        {
            listaSeries = new List<Serie>();
        }

        public void Agregar(Serie serie)
        {
            try
            {
                var serieAgregada = Buscar(serie.Id);

                if (serieAgregada == null)
                {
                    listaSeries.Add(serie);
                    Console.WriteLine($"Serie {serie.Nombre} agregada correctamente");
                }
                else
                {
                    throw new IdRepetidoException($"El ID {serie.Id} está asignado a otra serie");
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

        public void Modificar(Serie serie)
        {
            var serieRepetida = listaSeries.FirstOrDefault(s => s.Id == serie.Id);
            if (serieRepetida != null)
            {
                serieRepetida.Nombre = serie.Nombre;
                serieRepetida.CantidadTemporadas = serie.CantidadTemporadas;
                serieRepetida.Episodios = serie.Episodios;
                serieRepetida.Duracion = serie.Duracion;
                serieRepetida.Ranking = serie.Ranking;
                serieRepetida.TipoGenero = serie.TipoGenero;
                serieRepetida.Director = serie.Director;
                Console.WriteLine($"Serie {serie.Id} modificada correctamente");
            }
            else
            {
                Console.WriteLine("No se encontró la serie a modificar");
            }
        }

        public List<Serie> ListarTodos()
        {
            return listaSeries.ToList();
        }

        public Serie Buscar(int id)
        {
            return listaSeries.FirstOrDefault(p => p.Id == id);
        }

        public void Eliminar(int id)
        {
            var serieAEliminar = Buscar(id);
            listaSeries.Remove(serieAEliminar);
            Console.WriteLine($"Serie {serieAEliminar.Nombre} eliminada correctamente");
        }
    }
}
