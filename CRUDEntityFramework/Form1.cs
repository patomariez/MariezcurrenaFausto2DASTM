namespace CRUDEntityFramework
{
    public partial class Form1 : Form
    {
        RepositorioJugadores repositorio = new RepositorioJugadores();
        public Form1()
        {
            InitializeComponent();
            dgvJugadores.DataSource = repositorio.Listar();
        }

        public void Refrescar()
        {
            dgvJugadores.DataSource = null;
            dgvJugadores.DataSource = repositorio.Listar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Jugador jugador = new Jugador();
            jugador.Nombre = txtNombre.Text;
            jugador.Dorsal = int.Parse(txtDorsal.Text);
            jugador.Equipo = txtEquipo.Text;

            string mensaje = repositorio.Agregar(jugador);
            MessageBox.Show(mensaje);
        }
    }
}
