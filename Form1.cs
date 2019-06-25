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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\Registro;Initial Catalog=Entrar;Integrated Security=True");

      
    public void logear(string rfc, string nTrabajador)
        {
            try{
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT name, categoria, plantel, cel, mail, adress FROM prueba WHERE nTraba = @nTrabajador AND rfc =@rfc", con);
                cmd.Parameters.AddWithValue("nTrabajador", nTrabajador);
                cmd.Parameters.AddWithValue("rfc", rfc);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1){
                    this.Hide();
                    new Form2(dt.Rows[0][0].ToString(),dt.Rows[0][1].ToString(),dt.Rows[0][2].ToString(),dt.Rows[0][3].ToString(),dt.Rows[0][4].ToString(),dt.Rows[0][5].ToString()).Show();

                }
                else{
                    MessageBox.Show("RFC y/o nTrabajador incorrectos");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public void actualizar(string telefono, string correo, string direccion)
        {
            try
            {
                con.Open();
                SqlCommand com = new SqlCommand("INSERT cel, mail, adress FROM prueba WHERE cel =@telefono AND mail =@correo AND adress =@direccion", con);
                com.Parameters.AddWithValue("telefono", telefono);
                com.Parameters.AddWithValue("correo", correo);
                com.Parameters.AddWithValue("direccion", direccion);
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                sda.Fill(dt);

            } catch(Exception e)
            {
                con.Close();
            }
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logear(this.rfc.Text, this.nTrabajador.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
       




    }

}

