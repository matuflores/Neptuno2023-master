namespace Neptuno2023.Windows
{
    partial class frmClientes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelInferior = new System.Windows.Forms.Panel();
            this.btnPagUltima = new System.Windows.Forms.Button();
            this.btnPagSiguiente = new System.Windows.Forms.Button();
            this.btnPagAnterior = new System.Windows.Forms.Button();
            this.btnPagPrimera = new System.Windows.Forms.Button();
            this.labelCantidadDeRegistros = new System.Windows.Forms.Label();
            this.labelPagTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelNumPag = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaises = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnBorrar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFiltrar = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCerrar = new System.Windows.Forms.ToolStripButton();
            this.panelInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInferior
            // 
            this.panelInferior.Controls.Add(this.btnPagUltima);
            this.panelInferior.Controls.Add(this.btnPagSiguiente);
            this.panelInferior.Controls.Add(this.btnPagAnterior);
            this.panelInferior.Controls.Add(this.btnPagPrimera);
            this.panelInferior.Controls.Add(this.labelCantidadDeRegistros);
            this.panelInferior.Controls.Add(this.labelPagTotal);
            this.panelInferior.Controls.Add(this.label5);
            this.panelInferior.Controls.Add(this.labelNumPag);
            this.panelInferior.Controls.Add(this.label2);
            this.panelInferior.Controls.Add(this.label1);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 395);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(867, 100);
            this.panelInferior.TabIndex = 0;
            // 
            // btnPagUltima
            // 
            this.btnPagUltima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagUltima.Image = global::Neptuno2023.Windows.Properties.Resources.next_page_35px;
            this.btnPagUltima.Location = new System.Drawing.Point(525, 33);
            this.btnPagUltima.Name = "btnPagUltima";
            this.btnPagUltima.Size = new System.Drawing.Size(47, 44);
            this.btnPagUltima.TabIndex = 1;
            this.btnPagUltima.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPagUltima.UseVisualStyleBackColor = true;
            // 
            // btnPagSiguiente
            // 
            this.btnPagSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagSiguiente.Image = global::Neptuno2023.Windows.Properties.Resources.circled_play_35px;
            this.btnPagSiguiente.Location = new System.Drawing.Point(449, 33);
            this.btnPagSiguiente.Name = "btnPagSiguiente";
            this.btnPagSiguiente.Size = new System.Drawing.Size(47, 44);
            this.btnPagSiguiente.TabIndex = 1;
            this.btnPagSiguiente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPagSiguiente.UseVisualStyleBackColor = true;
            // 
            // btnPagAnterior
            // 
            this.btnPagAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagAnterior.Image = global::Neptuno2023.Windows.Properties.Resources.pause_button_35px;
            this.btnPagAnterior.Location = new System.Drawing.Point(374, 33);
            this.btnPagAnterior.Name = "btnPagAnterior";
            this.btnPagAnterior.Size = new System.Drawing.Size(47, 44);
            this.btnPagAnterior.TabIndex = 1;
            this.btnPagAnterior.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPagAnterior.UseVisualStyleBackColor = true;
            // 
            // btnPagPrimera
            // 
            this.btnPagPrimera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagPrimera.Image = global::Neptuno2023.Windows.Properties.Resources.back_to_35px;
            this.btnPagPrimera.Location = new System.Drawing.Point(299, 33);
            this.btnPagPrimera.Name = "btnPagPrimera";
            this.btnPagPrimera.Size = new System.Drawing.Size(47, 44);
            this.btnPagPrimera.TabIndex = 1;
            this.btnPagPrimera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPagPrimera.UseVisualStyleBackColor = true;
            // 
            // labelCantidadDeRegistros
            // 
            this.labelCantidadDeRegistros.AutoSize = true;
            this.labelCantidadDeRegistros.Location = new System.Drawing.Point(150, 18);
            this.labelCantidadDeRegistros.Name = "labelCantidadDeRegistros";
            this.labelCantidadDeRegistros.Size = new System.Drawing.Size(13, 13);
            this.labelCantidadDeRegistros.TabIndex = 0;
            this.labelCantidadDeRegistros.Text = "0";
            // 
            // labelPagTotal
            // 
            this.labelPagTotal.AutoSize = true;
            this.labelPagTotal.Location = new System.Drawing.Point(128, 53);
            this.labelPagTotal.Name = "labelPagTotal";
            this.labelPagTotal.Size = new System.Drawing.Size(13, 13);
            this.labelPagTotal.TabIndex = 0;
            this.labelPagTotal.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "de";
            // 
            // labelNumPag
            // 
            this.labelNumPag.AutoSize = true;
            this.labelNumPag.Location = new System.Drawing.Point(77, 53);
            this.labelNumPag.Name = "labelNumPag";
            this.labelNumPag.Size = new System.Drawing.Size(13, 13);
            this.labelNumPag.TabIndex = 0;
            this.labelNumPag.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Página:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad De Registros:";
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCliente,
            this.colPaises,
            this.colCiudad});
            this.dgvDatos.Location = new System.Drawing.Point(0, 49);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.Size = new System.Drawing.Size(867, 347);
            this.dgvDatos.TabIndex = 1;
            // 
            // colCliente
            // 
            this.colCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            // 
            // colPaises
            // 
            this.colPaises.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPaises.HeaderText = "Pais";
            this.colPaises.Name = "colPaises";
            this.colPaises.ReadOnly = true;
            // 
            // colCiudad
            // 
            this.colCiudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCiudad.HeaderText = "Ciudad";
            this.colCiudad.Name = "colCiudad";
            this.colCiudad.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnBorrar,
            this.btnEditar,
            this.toolStripSeparator1,
            this.btnFiltrar,
            this.btnActualizar,
            this.toolStripSeparator2,
            this.btnImprimir,
            this.toolStripSeparator3,
            this.btnCerrar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(867, 46);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Neptuno2023.Windows.Properties.Resources._01_Nuevo_24px;
            this.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(46, 43);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Image = global::Neptuno2023.Windows.Properties.Resources._01_Borrar_24px;
            this.btnBorrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(43, 43);
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::Neptuno2023.Windows.Properties.Resources._01_Editar_24px;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(41, 43);
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = global::Neptuno2023.Windows.Properties.Resources._01_Filtrar_24px;
            this.btnFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(41, 43);
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::Neptuno2023.Windows.Properties.Resources._01_Actualizar_24px;
            this.btnActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(63, 43);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::Neptuno2023.Windows.Properties.Resources._01_Imprimir_24px;
            this.btnImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(57, 43);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 46);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = global::Neptuno2023.Windows.Properties.Resources._01_Cerrar_24px;
            this.btnCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCerrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(43, 43);
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 495);
            this.ControlBox = false;
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.panelInferior);
            this.MaximumSize = new System.Drawing.Size(883, 534);
            this.MinimumSize = new System.Drawing.Size(883, 534);
            this.Name = "frmClientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnBorrar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnFiltrar;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnCerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaises;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCiudad;
        private System.Windows.Forms.Label labelCantidadDeRegistros;
        private System.Windows.Forms.Label labelPagTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelNumPag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPagUltima;
        private System.Windows.Forms.Button btnPagSiguiente;
        private System.Windows.Forms.Button btnPagAnterior;
        private System.Windows.Forms.Button btnPagPrimera;
    }
}