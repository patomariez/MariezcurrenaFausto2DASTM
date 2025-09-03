namespace TP03CRUD
{
    partial class FormAgregar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblNombre = new Label();
            lblDorsal = new Label();
            lblEquipo = new Label();
            txtNombre = new TextBox();
            txtEquipo = new TextBox();
            numDorsal = new NumericUpDown();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)numDorsal).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(58, 47);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblDorsal
            // 
            lblDorsal.AutoSize = true;
            lblDorsal.Location = new Point(69, 92);
            lblDorsal.Name = "lblDorsal";
            lblDorsal.Size = new Size(43, 15);
            lblDorsal.TabIndex = 1;
            lblDorsal.Text = "Dorsal:";
            // 
            // lblEquipo
            // 
            lblEquipo.AutoSize = true;
            lblEquipo.Location = new Point(65, 140);
            lblEquipo.Name = "lblEquipo";
            lblEquipo.Size = new Size(47, 15);
            lblEquipo.TabIndex = 2;
            lblEquipo.Text = "Equipo:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(129, 44);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(149, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtEquipo
            // 
            txtEquipo.Location = new Point(129, 140);
            txtEquipo.Name = "txtEquipo";
            txtEquipo.Size = new Size(100, 23);
            txtEquipo.TabIndex = 5;
            // 
            // numDorsal
            // 
            numDorsal.Location = new Point(129, 92);
            numDorsal.Name = "numDorsal";
            numDorsal.Size = new Size(68, 23);
            numDorsal.TabIndex = 6;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(99, 194);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(98, 29);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormAgregar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(322, 278);
            Controls.Add(btnGuardar);
            Controls.Add(numDorsal);
            Controls.Add(txtEquipo);
            Controls.Add(txtNombre);
            Controls.Add(lblEquipo);
            Controls.Add(lblDorsal);
            Controls.Add(lblNombre);
            Name = "FormAgregar";
            Text = "Modificaciones";
            Load += FormAgregar_Load;
            ((System.ComponentModel.ISupportInitialize)numDorsal).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblDorsal;
        private Label lblEquipo;
        private TextBox txtNombre;
        private TextBox txtEquipo;
        private NumericUpDown numDorsal;
        private Button btnGuardar;
    }
}