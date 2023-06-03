using PIA___AAVD.Pantallas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIA___AAVD.Pantallas_Admin;

namespace PIA___AAVD
{
    public partial class Admin : Form
    {
        public string usuario;

        public Admin()
        {
            InitializeComponent();
        }
        private void Admin_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            regUsuario regUsuarios = new regUsuario();
            regUsuarios.TopLevel = false;
            panelOpenForm.Controls.Add(regUsuarios);
            panelOpenForm.BringToFront();
            regUsuarios.Show();
        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            regHoteles regHotel = new regHoteles();
            regHotel.TopLevel = false;
            panelOpenForm.Controls.Add(regHotel);
            panelOpenForm.BringToFront();
            regHotel.Show();
        }

        private void btnCancelacion_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            cancelaciones cancelacionesP = new cancelaciones();
            cancelacionesP.TopLevel = false;
            panelOpenForm.Controls.Add(cancelacionesP);
            panelOpenForm.BringToFront();
            cancelacionesP.Show();
        }

        private void btnReporteOcup_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            reporteOcupacion reporteOcupacionP = new reporteOcupacion();
            reporteOcupacionP.TopLevel = false;
            panelOpenForm.Controls.Add(reporteOcupacionP);
            panelOpenForm.BringToFront();
            reporteOcupacionP.Show();

        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            reporteVenta reporteVentaP = new reporteVenta();
            reporteVentaP.TopLevel = false;
            panelOpenForm.Controls.Add(reporteVentaP);
            panelOpenForm.BringToFront();
            reporteVentaP.Show();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            historial historialP = new historial();
            historialP.TopLevel = false;
            panelOpenForm.Controls.Add(historialP);
            panelOpenForm.BringToFront();
            historialP.Show();
        }

        private void btnRehabilitar_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            rehabilitarUsuario rehabilitarUsuarioP = new rehabilitarUsuario();
            rehabilitarUsuarioP.TopLevel = false;
            panelOpenForm.Controls.Add(rehabilitarUsuarioP);
            panelOpenForm.BringToFront();
            rehabilitarUsuarioP.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login_ = new login();
            login_.ShowDialog();
        }
    }
}
