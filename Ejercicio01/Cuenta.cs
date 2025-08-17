using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio01.Excepcion;

namespace Ejercicio01
{
    public abstract class Cuenta
    {
        private Cliente titular;
        private string cbu;
        private decimal saldo;

        public Cliente Titular { get; set; }
        public string Cbu { get; set; }
        public decimal Saldo { get; set; }

        public virtual void Depositar(decimal monto)
        {
            if (monto <= 0)
                throw new DatosInvalidosException("El monto a depositar debe ser mayor a cero.");

            Saldo += monto;
        }

        public abstract void Retirar(decimal monto);
    }
}
