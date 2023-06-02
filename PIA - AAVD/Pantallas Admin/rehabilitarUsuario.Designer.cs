namespace PIA___MAD.Pantallas_Admin
{
    partial class rehabilitarUsuario
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
            this.dgvUsuarioInhabilib = new System.Windows.Forms.DataGridView();
            this.btnHabilitarUsuario = new System.Windows.Forms.Button();
            this.lblRegistro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarioInhabilib)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuarioInhabilib
            // 
            this.dgvUsuarioInhabilib.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarioInhabilib.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarioInhabilib.Location = new System.Drawing.Point(55, 104);
            this.dgvUsuarioInhabilib.Name = "dgvUsuarioInhabilib";
            this.dgvUsuarioInhabilib.RowHeadersWidth = 51;
            this.dgvUsuarioInhabilib.Size = new System.Drawing.Size(649, 264);
            this.dgvUsuarioInhabilib.TabIndex = 55;
            this.dgvUsuarioInhabilib.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Seleccion);
            // 
            // btnHabilitarUsuario
            // 
            this.btnHabilitarUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.btnHabilitarUsuario.FlatAppearance.BorderSize = 0;
            this.btnHabilitarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHabilitarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHabilitarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnHabilitarUsuario.Location = new System.Drawing.Point(333, 383);
            this.btnHabilitarUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.btnHabilitarUsuario.Name = "btnHabilitarUsuario";
            this.btnHabilitarUsuario.Size = new System.Drawing.Size(101, 26);
            this.btnHabilitarUsuario.TabIndex = 56;
            this.btnHabilitarUsuario.Text = "Habilitar";
            this.btnHabilitarUsuario.UseVisualStyleBackColor = false;
            this.btnHabilitarUsuario.Click += new System.EventHandler(this.btnRegUsuario_Click);
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblRegistro.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.Black;
            this.lblRegistro.Location = new System.Drawing.Point(328, 65);
            this.lblRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(100, 26);
            this.lblRegistro.TabIndex = 57;
            this.lblRegistro.Text = "Usuarios";
            // 
            // rehabilitarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(767, 528);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.btnHabilitarUsuario);
            this.Controls.Add(this.dgvUsuarioInhabilib);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(767, 528);
            this.Name = "rehabilitarUsuario";
            this.Text = "rehabilitarUsuario";
            this.Load += new System.EventHandler(this.rehabilitarUsuario_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarioInhabilib)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvUsuarioInhabilib;
        private System.Windows.Forms.Button btnHabilitarUsuario;
        private System.Windows.Forms.Label lblRegistro;
    }
}