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
    public partial class frmCiudades : Form
    {
        private readonly IServiciosCiudades _serviciosCiudades;
        private List<Ciudad> lista;
        int cantidad = 0;
        public frmCiudades()
        {
            InitializeComponent();
            _serviciosCiudades =new ServiciosCiudades();
        }

        private void frmCiudades_Load(object sender, EventArgs e)
        {
            try
            {
                cantidad=_serviciosCiudades.GetCantidad();
                labelCantidadRegistro.Text = cantidad.ToString();
                lista = _serviciosCiudades.GetCiudades();
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
            foreach (var ciudad in lista)
            {
                DataGridViewRow r = ConstruirFila();
                SetearFila(r, ciudad);
                AgregarFila(r);
            }

        }

        private void AgregarFila(DataGridViewRow r)
        {//ahora la celda que tiene valor se la agrego al DGV
            dgvDatos.Rows.Add(r);
        }

        private void SetearFila(DataGridViewRow r, Ciudad ciudad)
        {//uso este metodo para agregar los valores a la fila que cree previamente
            r.Cells[colNombreCiudad.Index].Value=ciudad.NombreCiudad;
            //r.Cells[colNombrePaises.Index].Value = ciudad.PaisId;//asigno un valor a la cell de la fila
            //anule el r.Cells de arriba porque ahora no me va a mostrar el ID sino el nombre del pais gracias a los metodos GetPaisPorId
            r.Cells[colNombrePaises.Index].Value = ciudad.Pais.NombrePais;
            r.Tag = ciudad;//Tag para asignar una cadena de identificación a un objeto sin que afecte a otra configuración o atributo de propiedad
        }

        private DataGridViewRow ConstruirFila()
        {
            DataGridViewRow r = new DataGridViewRow();//creo una nueva fila
            r.CreateCells(dgvDatos);
            return r;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
