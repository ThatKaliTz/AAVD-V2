using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using PIA___AAVD.Pantallas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIA___AAVD.Pantallas_Admin
{
    public partial class historial : Form
    {

        // Filtro: Un SELECT a la tabla de Cliente por el dato seleccionado para buscarlo
        // Va a mandarle todas las reservaciones hechas por ese cliente, o sea:
        // SELECT FROM Reservacion WHERE Cliente(???

        public historial()
        {
            InitializeComponent();
        }

        private void historial_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void limpiarTextBox()
        {
            cbFiltro.SelectedIndex = -1;
            txtDatoBuscado.Clear();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            var Err = false; // SI no hay error

            DataTable historialTabla = new DataTable();

            try
            {
                // Convertir los datos de los textBoxs
                string filtroSeleccionado = cbFiltro.SelectedItem.ToString();
                
                if (filtroSeleccionado == "Año")
                {
                    int anio = Convert.ToInt32(txtDatoBuscado.Text);

                }

                if (filtroSeleccionado == "Cliente")
                {
                    string cliente = Convert.ToString(txtDatoBuscado.Text);


                }

                // Agregar columnas faltantes
                List<HistorialCliente> listaHistorial = new List<HistorialCliente>();

                foreach (DataRow row in historialTabla.Rows)
                {
                    string idReserva = Convert.ToString(row["codigoReservacion"]);

                    HistorialCliente reserva = new HistorialCliente();
                    reserva.codigoReservacion = Guid.Parse(idReserva);
                    reserva.apellidoPaterno = Convert.ToString(row["apellidoPaterno"]);
                    reserva.apellidoMaterno = Convert.ToString(row["apellidoMaterno"]);
                    reserva.Nombre = Convert.ToString(row["Nombre"]);
                    reserva.nombreHotel = Convert.ToString(row["nombreHotel"]);
                    reserva.nombreTipo = Convert.ToString(row["nombreTipo"]);
                    reserva.idHabitacion = Convert.ToInt32(row["idHabitacion"]);
                    reserva.cantidadPersonas = Convert.ToInt32(row["cantidadPersonas"]);
                    reserva.fechaInicio = Convert.ToDateTime(row["fechaInicio"]);
                    reserva.fechaFin = Convert.ToDateTime(row["fechaFin"]);
                    reserva.anticipo = Convert.ToSingle(row["anticipo"]);
                    reserva.descuento = Convert.ToSingle(row["descuento"]);
                    reserva.costoServicio = Convert.ToSingle(row["costoServicio"]);
                    reserva.checkOut = Convert.ToInt32(row["checkOut"]);


                    

                    // Agregar el objeto HistorialCliente a la lista
                    listaHistorial.Add(reserva);
                }

                // Asignar la lista de reportes como origen de datos del DataGridView
                dgvHistorial.DataSource = listaHistorial;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Err = true;
            }

            limpiarTextBox();
        }
    }
}
