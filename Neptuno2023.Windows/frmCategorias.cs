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
    public partial class frmCategorias : Form
    {
        private readonly IServiciosCategorias _serviciosCategoria;//el frmCategoria va a trabajar con el la interfaz de servicio
        private List<Categoria> lista;//paso 13
        public frmCategorias()
        {
            InitializeComponent();
            _serviciosCategoria = new ServiciosCategorias();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            try//cuando se carga le dice al servicio que le traiga las categorias
            {
                //aca tuve un error que no dejaba que me funcionara, le habia puesto "var" como tipo de atributo de lista y me salia erro
                //var lista= _servicios.GetCategorias();
                lista = _serviciosCategoria.GetCategorias();//pero esta es la forma correcta! al ponerle el var la estoy creando como "local" al metodo load entonces al otro metodo "private list" no lo esta viendo
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            //dgvDatosCategoria.Rows.Clear();//limpio la grilla
            GripHelper.LimpiarGrilla(dgvDatosCategoria);//(*126)

            foreach (var categoria in lista) //por cada categoria de la lista
            {
                DataGridViewRow r = GripHelper.ConstruirFila(dgvDatosCategoria);//(*127)dgvRow crea una fila en blanco y va a tomar la forma que instancio en el construirfila
                //aca ya tengo la fila nueva con el formato que le indique en el metodo ConstruirFila, es decir este "r" toma el valor del r que cree en el metodo
                GripHelper.SetearFila(r, categoria);//(*128)aca le digo a la fila r, le voy a pasar los datos dde la categoria
                //ahora ya tengo la fila con sus celdas y cada celda tiene un valor asociado
                GripHelper.AgregarFila(dgvDatosCategoria,r);//(*129)ahora tengo que agregar esa fila nueva al DGV

            }
        }

        //private void AgregarFila(DataGridViewRow r)
        //{
        //    dgvDatosCategoria.Rows.Add(r);//aca digo al DGV tal en la partes de filas les voy agregar tal fila "r"
        //}

        //private void SetearFila(DataGridViewRow r, Categoria categoria)//clase Categoria como tipo de variable nombre del atributo atributto categoria
        //{//ahora le voy asignar a cada una de las celdas de "r" un valor de "categoria
        //    r.Cells[colCategoria.Index].Value = categoria.NombreCategoria;//a la fila le digo que voy a seleccionar la celda/columna que le indico y uso el index para la posicion, uso el value para decirle que va a tomar el valor que le paso. del objeto categoria le voy asignar el valor del atributo que le indicop
        //    r.Cells[colDescripcion.Index].Value=categoria.Descripcion;
        //    r.Tag = categoria;//el tag almaneza cualquier objeto en este caso a la fila "r".almacenar información de identificación, como un nombre de cadena, un identificador único
        //}

        //private DataGridViewRow ConstruirFila()(*127)
        //{
        //    DataGridViewRow r = new DataGridViewRow();//ACA DIGO Q  UE VA A SER UNA NUEVA FILA
        //    r.CreateCells(dgvDatosCategoria);//aca le digo que en la fila R voy a crear celdas y toma referencia las columnas del DGV para hacerlo(en este caso la fila va a tener dos celddad (una categoria y otra descipcion 
        //    return r;//el metodo devuelve ya la nueva fila con dos celdas(correspondiente a las dos columnas)
        //}

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCategoriaAE frm=new frmCategoriaAE()
            {
                Text="Agregar nueva categoria"
            };
            DialogResult dr= frm.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    var categoria = frm.GetCategoria();//aca me traigo la categoria del CategoriaAE - - - LEER ESTE METODO EN "FRMCATEGORIAPAIS" DONDE EXPLICO 
                    _serviciosCategoria.Guardar(categoria);//cuando pongo generar meteodo guardar se crea en "IServicio" 
                    DataGridViewRow r = GripHelper.ConstruirFila(dgvDatosCategoria);//(*127)construyo la fila del pais nuevo para cargarlo a la grilla||  TODO ESTO
                    GripHelper.SetearFila(r, categoria);//(*128)paso la fila y que dato voy a                             ||  SI NO LO
                    GripHelper.AgregarFila(dgvDatosCategoria,r);//(*129)agrego la fila a la grilla                        ||  PONGO CUANDO
                    MessageBox.Show("Registro agregado satifactoriamente",//                                              ||  LO GUARDO NO
                        "Mensaje",//                                                                                      ||  SE MUESTRA EL
                        MessageBoxButtons.OK, MessageBoxIcon.Information);//                                              ||  REGISTRO
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
