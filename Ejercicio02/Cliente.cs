using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Cliente
    {
        private string nombre;
        private string apellido;
        private int dni;
        private DateTime fechaNacimiento;
        private Paquete paqueteContratado;

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Paquete PaqueteContratado { get; set; }
    }
}
