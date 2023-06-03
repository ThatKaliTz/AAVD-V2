
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA___AAVD.Pantallas_Admin
{
    public partial class rehabilitarUsuario : Form
    {

        // Un SELECT que muestre a todos los de la tabla Usuario inhabilitados

        public rehabilitarUsuario()
        {
            InitializeComponent();
        }

        private void rehabilitarUsuario_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegUsuario_Click(object sender, EventArgs e)
        {
            //codigo de funcion
            //
            //-----
            this.Hide();
            regUsuario admin = new regUsuario();
            admin.ShowDialog();
            this.Show();
        }

        private void rehabilitarUsuario_Load_1(object sender, EventArgs e)
        {

        }

        private void Seleccion(object sender, DataGridViewCellMouseEventArgs e)
        {


            int indice = e.RowIndex;

            string prueba = dgvUsuarioInhabilib.Rows[indice].Cells[0].Value.ToString();
     
            MessageBox.Show("Prueba", prueba);

        }
    }
}
