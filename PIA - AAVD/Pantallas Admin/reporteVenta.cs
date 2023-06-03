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
using PIA___AAVD.Pantallas;
using static PIA___AAVD.Clases;

namespace PIA___AAVD.Pantallas_Admin
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
                    // Crear un BindingSource para filtrar y proyectar los datos
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = hotelTabla;

                    // Crear una nueva lista con los datos filtrados y proyectados
                    List<object> data = new List<object>();
                    foreach (Clases.Hotel hotel in hotelTabla)
                    {
                        // Agregar los datos deseados a la lista
                        data.Add(new
                        {
                            idhotel = hotel.idhotel,
                            NombreHotel = hotel.nombre_hotel,
                            CiudadHotel = hotel.ciudadHotel,
                            AñoRegistro = Convert.ToDateTime(hotel.fechaRegistro).Year,
                            MesRegistro = Convert.ToDateTime(hotel.fechaRegistro).Month
                        });
                    }

                    // Asignar la lista filtrada y proyectada como origen de datos del DataGridView
                    dataGridView1.DataSource = new BindingSource { DataSource = data };
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
                    // Crear un BindingSource para filtrar y proyectar los datos
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = hotelTabla;

                    // Crear una nueva lista con los datos filtrados y proyectados
                    List<object> data = new List<object>();
                    foreach (Clases.Hotel hotel in hotelTabla)
                    {
                        // Agregar los datos deseados a la lista
                        data.Add(new
                        {
                            idhotel = hotel.idhotel,
                            NombreHotel = hotel.nombre_hotel,
                            CiudadHotel = hotel.ciudadHotel,
                            AñoRegistro = Convert.ToDateTime(hotel.fechaRegistro).Year,
                            MesRegistro = Convert.ToDateTime(hotel.fechaRegistro).Month
                        });
                    }

                    // Asignar la lista filtrada y proyectada como origen de datos del DataGridView
                    dataGridView1.DataSource = new BindingSource { DataSource = data };
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
                    // Crear un BindingSource para filtrar y proyectar los datos
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = hotelTabla;

                    // Crear una nueva lista con los datos filtrados y proyectados
                    List<object> data = new List<object>();
                    foreach (Clases.Hotel hotel in hotelTabla)
                    {
                        // Agregar los datos deseados a la lista
                        data.Add(new
                        {
                            idhotel = hotel.idhotel,
                            NombreHotel = hotel.nombre_hotel,
                            CiudadHotel = hotel.ciudadHotel,
                            AñoRegistro = Convert.ToDateTime(hotel.fechaRegistro).Year,
                            MesRegistro = Convert.ToDateTime(hotel.fechaRegistro).Month
                        });
                    }

                    // Asignar la lista filtrada y proyectada como origen de datos del DataGridView
                    dataGridView1.DataSource = new BindingSource { DataSource = data };
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
                    // Crear un BindingSource para filtrar y proyectar los datos
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = hotelTabla;

                    // Crear una nueva lista con los datos filtrados y proyectados
                    List<object> data = new List<object>();
                    foreach (Clases.Hotel hotelP3 in hotelTabla)
                    {
                        // Agregar los datos deseados a la lista
                        data.Add(new
                        {
                            idhotel = hotelP3.idhotel,
                            NombreHotel = hotelP3.nombre_hotel,
                            CiudadHotel = hotelP3.ciudadHotel,
                            AñoRegistro = Convert.ToDateTime(hotelP3.fechaRegistro).Year,
                            MesRegistro = Convert.ToDateTime(hotelP3.fechaRegistro).Month
                        });
                    }

                    // Asignar la lista filtrada y proyectada como origen de datos del DataGridView
                    dataGridView1.DataSource = new BindingSource { DataSource = data };
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
                strHotel = hotelSeleccionado.Cells["idhotel"].Value.ToString();
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
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            List<int> mesesPorHotel = enlace.ObtenerMesesPorHotel(hotelID);

            foreach (int mes in mesesPorHotel)
            {
                // Crear un nuevo objeto ReporteVentas para almacenar los datos del mes actual
                ReporteVentas reporte = new ReporteVentas();
                reporte.Mes = mes;

                // Calcular los ingresos por hospedaje utilizando la función CalcularIngresosPorReserva
                reporte.IngresosHospedaje = enlace.CalcularIngresosPorReserva(hotelID, mes);
                // Calcular los ingresos por servicios adicionales utilizando la función SumarPorMesYVariable
                reporte.IngresosServiciosAd = enlace.ObtenerSumaCostoServicio(hotelID, mes);

                reporte.IngresosTotales = reporte.IngresosHospedaje + reporte.IngresosServiciosAd;

                // Agregar el objeto ReporteVentas a la lista
                listaReportes.Add(reporte);
            }

            // Asignar la listaReportes como origen de datos del DataGridView
            dgvReporte.DataSource = listaReportes;

        }

    }
}