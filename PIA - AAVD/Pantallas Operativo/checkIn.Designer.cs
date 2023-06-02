namespace PIA___MAD.Pantallas_Operativo
{
    partial class checkIn
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
            this.lblRegistro = new System.Windows.Forms.Label();
            this.btnBuscarReservacion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoReserv = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.lblRegistro.Location = new System.Drawing.Point(7, 12);
            this.lblRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(208, 26);
            this.lblRegistro.TabIndex = 94;
            this.lblRegistro.Text = "Lista de Check-ins";
            // 
            // btnBuscarReservacion
            // 
            this.btnBuscarReservacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.btnBuscarReservacion.FlatAppearance.BorderSize = 0;
            this.btnBuscarReservacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarReservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarReservacion.ForeColor = System.Drawing.Color.White;
            this.btnBuscarReservacion.Location = new System.Drawing.Point(232, 59);
            this.btnBuscarReservacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarReservacion.Name = "btnBuscarReservacion";
            this.btnBuscarReservacion.Size = new System.Drawing.Size(95, 28);
            this.btnBuscarReservacion.TabIndex = 92;
            this.btnBuscarReservacion.Text = "Buscar";
            this.btnBuscarReservacion.UseVisualStyleBackColor = false;
            this.btnBuscarReservacion.Click += new System.EventHandler(this.btnBuscarReservacion_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 91;
            this.label3.Text = "Ingresar codigo de reservacion:";
            // 
            // txtCodigoReserv
            // 
            this.txtCodigoReserv.Location = new System.Drawing.Point(12, 64);
            this.txtCodigoReserv.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoReserv.Name = "txtCodigoReserv";
            this.txtCodigoReserv.Size = new System.Drawing.Size(205, 20);
            this.txtCodigoReserv.TabIndex = 90;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(711, 243);
            this.dataGridView1.TabIndex = 93;
            // 
            // checkIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(751, 489);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBuscarReservacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoReserv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(751, 489);
            this.Name = "checkIn";
            this.Text = "checkIn";
            this.Load += new System.EventHandler(this.checkIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Button btnBuscarReservacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoReserv;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}