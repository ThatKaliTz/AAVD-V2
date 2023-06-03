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
        public checkIn()
        {
            InitializeComponent();
        }

        private void checkIn_Load(object sender, EventArgs e)
        {
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();

            this.FormClosed += new FormClosedEventHandler(exitApp);
            enlace.actualizarCheckIn();
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



            try
            {
                //DataTable dt = conexionSQL.ObtenerCheckIn(codigoReserv);
                //dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
