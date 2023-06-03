namespace PIA___AAVD
{
    partial class regTipoHab
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtCantidadPersonas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecioNoche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumCamas = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.cbTipoCama = new System.Windows.Forms.ComboBox();
            this.cbNivelHabitacion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkbPiscina = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkbJardin = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.checkbPlaya = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCrearHabitacion = new System.Windows.Forms.Button();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panelOpenForm = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 191);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 26);
            this.label2.TabIndex = 26;
            this.label2.Text = "Limite de personas\r\npor habitación\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtCantidadPersonas
            // 
            this.txtCantidadPersonas.Location = new System.Drawing.Point(177, 191);
            this.txtCantidadPersonas.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidadPersonas.Name = "txtCantidadPersonas";
            this.txtCantidadPersonas.Size = new System.Drawing.Size(205, 20);
            this.txtCantidadPersonas.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 165);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Precio por noche";
            // 
            // txtPrecioNoche
            // 
            this.txtPrecioNoche.Location = new System.Drawing.Point(177, 165);
            this.txtPrecioNoche.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrecioNoche.Name = "txtPrecioNoche";
            this.txtPrecioNoche.Size = new System.Drawing.Size(205, 20);
            this.txtPrecioNoche.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Tipos de cama";
            // 
            // txtNumCamas
            // 
            this.txtNumCamas.Location = new System.Drawing.Point(177, 110);
            this.txtNumCamas.Margin = new System.Windows.Forms.Padding(2);
            this.txtNumCamas.Name = "txtNumCamas";
            this.txtNumCamas.Size = new System.Drawing.Size(205, 20);
            this.txtNumCamas.TabIndex = 19;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(35, 113);
            this.lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(114, 13);
            this.lbl.TabIndex = 20;
            this.lbl.Text = "Numeros de camas";
            // 
            // cbTipoCama
            // 
            this.cbTipoCama.FormattingEnabled = true;
            this.cbTipoCama.Items.AddRange(new object[] {
            "Individual",
            "Matrimonial",
            "Queen Size",
            "King Size"});
            this.cbTipoCama.Location = new System.Drawing.Point(177, 137);
            this.cbTipoCama.Name = "cbTipoCama";
            this.cbTipoCama.Size = new System.Drawing.Size(205, 21);
            this.cbTipoCama.TabIndex = 27;
            // 
            // cbNivelHabitacion
            // 
            this.cbNivelHabitacion.FormattingEnabled = true;
            this.cbNivelHabitacion.Items.AddRange(new object[] {
            "Estándar",
            "Deluxe",
            "Suite"});
            this.cbNivelHabitacion.Location = new System.Drawing.Point(177, 219);
            this.cbNivelHabitacion.Name = "cbNivelHabitacion";
            this.cbNivelHabitacion.Size = new System.Drawing.Size(205, 21);
            this.cbNivelHabitacion.TabIndex = 30;
            this.cbNivelHabitacion.SelectedIndexChanged += new System.EventHandler(this.cbNivelHabitacion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 227);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Nivel de habitacion";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // checkbPiscina
            // 
            this.checkbPiscina.AutoSize = true;
            this.checkbPiscina.Location = new System.Drawing.Point(106, 271);
            this.checkbPiscina.Name = "checkbPiscina";
            this.checkbPiscina.Size = new System.Drawing.Size(62, 17);
            this.checkbPiscina.TabIndex = 35;
            this.checkbPiscina.Text = "Sí / No";
            this.checkbPiscina.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 271);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Piscina?";
            // 
            // checkbJardin
            // 
            this.checkbJardin.AutoSize = true;
            this.checkbJardin.Location = new System.Drawing.Point(265, 271);
            this.checkbJardin.Name = "checkbJardin";
            this.checkbJardin.Size = new System.Drawing.Size(62, 17);
            this.checkbJardin.TabIndex = 37;
            this.checkbJardin.Text = "Sí / No";
            this.checkbJardin.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(199, 272);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Jardin?";
            // 
            // checkbPlaya
            // 
            this.checkbPlaya.AutoSize = true;
            this.checkbPlaya.Location = new System.Drawing.Point(418, 272);
            this.checkbPlaya.Name = "checkbPlaya";
            this.checkbPlaya.Size = new System.Drawing.Size(62, 17);
            this.checkbPlaya.TabIndex = 39;
            this.checkbPlaya.Text = "Sí / No";
            this.checkbPlaya.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(356, 272);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "Playa?";
            // 
            // btnCrearHabitacion
            // 
            this.btnCrearHabitacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.btnCrearHabitacion.FlatAppearance.BorderSize = 0;
            this.btnCrearHabitacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearHabitacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearHabitacion.ForeColor = System.Drawing.Color.White;
            this.btnCrearHabitacion.Location = new System.Drawing.Point(409, 437);
            this.btnCrearHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnCrearHabitacion.Name = "btnCrearHabitacion";
            this.btnCrearHabitacion.Size = new System.Drawing.Size(139, 51);
            this.btnCrearHabitacion.TabIndex = 43;
            this.btnCrearHabitacion.Text = "Crear tipo de\r\nhabitacion";
            this.btnCrearHabitacion.UseVisualStyleBackColor = false;
            this.btnCrearHabitacion.Click += new System.EventHandler(this.btnRegHabitacion_Click);
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegistro.Location = new System.Drawing.Point(34, 38);
            this.lblRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(309, 26);
            this.lblRegistro.TabIndex = 46;
            this.lblRegistro.Text = "Registrar tipo de habitacion";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.btnSiguiente.FlatAppearance.BorderSize = 0;
            this.btnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiguiente.ForeColor = System.Drawing.Color.White;
            this.btnSiguiente.Location = new System.Drawing.Point(586, 437);
            this.btnSiguiente.Margin = new System.Windows.Forms.Padding(2);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(139, 51);
            this.btnSiguiente.TabIndex = 60;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(177, 86);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(205, 20);
            this.txtNombre.TabIndex = 62;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 86);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Nombre tipo";
            // 
            // panelOpenForm
            // 
            this.panelOpenForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOpenForm.Location = new System.Drawing.Point(0, 0);
            this.panelOpenForm.Name = "panelOpenForm";
            this.panelOpenForm.Size = new System.Drawing.Size(767, 528);
            this.panelOpenForm.TabIndex = 64;
            this.panelOpenForm.Visible = false;
            // 
            // regTipoHab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(767, 528);
            this.Controls.Add(this.panelOpenForm);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.btnCrearHabitacion);
            this.Controls.Add(this.checkbPlaya);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkbJardin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkbPiscina);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbNivelHabitacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbTipoCama);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCantidadPersonas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrecioNoche);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtNumCamas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(767, 528);
            this.Name = "regTipoHab";
            this.Text = "regHabitacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCantidadPersonas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrecioNoche;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumCamas;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cbTipoCama;
        private System.Windows.Forms.ComboBox cbNivelHabitacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkbPiscina;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkbJardin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkbPlaya;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCrearHabitacion;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelOpenForm;
    }
}