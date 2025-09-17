namespace CRUDEntityFramework
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
            btnAgregar = new Button();
            txtNombre = new TextBox();
            txtDorsal = new TextBox();
            txtEquipo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).BeginInit();
            SuspendLayout();
            // 
            // dgvJugadores
            // 
            dgvJugadores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJugadores.Location = new Point(186, 48);
            dgvJugadores.Name = "dgvJugadores";
            dgvJugadores.ReadOnly = true;
            dgvJugadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJugadores.Size = new Size(423, 235);
            dgvJugadores.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(44, 225);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(33, 71);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtDorsal
            // 
            txtDorsal.Location = new Point(33, 118);
            txtDorsal.Name = "txtDorsal";
            txtDorsal.Size = new Size(100, 23);
            txtDorsal.TabIndex = 3;
            // 
            // txtEquipo
            // 
            txtEquipo.Location = new Point(33, 165);
            txtEquipo.Name = "txtEquipo";
            txtEquipo.Size = new Size(100, 23);
            txtEquipo.TabIndex = 4;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(621, 327);
            Controls.Add(txtEquipo);
            Controls.Add(txtDorsal);
            Controls.Add(txtNombre);
            Controls.Add(btnAgregar);
            Controls.Add(dgvJugadores);
            Name = "Form1";
            Text = "Jugadores Liga";
            ((System.ComponentModel.ISupportInitialize)dgvJugadores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvJugadores;
        private Button btnAgregar;
        private TextBox txtNombre;
        private TextBox txtDorsal;
        private TextBox txtEquipo;
    }
}
