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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIA___MAD.Pantallas_Operativo
{
    public partial class checkOut : Form
    {
        private static datosCheckOut datos;
        public static bool validarBoton = false;

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
                DataTable dt = conexionSQL.ObtenerReservaCheckOut(codigoReservacion);
                dataGridView1.DataSource = dt;

                if (dataGridView1.RowCount > 0)
                {
                    // Obtener la primera fila de la DataGrid
                    var row = dataGridView1.Rows[0];

                    // Asignar los valores obtenidos a la variable datos
                    datos = new datosCheckOut();
                    datos.hotelID = Convert.ToInt32(row.Cells["idHotel"].Value);
                    datos.checkOut = Convert.ToInt32(row.Cells["checkOut"].Value);
                    datos.cantidadPersonas = Convert.ToInt32(row.Cells["cantidadPersonas"].Value);
                    string codigoBuscado = row.Cells["codigoReservacion"].Value?.ToString() ?? string.Empty;
                    if (codigoBuscado != null)
                        datos.codigoReservacion = Guid.Parse(codigoBuscado);
                    else
                        datos.codigoReservacion = Guid.Empty;

                    datos.anticipo = Convert.ToSingle(row.Cells["anticipo"].Value);
                    datos.servUtilizados = row.Cells["servUtilizados"].Value.ToString();
                    datos.costoServicio = Convert.ToSingle(row.Cells["costoServicio"].Value);
                    datos.metodoPago = row.Cells["metodoPago"].Value.ToString();
                    datos.fechaInicio = Convert.ToDateTime(row.Cells["fechaInicio"].Value);
                    datos.fechaFin = Convert.ToDateTime(row.Cells["fechaFin"].Value);

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
                    datos.checkOut = 0;
                    datos.cantidadPersonas = 0;
                    datos.codigoReservacion = Guid.Empty;
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
            if (checkOut == 0) { // Aun no ha pasado de la fechaFin

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
            //datos.anticipo = Convert.ToSingle(txtAnticipo.Text);
            //datos.servUtilizados = Convert.ToString(txtServiciosAd.Text);
            //datos.costoServicio = Convert.ToSingle(txtCostoServicio.Text);
            //datos.metodoPago = cbMetodoPago.SelectedItem.ToString();
            //ConexionSQL conexionSQL = new ConexionSQL();
            //// ** Metodo UPDATE al clickear el boton
            //conexionSQL.ActualizarReserva(datos.codigoReservacion, datos.anticipo, datos.servUtilizados,
            //    datos.costoServicio, datos.metodoPago);
            //conexionSQL.PonerCheckOut(datos.codigoReservacion);
            //decimal totalReserva = conexionSQL.ObtenerTotalReserva(datos.codigoReservacion);
            //if (totalReserva != 0)
            //{
            //    MessageBox.Show("El total de la reserva es: " + totalReserva.ToString(), 
            //        "Factura generada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    limpiarCampos();
            //    ocultarTodo();
            //}

        }
        private void btnBuscarHab_Click(object sender, EventArgs e)
        {
            datos.fechaFin = dtpFechaLimite.Value;
            // Metodo buscar habitacion y mostrarla
            ConexionSQL conexionSQL = new ConexionSQL();
            DataTable dt = conexionSQL.obtenerHabitacionesCheckOut(datos.hotelID, datos.fechaInicio, datos.fechaFin, datos.cantidadPersonas, datos.codigoReservacion);
            dgvHabitacion.DataSource = dt;
        }

        private void btnSeleccHabitacion_Click(object sender, EventArgs e)
        {
            // Metodo actualizar reserva
            ConexionSQL conexionSQL = new ConexionSQL();

            if (datos.fechaInicio >= datos.fechaFin)
            {
                MessageBox.Show("Proporcione todos los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (dgvHabitacion.SelectedRows.Count > 0) {
                // Obtener la primera fila seleccionada
                DataGridViewRow habSeleccionada = dgvHabitacion.SelectedRows[0];

                // Obtener los valores de las celdas de la fila seleccionada
                object id = habSeleccionada.Cells["idHabitacion"].Value;
                int idHabitacion = Convert.ToInt32(id);
                conexionSQL.ActualizarReservaExtendida(datos.codigoReservacion, idHabitacion, datos.fechaFin);
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
            ConexionSQL conexionSQL = new ConexionSQL();
            //conexionSQL.ActualizarCheckOut();

            ocultarTodo();
        }

        private void btnFechaFin_Click(object sender, EventArgs e)
        {
            if(validarBoton)
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
