using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        
        

        public Form2(string name, string categoria, string plantel, string cel, string mail, string adress, string nTraba)
        {
            InitializeComponent();
            label7.Text = name;
            label8.Text = categoria;
            label9.Text = plantel;
            telefono.Text = cel;
            correo.Text = mail;
            direccion.Text = adress;
            Trabajador.Text = nTraba;
            
        }




        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string con = "DataSource=(localdb)\Registro;Initial Catalog=Entrar;Integrated Security=True";
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\Registro;Initial Catalog=Entrar;Integrated Security=True");

            string Query = "UPDATE prueba set cel=' " + this.telefono.Text + "',mail='" + this.correo.Text +
             "',adress='" + this.direccion.Text + "' where nTraba ='" + this.Trabajador.Text + "';";

            //SqlConnection conn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand(Query, conn);
            SqlDataReader rdr;
            conn.Open();
            rdr = cmd.ExecuteReader();
            conn.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }

}
