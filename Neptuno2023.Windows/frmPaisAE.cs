using Neptuno2023.Entidades.Entidades;
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
    public partial class frmPaisAE : Form
    {
        public frmPaisAE()
        {
            InitializeComponent();
        }

        private Pais pais;//paso 6(agregar)
        protected override void OnLoad(EventArgs e)//paso 5(editar pais)
        {//tengo un pais pero como el form sirve para editar sobrescribe el onload si el pais es distinto de nulo  en el box me va a poner el nombrepais para ver(siguen en el btnOk [*5b])
            base.OnLoad(e);//agarra el metodo base lo trae y pone esto nuevo
            if (pais!=null)
            {
                txtNombrePais.Text = pais.NombrePais;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {//instancio el validar datos *8A
            if (ValidarDatos())
            {
                //[*5b]cuando le diga ok si el pais ya me lo pasaron no le puedo decir nuevo pais tengo que ver si el pais no es nulo
                if (pais == null)
                {
                    pais = new Pais();//si el pais es nulo es porque es un nuevo pais entonces lo creo
                                      //aca le digo que cuando aprete el boton OK, va a crear un objeto de tipo pais y le va asignar el valor que esta en el textbox al atributo del objeto que le indico
                }
                //aca le digo que si no es nulo el nombre pais que seleccione va a recibir el nuevo nombre pais que esta en el textBox
                pais.NombrePais = txtNombrePais.Text;
                DialogResult = DialogResult.OK;
            }
            
            
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtNombrePais.Text))
            {
                valido= false;
                errorProvider1.SetError(txtNombrePais, "Debe Ingresar un nombre al pais");
            }
            return valido;
        }

        public Pais GetPais()//esto era internal obj hay que modificarlo
        {
            return pais;//aca me va retornar el pais quye yo ingrese atraves dde este formulario, esta es la variable que tengo instanciada y referenciada arriba
        }

        public void SetPais(Pais pais)
        {//le paso un pais y ese pais lo tengo que poner en el pais definido arriba "private Pais pais;" linea 21
            this.pais = pais;//
        }

    }
}
