//imports System.Data.SqlClient

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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\Servidor;Initial Catalog=registroprueba;Integrated Security=True");
        public void logear (string idusuario, string RFC)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand ("SELECT Nombre, Categoria From datosUsuario WEHERE idtrabajador = @idusuario AND RFC = @RFC", con);
                cmd.Parameters.AddWithValue("idusuario", idusuario);
                cmd.Parameters.AddWithValue("RFC", RFC);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1){
                    dt.Rows[0][0].ToString();
                    this.Hide();
                    new datosPersonales(dt.Rows[0][0].ToString()).Show();
                    
                }else {
                    MessageBox.Show("ID Trabajador y/o RFC INCORRECTA");
                }
            }catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
           
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            logear(this.Textidusuario.Text,this.TextRFC.Text);
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    
    }
}
