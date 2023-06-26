using Neptuno2023.Entidades.Dtos.Cliente;
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
    public partial class frmClientes : Form
    {
        private readonly IServiciosClientes _serviciosClientes;
        List<ClienteListDto> lista;
        public frmClientes()
        {
            InitializeComponent();
            _serviciosClientes=new ServiciosClientes(); 
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                lista = _serviciosClientes.GetClientes();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        
        private void MostrarDatosEnGrilla()
        {
            GripHelper.LimpiarGrilla(dgvDatos);
            foreach (var cliente in lista)
            {
                var r = GripHelper.ConstruirFila(dgvDatos);
                GripHelper.SetearFila(r,cliente);
                GripHelper.AgregarFila(dgvDatos, r);
            }
        }
    }
}
