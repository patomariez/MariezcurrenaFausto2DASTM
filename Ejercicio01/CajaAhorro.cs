using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio01.Excepcion;

namespace Ejercicio01
{
    public class CajaAhorro : Cuenta
    {
        private decimal maxExtraccion;

        public decimal MaxExtraccion = 500000;

        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new DatosInvalidosException("El monto a retirar debe ser mayor a cero");

            if (monto > maxExtraccion)
                throw new MaximoExtraccionSuperadoException("El monto que desea retirar es superior al máximo permitido");

            if (monto > Saldo)
                throw new FondosInsuficientesException($"Fondos insuficientes. Saldo disponible: ${Saldo}");

            Saldo -= monto;
        }
    }
}
