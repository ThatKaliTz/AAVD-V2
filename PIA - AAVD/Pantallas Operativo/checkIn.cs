using PIA___AAVD;
using PIA___MAD.SQL_Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA___MAD.Pantallas_Operativo
{
    public partial class checkIn : Form
    {
        public static List<Clases.Reserva> reservaBuscada;

        public checkIn()
        {
            InitializeComponent();
        }

        private void checkIn_Load(object sender, EventArgs e)
        {
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            enlace.ActualizarCheckin();
            this.FormClosed += new FormClosedEventHandler(exitApp);

        }


        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBuscarReservacion_Click(object sender, EventArgs e)
        {

            EnlaceCassandra enlace = EnlaceCassandra.getInstance();

            string codigoReserv = Convert.ToString(txtCodigoReserv.Text);

            //Si no introdujo nada
            if (codigoReserv == null)
            {
                MessageBox.Show("Ingrese los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int codigoReservacion = Convert.ToInt32(codigoReserv);

            try
            {
                reservaBuscada = enlace.BuscarReservaPorCodigo(codigoReservacion);
                dataGridView1.DataSource = reservaBuscada;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}