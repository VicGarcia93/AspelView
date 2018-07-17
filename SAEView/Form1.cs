using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace SAEView
{
    public partial class Form1 : Form
    {
        Socket socket;
        Socket socketConexion;
        EndPoint puntoLocal;
        EndPoint puntoDestino;
        bool corriendo;
        byte[] buffer;
        string datosRecibidos;
        int contadorLeido;
        Process[] procesosSAE;
        Process[] procesosCOI;
        Process[] procesosBan;
        public Form1()
        {
            InitializeComponent();
            
            buffer = new byte[100];
            datosRecibidos = "";
            contadorLeido = 0;
            int puertoLocal = 8000;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            puntoLocal = new IPEndPoint(IPAddress.Any, puertoLocal);
            puntoDestino = new IPEndPoint(IPAddress.Parse(SAEView.Properties.Settings.Default.server), int.Parse(SAEView.Properties.Settings.Default.port));
            socket.Bind(puntoLocal);
            corriendo = true;
            new Thread(ListenerData).Start();
            
        }

        public void ShowNotify()
        {
           // notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipText = "Ejecutandose en segundo plano";
            notifyIcon1.ShowBalloonTip(1000);
            this.Hide();
        }

        public void CheckAspelsSystem()
        {
            procesosSAE = Process.GetProcessesByName("saewin70");
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
            procesosCOI = Process.GetProcessesByName("coiwin");
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
            procesosBan = Process.GetProcessesByName("banwin");
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
            if (signIn.GetIsOK())
            {
                corriendo = false;
                socket.Dispose();
            }
                
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
            this.ShowInTaskbar = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Configuration conf = new Configuration();
            conf.ShowDialog();
        }

        private void ListenerData()
        {
            try
            {
                socket.Listen(10);
                socketConexion = socket.Accept();
                
                while (corriendo)
                {
                    if (socketConexion.Available == 0)
                    {
                        Thread.Sleep(200);
                        continue;
                    }
                    
                    contadorLeido = socketConexion.Receive(buffer, 0, buffer.Length, 0);
                    datosRecibidos = Encoding.Default.GetString(buffer, 0, contadorLeido);

                    if (datosRecibidos.Equals("1"))
                    {
                        CheckAspelsSystem();
                        EnviarDatos();
                        Console.WriteLine("Recibido");
                        Console.WriteLine(datosRecibidos);
                        
                        datosRecibidos = "x";
                        socket.Listen(10);
                        socketConexion = socket.Accept();
                    }
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Cancelado");
            }
            
        }

        private void EnviarDatos()
        {
            Console.WriteLine("Enviando....");
            string datosEnviar = "";
            datosEnviar = procesosSAE.Length + "," + procesosCOI.Length + "," + procesosBan.Length;
            Console.WriteLine(socketConexion.RemoteEndPoint);
            socketConexion.SendTo(Encoding.Default.GetBytes(datosEnviar), socketConexion.RemoteEndPoint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
        }
    }
}
