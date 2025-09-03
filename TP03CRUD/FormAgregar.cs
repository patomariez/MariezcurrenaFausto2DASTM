using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP03CRUD
{
    public partial class FormAgregar : Form
    {
        private int? id;
        public FormAgregar(int? id = null)
        {
            InitializeComponent();
            this.id = id;
        }

        private void FormAgregar_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                dsJugadoresTableAdapters.JugadoresTableAdapter ta = new dsJugadoresTableAdapters.JugadoresTableAdapter();
                dsJugadores.JugadoresDataTable dt = ta.ObtenerDatosPorId((int)id);
                dsJugadores.JugadoresRow fila = (dsJugadores.JugadoresRow)dt.Rows[0];
                txtNombre.Text = fila.Nombre;
                txtEquipo.Text = fila.Equipo;
                numDorsal.Value = fila.Dorsal;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dsJugadoresTableAdapters.JugadoresTableAdapter ta = new dsJugadoresTableAdapters.JugadoresTableAdapter();

            if (id == null)
            {
                ta.Agregar(txtNombre.Text.Trim(), (int)numDorsal.Value, txtEquipo.Text.Trim());
            }
            else
            {
                ta.Editar(txtNombre.Text.Trim(), (int)numDorsal.Value, txtEquipo.Text.Trim(), (int)id);
            }

            this.Close();
        }


    }
}
