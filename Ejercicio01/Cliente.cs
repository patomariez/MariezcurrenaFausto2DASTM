using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01
{
    public class Cliente
    {
        private int dni;
        private string nombreCompleto;
        private long telefono;
        private string email;
        private DateTime fechaNacimiento;
        private bool tieneCuenta;

        public int Dni { get; set; }
        public string NombreCompleto { get; set; }
        public long Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool TieneCuenta = false;
    }
}
