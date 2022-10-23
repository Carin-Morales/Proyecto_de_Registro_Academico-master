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
    public partial class RegistrarEstudiantes : Form
    {
        public string cadena_conexion = "Database=ars;Data Source=localhost;User Id = fernando; Password=123" + "";

        public RegistrarEstudiantes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                MySqlConnection myConnection = new MySqlConnection(cadena_conexion);

                string myInsertQuery = "INSERT INTO estudiantes (CarnetEstudiante, NombreEstudiante, CorreoEstudiante, Direccion,Telefono, Usuario, Contraseña, DUI) Values(?CarnetEstudiante,?NombreEstudiante,?CorreoEstudiante,?Direccion,?Telefono,?Usuario,?Contraseña,?DUI)";

                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Parameters.Add("?CarnetEstudiante", MySqlDbType.VarChar, 25).Value = txtCarnetEstudiante.Text;
                myCommand.Parameters.Add("?NombreEstudiante", MySqlDbType.VarChar, 100).Value = txtNombreCompleto.Text;
                myCommand.Parameters.Add("?CorreoEstudiante", MySqlDbType.VarChar, 50).Value = txtCorreoEstudiante.Text;
                myCommand.Parameters.Add("?Direccion", MySqlDbType.VarChar, 100).Value = txtDireccion.Text;
                myCommand.Parameters.Add("?Telefono", MySqlDbType.Int32, 25).Value = txtTelefono.Text;
                myCommand.Parameters.Add("?Usuario", MySqlDbType.VarChar, 50).Value = txtUsuario.Text;
                myCommand.Parameters.Add("?Contraseña", MySqlDbType.VarChar, 25).Value = txtContraseña.Text;
                myCommand.Parameters.Add("?DUI", MySqlDbType.Int32, 9).Value = txtDUI.Text;


                myCommand.Connection = myConnection;
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Connection.Close();

                MessageBox.Show("Usuario agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //string consulta = "select * from contactos";
                //MySqlConnection conexion = new MySqlConnection(cadena_conexion);
                //MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion);
                //System.Data.DataSet ds = new System.Data.DataSet();
                //da.Fill(ds, "agenda");
                //dataGridView1.DataSource = ds;
                //dataGridView1.DataMember = "agenda";
            }
            catch (MySqlException)
            {

                MessageBox.Show("Ya existe el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            principal pri = new principal();
            this.Hide();
            pri.Show();
        }
    }
}
