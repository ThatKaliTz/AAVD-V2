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
using PIA___AAVD;

namespace PIA___AAVD.Pantallas_Operativo
{

    public partial class btnRegistrarCliente : Form
    {
        string usuario;
        public btnRegistrarCliente()
        {
            InitializeComponent();
        }

        private void clientes_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegCliente_Click(object sender, EventArgs e)
        {
            EnlaceCassandra enlace = EnlaceCassandra.getInstance();
            var Err = false; // SI no hay error

            try
            {
                string Nombre = Convert.ToString(txtNombre.Text);
                string ApellidoP = Convert.ToString(txtApellidoP.Text);
                string ApellidoM = Convert.ToString(txtApellidoM.Text);
                string Correo = Convert.ToString(txtCorreo.Text);
                string RFC = Convert.ToString(txtRFC.Text);
                string Nacimiento = dtpNacimiento.Value.ToString("yyyy-MM-dd");
                string EstadoCivil = cbEstadoCivil.SelectedItem.ToString();
                string Referencia = Convert.ToString(txtReferencia.Text);
                string Calle = Convert.ToString(txtCalle.Text);
                string Colonia = Convert.ToString(txtColonia.Text);
                string Municipio = Convert.ToString(txtMunicipio.Text);
                string Estado = Convert.ToString(txtEstado.Text);
                string Telefono = Convert.ToString(txtTelefono.Text);

                string Domicilio = Calle + Colonia + Municipio + Estado;

                string FechaGestion = DateTime.Now.ToString("yyyy-MM-dd");
                string HoraGestion = DateTime.Now.ToString("HH:mm:ss");


                enlace.insertClientes(RFC,Nombre,ApellidoP,ApellidoM,Domicilio,Correo,Referencia,Telefono,Nacimiento,EstadoCivil,   
                    FechaGestion,HoraGestion);


                txtNombre.Clear();
                txtApellidoP.Clear();
                txtApellidoM.Clear();
                txtCorreo.Clear();
                txtReferencia.Clear();
                txtCalle.Clear();
                txtReferencia.Clear();
                txtColonia.Clear();
                txtMunicipio.Clear();
                txtEstado.Clear();
                txtTelefono.Clear();
                cbEstadoCivil.SelectedIndex = -1;
                dtpNacimiento.ResetText();
            }
            catch 
            {

                
            }

        }
    }
}
