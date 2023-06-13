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
    public partial class frmCiudadAE : Form
    {
        public frmCiudadAE()
        {
            InitializeComponent();
        }

        private Ciudad ciudad;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CombosHelper.CargarComboPaises(ref cbPaises);//en el Onload establezco que se carguen los datos del comboBox una vez que se inicia
            if (ciudad!=null)
            {
                textBoxCiudad.Text = ciudad.NombreCiudad;
                cbPaises.SelectedValue = ciudad.PaisId;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (ciudad==null)
                {
                    ciudad = new Ciudad();//si no tengo ciudad la tengo que instanciar
                }
                //si la ciudad existe entonces la asigno
                ciudad.NombreCiudad=textBoxCiudad.Text;
                ciudad.Pais=(Pais)cbPaises.SelectedItem;//el select item me devuelve un objet y si tengo que asignar un pais lo debo castear a pais
                ciudad.PaisId=(int)cbPaises.SelectedValue;//apunta al id del pais, tengo que castearlo porque me devuelve un objet

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProviderCiudad.Clear();
            if (cbPaises.SelectedIndex == 0)//ESTO QUIERE DECIR QUE SI EN EL COMBO BOX NO SELECCIONE NINGUN PAIS ME DA ERROR
            {
                valido = false;
                errorProviderCiudad.SetError(cbPaises, "Debe selecionar un Pais");
            }
            if (string.IsNullOrEmpty(textBoxCiudad.Text))
            {
                valido = false;
                errorProviderCiudad.SetError(textBoxCiudad, "El nombre es requerido");
            }
            return valido;
        }

        public Ciudad GetCiudad()
        {
            return ciudad;
        }

        public void SetCiudad(Ciudad ciudad)
        {
            this.ciudad = ciudad;
        }
    }
}
