using PIA___AAVD;
using PIA___MAD.Pantallas_Admin;
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
using static PIA___MAD.Clases;
using PIA___MAD.Pantallas;
using PIA___MAD.SQL_Conexion;

namespace PIA___MAD.Pantallas_Admin
{
    public partial class cancelaciones : Form
    {

        public cancelaciones()
        {
            InitializeComponent();
        }

        private void cancelaciones_Load(object sender, EventArgs e)
        {
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();

            this.FormClosed += new FormClosedEventHandler(exitApp);
            DataTable dt = enlace.cObtenerReservas();

            dgvReserva.DataSource = dt;
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void limpiarTextBox()
        {
            txtCodigoReservacion.Clear();
            ConexionSQL conexionSQL = new ConexionSQL();
            DataTable dt = conexionSQL.cObtenerReservas();
            dgvReserva.DataSource = dt;
        }

        private void btnEliminarReserv_Click(object sender, EventArgs e)
        {
            var Err = false; // SI no hay error
            try
            {
                EnlaceCassandra enlace = EnlaceCassandra.getInstance();

                // Convertir los datos de los textBoxs
                int codigoBuscado = Convert.ToInt32(txtCodigoReservacion.Text);
            
                // Enviar los datos a la base de datos mediante el Table Adapter
                if (codigoBuscado != null)
                {

                    
                    enlace.rEliminarReservas(codigoBuscado);
                    limpiarTextBox();
                    DataTable dt = enlace.cObtenerReservas();

                    dgvReserva.DataSource = dt;
                }
                else
                    MessageBox.Show("Seleccione los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Err = true;
            }


        }
    }
}
