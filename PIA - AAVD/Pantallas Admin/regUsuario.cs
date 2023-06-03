using PIA___AAVD.Pantallas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIA___AAVD.Pantallas_Admin;
using PIA___AAVD;

using Cassandra.Data.Linq;
using PIA___AAVD;

namespace PIA___AAVD
{
    public partial class regUsuario : Form
    {

        // Un INSERT a la tabla de Usuario

        public regUsuario()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);

        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void limpiarTextBox()
        {
            txtCorreo.Clear();
            txtPassword.Clear();
            txtName.Clear();
            txtApellidoP.Clear();
            txtApellidoM.Clear();
            txtNumNomina.Clear();
            dtpNacimiento.ResetText();
            txtCalle.Clear();
            txtColonia.Clear();
            txtMunicipio.Clear();
            txtEstado.Clear();
            txtTelefono.Clear();
        }

        private void btnRegUsuario_Click(object sender, EventArgs e)
        {
            List<Clases.Usuario> usuario = new List<Clases.Usuario>();
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            
            var Err = false; // SI no hay error

            try
            {
                // Convertir los datos de los textBoxs
                string correoElec = Convert.ToString(txtCorreo.Text);
                string Contrasenia = Convert.ToString(txtPassword.Text);
                string apPat = Convert.ToString(txtApellidoP.Text);
                string apMat =Convert.ToString(txtApellidoM.Text);
                string Nombre = Convert.ToString(txtName.Text);
                int numNomina = int.Parse(txtNumNomina.Text);
                string Calle = Convert.ToString(txtCalle.Text);
                string Colonia = Convert.ToString(txtColonia.Text);
                string Municipio = Convert.ToString(txtMunicipio.Text);
                string Estado = Convert.ToString(txtEstado.Text);
                string fechaNacim = dtpNacimiento.Value.Date.ToString("yyyy-MM-dd");
                string Telefono = Convert.ToString(txtTelefono.Text);


                string Domicilio = Calle + " " + Colonia + " " + Municipio + " " + Estado;

                string FechaReg = DateTime.Now.ToString("yyyy-MM-dd");
                string HoraReg = DateTime.Now.ToString("HH:mm:ss");
                bool isAdmin = false;
                bool isHabilitado = true;
                // Enviar los datos a la base de datos mediante el Table Adapter
                enlace.insertOperativos(correoElec, Nombre, apPat, apMat,
                    Contrasenia, Domicilio, Telefono, fechaNacim, numNomina, FechaReg,HoraReg, isAdmin, isHabilitado);
                //tableManager.Insert(correoElec, Nombre, Contrasenia, Domicilio, Telefono, numNomina);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Err = true;
            }

            if(!Err) {
                MessageBox.Show("Datos enviados", "Yay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            limpiarTextBox();

        }

        private void regUsuario_Load(object sender, EventArgs e)
        {

        }
    }
}