namespace SAEView
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirInterfazToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCantidadBanco = new System.Windows.Forms.Label();
            this.lblCantidadCoi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCantidadSAE = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbStateBanco = new System.Windows.Forms.PictureBox();
            this.pbStateCOI = new System.Windows.Forms.PictureBox();
            this.pbStateSAE = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateBanco)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateCOI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateSAE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "AspelView";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirInterfazToolStripMenuItem,
            this.toolStripMenuItem1,
            this.salirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(151, 70);
            // 
            // abrirInterfazToolStripMenuItem
            // 
            this.abrirInterfazToolStripMenuItem.Name = "abrirInterfazToolStripMenuItem";
            this.abrirInterfazToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.abrirInterfazToolStripMenuItem.Text = "Abrir interfaz";
            this.abrirInterfazToolStripMenuItem.Click += new System.EventHandler(this.abrirInterfazToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem1.Text = "Configuración";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.lblCantidadBanco);
            this.groupBox1.Controls.Add(this.lblCantidadCoi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCantidadSAE);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pbStateBanco);
            this.groupBox1.Controls.Add(this.pbStateCOI);
            this.groupBox1.Controls.Add(this.pbStateSAE);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 266);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sistemas Aspel";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblCantidadBanco
            // 
            this.lblCantidadBanco.AutoSize = true;
            this.lblCantidadBanco.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadBanco.Location = new System.Drawing.Point(230, 221);
            this.lblCantidadBanco.Name = "lblCantidadBanco";
            this.lblCantidadBanco.Size = new System.Drawing.Size(14, 15);
            this.lblCantidadBanco.TabIndex = 11;
            this.lblCantidadBanco.Text = "0";
            // 
            // lblCantidadCoi
            // 
            this.lblCantidadCoi.AutoSize = true;
            this.lblCantidadCoi.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadCoi.Location = new System.Drawing.Point(230, 149);
            this.lblCantidadCoi.Name = "lblCantidadCoi";
            this.lblCantidadCoi.Size = new System.Drawing.Size(14, 15);
            this.lblCantidadCoi.TabIndex = 10;
            this.lblCantidadCoi.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(134, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sistemas";
            // 
            // lblCantidadSAE
            // 
            this.lblCantidadSAE.AutoSize = true;
            this.lblCantidadSAE.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadSAE.Location = new System.Drawing.Point(230, 78);
            this.lblCantidadSAE.Name = "lblCantidadSAE";
            this.lblCantidadSAE.Size = new System.Drawing.Size(14, 15);
            this.lblCantidadSAE.TabIndex = 7;
            this.lblCantidadSAE.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Cantidad";
            // 
            // pbStateBanco
            // 
            this.pbStateBanco.Image = global::SAEView.Properties.Resources.icon_inactvo;
            this.pbStateBanco.Location = new System.Drawing.Point(137, 207);
            this.pbStateBanco.Name = "pbStateBanco";
            this.pbStateBanco.Size = new System.Drawing.Size(51, 43);
            this.pbStateBanco.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStateBanco.TabIndex = 5;
            this.pbStateBanco.TabStop = false;
            // 
            // pbStateCOI
            // 
            this.pbStateCOI.Image = global::SAEView.Properties.Resources.icon_inactvo;
            this.pbStateCOI.Location = new System.Drawing.Point(137, 135);
            this.pbStateCOI.Name = "pbStateCOI";
            this.pbStateCOI.Size = new System.Drawing.Size(51, 43);
            this.pbStateCOI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStateCOI.TabIndex = 4;
            this.pbStateCOI.TabStop = false;
            // 
            // pbStateSAE
            // 
            this.pbStateSAE.Image = global::SAEView.Properties.Resources.icon_inactvo;
            this.pbStateSAE.Location = new System.Drawing.Point(137, 62);
            this.pbStateSAE.Name = "pbStateSAE";
            this.pbStateSAE.Size = new System.Drawing.Size(51, 43);
            this.pbStateSAE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbStateSAE.TabIndex = 3;
            this.pbStateSAE.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::SAEView.Properties.Resources.BANCO;
            this.pictureBox3.Location = new System.Drawing.Point(15, 196);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(80, 62);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SAEView.Properties.Resources.COI;
            this.pictureBox2.Location = new System.Drawing.Point(15, 124);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 62);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SAEView.Properties.Resources.aspel_SAE;
            this.pictureBox1.Location = new System.Drawing.Point(15, 52);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ClientSize = new System.Drawing.Size(306, 279);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "AspelView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateBanco)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateCOI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStateSAE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirInterfazToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCantidadBanco;
        private System.Windows.Forms.Label lblCantidadCoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCantidadSAE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbStateBanco;
        private System.Windows.Forms.PictureBox pbStateCOI;
        private System.Windows.Forms.PictureBox pbStateSAE;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

