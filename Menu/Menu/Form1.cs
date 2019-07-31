using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void directorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form directorio = new Form3();
            directorio.Show();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void usuarioToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Usuario: , Plantel: , Categoria: ");
        }

        private void curriculumToolStripMenuItem_Click_1(object sender, EventArgs e) 

        {
            Form datos = new Form2();
            datos.Show();

                
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void concursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form concurso = new Concurso();
            concurso.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PDFPRUEBAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form pdf = new PSPDF();
            pdf.Show();
        }
    }
}
