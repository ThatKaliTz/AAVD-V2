using PIA___AAVD;

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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIA___AAVD.Pantallas_Operativo
{
    public partial class checkOut : Form
    {
        private static datosCheckOut datos;
        public static bool validarBoton = false;
        public static List<Clases.Reserva> reservaBuscada;

        public checkOut()
        {
            InitializeComponent();
        }


        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtCodigoReservacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarReserv_Click(object sender, EventArgs e)
        {
            string codigoReserv = Convert.ToString(txtCodigoReservacion.Text);
            int codigoReservacion = Convert.ToInt32(codigoReserv);

            //Si no introdujo nada
            if (string.IsNullOrEmpty(codigoReserv))
            {
                MessageBox.Show("Ingrese los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EnlaceCassandra enlace = EnlaceCassandra.getInstance();

            try
            {
                //Aca
                reservaBuscada = enlace.BuscarReservaPorCodigo(codigoReservacion);
                dataGridView1.DataSource = reservaBuscada;

                if (dataGridView1.RowCount > 0)
                {
                    // Obtener la primera fila de la DataGrid
                    var row = dataGridView1.Rows[0];

                    // Asignar los valores obtenidos a la variable datos
                    datos = new datosCheckOut();
                    datos.idhabitacion = Convert.ToInt32(row.Cells["idhabitacion"].Value);
                    datos.hotelID = enlace.ObtenerIdHotelPorHabitacion(datos.idhabitacion);
                    datos.checkOut = Convert.ToBoolean(row.Cells["checkout"].Value);
                    datos.cantidadPersonas = Convert.ToInt32(row.Cells["cantidadpersonas"].Value);
                    string codigoBuscado = row.Cells["codigoreservacion"].Value?.ToString() ?? string.Empty;
                    if (codigoBuscado != null)
                        datos.codigoReservacion = Convert.ToInt32(codigoBuscado);

                    datos.anticipo = Convert.ToSingle(row.Cells["anticipo"].Value);
                    datos.servUtilizados = row.Cells["servutilizados"].Value.ToString();
                    datos.costoServicio = Convert.ToSingle(row.Cells["costoservicio"].Value);
                    datos.metodoPago = row.Cells["metodopago"].Value.ToString();
                    datos.fechaInicio = Convert.ToDateTime(row.Cells["fechainicio"].Value);
                    datos.fechaFin = Convert.ToDateTime(row.Cells["fechafin"].Value);
                    DateTime actualDate = DateTime.Now.Date;
                    int checkOut = 10;
                    if (datos.fechaFin > actualDate)
                        checkOut = 0;


                    validarCheckOut(checkOut);

                }
                else
                {
                    datos = new datosCheckOut();
                    datos.hotelID = 0;
                    datos.checkOut = false;
                    datos.cantidadPersonas = 0;
                    datos.codigoReservacion = 0;
                    datos.anticipo = 0.0f;
                    datos.servUtilizados = null;
                    datos.costoServicio = 0.0f;
                    datos.metodoPago = null;

                    ocultarTodo();

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void validarCheckOut(int checkOut)
        {
            if (checkOut == 0)
            { // Aun no ha pasado de la fechaFin

                // Check out false
                btnFechaFin.Visible = true;
                validarBoton = true;
                //lblFechaLimite.Visible = true;
                //dtpFechaLimite.Visible = true;
                //lblHabDisp.Visible = true;
                //dgvHabitacion.Visible = true;
                //btnSeleccHabitacion.Visible = true;
                //btnBuscarHab.Visible = true;

            }

            // Check out true
            lblAnticipo.Visible = true;
            txtAnticipo.Visible = true;
            lblCostoServicio.Visible = true;
            txtCostoServicio.Visible = true;
            lblMetodoPago.Visible = true;
            cbMetodoPago.Visible = true;
            lblServiciosAd.Visible = true;
            txtServiciosAd.Visible = true;
            btnGenerarFactura.Visible = true;

            // Desplegar los datos en los campos
            int indice = cbMetodoPago.FindStringExact(datos.metodoPago);
            if (indice != -1)
                cbMetodoPago.SelectedIndex = indice;
            txtAnticipo.Text = Convert.ToString(datos.anticipo);
            txtCostoServicio.Text = Convert.ToString(datos.costoServicio);
            txtServiciosAd.Text = Convert.ToString(datos.servUtilizados);

        }

        private void ocultarTodo()
        {
            validarBoton = false;

            // Check out true
            btnFechaFin.Visible = false;
            lblAnticipo.Visible = false;
            txtAnticipo.Visible = false;
            lblCostoServicio.Visible = false;
            txtCostoServicio.Visible = false;
            lblMetodoPago.Visible = false;
            cbMetodoPago.Visible = false;
            lblServiciosAd.Visible = false;
            txtServiciosAd.Visible = false;
            btnGenerarFactura.Visible = false;

            // Check out false
            lblFechaLimite.Visible = false;
            dtpFechaLimite.Visible = false;
            lblHabDisp.Visible = false;
            dgvHabitacion.Visible = false;
            btnSeleccHabitacion.Visible = false;
            btnBuscarHab.Visible = false;

        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            datos.anticipo = Convert.ToSingle(txtAnticipo.Text);
            datos.servUtilizados = Convert.ToString(txtServiciosAd.Text);
            datos.costoServicio = Convert.ToSingle(txtCostoServicio.Text);
            datos.metodoPago = cbMetodoPago.SelectedItem.ToString();

            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            enlace.ActualizarReserva(datos.codigoReservacion, datos.anticipo, datos.servUtilizados,
                datos.costoServicio, datos.metodoPago);
            enlace.PonerCheckOut(datos.codigoReservacion);

            float totalReserva = enlace.ObtenerTotalReserva(datos.codigoReservacion);
            if (totalReserva != 0)
            {
                MessageBox.Show("El total de la reserva es: " + totalReserva.ToString(),
                    "Factura generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarCampos();
                ocultarTodo();
            }

        }
        private void btnBuscarHab_Click(object sender, EventArgs e)
        {
            datos.fechaFin = dtpFechaLimite.Value;
            // Metodo buscar habitacion y mostrarla
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            List<Clases.HabitacionCheckOut> tablaHabitacion = enlace.ObtenerHabitacionesCheckOut(datos.hotelID, datos.fechaInicio, datos.fechaFin, datos.cantidadPersonas);
            dgvHabitacion.DataSource = tablaHabitacion;
        }

        private void btnSeleccHabitacion_Click(object sender, EventArgs e)
        {
            // Metodo actualizar reserva
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();

            if (datos.fechaInicio >= datos.fechaFin)
            {
                MessageBox.Show("Proporcione todos los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (dgvHabitacion.SelectedRows.Count > 0)
            {
                // Obtener la primera fila seleccionada
                DataGridViewRow habSeleccionada = dgvHabitacion.SelectedRows[0];

                // Obtener los valores de las celdas de la fila seleccionada
                object id = habSeleccionada.Cells["idhabitacion"].Value;
                int idHabitacion = Convert.ToInt32(id);
                enlace.ActualizarReservaExtendida(datos.codigoReservacion, idHabitacion, datos.fechaFin);
                limpiarCampos();
                ocultarTodo();
            }


        }

        private void limpiarCampos()
        {
            txtCodigoReservacion.Clear();
            txtServiciosAd.Clear();
            txtCostoServicio.Clear();
            txtAnticipo.Clear();
            cbMetodoPago.SelectedIndex = -1;
            dtpFechaLimite.ResetText();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dgvHabitacion.DataSource = null;
            dgvHabitacion.Rows.Clear();

        }

        private void checkOut_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);


            ocultarTodo();
        }

        private void btnFechaFin_Click(object sender, EventArgs e)
        {
            if (validarBoton)
            {
                lblFechaLimite.Visible = true;
                dtpFechaLimite.Visible = true;
                lblHabDisp.Visible = true;
                dgvHabitacion.Visible = true;
                btnSeleccHabitacion.Visible = true;
                btnBuscarHab.Visible = true;
            }
        }
    }

}