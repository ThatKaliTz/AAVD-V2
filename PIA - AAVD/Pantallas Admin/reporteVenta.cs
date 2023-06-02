using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIA___MAD.Pantallas;
using PIA___MAD.SQL_Conexion;
using static PIA___MAD.Clases;

namespace PIA___MAD.Pantallas_Admin
{
    public partial class reporteVenta : Form
    {

        private string strHotel;
        private DataTable mesesTabla;

        public reporteVenta()
        {
            InitializeComponent();
        }

        private void reporteVenta_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFiltroHotel_Click(object sender, EventArgs e)
        {
            ConexionSQL conexionSQL = new ConexionSQL();
            var Err = false; // SI no hay error
            try
            {
                // Convertir los datos de los textBoxs
                string filtroSeleccionado = cbFiltroHotel.SelectedItem.ToString();

                if (filtroSeleccionado == "Pais")
                {
                    string pais = Convert.ToString(txtFiltro.Text);
                    DataTable dt = conexionSQL.FiltrarHotelesPorPais(pais);
                    dataGridView1.DataSource = dt;
                    if (dgvReporte.DataSource != null)
                    {
                        dgvReporte.DataSource = null;
                        dgvReporte.Rows.Clear();
                        dgvReporte.Columns.Clear();
                    }
                }

                if (filtroSeleccionado == "Año")
                {
                    int anio = Convert.ToInt32(txtFiltro.Text);
                    DataTable dt = conexionSQL.FiltrarHotelesPorAnioRegistro(anio);
                    dataGridView1.DataSource = dt;
                    if (dgvReporte.DataSource != null)
                    {
                        dgvReporte.DataSource = null;
                        dgvReporte.Rows.Clear();
                        dgvReporte.Columns.Clear();
                    }
                }

                if (filtroSeleccionado == "Ciudad")
                {
                    string ciudad = Convert.ToString(txtFiltro.Text);
                    DataTable dt = conexionSQL.FiltrarHotelesPorCiudad(ciudad);
                    dataGridView1.DataSource = dt;
                    if (dgvReporte.DataSource != null)
                    {
                        dgvReporte.DataSource = null;
                        dgvReporte.Rows.Clear();
                        dgvReporte.Columns.Clear();
                    }
                }

                if (filtroSeleccionado == "Hotel")
                {
                    string hotel = Convert.ToString(txtFiltro.Text);
                    DataTable dt = conexionSQL.FiltrarHotelesPorNombre(hotel);
                    dataGridView1.DataSource = dt;
                    if (dgvReporte.DataSource != null)
                    {
                        dgvReporte.DataSource = null;
                        dgvReporte.Rows.Clear();
                        dgvReporte.Columns.Clear();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Err = true;
            }
        }

        private void seleccHotel_Click(object sender, EventArgs e)
        {
            // Verificar si hay al menos una fila seleccionada
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Obtener la primera fila seleccionada
                DataGridViewRow hotelSeleccionado = dataGridView1.SelectedRows[0];

                // Obtener los valores de las celdas de la fila seleccionada
                strHotel = hotelSeleccionado.Cells["idHotel"].Value.ToString();
            }

            if (strHotel == null)
            {
                MessageBox.Show("Seleccione los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvReporte.Rows.Clear();
                return;
            }

            int hotelID = Convert.ToInt32(strHotel);

            // Obtener los meses por hotel desde la base de datos
            List<ReporteVentas> listaReportes = new List<ReporteVentas>();
            mesesTabla = new DataTable();
            ConexionSQL conexionSQL = new ConexionSQL();
            mesesTabla = conexionSQL.ObtenerMesesPorHotel(hotelID);

            foreach (DataRow row in mesesTabla.Rows)
            {
                int mes = Convert.ToInt32(row["NumeroMes"]);

                // Crear un nuevo objeto ReporteVentas para almacenar los datos del mes actual
                ReporteVentas reporte = new ReporteVentas();
                reporte.Mes = mes;

                // Calcular los ingresos por hospedaje utilizando la función CalcularIngresosPorReserva
                reporte.IngresosHospedaje = conexionSQL.CalcularIngresosPorReserva(hotelID, mes);
                // Calcular los ingresos por servicios adicionales utilizando la función SumarPorMesYVariable
                reporte.IngresosServiciosAd = conexionSQL.ObtenerSumaCostoServicio(hotelID, mes);

                reporte.IngresosTotales = reporte.IngresosHospedaje + reporte.IngresosServiciosAd;

                // Agregar el objeto ReporteVentas a la lista
                listaReportes.Add(reporte);
            }

            // Asignar la listaReportes como origen de datos del DataGridView
            dgvReporte.DataSource = listaReportes;

        }

    }
}
