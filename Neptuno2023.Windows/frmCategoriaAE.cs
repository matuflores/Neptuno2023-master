﻿using Neptuno2023.Entidades.Entidades;
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
    public partial class frmCategoriaAE : Form
    {
        public frmCategoriaAE()
        {
            InitializeComponent();
        }
        private Categoria categoria;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);//para hacer esto primero tengo que darle uso al btnOk
            if (categoria!=null)
            {
                textNombreCategoria.Text = categoria.NombreCategoria;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (categoria==null)
            {
                categoria = new Categoria();
            }
            categoria.NombreCategoria = textNombreCategoria.Text;
            categoria.Descripcion= textDescripcion.Text;
            DialogResult = DialogResult.OK;
        }

        public Categoria GetCategoria()//internal object GetCategoria() cuando genero el metodo esto se pone asi, tengo que modificarlo
        {
            return categoria;
        }
    }
}
