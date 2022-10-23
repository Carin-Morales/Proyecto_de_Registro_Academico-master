using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace Proyecto_de_Registro_Academico
{
    public partial class Inicio_Sesion_Docente : Form
    {
        public string cadena_conexion = "Database=ars;Data Source=localhost;User Id = fernando; Password=123" + "";

        public Inicio_Sesion_Docente()
        {
            InitializeComponent();
        }

        private void btnIngresarDocente_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection(cadena_conexion);
                string myInsertQuery = ("select * from docentes Where Usuario = '" + txtUsuarioD.Text + "' and Contraseña = '" + txtContraseñaD.Text + "' ");
                MySqlCommand myCommand = new MySqlCommand(myInsertQuery, myConnection);
                myCommand.Connection = myConnection;
                myConnection.Open();
                MySqlDataReader myReader;
                myReader = myCommand.ExecuteReader();
                if (myReader.Read() == true)
                {
                    MessageBox.Show("Bienvenido a ARS", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormUsuarios fu = new FormUsuarios();
                    this.Hide();
                    fu.Show();
                }
                else
                {
                    MessageBox.Show("El usuario no existe", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                myReader.Close();
                myConnection.Close();
            }
            catch (MySqlException)
            {
                MessageBox.Show("Campo de busqueda está vacío", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRegresar_ISE_Click(object sender, EventArgs e)
        {
            Iniciar_Sesion inis = new Iniciar_Sesion();
            this.Hide();
            inis.Show();
        }
    }
}
