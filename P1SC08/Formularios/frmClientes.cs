using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using P1SC08;
using static P1SC08.Item;

namespace Primer_Parcial_Programacion
{
    public partial class frmClientes : Form
    {
        Boolean DataExiste;

        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            this.Text = "Maestro de Clientes"; 
            this.KeyPreview = true; 

            txtCliente.Text = Busco.BuscaUltimoNumero("4");
            DataExiste = false;

            //----------------------------------------------
            //LLENAR COMBOBOX
            //----------------------------------------------
            List<Item> lista = new List<Item>();

            lista.Add(new Item("Si", 1));
            lista.Add(new Item("No", 0));

            cbxPagoImpuesto.DisplayMember = "Name";
            cbxPagoImpuesto.ValueMember = "Value";
            cbxPagoImpuesto.DataSource = lista;
            //---------------------------------------------
        }
        

        private void ActualizarFotoDelCliente(string numCliente)
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(pictureBox1.Image);

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            SqlCommand cmd = new SqlCommand("UPDATE CLIENTES SET IMAGEN = @A1 WHERE IDCLIENTE = '" + numCliente + "'", cnx);
            cmd.Parameters.AddWithValue("@A1", byteArrayImagen);

            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        private void BorrarDato(string numCliente)
        {
            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            string tQuery = "UPFATE CLIENTES " +
                            "   SET ESTATUS = 0 " + 
                            "  FROM CLIENTES " +
                            " WHERE IDCLIENTE ='" + numCliente + "'";

            SqlCommand cmd = new SqlCommand(tQuery, cnx);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cnx.Close();
        }


