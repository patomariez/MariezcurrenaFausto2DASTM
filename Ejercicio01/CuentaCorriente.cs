using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio01.Excepcion;

namespace Ejercicio01
{
    public class CuentaCorriente : Cuenta
    {
        private decimal limiteCredito;

        public decimal LimiteCredito = 100000;
        public override void Retirar(decimal monto)
        {
            if (monto <= 0)
                throw new DatosInvalidosException("El monto a retirar debe ser mayor a cero.");

            decimal saldoDisponible = Saldo + LimiteCredito;

            if (monto > saldoDisponible)
                throw new FondosInsuficientesException($"Fondos insuficientes. Saldo disponible: ${saldoDisponible:N2}");

            Saldo -= monto;
        }
    }
}
