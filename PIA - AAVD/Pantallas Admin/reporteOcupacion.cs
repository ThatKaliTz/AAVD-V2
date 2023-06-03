using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIA___AAVD;
using static PIA___AAVD.Clases;

namespace PIA___AAVD.Pantallas_Admin
{
    public partial class reporteOcupacion : Form
    {

        private string strHotel;


        public reporteOcupacion()
        {
            InitializeComponent();
        }

        private void reporteOcupacion_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void limpiarTextBox()
        {
            cbFiltroHotel.SelectedIndex = -1;
        }

        private void btnFiltroHotel_Click(object sender, EventArgs e)
        {
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            List<Clases.Hotel> hotelTabla = new List<Clases.Hotel>();
            var Err = false; // SI no hay error
            try
            {
                // Convertir los datos de los textBoxs
                string filtroSeleccionado = cbFiltroHotel.SelectedItem.ToString();

                if (filtroSeleccionado == "Pais")
                {
                    string pais = Convert.ToString(txtFiltro.Text);
                    hotelTabla = enlace.GetHotelesPais(pais);
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
                    hotelTabla = enlace.GetHotelesAnio(anio);
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
                    hotelTabla = enlace.GetHotelesCiudad(ciudad);
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
                    hotelTabla = enlace.GetHotelesNombre(hotel);
                    if (dgvReporte.DataSource != null)
                    {
                        dgvReporte.DataSource = null;
                        dgvReporte.Rows.Clear();
                        dgvReporte.Columns.Clear();
                    }
                }

                // Agregar columnas faltantes
                List<HotelInfo> listaHotel = new List<HotelInfo>();

                foreach (var hotel in hotelTabla)
                {
                    int idHotel = hotel.idhotel;

                    HotelInfo hotelInfo = new HotelInfo();
                    hotelInfo.idHotel = idHotel;
                    hotelInfo.nombreHotel = hotel.nombre_hotel;
                    hotelInfo.ciudadHotel = hotel.ciudadHotel;
                    // Resto del código para asignar valores a hotelInfo

                    int limitePersonas = enlace.ObtenerLimitePersonasPorHotel(idHotel);

                    // Obtener la cantidad de personas hospedadas por hotel
                    int cantidadPersonasHospedadas = enlace.ObtenerCantidadPersonasReservadas(idHotel);

                    // Calcular el porcentaje de ocupación
                    double porcentajeOcupacion, porcentajeOcupacionRedondeado;
                    if (cantidadPersonasHospedadas != 0)
                    {
                        porcentajeOcupacion = (double)cantidadPersonasHospedadas / limitePersonas * 100;
                        // Redondear el porcentaje de ocupación a 2 decimales
                        porcentajeOcupacionRedondeado = Math.Round(porcentajeOcupacion, 2);
                    }
                    else
                    {
                        porcentajeOcupacionRedondeado = 0.0;
                    }

                    // Asignar los valores calculados a hotelInfo
                    hotelInfo.limitePersonas = limitePersonas;
                    hotelInfo.cantidadPersonasHospedadas = cantidadPersonasHospedadas;
                    hotelInfo.porcentajeOcupacion = porcentajeOcupacionRedondeado;

                    // Agregar el objeto hotelInfo a la lista
                    listaHotel.Add(hotelInfo);
                }

                // Asignar la lista de reportes como origen de datos del DataGridView
                dgvHotel.DataSource = listaHotel;

            }
            catch (Exception ex)
            {
                throw ex;
                Err = true;
            }
        }

        private void generarReporte_Click(object sender, EventArgs e)
        {
            // Verificar si hay al menos una fila seleccionada
            if (dgvHotel.SelectedRows.Count > 0)
            {
                // Obtener la primera fila seleccionada
                DataGridViewRow hotelSeleccionado = dgvHotel.SelectedRows[0];

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
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            List<Clases.ResumenTipoHabitacion> resumenTipoHabitacion = enlace.ObtenerResumenTipoHabitacion(hotelID);
            dgvReporte.DataSource = resumenTipoHabitacion;
        }
    }
}