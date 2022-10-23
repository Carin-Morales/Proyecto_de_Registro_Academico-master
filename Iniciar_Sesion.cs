using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_de_Registro_Academico
{
    public partial class Iniciar_Sesion : Form
    {
        public Iniciar_Sesion()
        {
            InitializeComponent();
        }

        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            Inicio_Sesion_Estudiantes ise = new Inicio_Sesion_Estudiantes();
            this.Hide();
            ise.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            principal pri = new principal();
            this.Hide();
            pri.Show();
        }

        private void btnDocente_Click(object sender, EventArgs e)
        {
            Inicio_Sesion_Docente isd = new Inicio_Sesion_Docente();
            this.Hide();
            isd.Show();
        }
    }
    
}
