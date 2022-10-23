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
    public partial class Registrodocentes : Form
    {
        public string cadena_conexion = "database = ars; data source = localhost; user id = fernando; password=123";


        public Registrodocentes()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Registrodocentes_Load(object sender, EventArgs e)
        {

        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            restaurar.Visible = false;
            maximizar.Visible = true;
        }

        private void restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1300, 650);
            restaurar.Visible = true;
            maximizar.Visible = false;
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection myConnection = new MySqlConnection(cadena_conexion);

                string myInsertQuery = "INSERT INTO docentes (NombreDocente, DUI, FechaNacimiento, DireccionDocente, Telefono, Correo, Profesion, Area, Usuario, Contraseña) Values(?NombreDocente,?DUI,?FechaNacimiento,?DireccionDocente,?Telefono,?Correo,?Profesion,?Area,?Usuario,?Contraseña)";

                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Parameters.Add("?NombreDocente", MySqlDbType.VarChar,75).Value = txtn.Text;
                myCommand.Parameters.Add("?DUI", MySqlDbType.Int32,9 ).Value = txtd.Text;
                myCommand.Parameters.Add("?FechaNacimiento", MySqlDbType.Date,20).Value = dateTime.Value;
                myCommand.Parameters.Add("?DireccionDocente", MySqlDbType.VarChar, 50).Value = txtdirec.Text;
                myCommand.Parameters.Add("?Telefono", MySqlDbType.Int32, 10).Value = txtt.Text;
                myCommand.Parameters.Add("?Correo", MySqlDbType.VarChar, 50).Value = txtcorreo.Text;
                myCommand.Parameters.Add("?Profesion", MySqlDbType.VarChar, 50).Value = combopro.Text;
                myCommand.Parameters.Add("?Area", MySqlDbType.VarChar, 50).Value = comboarea.Text;
                myCommand.Parameters.Add("?Usuario", MySqlDbType.VarChar, 50).Value = texU.Text;
                myCommand.Parameters.Add("?Contraseña", MySqlDbType.VarChar, 25).Value = texC.Text;


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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
