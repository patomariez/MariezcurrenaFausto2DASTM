using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ejercicio01.Excepcion;

namespace Ejercicio01
{
    public class RepositorioCuentas
    {
        private List<Cuenta> listaCuentas;

        public RepositorioCuentas()
        {
            listaCuentas = new List<Cuenta>();
        }

        public void AgregarCuenta(Cuenta cuenta)
        {
            if (cuenta == null)
                throw new DatosInvalidosException("La cuenta no puede ser nula");

            if (string.IsNullOrWhiteSpace(cuenta.Cbu))
                throw new DatosInvalidosException("El número de cuenta no puede estar vacío");

            if (cuenta.Titular == null)
                throw new DatosInvalidosException("El titular no puede estar vacío");

            if (ExisteCuenta(cuenta.Cbu))
                throw new DatosInvalidosException("Ya existe una cuenta con ese número");

            listaCuentas.Add(cuenta);
        }

        public Cuenta BuscarCuenta(string cbu)
        {
            return listaCuentas.FirstOrDefault(c => c.Cbu == cbu);
        }

        public bool ExisteCuenta(string cbu)
        {
            return listaCuentas.Any(c => c.Cbu == cbu);
        }

        public List<Cuenta> ObtenerTodasLasCuentas()
        {
            return listaCuentas.ToList();
        }

        public void EliminarCuenta(string cbu)
        {
            var cuenta = BuscarCuenta(cbu);

            if (cuenta != null)
            {
                if (cuenta.Saldo != 0)
                    throw new SaldoPendienteException("No se puede eliminar la cuenta porque no tiene saldo cero");

                listaCuentas.Remove(cuenta);
            }
        }
    }
}
