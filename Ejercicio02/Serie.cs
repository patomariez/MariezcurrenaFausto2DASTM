using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Serie
    {
        private int id;
        private string nombre;
        private int cantidadTemporadas;
        private int episodios;
        private decimal duracion;
        private decimal ranking;
        private enum genero;
        private string director;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CantidadTemporadas { get; set; }
        public int Episodios { get; set; }
        public decimal Duracion { get; set; }
        public decimal Ranking { get; set; }
        public string Director { get; set; }

        public Genero TipoGenero { get; set; }

        public enum Genero
        {
            Accion,
            Comedia,
            Romance,
            Drama,
            Terror,
            CienciaFiccion
        }
    }
}
