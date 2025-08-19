using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Excepcion :  Exception
    {
        public class DatosInvalidosException : Exception
        {
            public DatosInvalidosException(string mensaje) : base(mensaje) { }
        }

        public class ClienteNoRegistradoException : Exception
        {
            public ClienteNoRegistradoException(string mensaje) : base(mensaje) { }
        }

        public class IdRepetidoException : Exception
        {
            public IdRepetidoException(string mensaje) : base(mensaje) { }
        }

        public class ObjetoNoEncontradoException : Exception
        {
            public ObjetoNoEncontradoException(string mensaje) : base(mensaje) { }
        }
    }
}
