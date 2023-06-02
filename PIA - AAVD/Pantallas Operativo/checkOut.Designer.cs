namespace PIA___MAD.Pantallas_Operativo
{
    partial class checkOut
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
            this.btnGenerarFactura = new System.Windows.Forms.Button();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.lblAnticipo = new System.Windows.Forms.Label();
            this.txtAnticipo = new System.Windows.Forms.TextBox();
            this.lblCostoServicio = new System.Windows.Forms.Label();
            this.txtCostoServicio = new System.Windows.Forms.TextBox();
            this.txtServiciosAd = new System.Windows.Forms.TextBox();
            this.btnSeleccHabitacion = new System.Windows.Forms.Button();
            this.lblHabDisp = new System.Windows.Forms.Label();
            this.dgvHabitacion = new System.Windows.Forms.DataGridView();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.dtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.lblServiciosAd = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnBuscarReserv = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodigoReservacion = new System.Windows.Forms.TextBox();
            this.btnBuscarHab = new System.Windows.Forms.Button();
            this.btnFechaFin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerarFactura
            // 
            this.btnGenerarFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.btnGenerarFactura.FlatAppearance.BorderSize = 0;
            this.btnGenerarFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarFactura.ForeColor = System.Drawing.Color.White;
            this.btnGenerarFactura.Location = new System.Drawing.Point(579, 238);
            this.btnGenerarFactura.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerarFactura.Name = "btnGenerarFactura";
            this.btnGenerarFactura.Size = new System.Drawing.Size(105, 25);
            this.btnGenerarFactura.TabIndex = 129;
            this.btnGenerarFactura.Text = "Generar factura";
            this.btnGenerarFactura.UseVisualStyleBackColor = false;
            this.btnGenerarFactura.Click += new System.EventHandler(this.btnGenerarFactura_Click);
            // 
            // cbMetodoPago
            // 
            this.cbMetodoPago.FormattingEnabled = true;
            this.cbMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Cheques",
            "Tarjeta de débito",
            "Tarjeta de crédito",
            "Pago móvil",
            "Transferencia bancaria electrónicas"});
            this.cbMetodoPago.Location = new System.Drawing.Point(532, 199);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(192, 21);
            this.cbMetodoPago.TabIndex = 128;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetodoPago.Location = new System.Drawing.Point(413, 202);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(101, 13);
            this.lblMetodoPago.TabIndex = 127;
            this.lblMetodoPago.Text = "Metodo de pago:";
            // 
            // lblAnticipo
            // 
            this.lblAnticipo.AutoSize = true;
            this.lblAnticipo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnticipo.Location = new System.Drawing.Point(413, 172);
            this.lblAnticipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnticipo.Name = "lblAnticipo";
            this.lblAnticipo.Size = new System.Drawing.Size(87, 13);
            this.lblAnticipo.TabIndex = 126;
            this.lblAnticipo.Text = "Anticipo dado:";
            // 
            // txtAnticipo
            // 
            this.txtAnticipo.Location = new System.Drawing.Point(532, 169);
            this.txtAnticipo.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnticipo.Name = "txtAnticipo";
            this.txtAnticipo.Size = new System.Drawing.Size(192, 20);
            this.txtAnticipo.TabIndex = 125;
            // 
            // lblCostoServicio
            // 
            this.lblCostoServicio.AutoSize = true;
            this.lblCostoServicio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostoServicio.Location = new System.Drawing.Point(413, 143);
            this.lblCostoServicio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCostoServicio.Name = "lblCostoServicio";
            this.lblCostoServicio.Size = new System.Drawing.Size(111, 13);
            this.lblCostoServicio.TabIndex = 124;
            this.lblCostoServicio.Text = "Costo por servicio:";
            // 
            // txtCostoServicio
            // 
            this.txtCostoServicio.Location = new System.Drawing.Point(532, 140);
            this.txtCostoServicio.Margin = new System.Windows.Forms.Padding(2);
            this.txtCostoServicio.Name = "txtCostoServicio";
            this.txtCostoServicio.Size = new System.Drawing.Size(192, 20);
            this.txtCostoServicio.TabIndex = 123;
            // 
            // txtServiciosAd
            // 
            this.txtServiciosAd.Location = new System.Drawing.Point(532, 107);
            this.txtServiciosAd.Margin = new System.Windows.Forms.Padding(2);
            this.txtServiciosAd.Name = "txtServiciosAd";
            this.txtServiciosAd.Size = new System.Drawing.Size(192, 20);
            this.txtServiciosAd.TabIndex = 122;
            // 
            // btnSeleccHabitacion
            // 
            this.btnSeleccHabitacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.btnSeleccHabitacion.FlatAppearance.BorderSize = 0;
            this.btnSeleccHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccHabitacion.ForeColor = System.Drawing.Color.White;
            this.btnSeleccHabitacion.Location = new System.Drawing.Point(12, 445);
            this.btnSeleccHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeleccHabitacion.Name = "btnSeleccHabitacion";
            this.btnSeleccHabitacion.Size = new System.Drawing.Size(95, 28);
            this.btnSeleccHabitacion.TabIndex = 121;
            this.btnSeleccHabitacion.Text = "Extender";
            this.btnSeleccHabitacion.UseVisualStyleBackColor = false;
            this.btnSeleccHabitacion.Click += new System.EventHandler(this.btnSeleccHabitacion_Click);
            // 
            // lblHabDisp
            // 
            this.lblHabDisp.AutoSize = true;
            this.lblHabDisp.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHabDisp.Location = new System.Drawing.Point(9, 312);
            this.lblHabDisp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHabDisp.Name = "lblHabDisp";
            this.lblHabDisp.Size = new System.Drawing.Size(149, 13);
            this.lblHabDisp.TabIndex = 120;
            this.lblHabDisp.Text = "Habitaciones disponibles:";
            // 
            // dgvHabitacion
            // 
            this.dgvHabitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHabitacion.Location = new System.Drawing.Point(12, 328);
            this.dgvHabitacion.Name = "dgvHabitacion";
            this.dgvHabitacion.RowHeadersWidth = 51;
            this.dgvHabitacion.Size = new System.Drawing.Size(376, 106);
            this.dgvHabitacion.TabIndex = 119;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLimite.Location = new System.Drawing.Point(9, 265);
            this.lblFechaLimite.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(169, 13);
            this.lblFechaLimite.TabIndex = 118;
            this.lblFechaLimite.Text = "Si desea extender fecha fin...\r\n";
            // 
            // dtpFechaLimite
            // 
            this.dtpFechaLimite.Location = new System.Drawing.Point(12, 281);
            this.dtpFechaLimite.Name = "dtpFechaLimite";
            this.dtpFechaLimite.Size = new System.Drawing.Size(231, 20);
            this.dtpFechaLimite.TabIndex = 117;
            // 
            // lblServiciosAd
            // 
            this.lblServiciosAd.AutoSize = true;
            this.lblServiciosAd.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiciosAd.Location = new System.Drawing.Point(413, 101);
            this.lblServiciosAd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblServiciosAd.Name = "lblServiciosAd";
            this.lblServiciosAd.Size = new System.Drawing.Size(99, 26);
            this.lblServiciosAd.TabIndex = 115;
            this.lblServiciosAd.Text = "Servicios adicio-\r\nnales utilizados:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(10, 85);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 13);
            this.lblName.TabIndex = 114;
            this.lblName.Text = "Cliente:";
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.lblRegistro.Location = new System.Drawing.Point(7, 8);
            this.lblRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(224, 26);
            this.lblRegistro.TabIndex = 112;
            this.lblRegistro.Text = "Lista de Check-outs";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(375, 118);
            this.dataGridView1.TabIndex = 111;
            // 
            // btnBuscarReserv
            // 
            this.btnBuscarReserv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.btnBuscarReserv.FlatAppearance.BorderSize = 0;
            this.btnBuscarReserv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarReserv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarReserv.ForeColor = System.Drawing.Color.White;
            this.btnBuscarReserv.Location = new System.Drawing.Point(232, 55);
            this.btnBuscarReserv.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarReserv.Name = "btnBuscarReserv";
            this.btnBuscarReserv.Size = new System.Drawing.Size(95, 28);
            this.btnBuscarReserv.TabIndex = 110;
            this.btnBuscarReserv.Text = "Buscar";
            this.btnBuscarReserv.UseVisualStyleBackColor = false;
            this.btnBuscarReserv.Click += new System.EventHandler(this.btnBuscarReserv_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 44);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 13);
            this.label3.TabIndex = 109;
            this.label3.Text = "Ingresar codigo de reservacion:";
            // 
            // txtCodigoReservacion
            // 
            this.txtCodigoReservacion.Location = new System.Drawing.Point(12, 60);
            this.txtCodigoReservacion.Margin = new System.Windows.Forms.Padding(2);
            this.txtCodigoReservacion.Name = "txtCodigoReservacion";
            this.txtCodigoReservacion.Size = new System.Drawing.Size(205, 20);
            this.txtCodigoReservacion.TabIndex = 108;
            this.txtCodigoReservacion.TextChanged += new System.EventHandler(this.txtCodigoReservacion_TextChanged);
            // 
            // btnBuscarHab
            // 
            this.btnBuscarHab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.btnBuscarHab.FlatAppearance.BorderSize = 0;
            this.btnBuscarHab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarHab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarHab.ForeColor = System.Drawing.Color.White;
            this.btnBuscarHab.Location = new System.Drawing.Point(258, 278);
            this.btnBuscarHab.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarHab.Name = "btnBuscarHab";
            this.btnBuscarHab.Size = new System.Drawing.Size(130, 25);
            this.btnBuscarHab.TabIndex = 130;
            this.btnBuscarHab.Text = "Buscar habitaciones";
            this.btnBuscarHab.UseVisualStyleBackColor = false;
            this.btnBuscarHab.Click += new System.EventHandler(this.btnBuscarHab_Click);
            // 
            // btnFechaFin
            // 
            this.btnFechaFin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.btnFechaFin.FlatAppearance.BorderSize = 0;
            this.btnFechaFin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechaFin.ForeColor = System.Drawing.Color.White;
            this.btnFechaFin.Location = new System.Drawing.Point(163, 225);
            this.btnFechaFin.Margin = new System.Windows.Forms.Padding(2);
            this.btnFechaFin.Name = "btnFechaFin";
            this.btnFechaFin.Size = new System.Drawing.Size(225, 25);
            this.btnFechaFin.TabIndex = 131;
            this.btnFechaFin.Text = "Extender fecha fin";
            this.btnFechaFin.UseVisualStyleBackColor = false;
            this.btnFechaFin.Click += new System.EventHandler(this.btnFechaFin_Click);
            // 
            // checkOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(751, 489);
            this.Controls.Add(this.btnFechaFin);
            this.Controls.Add(this.btnBuscarHab);
            this.Controls.Add(this.btnGenerarFactura);
            this.Controls.Add(this.cbMetodoPago);
            this.Controls.Add(this.lblMetodoPago);
            this.Controls.Add(this.lblAnticipo);
            this.Controls.Add(this.txtAnticipo);
            this.Controls.Add(this.lblCostoServicio);
            this.Controls.Add(this.txtCostoServicio);
            this.Controls.Add(this.txtServiciosAd);
            this.Controls.Add(this.btnSeleccHabitacion);
            this.Controls.Add(this.lblHabDisp);
            this.Controls.Add(this.dgvHabitacion);
            this.Controls.Add(this.lblFechaLimite);
            this.Controls.Add(this.dtpFechaLimite);
            this.Controls.Add(this.lblServiciosAd);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBuscarReserv);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoReservacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(751, 489);
            this.Name = "checkOut";
            this.Text = "checkOut";
            this.Load += new System.EventHandler(this.checkOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHabitacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerarFactura;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.Label lblAnticipo;
        private System.Windows.Forms.TextBox txtAnticipo;
        private System.Windows.Forms.Label lblCostoServicio;
        private System.Windows.Forms.TextBox txtCostoServicio;
        private System.Windows.Forms.TextBox txtServiciosAd;
        private System.Windows.Forms.Button btnSeleccHabitacion;
        private System.Windows.Forms.Label lblHabDisp;
        private System.Windows.Forms.DataGridView dgvHabitacion;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.DateTimePicker dtpFechaLimite;
        private System.Windows.Forms.Label lblServiciosAd;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBuscarReserv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCodigoReservacion;
        private System.Windows.Forms.Button btnBuscarHab;
        private System.Windows.Forms.Button btnFechaFin;
    }
}