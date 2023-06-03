namespace PIA___AAVD.Pantallas_Admin
{
    partial class reporteVenta
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
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.generarReporte = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnFiltroHotel = new System.Windows.Forms.Button();
            this.cbFiltroHotel = new System.Windows.Forms.ComboBox();
            this.lbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRegistro
            // 
            this.lblRegistro.AutoSize = true;
            this.lblRegistro.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRegistro.Location = new System.Drawing.Point(11, 22);
            this.lblRegistro.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistro.Name = "lblRegistro";
            this.lblRegistro.Size = new System.Drawing.Size(208, 26);
            this.lblRegistro.TabIndex = 58;
            this.lblRegistro.Text = "Reporte de ventas";
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(25, 286);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.Size = new System.Drawing.Size(651, 176);
            this.dgvReporte.TabIndex = 56;
            // 
            // generarReporte
            // 
            this.generarReporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.generarReporte.FlatAppearance.BorderSize = 0;
            this.generarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generarReporte.ForeColor = System.Drawing.Color.White;
            this.generarReporte.Location = new System.Drawing.Point(25, 241);
            this.generarReporte.Margin = new System.Windows.Forms.Padding(2);
            this.generarReporte.Name = "generarReporte";
            this.generarReporte.Size = new System.Drawing.Size(140, 36);
            this.generarReporte.TabIndex = 55;
            this.generarReporte.Text = "Generar reporte";
            this.generarReporte.UseVisualStyleBackColor = false;
            this.generarReporte.Click += new System.EventHandler(this.seleccHotel_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(651, 139);
            this.dataGridView1.TabIndex = 54;
            // 
            // btnFiltroHotel
            // 
            this.btnFiltroHotel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(188)))), ((int)(((byte)(92)))));
            this.btnFiltroHotel.FlatAppearance.BorderSize = 0;
            this.btnFiltroHotel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroHotel.ForeColor = System.Drawing.Color.White;
            this.btnFiltroHotel.Location = new System.Drawing.Point(408, 68);
            this.btnFiltroHotel.Margin = new System.Windows.Forms.Padding(2);
            this.btnFiltroHotel.Name = "btnFiltroHotel";
            this.btnFiltroHotel.Size = new System.Drawing.Size(101, 22);
            this.btnFiltroHotel.TabIndex = 53;
            this.btnFiltroHotel.Text = "Filtrar";
            this.btnFiltroHotel.UseVisualStyleBackColor = false;
            this.btnFiltroHotel.Click += new System.EventHandler(this.btnFiltroHotel_Click);
            // 
            // cbFiltroHotel
            // 
            this.cbFiltroHotel.FormattingEnabled = true;
            this.cbFiltroHotel.Items.AddRange(new object[] {
            "Pais",
            "Año",
            "Ciudad",
            "Hotel"});
            this.cbFiltroHotel.Location = new System.Drawing.Point(25, 70);
            this.cbFiltroHotel.Name = "cbFiltroHotel";
            this.cbFiltroHotel.Size = new System.Drawing.Size(141, 21);
            this.cbFiltroHotel.TabIndex = 52;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl.Location = new System.Drawing.Point(22, 55);
            this.lbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(69, 13);
            this.lbl.TabIndex = 51;
            this.lbl.Text = "Filtrar por: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(178, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 92;
            this.label3.Text = "Ingresar dato:";
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(181, 70);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(2);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(205, 20);
            this.txtFiltro.TabIndex = 91;
            // 
            // reporteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(767, 528);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblRegistro);
            this.Controls.Add(this.dgvReporte);
            this.Controls.Add(this.generarReporte);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnFiltroHotel);
            this.Controls.Add(this.cbFiltroHotel);
            this.Controls.Add(this.lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(767, 528);
            this.Name = "reporteVenta";
            this.Text = "reporteVenta";
            this.Load += new System.EventHandler(this.reporteVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRegistro;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button generarReporte;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFiltroHotel;
        private System.Windows.Forms.ComboBox cbFiltroHotel;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFiltro;
    }
}