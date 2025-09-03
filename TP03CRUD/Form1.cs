using System.Data;
using System.Data.SqlClient;

namespace TP03CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Recargar();
        }

        private void Recargar()
        {
            dsJugadoresTableAdapters.JugadoresTableAdapter ta = new dsJugadoresTableAdapters.JugadoresTableAdapter();
            dsJugadores.JugadoresDataTable dt = ta.ObtenerDatos();
            dgvJugadores.DataSource = dt;
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            Recargar();
        }

        private void btnAgregarJugador_Click(object sender, EventArgs e)
        {
            FormAgregar frm = new FormAgregar();
            frm.ShowDialog();
            Recargar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = ObtenerId();

            if (id != null)
            {
                FormAgregar frm = new FormAgregar(id);
                frm.ShowDialog();
                Recargar();
            }
        }

        private int? ObtenerId()
        {
            try
            {
                return int.Parse(dgvJugadores.Rows[dgvJugadores.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = ObtenerId();

            if (id != null)
            {
                dsJugadoresTableAdapters.JugadoresTableAdapter ta = new dsJugadoresTableAdapters.JugadoresTableAdapter();
                ta.Eliminar((int)id);
                Recargar();
            }
        }
    }
}
