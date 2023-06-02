namespace PIA___MAD.Pantallas_Admin
{
    partial class reporteOcupacion
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
            this.button4 = new System.Windows.Forms.Button();
            this.lblRegistro = new System.Windows.Forms.Label();
            this.dgvHotel = new System.Windows.Forms.DataGridView();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lbl = new System.Windows.Forms.Label();
            this.cbFiltroHotel = new System.Windows.Forms.ComboBox();
            this.btnFiltroHotel = new System.Windows.Forms.Button();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.generarReporte = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(928, 605);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(101, 26);
            this.button4.TabIndex = 48;
            this.button4.Text = "Seleccionar";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegistro.Location = new System.Drawing.Point(11, 21);
            this.lblRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(357, 26);
            this.lblRegistro.TabIndex = 49;
            this.lblRegistro.Text = "Reporte de ocupacion por Hotel";
            // 
            // dgvHotel
            // 
            this.dgvHotel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHotel.Location = new System.Drawing.Point(24, 94);
            this.dgvHotel.Name = "dgvHotel";
            this.dgvHotel.RowHeadersWidth = 51;
            this.dgvHotel.Size = new System.Drawing.Size(651, 173);
            this.dgvHotel.TabIndex = 45;
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(24, 318);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.Size = new System.Drawing.Size(651, 150);
            this.dgvReporte.TabIndex = 47;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(21, 52);
            this.lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(69, 13);
            this.lbl.TabIndex = 93;
            this.lbl.Text = "Filtrar por: ";
            // 
            // cbFiltroHotel
            // 
            this.cbFiltroHotel.FormattingEnabled = true;
            this.cbFiltroHotel.Items.AddRange(new object[] {
            "Pais",
            "Año",
            "Ciudad",
            "Hotel"});
            this.cbFiltroHotel.Location = new System.Drawing.Point(24, 67);
            this.cbFiltroHotel.Name = "cbFiltroHotel";
            this.cbFiltroHotel.Size = new System.Drawing.Size(141, 21);
            this.cbFiltroHotel.TabIndex = 94;
            // 
            // btnFiltroHotel
            // 
            this.btnFiltroHotel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.btnFiltroHotel.FlatAppearance.BorderSize = 0;
            this.btnFiltroHotel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroHotel.ForeColor = System.Drawing.Color.White;
            this.btnFiltroHotel.Location = new System.Drawing.Point(407, 65);
            this.btnFiltroHotel.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiltroHotel.Name = "btnFiltroHotel";
            this.btnFiltroHotel.Size = new System.Drawing.Size(101, 22);
            this.btnFiltroHotel.TabIndex = 95;
            this.btnFiltroHotel.Text = "Filtrar";
            this.btnFiltroHotel.UseVisualStyleBackColor = false;
            this.btnFiltroHotel.Click += new System.EventHandler(this.btnFiltroHotel_Click);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(180, 67);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(205, 20);
            this.txtFiltro.TabIndex = 96;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(177, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 97;
            this.label3.Text = "Ingresar dato:";
            // 
            // generarReporte
            // 
            this.generarReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.generarReporte.FlatAppearance.BorderSize = 0;
            this.generarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generarReporte.ForeColor = System.Drawing.Color.White;
            this.generarReporte.Location = new System.Drawing.Point(24, 272);
            this.generarReporte.Margin = new System.Windows.Forms.Padding(2);
            this.generarReporte.Name = "generarReporte";
            this.generarReporte.Size = new System.Drawing.Size(140, 36);
            this.generarReporte.TabIndex = 98;
            this.generarReporte.Text = "Generar reporte";
            this.generarReporte.UseVisualStyleBackColor = false;
            this.generarReporte.Click += new System.EventHandler(this.generarReporte_Click);
            // 
            // reporteOcupacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(767, 528);
            this.Controls.Add(this.generarReporte);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.btnFiltroHotel);
            this.Controls.Add(this.cbFiltroHotel);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.dgvHotel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(767, 528);
            this.Name = "reporteOcupacion";
            this.Text = "reporteOcupacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHotel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.DataGridView dgvHotel;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox cbFiltroHotel;
        private System.Windows.Forms.Button btnFiltroHotel;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button generarReporte;
    }
}