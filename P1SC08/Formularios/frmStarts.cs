using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient; // esta libreria es utilizada para el SQL

namespace P1SC08
{
    public partial class frmStarts : Form
    {
        string password;

        public frmStarts()
        {
            InitializeComponent();
        }

        private void frmStarts_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true; // activa las teclas de funciones 
            this.Text = "Login";   // cambia el titulo del form en ejecucion
        }

        private void frmStarts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)  // aqui pregunta si presionaste la tecla ESC
            {
                Application.Exit(); // cierra toda la aplicacion
            }
        }

        // ------------------------------------------------------
        // BOTONES
        // ------------------------------------------------------
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim() != string.Empty)
            {
                if (txtPassword.Text.Trim() != string.Empty)
                {
                    if (txtPassword.Text.Trim() == password)
                    {
                        frmMenu frm = new frmMenu(); // le asigna al objeto frm el formulario llamado frmMenu 
                        frm.Show();  // muestra o carga el formulario del menu

                        this.Hide(); // aqui esconde el formulario frmStars
                    }
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();  // cierra la aplicacion
        }

        // ------------------------------------------------------
        // TEXTBOX
        // ------------------------------------------------------
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtUsuario.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    txtPassword.Focus();  // mueve el cursor hacia el textbox txtPassword
                }
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            BuscarUsuario(txtUsuario.Text);
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)  // aqui que si la tecla que presionaste es igual a ENTER
            {
                e.Handled = true;
                if (txtPassword.Text.Trim() != string.Empty)  // aqui pregunta que si el el textbox es diferente de vacio
                {
                    btnAceptar.Focus();  // mueve el cursor hacia el textbox txtPassword
                }
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            btnAceptar.PerformClick();
        }

        private void BuscarUsuario(string cualUsuario)
        {
            // SELECT CLAVE FROM USUARIO WHERE NOMBRECORTO = 'JUANC'
            string miQuery = "SELECT CLAVE " +
                             "  FROM USUARIO " +
                             " WHERE NOMBRECORTO = '" + cualUsuario + "'";

            SqlConnection cnxn = new SqlConnection(cnn.db);  // le indico la conexion a utilizar para la base de datos
            cnxn.Open();  // abro la base de datos

            SqlCommand cmnd = new SqlCommand(miQuery, cnxn);  // le indicamos el script de sql a utilizar
            SqlDataReader rcd = cmnd.ExecuteReader();  // ejecutamos el script de sql

            if (rcd.Read())
            {
                password = rcd["CLAVE"].ToString();  // ME TRAE LA DATA CONTENIDA EN EL CAMPO DE LA TABLA
            }
        }
    }
}
