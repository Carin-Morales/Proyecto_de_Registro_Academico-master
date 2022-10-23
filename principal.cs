using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;

namespace Proyecto_de_Registro_Academico
{
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void btn1_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 250)
            {
                panel1.Width = 70;
            }

            else
                panel1.Width = 250;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            restaurar.Visible = true;
            maximizar.Visible = false;
        }

        private void restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1300, 650);
            restaurar.Visible = false;
            maximizar.Visible = true;
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btdocente_Click(object sender, EventArgs e)
        {
            Registrodocentes rd = new Registrodocentes();
            this.Hide();
            rd.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListadoDocentes DR = new ListadoDocentes();
            this.Hide();
            DR.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            acerca_de ad = new acerca_de();
            this.Hide();
            ad.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Proyecto_verde pv = new Proyecto_verde();
            this.Hide();
            pv.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Contactos c = new Contactos();
            this.Hide();
            c.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RegistrarEstudiantes rge = new RegistrarEstudiantes();
            this.Hide();
            rge.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ListadoEstudiantes le = new ListadoEstudiantes();
            this.Hide();
            le.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Iniciar_Sesion ins = new Iniciar_Sesion();
            this.Hide();
            ins.Show();
        }
    }
}
