using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace Menu
{
    public partial class PDFS : Form
    {
        public PDFS()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Abrimos el primer documento existente
            PdfReader reader = new PdfReader("portada.pdf");
            // Creamos el nuevo PDF
            MemoryStream m = new MemoryStream();
            Document pdf = new Document(PageSize.LETTER);
            PdfWriter writer = PdfWriter.GetInstance(pdf, m);// Instrucción para que el PDF imprima correctamente según el tamaño de papel seleccionado.
            writer.AddViewerPreference(PdfName.PICKTRAYBYPDFSIZE, PdfBoolean.PDFTRUE);// Añadimos los atributos del nuevo PDF
            pdf.AddAuthor("Autor");
            pdf.AddTitle("Titulo del nuevo PDF");
            pdf.AddCreator("Creador del documento");
            pdf.AddCreationDate();

            // Abrimos el documento
            pdf.Open();
            // writer.PageEvent = new PdfFooter();

            PdfContentByte cb = writer.DirectContent;

            // Aquí declaramos el tipo de letra, tamaño y color que deseamos utilizar
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.BLACK);
            cb.SetFontAndSize(bf, 12);

            // Creamos una nueva página e importamos el contenido del paso #1: portada.pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            cb.AddTemplate(page, 0, 0);
            // Cerramos el nuevo archivo PDF
            //pdf.Close();
            writer.Close();// En el caso que querramos guardarlo en una carpeta
            byte[] bytArr = m.ToArray();
            using (FileStream fs = File.Create("carpetaYNombreDelNuevoPDF.pdf"))
                ;
            
        }

       /* private void Button2_Click(object sender, EventArgs e)
        {
            if (/*digital.Rows.Count > 0)
            {
                int id = int.Parse(/**digital .Rows[*digital .currentRow.Index].Cell[0].Value.ToString());
                using (Model.datosUsuario db = new Model.datosUsuario())
                {
                    var oDocument = db.documen.Find(id);
                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    string folder = path + "/temp/";
                    string fullFilePath = folder + oDocument.realName;

                    if (!Directory.Exists(folder))
                        Directory.CreateDirectory(folder);

                    if (File.Exists(fullFilePath))
                        Directory.Delete(fullFilePath);

                    File.WriteAllBytes(fullFilePath, oDocument.doc);

                    Process.Start(fullFilePath);

                }

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Close();
                SqlDataAdapter adapter = new SqlDataAdapter("Select Archivo from Scanner where Nombre = '" + Nombre + "'", conexion);
                DataSet set = new DataSet();
                conecta();
                adapter.Fill(set, "Scanner");
                byte[] datos = new byte[0];
                DataRow row = set.Tables["Scanner"].Rows[0];
                datos = (byte[])row["Archivo"];
                datos = (byte[])row["Archivo"];
                datos = (byte[])row["Archivo"];
                datos = (byte[])row["Archivo"];
                System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);

                PDF.src = openFileDialog.FileName;

            }
            catch (SqlException)
            {
                MessageBox.Show("Error Al Cargar La Imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        public void verdocumentos(string Nombre, AxAcroPDF PDF, OpenFileDialog openFileDialog)
        {
            try
            {
                string query = "Select Archivo from Scanner where Nombre = @nombre";
                SqlCommand cmd = new SqlCommand(query, conexion)
        
        cmd.Parameters.AddWithValue("@nombre", Nombre);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                DataRow row = dt.Rows[0];
                byte[] datos = (byte[])row["Archivo"];

                File.WriteAllBytes("ruta", datos);
                File.WriteAllBytes(fileDialog.FileName, datos);
                PDF.src = "ruta";


            }
            catch (SqlException)
            {
                MessageBox.Show("Error Al Cargar La Imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void Button4_Click(object sender, EventArgs e)
        {
            var document = new Document();
            var ms = new MemoryStream();

            string[] Lista = { "PRUEBA5.pdf", "PRUEBA7.pdf" };

            var pdfCopy = new PdfCopy(document, ms);

            document.Open();

            foreach (var item in Lista)
            {
                var pdfReader = new PdfReader(item);
                var n = pdfReader.NumberOfPages;
                for (var page = 0; page < n;)
                {
                    pdfCopy.AddPage(pdfCopy.GetImportedPage(pdfReader, ++page));
                }
                pdfCopy.FreeReader(pdfReader);
            }
            pdfCopy.Flush();

            document.Close();
            ms.WriteTo(new FileStream("documentoJutar.pdf", FileMode.OpenOrCreate));

        }
    }
}
