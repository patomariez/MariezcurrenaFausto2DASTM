using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Canal
    {
        private int id;
        private string nombre;
        private List<Serie> series;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Serie> Series { get; set;}
    }
}
