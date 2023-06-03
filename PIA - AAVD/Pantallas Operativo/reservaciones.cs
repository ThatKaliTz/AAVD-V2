using PIA___AAVD;
using PIA___AAVD.Pantallas_Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PIA___AAVD.Clases;

namespace PIA___AAVD.Pantallas_Operativo
{
    public partial class reservaciones : Form
    {
        public Panel panelReserv
        {
            get { return panelOpenForm; }
        }

        public reservaciones()
        {
            InitializeComponent();
        }

        private void reservaciones_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
            panelOpenForm.Visible = false;
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            // Verificar si hay al menos una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0 
                && dataGridView2.SelectedRows.Count > 0)
            {
                // Obtener la primera fila seleccionada
                DataGridViewRow clienteSeleccionado = dataGridView1.SelectedRows[0];
                DataGridViewRow hotelSeleccionado = dataGridView2.SelectedRows[0];

                // Obtener los valores de las celdas de la fila seleccionada
                reservID.ClienteRFC = clienteSeleccionado.Cells["rfc"].Value.ToString();
                reservID.HotelID = hotelSeleccionado.Cells["idhotel"].Value.ToString();
            }


            // Aca verificamos lo que el usuario selecciono
            if (reservID.ClienteRFC != null && reservID.HotelID != null)
            {
                // Abrir otra ventana
                panelOpenForm.Visible = true;
                panelOpenForm.Controls.Clear();
                reservacionesHabitaciones reservH = new reservacionesHabitaciones();
                reservH.TopLevel = false;
                panelOpenForm.Controls.Add(reservH);
                panelOpenForm.BringToFront();
                reservH.Show();

                //MessageBox.Show(reservID.ClienteRFC + reservID.HotelID);
                //cbFiltroCliente.SelectedIndex = -1;
                //string prueba = dataGridView1.Rows[0].Cells[0].Value.ToString();
                //dtpFechaReservacion.ResetText();
                //DateTime FechaReservacion = dtpFechaReservacion.Value;
            }
            else
                MessageBox.Show("Seleccione los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {


            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            List<Cliente> clientelista = new List<Cliente>();

            string FiltroCliente = cbFiltroCliente.SelectedItem.ToString();
            string DatoCliente = Convert.ToString(txtDatoCliente.Text);

            if (FiltroCliente != null) {
                DataTable dt  = enlace.filtrarReserva(DatoCliente, FiltroCliente);
                dataGridView1.DataSource = dt;
            }

        }

        private void btnBuscarHotelPorCiudad_Click(object sender, EventArgs e)
        {
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();

            string DatoHotel = Convert.ToString(txtCiudad.Text);
            if(DatoHotel != null)
            {
                DataTable dt = enlace.filtrarHotel(DatoHotel);
                dataGridView2.DataSource = dt;
            }
        }

    }
}
