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
        public string cadena_conexion = "database = ars; data source = localhost; user id = carinS; password=123456";


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

                string myInsertQuery = "INSERT INTO docentes (nombre_docente, dui, fecha_de_nacimiento,direccion,telefono,correo,profecion,area,usuario,contraseña) Values(?nombre_docente,?dui,?fecha_de_nacimiento,?direccion,?telefono,?correo,?profecion,?area,?usuario,?contraseña)";

                MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
                myCommand.Parameters.Add("?nombre_docente", MySqlDbType.VarChar,50).Value = txtn.Text;
                myCommand.Parameters.Add("?dui", MySqlDbType.Int32,20 ).Value = txtd.Text;
                myCommand.Parameters.Add("?fecha_de_nacimiento", MySqlDbType.Date,20).Value = dateTime.Value;
                myCommand.Parameters.Add("?direccion", MySqlDbType.VarChar, 50).Value = txtdirec.Text;
                myCommand.Parameters.Add("?telefono", MySqlDbType.Int32, 11).Value = txtt.Text;
                myCommand.Parameters.Add("?correo", MySqlDbType.VarChar, 50).Value = txtcorreo.Text;
                myCommand.Parameters.Add("?profecion", MySqlDbType.VarChar, 50).Value = combopro.Text;
                myCommand.Parameters.Add("?area", MySqlDbType.VarChar, 50).Value = comboarea.Text;
                myCommand.Parameters.Add("?usuario", MySqlDbType.VarChar, 50).Value = texU.Text;
                myCommand.Parameters.Add("?contraseña", MySqlDbType.VarChar, 50).Value = texC.Text;


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
