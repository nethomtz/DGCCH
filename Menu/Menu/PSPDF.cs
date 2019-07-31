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
using System.Data.Sql;
using System.IO;
using System.ComponentModel;


namespace Menu
{
    public partial class PSPDF : Form
    {
        public byte[] Transformador { get; private set; }

        public PSPDF()
        {
            InitializeComponent();
            fill_listbox();


        }
        void fill_listbox()
        {

            string connlist = (@"Data Source=(localdb)\Servidor;Initial Catalog=registroprueba;Integrated Security=True");
            SqlConnection conn = new SqlConnection(connlist);
            string Query = "select *from dbo.Licenciaturas;";
            SqlCommand cmdDatabase = new SqlCommand(Query, conn);
            SqlDataReader dataReader;
            try
            {
                conn.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                   // string nombre = dataReader.GetString("name");
                  //  listBox1.Items.Add(nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PSPDF_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)//BOTON PARA CARGAR 
        {
            OpenFileDialog Explorador = new OpenFileDialog();

            string Direccion = "All files |*.*"; 

            if (Explorador.ShowDialog() == System.Windows.Forms.DialogResult.OK)


            {
                axAcroPDF1.LoadFile(Explorador.FileName);

                Transformador = File.ReadAllBytes(Explorador.FileName);

            }
        }

        private void Button2_Click(object sender, EventArgs e) //BOTON PARA GUARDAR ARCHIVO 
        {

        }

        public void CreateCommand(string queryString, string connectionString)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\Servidor; Initial Catalog = registroprueba; Integrated Security = True");
                SqlCommand sql = new SqlCommand(queryString, conn);
                //Dato.Conexion conexion = new Conexion();
                conn.Open();
                //sql.Connection = con.conexion;
                sql.CommandText = "ingresoscanner";
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@idLicenciatura", textBox1.Text);
                sql.Parameters.AddWithValue("@PDF", Transformador);
                SqlDataReader go = sql.ExecuteReader(CommandBehavior.CloseConnection);
                go.Close();
                //conn.Close();-

                MessageBox.Show("Documento Guardado Satisfactoriamente");

            }
            catch (SqlException)
            {
                MessageBox.Show("No se Guardo Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.Filter = "Todos los archivios (*.*)|*.*";//define que tipo de archivo se puede ingresar
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textFile.Text = openFileDialog1.FileName;
                axAcroPDF1.LoadFile(openFileDialog1.FileName);
            }
        }
       
        private void AxAcroPDF1_Enter(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)//guardar archivo
        {
            if(textName.Text.Trim().Equals("")| textFile.Text.Trim().Equals(""))
            {
                MessageBox.Show("El nombre es Obligatorio");
                return;
            }

            byte[] file = null;
            Stream myStream = openFileDialog1.OpenFile();
            using (MemoryStream ms = new MemoryStream())
            {
                myStream.CopyTo(ms);
                file = ms.ToArray();
            }
            using (Model.registropruebaEntities2 db = new Model.registropruebaEntities2())
            {
                Model.documents oDocument = new Model.documents();
                oDocument.name = textName.Text.Trim();
                oDocument.doc = file;
                oDocument.realName = openFileDialog1.SafeFileName;
               // oLicenciaturas.idtrabajador = label---;/// aqui ira loq ue esta en el label

                db.documents.Add(oDocument);
                db.SaveChanges();

            }
            Refresh();
            }
        private void Refresh()
        {
            using (Model.registropruebaEntities2 db = new Model.registropruebaEntities2())
            {
                var lst = from d in db.Licenciaturas
                          select new { d.nomLicenciatura };
                dataGridView1.DataSource = lst.ToList();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\Servidor; Initial Catalog = registroprueba; Integrated Security = True");
           
            string actualizar = "update pruebaInsert = " + txtNombre.Text
                + " where  id_insert = " + txtId.Text;
            if ( )
        }
    }
}

