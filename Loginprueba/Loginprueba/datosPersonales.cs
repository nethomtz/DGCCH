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
        public actualizar(string Telefono, string Correo, string Direccion)

        public datosPersonales(string Nombre, string Categoria , string Plantel, string Correo, string Direccion, string Celular)
        {
            InitializeComponent();
            label7.Text = Nombre;
            label8.Text = Categoria;
            label9.Text = Plantel;
            textBox2.Text = Celular;
            textBox3.Text = Correo;
            textBox4.Text = Direccion;

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

        }
    }
}
