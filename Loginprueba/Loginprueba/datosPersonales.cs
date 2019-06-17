using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loginprueba
{
    public partial class datosPersonales : Form
    {
        public datosPersonales(string Nombre)
        {
            InitializeComponent();
            label7.Text = Nombre;
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
    }
}
