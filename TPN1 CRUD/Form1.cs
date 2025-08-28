namespace TPN1_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LlenarGrilla();
        }

        private void LlenarGrilla()
        {
            TrabajosDB trabajoBD = new TrabajosDB();
            dgvTrabajos.DataSource = trabajoBD.Obtener();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FormNuevo formularioNuevo = new FormNuevo();
            formularioNuevo.ShowDialog();
            LlenarGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? id = ObtenerId();

            if (id != null)
            {
                FormNuevo formularioEditar = new FormNuevo(id);
                formularioEditar.ShowDialog();
                LlenarGrilla();
            }
        }

        private int ObtenerId()
        {
            return int.Parse(dgvTrabajos.Rows[dgvTrabajos.CurrentRow.Index].Cells[0].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? id = ObtenerId();

            try
            {
                if (id != null)
                {
                    TrabajosDB trabajoDB = new TrabajosDB();
                    trabajoDB.Eliminar((int)id);
                    LlenarGrilla();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al eliminar: {ex.Message}");
            }
        }
    }
}