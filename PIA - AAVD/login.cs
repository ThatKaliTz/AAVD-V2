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
using PIA___AAVD.Pantallas_Operativo;


namespace PIA___AAVD
{
    public partial class login : Form
    {
        public int contador = 0;
        public string usuario;
        Admin admin = new Admin();
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(exitApp);
        }

        private void exitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (txtCorreo.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Falta uno o mas campos por completar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<Clases.Usuario> usuario = new List<Clases.Usuario>();
                EnlaceCassandra enlace = EnlaceCassandra.getInstance();
                usuario = enlace.GetUsuario();
                int a = enlace.ObtenerNumeroRegistros("usuario");
                foreach (var search in usuario)
                {
                    if (search.correoElec == txtCorreo.Text && search.Contrasenia == textBox1.Text && search.isHabilitado == true)
                    {
                        if (search.isAdmin == true && checkBox1.Checked == true)
                        {
                            this.Hide();
                            Admin adminP = new Admin();
                            Validaciones.usuario = search.correoElec;
                            adminP.ShowDialog();
                        }
                        else if (search.isAdmin == false && checkBox1.Checked == false)
                        {
                            this.Hide();
                            Operativo operativo = new Operativo();
                            Validaciones.usuario = search.correoElec;

                            operativo.ShowDialog();
                        }
                        else if (search.isAdmin == true && checkBox1.Checked == false)
                        {
                            MessageBox.Show("El usuario al que trata de acceder es administrador", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (search.isAdmin == false && checkBox1.Checked == true)
                        {
                            MessageBox.Show("El usuario al que trata de acceder es operativo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        //MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        
                    }
                }
            }
        }
    }
}