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
            this.FormClosed += new FormClosedEventHandler(exitApp);
            ConexionSQL conexionSQL = new ConexionSQL();
            conexionSQL.ActualizarCheckIn();
        }
   

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBuscarReservacion_Click(object sender, EventArgs e)
        {
            string codigoReserv = Convert.ToString(txtCodigoReserv.Text);
            Guid codigoReservacion = Guid.Parse(codigoReserv);

            //Si no introdujo nada
            if (codigoReservacion == Guid.Empty)
            {
                MessageBox.Show("Ingrese los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ConexionSQL conexionSQL = new ConexionSQL();

            try
            {
                DataTable dt = conexionSQL.ObtenerCheckIn(codigoReservacion);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
