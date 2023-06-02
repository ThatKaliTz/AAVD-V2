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

namespace PIA___MAD.Pantallas_Operativo
{
    public partial class reservacionesHabitaciones : Form
    {
        public reservacionesHabitaciones()
        {
            InitializeComponent();
        }

        private void reservacionesHabitaciones_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            this.Hide();
            btnRegistrarCliente clientesP = new btnRegistrarCliente();
            clientesP.ShowDialog();
            this.Show();
        }

        private void btnReservacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            reservaciones reservacionesP = new reservaciones();
            reservacionesP.ShowDialog();
            this.Show();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            checkIn CheckIn = new checkIn();
            CheckIn.ShowDialog();
            this.Show();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            checkOut CheckOut = new checkOut();
            CheckOut.ShowDialog();
            this.Show();
        }


        private void btnReservar_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dtpFechaInicio.Value;
            DateTime fechaFin = dtpFechaFin.Value;

            if (fechaInicio > fechaFin)
            {
                MessageBox.Show("Proporcione todos los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

                ConexionSQL conexionSQL = new ConexionSQL();
            Guid codigoReservacion = Guid.Empty;
            int idHabitacion;
            var Err = false; // SI no hay error

            // Verificar si hay al menos una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la primera fila seleccionada
                DataGridViewRow habitacionSeleccionada = dataGridView1.SelectedRows[0];

                // Obtener los valores de las celdas de la fila seleccionada
                string strHabitacion = habitacionSeleccionada.Cells["idHabitacion"].Value.ToString();
                idHabitacion = Convert.ToInt16(strHabitacion);
            }
            else
            {
                MessageBox.Show("Proporcione todos los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                float Anticipo = Convert.ToSingle(txtAnticipo.Text);
                string servUtilizados = Convert.ToString(txtServiciosAd.Text);
                float descuento = Convert.ToSingle(txtDescuento.Text);
                float costoServicio = Convert.ToSingle(txtCostoServicio.Text);
                string numeroFactura = Convert.ToString(txtNumeroFactura.Text);
                string MetodoPago = cbMetodoPago.SelectedItem.ToString();
                int cantidadPersonas = Convert.ToInt16(txtCantidad.Text);
                int hotelID = Convert.ToInt16(reservID.HotelID);
                DateTime fechaRegistro = DateTime.Now.Date;
                TimeSpan horaRegistro = DateTime.Now.TimeOfDay;

                codigoReservacion = conexionSQL.InsertarReserva(fechaInicio, fechaFin, servUtilizados, costoServicio,
                    MetodoPago, descuento, Anticipo, numeroFactura, cantidadPersonas, Validaciones.usuario,
                    fechaRegistro, horaRegistro, reservID.ClienteRFC, idHabitacion);
            }
            catch (Exception ex)
            {
                Err = true;
            }

            if (!Err && codigoReservacion != Guid.Empty)
            {
                reservID.ClienteRFC = null;
                reservID.HotelID = null;

                MessageBox.Show("Su codigo de reservacion es" + codigoReservacion.ToString(), "Reserva completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                panelOpenForm.Visible = true;
                panelOpenForm.Controls.Clear();
                reservaciones reservacionesP = new reservaciones();
                reservacionesP.TopLevel = false;
                panelOpenForm.Controls.Add(reservacionesP);
                panelOpenForm.BringToFront();
                reservacionesP.Show();

            }



        }

        private void btnBuscarHabitacion_Click(object sender, EventArgs e)
        {
            //
            ConexionSQL conexionSQL = new ConexionSQL();
            try
            {
                DateTime FechaInicio = dtpFechaInicio.Value.Date;
                DateTime FechaFin = dtpFechaFin.Value.Date;
                int personasHospedar = Convert.ToInt16(txtCantidad.Text);
                int hotelID = Convert.ToInt16(reservID.HotelID);
                DataTable dt = conexionSQL.rObtenerHabitacionesDisponibles(hotelID, FechaInicio, FechaFin, personasHospedar);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seleccionar el ID de la Habitacion
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            panelOpenForm.Visible = true;
            panelOpenForm.Controls.Clear();
            reservaciones reservacionesP = new reservaciones();
            reservacionesP.TopLevel = false;
            panelOpenForm.Controls.Add(reservacionesP);
            panelOpenForm.BringToFront();
            reservacionesP.Show();

        }
    }
}
