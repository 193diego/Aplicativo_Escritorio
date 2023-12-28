using System;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Bohorquez
{
    public partial class frmlogin : MaterialSkin.Controls.MaterialForm
    {
        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            txtClave.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtClave.PasswordChar == '*')
            {
                txtClave.PasswordChar = '\0';
            }
            else
            {
                txtClave.PasswordChar = '*';
            }

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text;
            string clave = txtClave.Text;

            Logica.Logica logicaUsuario = new Logica.Logica();

            if (logicaUsuario.AutenticarUsuario(nombreUsuario, clave))
            {
                frmmenu formulario = new frmmenu();
                formulario.Show();
                this.Hide(); // O puedes cerrar el formulario actual si no es necesario mantenerlo abierto
            }
            else
            {
                MessageBox.Show("Usuario y/o clave incorrectos", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
