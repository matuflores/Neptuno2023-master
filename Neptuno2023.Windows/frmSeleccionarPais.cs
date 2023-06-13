using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Windows.Helpers;
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
    public partial class frmSeleccionarPais : Form
    {
        public frmSeleccionarPais()
        {
            InitializeComponent();
        }

        private Pais paisSeleccionado;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmSeleccionarPais_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboPaises(ref cbSeleccionarPaisFiltro);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                paisSeleccionado=(Pais)cbSeleccionarPaisFiltro.SelectedItem;//pais seleccionado es igual al pais que esta puesto en el combo box
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorPFiltro.Clear();
            if (cbSeleccionarPaisFiltro.SelectedIndex==0)//aca pregunto si seleccione un pais
            {
                valido = false;
                errorPFiltro.SetError(cbSeleccionarPaisFiltro,"Debe seleccionar un Pais");
            }
            return valido;
        }

        public Pais GetPais()
        {
            return paisSeleccionado;
        }
    }
}