        private void frmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close(); 
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) 
            {
                e.Handled = true;

                if (txtCliente.Text.Trim() != string.Empty) 
                {
                    txtNombreCliente.Focus(); 
                }
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)  
            {
                btnCliente.PerformClick(); 
            }
        }

        private void txtCliente_Leave(object sender, EventArgs e)
        {
            if (txtCliente.Text.Trim() != string.Empty) 
            {
                BuscarCliente(txtCliente.Text);  
            }
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) 
            {
                e.Handled = true; 
                if (txtNombreCliente.Text.Trim() != string.Empty) 
                {
                    txtDireccion.Focus(); 
                }
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtDireccion.Text.Trim() != string.Empty)
                {
                    txtSector.Focus();
                }
            }
        }

        private void txtSector_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtSector.Text.Trim() != string.Empty)
                {
                    txtCiudad.Focus();
                }
            }
        }

        private void txtCiudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtCiudad.Text.Trim() != string.Empty)
                {
                    txtTelefono.Focus();
                }
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;


                if (txtTelefono.Text.Trim() != string.Empty)
                {
                    txtMovil.Focus();
                }
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Trim() != string.Empty)
            {
                var nPhone00 = txtTelefono.Text.Replace(" - ", "");
                txtTelefono.Text = nPhone00.ToString();

                var nPhone01 = txtTelefono.Text.Replace(" / ", "");
                txtTelefono.Text = nPhone01.ToString();

                var nPhone02 = txtTelefono.Text.Replace(" ( ", "");
                txtTelefono.Text = nPhone02.ToString();

                var nPhone03 = txtTelefono.Text.Replace(" ) ", "");
                txtTelefono.Text = nPhone03.ToString();

                var nPhone04 = txtTelefono.Text.Replace(" [ ", "");
                txtTelefono.Text = nPhone04.ToString();

                var nPhone05 = txtTelefono.Text.Replace(" ] ", "");
                txtTelefono.Text = nPhone05.ToString();

                var nPhone06 = txtTelefono.Text.Replace(" . ", "");
                txtTelefono.Text = nPhone06.ToString();
            }
        }

        private void txtMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (txtMovil.Text.Trim() != string.Empty)
                {
                    cbxPagoImpuesto.Focus();
                }
            }
        }

        private void txtMovil_Leave(object sender, EventArgs e)
        {
            if (txtMovil.Text.Trim() != string.Empty)
            {
                var nPhone00 = txtMovil.Text.Replace(" - ", "");
                txtMovil.Text = nPhone00.ToString();

                var nPhone01 = txtMovil.Text.Replace(" / ", "");
                txtMovil.Text = nPhone01.ToString();

                var nPhone02 = txtMovil.Text.Replace(" ( ", "");
                txtMovil.Text = nPhone02.ToString();

                var nPhone03 = txtMovil.Text.Replace(" ) ", "");
                txtMovil.Text = nPhone03.ToString();

                var nPhone04 = txtMovil.Text.Replace(" [ ", "");
                txtMovil.Text = nPhone04.ToString();

                var nPhone05 = txtMovil.Text.Replace(" ] ", "");
                txtMovil.Text = nPhone05.ToString();

                var nPhone06 = txtMovil.Text.Replace(" . ", "");
                txtMovil.Text = nPhone06.ToString();
            }
        }

        private void cbxPagoImpuesto_KeyKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                e.Handled = true;
                if (cbxPagoImpuesto.Text.Trim() != string.Empty)
                {
                    btnGuardar.Focus();
                }
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            frmListClientes frm = new frmListClientes();  
            frm.Show(); 
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text.Trim() != string.Empty)
            {
                if (txtNombreCliente.Text.Trim() != string.Empty)
                {
                    if (txtDireccion.Text.Trim() != string.Empty)
                    {
                        if (txtSector.Text.Trim() != string.Empty)
                        {
                            if (txtCiudad.Text.Trim() != string.Empty)
                            {
                                if (txtTelefono.Text.Trim() != string.Empty)
                                {
                                    if (txtMovil.Text.Trim() != string.Empty)
                                    {
                                        if (txtCorreo.Text.Trim() != string.Empty)
                                        {
                                            if (lblBalance.Text.Trim() != string.Empty)
                                            {
                                                if (cbxPagoImpuesto.Text.Trim() != string.Empty)
                                                {
                                                    if (DataExiste == false)
                                                    {
                                                        InsertarDato();
                                                        ActualizarSecuencia(txtCliente.Text);
                                                        ActualizarFotoDelCliente(txtCliente.Text);
                                                        LimpiarFormulario();
                                                    }
                                                    else
                                                    {
                                                        ActualizarDato();
                                                        ActualizarFotoDelCliente(txtCliente.Text);
                                                        LimpiarFormulario();
                                                    }

                                                    // colocar messagebox
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void InsertarDato()
        {
            string tQuery = "INSERT INTO CLIENTES (IDCLIENTE,  NOMBRE,   DIRECCION, " +
                            "                       SECTOR, CIUDAD, CORREO, TELEFONO01, TELEFONO02 " +
                            "                        PAGAIMPUESTO,  ESTATUS) " +
                            " VALUES ( @A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8, @A9. @A0 )";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cnx);

            cmd.Parameters.AddWithValue("@A1", txtCliente.Text);
            cmd.Parameters.AddWithValue("@A2", txtNombreCliente.Text);
            cmd.Parameters.AddWithValue("@A3", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@A4", txtSector.Text);
            cmd.Parameters.AddWithValue("@A5", txtCiudad.Text);
            cmd.Parameters.AddWithValue("@A6", txtCorreo.Text);
            cmd.Parameters.AddWithValue("@A7", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@A8", txtMovil.Text);
            cmd.Parameters.AddWithValue("@A9", cbxPagoImpuesto.Text);
            cmd.Parameters.AddWithValue("@A0", 1); 

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cnx.Close();
        }

        private void ActualizarDato()
        {
            string tQuery = "UPDATE Clientes " +
                        "   SET DESCRIPCION          = @A2," +
                        "       CANTIDADEXISTENCIA   = @A3," +
                        "       COSTO                = @A4," +
                        "       PRECIOVENTA          = @A5," +
                        "       IMPUESTO             = @A8," +
                        "       BARCODE              = @A6," +
                        "  FROM CLIENTES " +
                        " WHERE ITEM = @A1";


            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cnx);

            cmd.Parameters.AddWithValue("@A1", txtCliente.Text);
            cmd.Parameters.AddWithValue("@A2", txtNombreCliente.Text);
            cmd.Parameters.AddWithValue("@A3", txtDireccion.Text);
            cmd.Parameters.AddWithValue("@A4", txtSector.Text);
            cmd.Parameters.AddWithValue("@A5", txtCiudad.Text);
            cmd.Parameters.AddWithValue("@A6", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@A7", txtMovil.Text);
            cmd.Parameters.AddWithValue("@A8", 1);
            cmd.Parameters.AddWithValue("@A9", cbxPagoImpuesto.Text);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cnx.Close();
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario(); 
            txtCliente.Focus();  
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (DataExiste == true)
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro de borrar? ", "ITLA", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    BorrarDato(txtCliente.Text);
                    LimpiarFormulario();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void LimpiarFormulario()
        {
            txtMovil.Clear(); 
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCiudad.Clear();
            txtNombreCliente.Clear();
            txtCliente.Clear();
            txtCorreo.Clear();
            lblBalance.Text = "";
            txtSector.Clear();

            DataExiste = false;

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            txtCliente.Text = Busco.BuscaUltimoNumero("4");

            txtCliente.Focus();
        }

        private void BuscarCliente(string numCliente)
        {
            DataExiste = false;

            if (pictureBox1.Image != null) 
            {
                pictureBox1.Image.Dispose(); 
                pictureBox1.Image = null; 
            }

            SqlConnection cnx = new SqlConnection(cnn.db);     cnx.Open();  
            SqlCommand cmd = new SqlCommand(" SELECT IDCLIENTE,  NOMBRE   ,   DIRECCION, " +
                                            "        SECTOR, CIUDAD, TELEFONO01, TELEFONO02 " +
                                            "        MONTO,    CORREO, " +
                                            "        IMAGEN,  PAGAIMPUESTO " +
                                            "   FROM CLIENTES " +
                                            "  WHERE IDCLIENTE = '" + numCliente +
                                            "'" , cnx);

            SqlDataReader rsd = cmd.ExecuteReader();

            if (rsd.Read()) 
            {
                DataExiste = true;

                txtNombreCliente.Text = Convert.ToString(rsd["NOMBRE"]);
                txtDireccion.Text = Convert.ToString(rsd["DIRECCION"]);
                txtSector.Text = Convert.ToString(rsd["SECTOR"]);
                txtCiudad.Text = Convert.ToString(rsd["CIUDAD"]);
                txtTelefono.Text = Convert.ToString(rsd["TELEFONO01"]);
                txtMovil.Text = Convert.ToString(rsd["TELEFONO02"]);
                txtCorreo.Text = Convert.ToString(rsd["CORREO"]);
                cbxPagoImpuesto.Text = Convert.ToString(rsd["PAGAIMPUESTO"]);
                lblBalance.Text = Convert.ToString(rsd["MONTO"]);

                try
                {
                    
                    pictureBox1.Image = ConvertImage.ByteArrayToImage((byte[])rsd["IMAGEN"]);
                }
                catch
                {
                    
                }
            }

            cmd.Dispose();
            cnx.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarSecuencia(string numCliente)
        {
            string tQuery = "UPDATE SECUENCIA " +
                            "  SET SECUENCIA = '" + numCliente +
                            "  WHERE ID = 4  ";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand( tQuery, cnx);

            cmd.ExecuteNonQuery();


            cmd.Dispose();
            cnx.Close();
        }
    }
        
}

