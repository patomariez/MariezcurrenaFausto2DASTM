using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public abstract class Paquete
    {
        private int id;
        private List<Canal> canales;
        private decimal abono;

        public int Id { get; set; }
        public List<Canal> Canales { get; set; }
        public decimal Abono = 5000;

        public abstract string Tipo();

        public abstract decimal CalcularPrecio();
    }
}
