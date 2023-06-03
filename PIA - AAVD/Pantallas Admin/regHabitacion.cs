
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
using PIA___AAVD.Pantallas_Admin;
using static PIA___AAVD.Clases;
using PIA___AAVD;

namespace PIA___AAVD.Pantallas_Admin
{
    public partial class regHabitacion : Form
    {
        int hotelID;

        public regHabitacion()
        {
            InitializeComponent();
        }

        private void regHabitacion_Load(object sender, EventArgs e)
        {
            if (Validaciones.ultimohotel != 0) {

                List<TipoHabitacion> listaReportes = new List<TipoHabitacion>();
                List<Clases.Usuario> usuario = new List<Clases.Usuario>();
                EnlaceCassandra enlace = EnlaceCassandra.getInstance();


                listaReportes = enlace.ObtenerTiposHabitacion();
                dgvTipoHab.DataSource = listaReportes;
            }
        }


        private void limpiarTextBox()
        {
            txtCantidad.Clear();
            txtID.Clear();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            var Err = false;
            try
            {
                int tipoHabID = Convert.ToInt16(txtID.Text);
                int cantidadHabitacion = Convert.ToInt16(txtCantidad.Text);
                bool existeValor = false;

                foreach (DataGridViewRow row in dgvTipoHab.Rows)
                {
                    int valorCelda = Convert.ToInt32(row.Cells["idTipo"].Value);

                    if (valorCelda == tipoHabID)
                    {
                        existeValor = true;
                        break;
                    }
                }

                if(!existeValor)
                {
                    MessageBox.Show("Seleccione los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                for (int i = 0; i < cantidadHabitacion; i++)
                {
                    Validaciones.cantidadDelHotel++;
                    enlace.InsertarHabitacion(enlace.ObtenerNumeroRegistros("Habitacion"), tipoHabID, Validaciones.ultimohotel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Err = true;
            }
            if (!Err)
            {
                MessageBox.Show("Registro completado", "Yay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiarTextBox();
            }

        }
    }
}
