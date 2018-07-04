using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SAEView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ShowNotify()
        {
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipText = "Ejecutandose en segundo plano";
            notifyIcon1.ShowBalloonTip(1000);
            this.Hide();
        }

        public void CheckAspelsSystem()
        {
            Process[] procesosSAE = Process.GetProcessesByName("saewin70");
            if (procesosSAE.Length > 0)
            {
                pbStateSAE.Image = SAEView.Properties.Resources.icon_ok;
                lblCantidadSAE.Text = ""+ procesosSAE.Length;
            }
            else
            {
                pbStateSAE.Image = SAEView.Properties.Resources.icon_inactvo;
                lblCantidadSAE.Text = "0";
            }
            Process[] procesosCOI = Process.GetProcessesByName("coiwin");
            if (procesosCOI.Length > 0)
            {
                pbStateCOI.Image = SAEView.Properties.Resources.icon_ok;
                lblCantidadCoi.Text = "" + procesosCOI.Length;
            }
            else
            {
                pbStateCOI.Image = SAEView.Properties.Resources.icon_inactvo;
                lblCantidadCoi.Text = "0";
            }
            Process[] procesosBan = Process.GetProcessesByName("banwin");
            if (procesosBan.Length > 0)
            {
                pbStateBanco.Image = SAEView.Properties.Resources.icon_ok;
                lblCantidadBanco.Text = "" + procesosBan.Length;
            }
            else
            {
                pbStateBanco.Image = SAEView.Properties.Resources.icon_inactvo;
                lblCantidadBanco.Text = "0";
            }
                

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                ShowNotify();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            MostrarInterfaz();
        }

        private void abrirInterfazToolStripMenuItem_Click(object sender, EventArgs e)
        {


            MostrarInterfaz();
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignIn signIn = new SignIn(this);
            signIn.ShowDialog();
           // this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.Visible)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                ShowNotify();
            }
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            CheckAspelsSystem();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CheckAspelsSystem();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            CheckAspelsSystem();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CheckAspelsSystem();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void MostrarInterfaz()
        {
            
            CheckAspelsSystem();
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Configuration conf = new Configuration();
            conf.ShowDialog();
        }
    }
}
