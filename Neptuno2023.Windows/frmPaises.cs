using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
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
    public partial class frmPaises : Form
    {
        public frmPaises()
        {
            InitializeComponent();
            _serviciosPaises = new ServiciosPaises();//(*1)
        }
        private readonly IServiciosPaises _serviciosPaises;//como windddows trabaja con servicio creo la variable para que lea desde servicio y una vez que se abre el frm se abre el servicio(*1)
        private List<Pais> lista;//tengo que tener un contenedor para que el servicio me pueda poner los datos que yo les pido

        private void frmPaises_Load(object sender, EventArgs e)
        {//cuando se carga se va a fijar si el repo tiene datos, si los tiene los desplegas
            try//un bloque try para separar el código que podría verse afectado por una excepción
            {//la variable lista, le pide los paises al 
                lista = _serviciosPaises.GetPaises();//paso 9: cargar los datos en la grilla es leer los datos de servicio y darselo a la listya y a su vez generar el metodo para mostrarlos
                //*7A
                labelCantidadRegistro.Text = _serviciosPaises.GetCantidad().ToString();//esto me devuelvo un int pero el label es text asique lo tengo que castear
                MostrasDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrasDatosEnGrilla()
        {//busco el nombre de la grilla para cargar los datos - config eldatagriedview
            dgvDatos.Rows.Clear();//anters de mostrar algo en grilla debo limpiarla
            foreach (var pais in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, pais);
                AgregarFila(r);
            }
            
        }

        private void AgregarFila(DataGridViewRow r)
        {//ahora la celda que tiene valor se la agrego al DGV
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Pais pais)
        {//uso este metodo para agregar los valores a la fila que cree previamente
            r.Cells[colPais.Index].Value = pais.NombrePais;//asigno un valor a la cell de la fila
            r.Tag = pais;//Tag para asignar una cadena de identificación a un objeto sin que afecte a otra configuración o atributo de propiedad
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r= new DataGridViewRow();//creo una nueva fila
            r.CreateCells(dgvDatos);
            return r;
        }

        private void btnNuevo_Click(object sender, EventArgs e)//paso 5(agregar)
        {
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
                        DataGridViewRow r = ConstruirFila();//construyo la fila del pais nuevo para cargarlo a la grilla
                        SetearFila(r, pais);//paso la fila y que dato voy agregar
                        AgregarFila(r);//agrego la fila a la grilla
                        labelCantidadRegistro.Text = _serviciosPaises.GetCantidad().ToString();//lo pongo aca para que me actualice la cantidad registro
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
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count==0)//LO PRIMERO TENGO QUE FIJARME SI TENGO UNA FILA SELECCIONADA
            {
                return;
            }
            try
            {
                var r = dgvDatos.SelectedRows[0];//si tengo una fila seleccionada me fijo cual es la filas
                Pais pais = (Pais)r.Tag;//una vez en la fila obtengo el páis
                frmPaisAE frm = new frmPaisAE()
                {
                    Text = "Editar Pais"
                };//para poder editar lo tengo que pasar al formulario
                frm.SetPais(pais);//para poder pasarlo necesito un metodo
                DialogResult dr = frm.ShowDialog();//se habre el dialogo entre formularios
                                                   //ahora preguntamos 
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                //caso contrario si no aprete cancel es porque modifique un pais y lo debo agregar
                pais = frm.GetPais();//tengo mi nuevo pais
                                     //el formulario le pide a servicios que lo guarde
                _serviciosPaises.Guardar(pais);
                //una vez que guardo el pais, tewngo que setear fila con el nuevo pais
                SetearFila(r, pais);
                MessageBox.Show("Pais Editado satisfactoriamente",
                    "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //como todo esto implica que debo acceder a la tabla deberia agregarlos con un try
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
