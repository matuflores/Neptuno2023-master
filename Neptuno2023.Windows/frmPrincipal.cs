using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neptuno2023.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPaises_Click(object sender, EventArgs e)
        {
            frmPaises frm=new frmPaises();//al apretar el boton se abre el formulario de los paises
            frm.ShowDialog();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias frm=new frmCategorias();
            frm.ShowDialog();
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            frmCiudades frm=new frmCiudades();
            frm.ShowDialog();
        }
    }
}
