
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA___AAVD.Pantallas_Operativo
{
    public partial class pedirContraseña : Form
    {
        public string usuario;

        public pedirContraseña()
        {
            InitializeComponent();
        }

        private void pedirContraseña_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnContra_Click(object sender, EventArgs e)
        {

            string Contra = Convert.ToString(txtContra.Text);
            if (Contra != null)
            {

                LogIn.nuevaContra = false;
                this.Hide();
                login login_ = new login();
                login_.ShowDialog();
            }
            else
                MessageBox.Show("Seleccione los datos correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
