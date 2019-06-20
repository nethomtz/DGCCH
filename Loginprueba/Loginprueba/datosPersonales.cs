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

namespace Loginprueba
{
    public partial class datosPersonales : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\Servidor;Initial Catalog=registroprueba;Integrated Security=True");

        public void actualizar(string correo, string telefono, string direccion, string idtrabajador)
        {
            
            con.Open();
            //SqlCommand cmd = new SqlCommand("UPDATE datosUsuario set correo, telefono, direccion WHERE  Correo = @correo, Telefono = @telefono, Direccion = @direccion", con);//
            SqlCommand cmd = new SqlCommand("Update datosUsuario set @correo = correo , @telefono = telefono, @direccion = direccion WHERE @idtrabajador = idusuario", con);

            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("Correo", correo);
            cmd.Parameters.AddWithValue("Telefono", telefono);
            cmd.Parameters.AddWithValue("Direccion", direccion);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Update(dt);
            cmd.ExecuteNonQuery();
            con.Close();
            InitializeComponent();
            textBox2.Text = telefono;
            textBox3.Text = correo;
            textBox4.Text = direccion;
            
            
        }
        public datosPersonales(string Nombre, string Categoria , string Plantel, string Correo, string Direccion, string Celular , string idtrabajador)
        {
            InitializeComponent();
            label7.Text = Nombre;
            label8.Text = Categoria;
            label9.Text = Plantel;
            textBox2.Text = Celular;
            textBox3.Text = Correo;
            textBox4.Text = Direccion;
            label11.Text = idtrabajador;

        }
        public datosPersonales()
        {
            InitializeComponent();
        }

        private void DatosPersonales_Load(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            actualizar(this.textBox2.Text, this.textBox3.Text, this.textBox4.Text, this.label11.Text);
        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }
    }
}
