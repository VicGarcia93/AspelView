using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAEView
{
    class Inicio
    {
       static Form1 formPrincipal = new Form1();

        //formPrincipal.ShowDialog();
        static NotifyIcon aplicacionIcon = new NotifyIcon();
        static ContextMenuStrip menuIcon = new ContextMenuStrip();
        public Inicio()
        {

        }
        public static void Main()
        {
            
            menuIcon.Items.Add("Abrir Interfaz");
            menuIcon.Items.Add("Configuración");
            menuIcon.Items.Add("Salir");

            menuIcon.Items[0].Click += Inicio_Click_1;
            menuIcon.Items[1].Click += Inicio_Click_2;
            menuIcon.Items[2].Click += Inicio_Click_3;

            aplicacionIcon.ContextMenuStrip = menuIcon;

            formPrincipal.ShowDialog();
            
        }

        static void Inicio_Click_1(object sender, EventArgs e)
        {
            formPrincipal.Show();
        }
        static void Inicio_Click_2(object sender, EventArgs e)
        {
            Configuration config = new Configuration();
            config.Show();
        }
        static void Inicio_Click_3(object sender, EventArgs e)
        {
            SignIn seguridad = new SignIn(formPrincipal);
            seguridad.Show();
        }
        
    }
}
