using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIA___AAVD.Pantallas_Operativo;

namespace PIA___AAVD
{

    public partial class Operativo : Form
    {
        public string usuario;

        public Operativo()
        {
            InitializeComponent();
        }

        private void Operativo_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            btnRegistrarCliente clientesP = new btnRegistrarCliente();
            clientesP.TopLevel = false;
            panelOpenForm.Controls.Add(clientesP);
            panelOpenForm.BringToFront();
            clientesP.Show();
        }

        private void btnReservacion_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            reservaciones reservacionesP = new reservaciones();
            reservacionesP.TopLevel = false;
            panelOpenForm.Controls.Add(reservacionesP);
            panelOpenForm.BringToFront();
            reservacionesP.Show();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            checkIn CheckIn = new checkIn();
            CheckIn.TopLevel = false;
            panelOpenForm.Controls.Add(CheckIn);
            panelOpenForm.BringToFront();
            CheckIn.Show();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            panelOpenForm.Controls.Clear();
            checkOut CheckOut = new checkOut();
            CheckOut.TopLevel = false;
            panelOpenForm.Controls.Add(CheckOut);
            panelOpenForm.BringToFront();
            CheckOut.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login_ = new login();
            login_.ShowDialog();
        }
    }
}
