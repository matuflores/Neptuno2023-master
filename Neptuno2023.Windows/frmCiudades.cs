﻿using Neptuno2023.Entidades.Entidades;
using Neptuno2023.Servicios.Interfases;
using Neptuno2023.Servicios.Servicios;
using Neptuno2023.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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

            //dgvDatos.Rows.Clear();//anters de mostrar algo en grilla debo limpiarla
            GripHelper.LimpiarGrilla(dgvDatos);//(*126)

            foreach (var ciudad in lista)
            {
                DataGridViewRow r = GripHelper.ConstruirFila(dgvDatos);//(*127)
                GripHelper.SetearFila(r, ciudad);//(*128)
                GripHelper.AgregarFila(dgvDatos, r);//(*129)
            }

        }

        //private void AgregarFila(DataGridViewRow r)
        //{//ahora la celda que tiene valor se la agrego al DGV
        //    dgvDatos.Rows.Add(r);
        //}

        //ANULO PORQUE ESTA EN EL HELPER
        //private void SetearFila(DataGridViewRow r, Ciudad ciudad)
        //{//uso este metodo para agregar los valores a la fila que cree previamente
        //    r.Cells[colNombreCiudad.Index].Value=ciudad.NombreCiudad;
        //    //r.Cells[colNombrePaises.Index].Value = ciudad.PaisId;//asigno un valor a la cell de la fila
        //    //anule el r.Cells de arriba porque ahora no me va a mostrar el ID sino el nombre del pais gracias a los metodos GetPaisPorId
        //    r.Cells[colNombrePaises.Index].Value = ciudad.Pais.NombrePais;
        //    r.Tag = ciudad;//Tag para asignar una cadena de identificación a un objeto sin que afecte a otra configuración o atributo de propiedad
        //}

        //private DataGridViewRow ConstruirFila()
        //{
        //    DataGridViewRow r = new DataGridViewRow();//creo una nueva fila
        //    r.CreateCells(dgvDatos);
        //    return r;
        //}

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmCiudadAE frm= new frmCiudadAE()
            {
                Text="Agregar Ciudad"
            };
            DialogResult dr= frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Ciudad ciudad = frm.GetCiudad();
                if (!_serviciosCiudades.Existe(ciudad))
                {
                    //si la ciudad no existe
                    _serviciosCiudades.Guardar(ciudad);
                    //una vez que se agrego tengo que mostrarla
                    var r = GripHelper.ConstruirFila(dgvDatos);
                    GripHelper.SetearFila(r,ciudad);
                    GripHelper.AgregarFila(dgvDatos, r);

                    MessageBox.Show("Registro Agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro Duplicado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)//LO PRIMERO TENGO QUE FIJARME SI TENGO UNA FILA SELECCIONADA
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];//si tengo una fila seleccionada me fijo cual es la filas
            Ciudad ciudad = (Ciudad)r.Tag;//una vez en la fila obtengo el páis
            Ciudad ciudadCopia = (Ciudad)ciudad.Clone();//ESTO DEVUELVE UN OBJET POR ESO TENGO QUE CASTEARLO (*F8)
            try
            {

                frmCiudadAE frm = new frmCiudadAE()
                {
                    Text = "Editar Ciudad"
                };//para poder editar lo tengo que pasar al formulario
                frm.SetCiudad(ciudad);//para poder pasarlo necesito un metodo
                DialogResult dr = frm.ShowDialog();//se habre el dialogo entre formularios
                                                   //ahora preguntamos 
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                //caso contrario si no aprete cancel es porque modifique un pais y lo debo agregar
                ciudad = frm.GetCiudad();//tengo mi nuevo pais
                                     //el formulario le pide a servicios que lo guarde
                if (!_serviciosCiudades.Existe(ciudad))
                {
                    _serviciosCiudades.Guardar(ciudad);
                    //una vez que guardo el pais, tewngo que setear fila con el nuevo pais
                    GripHelper.SetearFila(r, ciudad);//(*128)
                    MessageBox.Show("Ciudad Editada satisfactoriamente",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    GripHelper.SetearFila(r, ciudadCopia);//(*128)
                    MessageBox.Show("Registro Duplicado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //como todo esto implica que debo acceder a la tabla deberia agregarlos con un try
            }
            catch (Exception ex)
            {
                GripHelper.SetearFila(r, ciudadCopia);//(*128)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;//si no seleccione nada vuelve
            }
            var r = dgvDatos.SelectedRows[0];//AL PONERLE EL NUMERO CERO, NO ME DEVUELVE UNA FILA PREESTABLECIDA SINO QUE ME DE TRAE LA QUE YO SELECCIONE EN ESE MOMENTO
            Ciudad ciudad= (Ciudad)r.Tag;
            try
            {
                //se debe controlar que no esten relacionado con otras tablas (ver clase 17/5)
                DialogResult dr = MessageBox.Show("¿Seguro que desea el eliminar el registro?", "Confirmacion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) { return; }//
                _serviciosCiudades.Borrar(ciudad.CiudadId);
                GripHelper.QuitarFila(dgvDatos, r);//(*130)
                labelCantidadRegistro.Text = _serviciosCiudades.GetCantidad().ToString();//Poner la canmtidad en este punto hace que una vez que eliminio el "pais" el contador se actualice
                MessageBox.Show("Registro borrado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //throw; si en el catch dejo (exception) y dejo el throw cuando tenga el error lo que va hacer es que el programa se detenga sin mostrarme en la pantalla pincripal el error
                //MessageBox.Show("El registro no se puede borrar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error); si en el catch dejo (exception) y dejo este, me sale una ventana con lo que escribi entre comillas.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//si en el catch dejo (exception ex) y pongo esto, me va a salir con la especificacion del detalle pero como una ventana
            }
        }
    }
}
