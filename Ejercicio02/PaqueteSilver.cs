using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class PaqueteSilver : Paquete
    {
        public override string Tipo()
        {
            return "Silver";
        }
        public override decimal CalcularPrecio()
        {
            return Abono + (Abono * 15 / 100);
        }
    }
}
