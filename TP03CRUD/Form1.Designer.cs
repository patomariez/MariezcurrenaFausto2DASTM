using System.Data;
using System.Data.SqlClient;

namespace TP03CRUD
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvJugadores = new DataGridView();
            btnRecargar = new Button();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).BeginInit();
            SuspendLayout();
            // 
            // dgvJugadores
            // 
            dgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadores.Location = new Point(12, 31);
            dgvJugadores.Name = "dgvJugadores";
            dgvJugadores.ReadOnly = true;
            dgvJugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJugadores.Size = new Size(492, 249);
            dgvJugadores.TabIndex = 0;
            // 
            // btnRecargar
            // 
            btnRecargar.Location = new Point(379, 288);
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Size = new Size(114, 43);
            btnRecargar.TabIndex = 1;
            btnRecargar.Text = "Recargar";
            btnRecargar.UseVisualStyleBackColor = true;
            btnRecargar.Click += btnRecargar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 293);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(110, 28);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregarJugador_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(128, 293);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(110, 28);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(244, 293);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(110, 28);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(525, 343);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(btnRecargar);
            Controls.Add(dgvJugadores);
            Name = "Form1";
            Text = "Jugadores Liga";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvJugadores;
        private Button btnRecargar;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
    }
}
