using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
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
        private readonly IServiciosCiudades _serviciosCiudades;//le paso el servicio para poder agregar una ciudad desde este formulario (anule las lineas del btnNuevo del frmCiudades)
        public frmCiudadAE(IServiciosCiudades serviciosCiudades)//(*96) van con lo de abajo
        {
            _serviciosCiudades=serviciosCiudades;//preguntar esto a carlos bien como trabaja******(*96)
            InitializeComponent();
        }

        private Ciudad ciudad;
        private bool esEdicion = false;//Lo instancio para el agregar desde frmCiudadAE, (**33) LO CREO PARA QUE CUANDO SEA UNA EDICION EL FRM NO SE QUEDE UNA VEZ QUE PONGO OK
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
                esEdicion=true;//lo pongo verdadero porque a la ciuda al no ser nula es porque existe por lo que va a ser una "Edicion" (**33)
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

                //DialogResult = DialogResult.OK;
                try
                {
                    if (!_serviciosCiudades.Existe(ciudad))
                    {
                        _serviciosCiudades.Guardar(ciudad);

                        if (!esEdicion)// (**33)
                        {
                            MessageBox.Show("Registro agregado","Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            DialogResult dr = MessageBox.Show("¿Desea agregar otro registro?","Pregunta",MessageBoxButtons.YesNo, MessageBoxIcon.Question,MessageBoxDefaultButton.Button2);
                            if (dr == DialogResult.No)
                            {
                                DialogResult = DialogResult.OK;

                            }
                            ciudad = null;
                            InicializarControles();
                        }
                        else
                        {
                            MessageBox.Show("Registro editado", "Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Information);DialogResult = DialogResult.OK;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Registro duplicado","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);ciudad = null;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InicializarControles()
        {
            cbPaises.SelectedIndex = 0;
            textBoxCiudad.Clear();
            cbPaises.Focus();
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

        private void btnAgregarPais_Click(object sender, EventArgs e)
        {//
            var _serviciosPaises = new ServiciosPaises();
            frmPaisAE frm = new frmPaisAE()
            {
                Text = "Agregar Nuevo Pais"
            };
            DialogResult dr = frm.ShowDialog(this);//creo un dialogoresult en el que pregunto si quiere agregar un nuevo pais
            if (dr == DialogResult.OK)//en caso que la repuesta sea "OK" entonces ahora deberia abrir el formulario
            {//paso 8(agregar)
                try//le tengo que pedir al frm de paisae que me pase el pais para podder agregarlo 
                {
                    var pais = frm.GetPais();
                    if (!_serviciosPaises.Existe(pais))//*9A
                    {
                        _serviciosPaises.Guardar(pais);//este metodo esta instanciado en el "IServicioPaises" y lo implemento por Herencia en "ServiciosPaises" y en esete metodo uso el agregar del repositori que es donde abro la conexion con sql y paso el parametro para agregarlo a sql

                        //COMO NO TENGO QUE MOSTRAR NADA EN GRILLA ESTO LO ANULO.
                        //DataGridViewRow r = GripHelper.ConstruirFila(dgvDatos);//(*127)construyo la fila del pais nuevo para cargarlo a la grilla
                        //GripHelper.SetearFila(r, pais);//(*128)paso la fila y que dato voy agregar
                        //GripHelper.AgregarFila(dgvDatos, r);//(*129)agrego la fila a la grilla
                        //labelCantidadRegistro.Text = _serviciosPaises.GetCantidad().ToString();//lo pongo aca para que me actualice la cantidad registro

                        MessageBox.Show("Registro agregado satifactoriamente",
                            "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro ya existe",
                            "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                CombosHelper.CargarComboPaises(ref cbPaises);//Una vez que termino todo el proceso lo agrego al combo box
            }
        }
    }
}
