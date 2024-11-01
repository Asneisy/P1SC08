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
using static P1SC08.Item;  // libreria que permite acceder a la base de datos

namespace P1SC08
{
    public partial class frmProductos : Form
    {
        Boolean DataExiste;

        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            this.Text = "Maestro de Productos";  // cambia el titulo de formualario en ejecucion
            this.KeyPreview = true;  // activa las teclas de funciones

            txtProducto.Text = Busco.BuscaUltimoNumero("1");  // buscara el ultimo numero en la tabla
        }

        private void frmProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)  // estoy preguntando si la tecla que presionaste es igual a 27 (es igual tecla ESC)
            {
                this.Close();  // Cierra el formulario 
            }
        }

        // -------------------------------------------------------------------
        // TEXTBOX
        // -------------------------------------------------------------------
        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) // pregunta si presionaste la tecla Enter
            {
                e.Handled = true; // si presionaste enter tiene valor true el keypresseventargs
                // .Text ==>> se guarda la data escrita en el textbox
                // .Trim ==>> le suprime los espacios en los lados a lo escrito
                // '  12345  '
                // '12345'

                if (txtProducto.Text.Trim() != string.Empty) // pregunta si es diferente de vacio
                {
                    txtDescripcion.Focus(); // mueve el cursor hacia el siguiente textbox (txtDescripcion)
                }
            }
        }

        private void txtProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)  // estoy preguntando si la tecla que presionaste es igual a 27 (es igual tecla ESC)
            {
                btnProducto.PerformClick();  // ejecuta el evento del boton btnProducto
            }
        }

        private void txtProducto_Leave(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim() != string.Empty) // pregunta si es diferente de vacio
            {
                BuscarProducto(txtProducto.Text);  // ejecuto el metodo y le envio el valor contenido en el textbox producto
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) // pregunta si presionaste la tecla Enter
            {
                e.Handled = true; // si presionaste enter tiene valor true el keypresseventargs
                if (txtDescripcion.Text.Trim() != string.Empty) // pregunta si es diferente de vacio
                {
                    txtCantidad.Focus(); // mueve el cursor hacia el siguiente textbox (txtDescripcion)
                }
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) // pregunta si presionaste la tecla Enter
            {
                e.Handled = true; // si presionaste enter tiene valor true el keypresseventargs
                if (txtCantidad.Text.Trim() != string.Empty) // pregunta si es diferente de vacio
                {
                    txtCosto.Focus(); // mueve el cursor hacia el siguiente textbox (txtDescripcion)
                }
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) // pregunta si presionaste la tecla Enter
            {
                e.Handled = true; // si presionaste enter tiene valor true el keypresseventargs
                if (txtCosto.Text.Trim() != string.Empty) // pregunta si es diferente de vacio
                {
                    txtPrecio.Focus(); // mueve el cursor hacia el siguiente textbox (txtDescripcion)
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) // pregunta si presionaste la tecla Enter
            {
                e.Handled = true; // si presionaste enter tiene valor true el keypresseventargs
                if (txtPrecio.Text.Trim() != string.Empty) // pregunta si es diferente de vacio
                {
                    txtPorciento.Focus(); // mueve el cursor hacia el siguiente textbox (txtDescripcion)
                }
            }
        }

        private void txtPorciento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) // pregunta si presionaste la tecla Enter
            {
                e.Handled = true; // si presionaste enter tiene valor true el keypresseventargs
                if (txtPorciento.Text.Trim() != string.Empty) // pregunta si es diferente de vacio
                {
                    txtBarCode.Focus(); // mueve el cursor hacia el siguiente textbox (txtDescripcion)
                }
            }
        }

        private void txtBarCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter) // pregunta si presionaste la tecla Enter
            {
                e.Handled = true; // si presionaste enter tiene valor true el keypresseventargs
                if (txtBarCode.Text.Trim() != string.Empty) // pregunta si es diferente de vacio
                {
                    btnGuardar.Focus(); // mueve el cursor hacia el siguiente textbox (txtDescripcion)
                }
            }
        }

        // -------------------------------------------------------------------
        // BOTONES
        // -------------------------------------------------------------------
        private void btnProducto_Click(object sender, EventArgs e)
        {
            frmVENPROD frm = new frmVENPROD();  // asignamos un objeto llamado frm cuyo objetivo es ser el formulario
            frm.Show();  // muestra el formulario
        }

        private void InsertarDato()
        {
            string tQuery = "INSERT INTO CLIENTES (IDCLIENTE,  NOMBRE,   DIRECCION, " +
                            "                       SECTOR, CIUDAD, TELEFONO, MOVIL " +
                            "                       MONTO,      PAGAIMPUESTO) " +
                            " VALUES ( @A1, @A2, @A3, @A4, @A5, @A6, @A7, @A8, @A9 )";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cnx);

            cmd.Parameters.AddWithValue("@A1", txtProducto.Text);
            cmd.Parameters.AddWithValue("@A2", txtDescripcion.Text);
            cmd.Parameters.AddWithValue("@A3", txtCantidad.Text);
            cmd.Parameters.AddWithValue("@A4", txtCosto.Text);
            cmd.Parameters.AddWithValue("@A5", txtPrecio.Text);
            cmd.Parameters.AddWithValue("@A6", txtPorciento.Text);
            cmd.Parameters.AddWithValue("@A7", txtBarCode.Text);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cnx.Close();
        }

        private void ActualizarDato()
        {
            string tQuery = "UPDATE Clientes " +
                        "   SET NOMBRE               = @A2," +
                        "       DIRECCION            = @A3," +
                        "       SECTOR               = @A4," +
                        "       CIUDAD               = @A5," +
                        "       TELEFONO             = @A8," +
                        "       MOVIL                = @A6," +
                        "       MONTO                = @A7," +
                        "       PAGAIMPUESTO         = @A8" +
                        "  FROM CLIENTES " +
                        " WHERE ITEM = @A1";


            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cnx);

            cmd.Parameters.AddWithValue("@A1", txtProducto.Text);
            cmd.Parameters.AddWithValue("@A2", txtDescripcion.Text);
            cmd.Parameters.AddWithValue("@A3", txtCantidad.Text);
            cmd.Parameters.AddWithValue("@A4", txtCosto.Text);
            cmd.Parameters.AddWithValue("@A5", txtPrecio.Text);
            cmd.Parameters.AddWithValue("@A6", txtPorciento.Text);
            cmd.Parameters.AddWithValue("@A7", txtBarCode.Text);

            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cnx.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtProducto.Text.Trim() != string.Empty)
            {
                if (txtDescripcion.Text.Trim() != string.Empty)
                {
                    if (txtCantidad.Text.Trim() != string.Empty)
                    {
                        if (txtCosto.Text.Trim() != string.Empty)
                        {
                            if (txtPrecio.Text.Trim() != string.Empty)
                            {
                                if (txtPorciento.Text.Trim() != string.Empty)
                                {
                                    if (txtBarCode.Text.Trim() != string.Empty)
                                    {
                                       if (DataExiste == false)
                                       {
                                            InsertarDato();
                                            ActualizarSecuencia (txtProducto.Text);
                                            ActualizarFotoDelProducto(txtProducto.Text);
                                       }
                                       else
                                       {
                                            ActualizarDato();
                                            ActualizarFotoDelProducto(txtProducto.Text);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();  // ejecutara el metodo LimpiarFormulario
            txtProducto.Focus();  // mueve el cursor hacia el textbox indicado
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (DataExiste == true)
            {
                DialogResult dialogResult = MessageBox.Show("Esta seguro de borrar? ", "ITLA", MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    BorrarDato(txtProducto.Text);
                    LimpiarFormulario();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // -------------------------------------------------------------------
        // METODOS
        // -------------------------------------------------------------------
        private void LimpiarFormulario()
        {
            txtBarCode.Clear(); // .Clear limpia el contenido del textbox
            txtCantidad.Clear();
            txtCosto.Clear();
            txtDescripcion.Clear();
            txtPorciento.Clear();
            txtPrecio.Clear();
            txtProducto.Clear();

            txtProducto.Text = Busco.BuscaUltimoNumero("1");
        }

        private void BuscarProducto(string numProducto)
        {
            DataExiste = false;

            if (pictureBox1.Image != null) // pregunta si picturebox tiene una imagen presente
            {
                pictureBox1.Image.Dispose(); // descompone la imagen que esta presente en picturebox
                pictureBox1.Image = null; // aqui la anula
            }

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand(" SELECT ITEM,  DESCRIPCION,   CANTIDADENEXISTENCIA, " +
                                            "        COSTO, PRECIODEVENTA, IMPUESTO, " +
                                            "        BARCODE " +
                                            "   FROM PRODUCTOS " +
                                            "  WHERE ITEM = '" + numProducto +
                                            "'   AND EstatusProducto = 1", cnx);
            SqlDataReader rsd = cmd.ExecuteReader();

            if (rsd.Read())
            {
                DataExiste = true;

                txtProducto.Text = Convert.ToString(rsd["ITEM"]);
                txtDescripcion.Text = Convert.ToString(rsd["DESCRIPCION"]);
                txtCantidad.Text = Convert.ToString(rsd["CANTIDADENEXISTENCIA"]);
                txtCosto.Text = Convert.ToString(rsd["COSTO"]);
                txtPrecio.Text = Convert.ToString(rsd["PRECIO"]);
                txtPorciento.Text = Convert.ToString(rsd["IMPUESTO"]);
                txtBarCode.Text = Convert.ToString(rsd["BARRA"]);

                try
                {
                    // convierte el arreglo que viene de la tabla a imagen
                    pictureBox1.Image = ConvertImage.ByteArrayToImage((byte[])rsd["IMAGEN"]); 
                }
                catch
                {
                    //
                }
            }

            cmd.Dispose();
            cnx.Close();
        }

        private void ActualizarFotoDelProducto(string numProducto)
        {
            byte[] byteArrayImagen = ConvertImage.ImageToByteArray(pictureBox1.Image);

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            SqlCommand cmd = new SqlCommand("UPDATE PRODUCTOS SET IMAGEN = @A1 WHERE ITEM = '" + numProducto + "'", cnx);
            cmd.Parameters.AddWithValue("@A1", byteArrayImagen);

            cmd.ExecuteNonQuery();
            cnx.Close();
        }

        private void BorrarDato(string numProducto)
        {
            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();

            string tQuery = "DELETE FROM PRODUCTOS WHERE ITEM ='" + numProducto + "'";

            SqlCommand cmd = new SqlCommand(tQuery, cnx);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cnx.Close();
        }

        private void ActualizarSecuencia(string numProducto)
        {
            string tQuery = "UPDATE SECUENCIA " +
                            "  SET SECUENCIA = '" + numProducto +
                            "  WHERE ID = 3 ";

            SqlConnection cnx = new SqlConnection(cnn.db); cnx.Open();
            SqlCommand cmd = new SqlCommand(tQuery, cnx);

            cmd.ExecuteNonQuery();


            cmd.Dispose();
            cnx.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
