using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.FormClosed += new FormClosedEventHandler(exitApp);
            ConexionSQL conexionSQL = new ConexionSQL();
            DataTable dt = conexionSQL.cObtenerReservas();
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
            ConexionSQL conexionSQL = new ConexionSQL();
            try
            {
                // Convertir los datos de los textBoxs
                string codigoBuscado = Convert.ToString(txtCodigoReservacion.Text);
            
                // Enviar los datos a la base de datos mediante el Table Adapter
                if (codigoBuscado != null)
                {
                    Guid idReserva = Guid.Parse(codigoBuscado);
                    conexionSQL.cEliminarReserva(idReserva);
                    limpiarTextBox();
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
