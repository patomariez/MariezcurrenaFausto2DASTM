using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Excepcion : Exception
    {
        public class FondosInsuficientesException : Exception
        {
            public FondosInsuficientesException(string mensaje) : base(mensaje) { }
        }

        public class LimiteRetirosExcedidoException : Exception
        {
            public LimiteRetirosExcedidoException(string mensaje) : base(mensaje) { }
        }

        public class DatosInvalidosException : Exception
        {
            public DatosInvalidosException(string mensaje) : base(mensaje) { }
        }

        public class ClienteNoRegistradoException : Exception
        {
            public ClienteNoRegistradoException(string mensaje) : base(mensaje) { }
        }

        public class CuentaAsociadaException : Exception
        {
            public CuentaAsociadaException(string mensaje) : base(mensaje) { }
        }

        public class SaldoPendienteException : Exception
        {
            public SaldoPendienteException(string mensaje) : base(mensaje) { }
        }

        public class MaximoExtraccionSuperadoException : Exception
        {
            public MaximoExtraccionSuperadoException(string mensaje) : base(mensaje) { }
        }
    }
}
