namespace Neptuno2023.Windows
{
    partial class frmCiudades
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnBorrar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFiltrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.btnPagUltima = new System.Windows.Forms.Button();
            this.btnPagSiguiente = new System.Windows.Forms.Button();
            this.btnPagAnterior = new System.Windows.Forms.Button();
            this.btnPagPrimera = new System.Windows.Forms.Button();
            this.labelPagTotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelNumPagina = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCantidadRegistro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelGrilla = new System.Windows.Forms.Panel();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.colNombrePaises = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.panelInferior.SuspendLayout();
            this.panelGrilla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnBorrar,
            this.btnEditar,
            this.toolStripSeparator1,
            this.toolStripButtonFiltrar,
            this.toolStripButtonActualizar,
            this.toolStripSeparator2,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.toolStripButton7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(867, 46);
            this.toolStrip1.TabIndex = 0;
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
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
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
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 46);
            // 
            // toolStripButtonFiltrar
            // 
            this.toolStripButtonFiltrar.Image = global::Neptuno2023.Windows.Properties.Resources._01_Filtrar_24px;
            this.toolStripButtonFiltrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonFiltrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFiltrar.Name = "toolStripButtonFiltrar";
            this.toolStripButtonFiltrar.Size = new System.Drawing.Size(41, 43);
            this.toolStripButtonFiltrar.Text = "Filtrar";
            this.toolStripButtonFiltrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonFiltrar.Click += new System.EventHandler(this.toolStripButtonFiltrar_Click);
            // 
            // toolStripButtonActualizar
            // 
            this.toolStripButtonActualizar.Image = global::Neptuno2023.Windows.Properties.Resources._01_Actualizar_24px;
            this.toolStripButtonActualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonActualizar.Name = "toolStripButtonActualizar";
            this.toolStripButtonActualizar.Size = new System.Drawing.Size(63, 43);
            this.toolStripButtonActualizar.Text = "Actualizar";
            this.toolStripButtonActualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonActualizar.Click += new System.EventHandler(this.toolStripButtonActualizar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 46);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Image = global::Neptuno2023.Windows.Properties.Resources._01_Imprimir_24px;
            this.toolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(57, 43);
            this.toolStripButton6.Text = "Imprimir";
            this.toolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 46);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.Image = global::Neptuno2023.Windows.Properties.Resources._01_Cerrar_24px;
            this.toolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(43, 43);
            this.toolStripButton7.Text = "Cerrar";
            this.toolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // panelInferior
            // 
            this.panelInferior.Controls.Add(this.btnPagUltima);
            this.panelInferior.Controls.Add(this.btnPagSiguiente);
            this.panelInferior.Controls.Add(this.btnPagAnterior);
            this.panelInferior.Controls.Add(this.btnPagPrimera);
            this.panelInferior.Controls.Add(this.labelPagTotal);
            this.panelInferior.Controls.Add(this.label4);
            this.panelInferior.Controls.Add(this.labelNumPagina);
            this.panelInferior.Controls.Add(this.label2);
            this.panelInferior.Controls.Add(this.labelCantidadRegistro);
            this.panelInferior.Controls.Add(this.label1);
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 400);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(867, 95);
            this.panelInferior.TabIndex = 1;
            // 
            // btnPagUltima
            // 
            this.btnPagUltima.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagUltima.Image = global::Neptuno2023.Windows.Properties.Resources.next_page_35px;
            this.btnPagUltima.Location = new System.Drawing.Point(536, 22);
            this.btnPagUltima.Name = "btnPagUltima";
            this.btnPagUltima.Size = new System.Drawing.Size(50, 45);
            this.btnPagUltima.TabIndex = 6;
            this.btnPagUltima.UseVisualStyleBackColor = true;
            this.btnPagUltima.Click += new System.EventHandler(this.btnPagUltima_Click);
            // 
            // btnPagSiguiente
            // 
            this.btnPagSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagSiguiente.Image = global::Neptuno2023.Windows.Properties.Resources.circled_play_35px;
            this.btnPagSiguiente.Location = new System.Drawing.Point(462, 22);
            this.btnPagSiguiente.Name = "btnPagSiguiente";
            this.btnPagSiguiente.Size = new System.Drawing.Size(50, 45);
            this.btnPagSiguiente.TabIndex = 6;
            this.btnPagSiguiente.UseVisualStyleBackColor = true;
            this.btnPagSiguiente.Click += new System.EventHandler(this.btnPagSiguiente_Click);
            // 
            // btnPagAnterior
            // 
            this.btnPagAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagAnterior.Image = global::Neptuno2023.Windows.Properties.Resources.pause_button_35px;
            this.btnPagAnterior.Location = new System.Drawing.Point(395, 22);
            this.btnPagAnterior.Name = "btnPagAnterior";
            this.btnPagAnterior.Size = new System.Drawing.Size(50, 45);
            this.btnPagAnterior.TabIndex = 6;
            this.btnPagAnterior.UseVisualStyleBackColor = true;
            this.btnPagAnterior.Click += new System.EventHandler(this.btnPagAnterior_Click);
            // 
            // btnPagPrimera
            // 
            this.btnPagPrimera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagPrimera.Image = global::Neptuno2023.Windows.Properties.Resources.back_to_35px;
            this.btnPagPrimera.Location = new System.Drawing.Point(323, 22);
            this.btnPagPrimera.Name = "btnPagPrimera";
            this.btnPagPrimera.Size = new System.Drawing.Size(50, 45);
            this.btnPagPrimera.TabIndex = 6;
            this.btnPagPrimera.UseVisualStyleBackColor = true;
            this.btnPagPrimera.Click += new System.EventHandler(this.btnPagPrimera_Click);
            // 
            // labelPagTotal
            // 
            this.labelPagTotal.AutoSize = true;
            this.labelPagTotal.Location = new System.Drawing.Point(136, 54);
            this.labelPagTotal.Name = "labelPagTotal";
            this.labelPagTotal.Size = new System.Drawing.Size(13, 13);
            this.labelPagTotal.TabIndex = 5;
            this.labelPagTotal.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "de";
            // 
            // labelNumPagina
            // 
            this.labelNumPagina.AutoSize = true;
            this.labelNumPagina.Location = new System.Drawing.Point(92, 54);
            this.labelNumPagina.Name = "labelNumPagina";
            this.labelNumPagina.Size = new System.Drawing.Size(13, 13);
            this.labelNumPagina.TabIndex = 3;
            this.labelNumPagina.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Página:";
            // 
            // labelCantidadRegistro
            // 
            this.labelCantidadRegistro.AutoSize = true;
            this.labelCantidadRegistro.Location = new System.Drawing.Point(155, 22);
            this.labelCantidadRegistro.Name = "labelCantidadRegistro";
            this.labelCantidadRegistro.Size = new System.Drawing.Size(13, 13);
            this.labelCantidadRegistro.TabIndex = 1;
            this.labelCantidadRegistro.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cantidad de Registros:";
            // 
            // panelGrilla
            // 
            this.panelGrilla.Controls.Add(this.dgvDatos);
            this.panelGrilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrilla.Location = new System.Drawing.Point(0, 46);
            this.panelGrilla.Name = "panelGrilla";
            this.panelGrilla.Size = new System.Drawing.Size(867, 354);
            this.panelGrilla.TabIndex = 2;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNombrePaises,
            this.colNombreCiudad});
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(867, 354);
            this.dgvDatos.TabIndex = 0;
            // 
            // colNombrePaises
            // 
            this.colNombrePaises.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombrePaises.HeaderText = "Paises";
            this.colNombrePaises.Name = "colNombrePaises";
            this.colNombrePaises.ReadOnly = true;
            // 
            // colNombreCiudad
            // 
            this.colNombreCiudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNombreCiudad.HeaderText = "Ciudad";
            this.colNombreCiudad.Name = "colNombreCiudad";
            this.colNombreCiudad.ReadOnly = true;
            // 
            // frmCiudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 495);
            this.ControlBox = false;
            this.Controls.Add(this.panelGrilla);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.toolStrip1);
            this.MaximumSize = new System.Drawing.Size(883, 534);
            this.MinimumSize = new System.Drawing.Size(883, 534);
            this.Name = "frmCiudades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCiudades";
            this.Load += new System.EventHandler(this.frmCiudades_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelInferior.ResumeLayout(false);
            this.panelInferior.PerformLayout();
            this.panelGrilla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnBorrar;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonFiltrar;
        private System.Windows.Forms.ToolStripButton toolStripButtonActualizar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Panel panelGrilla;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombrePaises;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreCiudad;
        private System.Windows.Forms.Label labelCantidadRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPagTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelNumPagina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPagUltima;
        private System.Windows.Forms.Button btnPagSiguiente;
        private System.Windows.Forms.Button btnPagAnterior;
        private System.Windows.Forms.Button btnPagPrimera;
    }
}