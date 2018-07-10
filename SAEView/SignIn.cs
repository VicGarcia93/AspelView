using SAEView.ROOT.CIMV2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;


namespace SAEView
{
    public partial class SignIn : Form
    {
        private bool isOK = false;
        Form1 form;
        public SignIn(Form1 view)
        {
            InitializeComponent();
            this.form = view;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EvaluarPass();
        }
        public bool GetIsOK()
        {
            return isOK;
        }

        private void EvaluarPass()
        {
            String pass;
            pass = textBox1.Text;
            if (pass == SAEView.Properties.Settings.Default.PASS)
            {
                isOK = true;
                form.Dispose();
                this.Dispose();
            }
            else
                MessageBox.Show("Contraseña incorrecta");

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                EvaluarPass();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        
    }
}
