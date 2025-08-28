using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPN1_CRUD
{
    public partial class FormNuevo : Form
    {
        private int? id;
        public FormNuevo(int? id = null)
        {
            InitializeComponent();
            this.id = id;

            if (this.id != null)
                CargarDatos();
        }

        private void CargarDatos()
        {
            TrabajadoresDB trabajadoresDB = new TrabajadoresDB();
            Trabajador trabajador = trabajadoresDB.ObtenerId((int)id);
            txtNombre.Text = trabajador.Nombre;
            txtProfesion.Text = trabajador.Profesion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TrabajadoresDB trabajadoresDB = new TrabajadoresDB();

            try
            {
                if (id == null)
                {
                    trabajadoresDB.Agregar(txtNombre.Text, txtProfesion.Text);
                }
                else
                {
                    trabajadoresDB.Editar(txtNombre.Text, txtProfesion.Text, (int)id);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar en la Base de Datos: {ex.Message}");
            }

        }
    }
}
