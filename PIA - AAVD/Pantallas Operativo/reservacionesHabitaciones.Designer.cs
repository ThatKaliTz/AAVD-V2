namespace PIA___MAD.Pantallas_Operativo
{
    partial class reservacionesHabitaciones
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
            this.btnReservar = new System.Windows.Forms.Button();
            this.lblCP = new System.Windows.Forms.Label();
            this.txtAnticipo = new System.Windows.Forms.TextBox();
            this.cbMetodoPago = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarHabitacion = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.txtServiciosAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCostoServicio = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.lblNomina = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panelOpenForm = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.lblRegistro.Location = new System.Drawing.Point(7, 13);
            this.lblRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(227, 26);
            this.lblRegistro.TabIndex = 104;
            this.lblRegistro.Text = "Pedir habitacion(es)";
            // 
            // btnReservar
            // 
            this.btnReservar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.btnReservar.FlatAppearance.BorderSize = 0;
            this.btnReservar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservar.ForeColor = System.Drawing.Color.White;
            this.btnReservar.Location = new System.Drawing.Point(586, 444);
            this.btnReservar.Margin = new System.Windows.Forms.Padding(2);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(139, 51);
            this.btnReservar.TabIndex = 103;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.UseVisualStyleBackColor = false;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCP.Location = new System.Drawing.Point(378, 348);
            this.lblCP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(56, 13);
            this.lblCP.TabIndex = 102;
            this.lblCP.Text = "Anticipo:";
            // 
            // txtAnticipo
            // 
            this.txtAnticipo.Location = new System.Drawing.Point(497, 345);
            this.txtAnticipo.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnticipo.Name = "txtAnticipo";
            this.txtAnticipo.Size = new System.Drawing.Size(205, 20);
            this.txtAnticipo.TabIndex = 101;
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
            this.cbMetodoPago.Location = new System.Drawing.Point(497, 378);
            this.cbMetodoPago.Name = "cbMetodoPago";
            this.cbMetodoPago.Size = new System.Drawing.Size(205, 21);
            this.cbMetodoPago.TabIndex = 100;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(378, 384);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Metodo de pago:";
            // 
            // lblNacimiento
            // 
            this.lblNacimiento.AutoSize = true;
            this.lblNacimiento.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNacimiento.Location = new System.Drawing.Point(22, 123);
            this.lblNacimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNacimiento.Name = "lblNacimiento";
            this.lblNacimiento.Size = new System.Drawing.Size(137, 13);
            this.lblNacimiento.TabIndex = 98;
            this.lblNacimiento.Text = "Fecha fin de la reserva:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(23, 139);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(231, 20);
            this.dtpFechaFin.TabIndex = 97;
            // 
            // btnBuscarHabitacion
            // 
            this.btnBuscarHabitacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.btnBuscarHabitacion.FlatAppearance.BorderSize = 0;
            this.btnBuscarHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarHabitacion.ForeColor = System.Drawing.Color.White;
            this.btnBuscarHabitacion.Location = new System.Drawing.Point(90, 208);
            this.btnBuscarHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarHabitacion.Name = "btnBuscarHabitacion";
            this.btnBuscarHabitacion.Size = new System.Drawing.Size(95, 37);
            this.btnBuscarHabitacion.TabIndex = 94;
            this.btnBuscarHabitacion.Text = "Buscar";
            this.btnBuscarHabitacion.UseVisualStyleBackColor = false;
            this.btnBuscarHabitacion.Click += new System.EventHandler(this.btnBuscarHabitacion_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(283, 66);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(149, 13);
            this.lblName.TabIndex = 93;
            this.lblName.Text = "Habitaciones disponibles:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(286, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(416, 163);
            this.dataGridView1.TabIndex = 92;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 310);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 26);
            this.label10.TabIndex = 144;
            this.label10.Text = "Servicios adicio-\r\nnales utilizados:";
            // 
            // txtServiciosAd
            // 
            this.txtServiciosAd.Location = new System.Drawing.Point(139, 316);
            this.txtServiciosAd.Margin = new System.Windows.Forms.Padding(2);
            this.txtServiciosAd.Name = "txtServiciosAd";
            this.txtServiciosAd.Size = new System.Drawing.Size(205, 20);
            this.txtServiciosAd.TabIndex = 145;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 352);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 147;
            this.label1.Text = "Costo por servicio:";
            // 
            // txtCostoServicio
            // 
            this.txtCostoServicio.Location = new System.Drawing.Point(139, 349);
            this.txtCostoServicio.Margin = new System.Windows.Forms.Padding(2);
            this.txtCostoServicio.Name = "txtCostoServicio";
            this.txtCostoServicio.Size = new System.Drawing.Size(205, 20);
            this.txtCostoServicio.TabIndex = 148;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(22, 386);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 151;
            this.label12.Text = "Descuento:";
            // 
            // txtDescuento
            // 
            this.txtDescuento.Location = new System.Drawing.Point(139, 383);
            this.txtDescuento.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(205, 20);
            this.txtDescuento.TabIndex = 152;
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(497, 316);
            this.txtNumeroFactura.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(205, 20);
            this.txtNumeroFactura.TabIndex = 153;
            // 
            // lblNomina
            // 
            this.lblNomina.AutoSize = true;
            this.lblNomina.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomina.Location = new System.Drawing.Point(378, 316);
            this.lblNomina.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomina.Name = "lblNomina";
            this.lblNomina.Size = new System.Drawing.Size(115, 13);
            this.lblNomina.TabIndex = 154;
            this.lblNomina.Text = "Numero de factura:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 166);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 13);
            this.label3.TabIndex = 155;
            this.label3.Text = "Cantidad de personas a hospedar:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(23, 181);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(233, 20);
            this.txtCantidad.TabIndex = 156;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 13);
            this.label4.TabIndex = 157;
            this.label4.Text = "Seleccionar fecha de inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(23, 96);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(231, 20);
            this.dtpFechaInicio.TabIndex = 158;
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(37)))), ((int)(((byte)(99)))));
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(410, 444);
            this.btnRegresar.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(139, 51);
            this.btnRegresar.TabIndex = 159;
            this.btnRegresar.Text = "Volver";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 285);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 13);
            this.label5.TabIndex = 160;
            this.label5.Text = "Una vez seleccionada, llenar:";
            // 
            // panelOpenForm
            // 
            this.panelOpenForm.ImeMode = System.Windows.Forms.ImeMode.On;
            this.panelOpenForm.Location = new System.Drawing.Point(693, 0);
            this.panelOpenForm.Name = "panelOpenForm";
            this.panelOpenForm.Size = new System.Drawing.Size(74, 67);
            this.panelOpenForm.TabIndex = 161;
            this.panelOpenForm.Visible = false;
            // 
            // reservacionesHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 528);
            this.Controls.Add(this.panelOpenForm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNomina);
            this.Controls.Add(this.txtNumeroFactura);
            this.Controls.Add(this.txtDescuento);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtCostoServicio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtServiciosAd);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.btnReservar);
            this.Controls.Add(this.lblCP);
            this.Controls.Add(this.txtAnticipo);
            this.Controls.Add(this.cbMetodoPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNacimiento);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.btnBuscarHabitacion);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(767, 528);
            this.Name = "reservacionesHabitaciones";
            this.Text = "reservacionesHabitaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.TextBox txtAnticipo;
        private System.Windows.Forms.ComboBox cbMetodoPago;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnBuscarHabitacion;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtServiciosAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCostoServicio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label lblNomina;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelOpenForm;
    }
}