namespace PIA___AAVD.Pantallas_Admin
{
    partial class cancelaciones
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
            this.dgvReserva = new System.Windows.Forms.DataGridView();
            this.btnEliminarReserv = new System.Windows.Forms.Button();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoReservacion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserva)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReserva
            // 
            this.dgvReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReserva.Location = new System.Drawing.Point(29, 79);
            this.dgvReserva.Name = "dgvReserva";
            this.dgvReserva.RowHeadersWidth = 51;
            this.dgvReserva.Size = new System.Drawing.Size(674, 259);
            this.dgvReserva.TabIndex = 19;
            // 
            // btnEliminarReserv
            // 
            this.btnEliminarReserv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.btnEliminarReserv.FlatAppearance.BorderSize = 0;
            this.btnEliminarReserv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarReserv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarReserv.ForeColor = System.Drawing.Color.White;
            this.btnEliminarReserv.Location = new System.Drawing.Point(564, 379);
            this.btnEliminarReserv.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarReserv.Name = "btnEliminarReserv";
            this.btnEliminarReserv.Size = new System.Drawing.Size(139, 51);
            this.btnEliminarReserv.TabIndex = 44;
            this.btnEliminarReserv.Text = "Eliminar";
            this.btnEliminarReserv.UseVisualStyleBackColor = false;
            this.btnEliminarReserv.Click += new System.EventHandler(this.btnEliminarReserv_Click);
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.lblRegistro.Location = new System.Drawing.Point(24, 20);
            this.lblRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(175, 26);
            this.lblRegistro.TabIndex = 45;
            this.lblRegistro.Text = "Cancelaciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(25, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 19);
            this.label1.TabIndex = 46;
            this.label1.Text = "Tabla con las reservaciones";
            // 
            // txtCodigoReservacion
            // 
            this.txtCodigoReservacion.Location = new System.Drawing.Point(31, 372);
            this.txtCodigoReservacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoReservacion.Name = "txtCodigoReservacion";
            this.txtCodigoReservacion.Size = new System.Drawing.Size(205, 20);
            this.txtCodigoReservacion.TabIndex = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 356);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 112;
            this.label3.Text = "Ingresar codigo de reservacion:";
            // 
            // cancelaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(767, 528);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoReservacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.btnEliminarReserv);
            this.Controls.Add(this.dgvReserva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(767, 528);
            this.Name = "cancelaciones";
            this.Text = "cancelaciones";
            this.Load += new System.EventHandler(this.cancelaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvReserva;
        private System.Windows.Forms.Button btnEliminarReserv;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoReservacion;
        private System.Windows.Forms.Label label3;
    }
}