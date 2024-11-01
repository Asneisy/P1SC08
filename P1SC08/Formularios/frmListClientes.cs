using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Primer_Parcial_Programacion
{
    public partial class frmListClientes : Form
    {
        public frmListClientes()
        {
            InitializeComponent();
        }

        private void frmListClientes_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void frmListClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)  
            {
                this.Close();   
            }
        }
    }
}
