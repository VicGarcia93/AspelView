﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace SAEView
{
    public partial class Configuration : Form
    {
        
        public Configuration()
        {
            InitializeComponent();
            

        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            if (SAEView.Properties.Settings.Default.server.Equals(""))
            {
                txtPuerto.Text = "Ej. 8000";
                txtServidor.Text = "Ej. 192.168.1.201";
                txtServidor.ForeColor = Color.Gray;
                txtPuerto.ForeColor = Color.Gray;
            }
            else
            {
                txtServidor.Text = SAEView.Properties.Settings.Default.server;
                txtPuerto.Text = SAEView.Properties.Settings.Default.port;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
             
            if(txtServidor.Text.Trim().Equals("Ej. 192.168.1.201") || txtPuerto.Text.Trim().Equals("Ej. 8000"))
                MessageBox.Show("Complete los 2 campos");
            else
            {
                if (ProbandoIP(txtServidor.Text) && ProbandoPuerto(txtPuerto.Text))
                {
                    SAEView.Properties.Settings.Default.port = txtPuerto.Text;
                    SAEView.Properties.Settings.Default.server = txtServidor.Text;
                    SAEView.Properties.Settings.Default.Save();
                    this.Close();
                }
               
            }
        }

        private void txtServidor_Enter(object sender, EventArgs e)
        {
            if (txtServidor.Text.Equals("Ej. 192.168.1.201"))
                txtServidor.Text = "";
            
        }

        private void txtPuerto_Enter(object sender, EventArgs e)
        {
            if (txtPuerto.Text.Equals("Ej. 8000"))
                txtPuerto.Text = "";
        }

        private bool ProbandoIP(string ipAddress)
        {
            Ping Pings = new Ping();
            int timeout = 10;
            byte[] bufferPing = new byte[102];
            string dataPing = "xd";
            bufferPing = Encoding.Default.GetBytes(dataPing);

            try
            {
                if (Pings.Send(ipAddress,timeout,bufferPing).Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }catch(Exception e){
                MessageBox.Show(e.ToString());
                return false;
            }
           
        }
        private bool ProbandoPuerto(string puerto)
        {
            try
            {
                int.Parse(puerto);
                return true;
            }
            catch(Exception e) {
                return false;
            }
        }

        private void txtServidor_Leave(object sender, EventArgs e)
        {
            if (txtServidor.Text.Trim().Equals(""))
                txtServidor.Text = "Ej. 192.168.1.201";
        }

        private void txtPuerto_Leave(object sender, EventArgs e)
        {
            if (txtPuerto.Text.Trim().Equals(""))
                txtPuerto.Text = "Ej. 8000";
        }

        
    }
}
