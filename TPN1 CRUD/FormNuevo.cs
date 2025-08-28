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
            TrabajosDB trabajoDB = new TrabajosDB();
            Trabajo trabajo = trabajoDB.ObtenerId((int)id);
            txtNombre.Text = trabajo.Nombre;
            txtProfesion.Text = trabajo.Profesion;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TrabajosDB trabajoDB = new TrabajosDB();

            try
            {
                if (id == null)
                {
                    trabajoDB.Agregar(txtNombre.Text, txtProfesion.Text);
                }
                else
                {
                    trabajoDB.Editar(txtNombre.Text, txtProfesion.Text, (int)id);
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
