using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class PaquetePremium : Paquete
    {
        public override string Tipo()
        {
            return "Premium";
        }

        public override decimal CalcularPrecio()
        {
            return Abono + (Abono * 20 / 100);
        }
    }
}
