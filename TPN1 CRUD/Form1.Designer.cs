namespace TPN1_CRUD
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
            dgvTrabajos = new DataGridView();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTrabajos).BeginInit();
            SuspendLayout();
            // 
            // dgvTrabajos
            // 
            dgvTrabajos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTrabajos.Location = new Point(12, 12);
            dgvTrabajos.Name = "dgvTrabajos";
            dgvTrabajos.ReadOnly = true;
            dgvTrabajos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTrabajos.Size = new Size(448, 286);
            dgvTrabajos.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(512, 75);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(93, 29);
            btnAgregar.TabIndex = 2;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(512, 129);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(93, 29);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(512, 185);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(93, 29);
            btnEliminar.TabIndex = 4;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 322);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvTrabajos);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTrabajos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTrabajos;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
    }
}
