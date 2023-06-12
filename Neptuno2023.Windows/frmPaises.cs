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

            //para limpiar la grilla, ya que se reutiliza este codigo, lo agregue en los Helpers, por eso lo anulo
            //dgvDatos.Rows.Clear();//anters de mostrar algo en grilla debo limpiarla
            GripHelper.LimpiarGrilla(dgvDatos);//anule el anterior para usar este, y lo voy a usar cada vez que tenga que limpiar grilla (*126)

            foreach (var pais in lista)
            {
                //DataGridViewRow r = ConstruirFila();//anulo esto para implementar el helper
                DataGridViewRow r = GripHelper.ConstruirFila(dgvDatos);//(*127)
                GripHelper.SetearFila(r, pais);//(*128)
                GripHelper.AgregarFila(dgvDatos,r);//(*129)aca para que funcione le debo pasar la grilla
            }
            
        }

        //ANULO ESTE METODO ´PORQUE YA ESTA EN EL HELPER
        //private void AgregarFila(DataGridViewRow r)
        //{//ahora la celda que tiene valor se la agrego al DGV
        //    dgvDatos.Rows.Add(r);
        //}

        //ANULO ESTE METODO PORQUE YA ESTA EN EL HELPER
        //private void SetearFila(DataGridViewRow r, Pais pais)
        //{//uso este metodo para agregar los valores a la fila que cree previamente
        //    r.Cells[colPais.Index].Value = pais.NombrePais;//asigno un valor a la cell de la fila
        //    r.Tag = pais;//Tag para asignar una cadena de identificación a un objeto sin que afecte a otra configuración o atributo de propiedad
        //}

        //ANULO ESTE METODO PORQUE YA ESTA EN EL HELPER
        //private DataGridViewRow ConstruirFila()
        //{
        //    DataGridViewRow r= new DataGridViewRow();//creo una nueva fila
        //    r.CreateCells(dgvDatos);
        //    return r;
        //}

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
                        
                        DataGridViewRow r = GripHelper.ConstruirFila(dgvDatos);//(*127)construyo la fila del pais nuevo para cargarlo a la grilla
                        GripHelper.SetearFila(r, pais);//(*128)paso la fila y que dato voy agregar
                        GripHelper.AgregarFila(dgvDatos, r);//(*129)agrego la fila a la grilla
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
            //PREGUNTAR A CARLOS PORQUE NO SE ME GUARDA LA EDICION
            if (dgvDatos.SelectedRows.Count==0)//LO PRIMERO TENGO QUE FIJARME SI TENGO UNA FILA SELECCIONADA
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];//si tengo una fila seleccionada me fijo cual es la filas
            Pais pais = (Pais)r.Tag;//una vez en la fila obtengo el páis
            Pais paisCopia =(Pais) pais.Clone();//ESTO DEVUELVE UN OBJET POR ESO TENGO QUE CASTEARLO (*F8)
            try
            {
                
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
                if (!_serviciosPaises.Existe(pais))
                {
                    _serviciosPaises.Guardar(pais);
                    //una vez que guardo el pais, tewngo que setear fila con el nuevo pais
                    GripHelper.SetearFila(r, pais);//(*128)
                    MessageBox.Show("Pais Editado satisfactoriamente",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GripHelper.SetearFila(r, paisCopia);//(*128)
                    MessageBox.Show("Registro Duplicado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                //como todo esto implica que debo acceder a la tabla deberia agregarlos con un try
            }
            catch (Exception)
            {
                GripHelper.SetearFila(r, paisCopia);//(*128)
                MessageBox.Show("Registro Duplicado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //para poder borrar tengo que haber seleccionado uno
            if (dgvDatos.SelectedRows.Count==0)
            {
                return;//si no seleccione nada vuelve
            }
            var r = dgvDatos.SelectedRows[0];//AL PONERLE EL NUMERO CERO, NO ME DEVUELVE UNA FILA PREESTABLECIDA SINO QUE ME DE TRAE LA QUE YO SELECCIONE EN ESE MOMENTO
            Pais pais=(Pais)r.Tag;
            try
            {
                //se debe controlar que no esten relacionado con otras tablas (ver clase 17/5)
                DialogResult dr=MessageBox.Show("¿Seguro que desea el eliminar el registro?","Confirmacion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }//
                _serviciosPaises.Borrar(pais.PaisId);
                QuitarFila(r);
                labelCantidadRegistro.Text = _serviciosPaises.GetCantidad().ToString();//Poner la canmtidad en este punto hace que una vez que eliminio el "pais" el contador se actualice
                MessageBox.Show("Registro borrado","Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //throw; si en el catch dejo (exception) y dejo el throw cuando tenga el error lo que va hacer es que el programa se detenga sin mostrarme en la pantalla pincripal el error
                //MessageBox.Show("El registro no se puede borrar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error); si en el catch dejo (exception) y dejo este, me sale una ventana con lo que escribi entre comillas.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//si en el catch dejo (exception ex) y pongo esto, me va a salir con la especificacion del detalle pero como una ventana
            }
        }

        private void QuitarFila(DataGridViewRow r)
        {
            dgvDatos.Rows.Remove(r);//EL REMOVE ES UN METODO DE LA COLECCION DEL DATA GRID VIEW
        }
    }
}
