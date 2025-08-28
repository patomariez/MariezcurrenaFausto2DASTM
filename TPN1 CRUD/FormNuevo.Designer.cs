namespace TPN1_CRUD
{
    partial class FormNuevo
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
            lblProfesion = new Label();
            txtNombre = new TextBox();
            txtProfesion = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(31, 41);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // lblProfesion
            // 
            lblProfesion.AutoSize = true;
            lblProfesion.Location = new Point(25, 96);
            lblProfesion.Name = "lblProfesion";
            lblProfesion.Size = new Size(60, 15);
            lblProfesion.TabIndex = 1;
            lblProfesion.Text = "Profesión:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(115, 38);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(155, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtProfesion
            // 
            txtProfesion.Location = new Point(115, 93);
            txtProfesion.Name = "txtProfesion";
            txtProfesion.Size = new Size(155, 23);
            txtProfesion.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(115, 158);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 27);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FormNuevo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 227);
            Controls.Add(btnGuardar);
            Controls.Add(txtProfesion);
            Controls.Add(txtNombre);
            Controls.Add(lblProfesion);
            Controls.Add(lblNombre);
            Name = "FormNuevo";
            Text = "FormNuevo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblProfesion;
        private TextBox txtNombre;
        private TextBox txtProfesion;
        private Button btnGuardar;
    }
}