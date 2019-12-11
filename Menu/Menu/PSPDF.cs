using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Collections.Generic;

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
       

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\Servidor; Initial Catalog = registroprueba; Integrated Security = True");
           
            string Query = "update pruebaInsert set "+txtNom.Text+" = '"+textNombre.Text+"' where id_Insert = " + txtidinsert.Text +";";
            SqlCommand cmdData = new SqlCommand(Query, conn);
            SqlDataReader sqlDataReader;
            try
            {
                conn.Open();
                sqlDataReader = cmdData.ExecuteReader();
                MessageBox.Show("Actualizados");
                while (sqlDataReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button5_Click(object sender, EventArgs e) /// genera el pdf con los atributos que le estas dando 
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("Prueba.pdf", FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph();
            title.Font = FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLUE);
            title.Add("Hola Mundo!!");
            doc.Add(title);

            //doc.Add(new Paragraph("Hola Mundo!!"));
            //doc.Add(new Paragraph("Parrafo 1"));
            //doc.Add(new Paragraph("Parrafo 2"));
            doc.Close();
        }
       
        private void Button6_Click(object sender, EventArgs e)////Modifica el archivo original
        {
            PdfReader pdfCV = new PdfReader("Guia_CV_2016.pdf");
            PdfReader reader = new PdfReader("COMPLETO.pdf");////2do pdf
                MemoryStream m = new MemoryStream();///cREAR NUEVO PDF
            Document pdf = new Document();
            PdfWriter writer = PdfWriter.GetInstance(pdf, m);// Instrucción para que el PDF imprima correctamente según el tamaño de papel seleccionado.
           /* writer.AddViewerPreference(PdfName.PICKTRAYBYPDFSIZE, PdfBoolean.PDFTRUE);// Añadimos los atributos del nuevo PDF
            pdf.AddAuthor("Autor");
            pdf.AddTitle("Titulo del nuevo PDF");
            pdf.AddCreator("Creador del documento");
            pdf.AddCreationDate();*/

            pdf.Open();
            //writer.PageEvent = new PdfFooter();   // Para pi y encabezado
            

            PdfContentByte cb = writer.DirectContent;
            /*
            // Aquí declaramos el tipo de letra, tamaño y color que deseamos utilizar
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            cb.SetColorFill(BaseColor.BLACK);
            cb.SetFontAndSize(bf, 12);*/

            // Creamos una nueva página e importamos el contenido del paso #1: portada.pdf
            PdfImportedPage page = writer.GetImportedPage(reader, 1);
            PdfImportedPage CV = writer.GetImportedPage(pdfCV,1);
            cb.AddTemplate(CV, 0, 0);

            pdf.Close();
            writer.Close();// En el caso que querramos guardarlo en una carpeta
            byte[] bytArr = m.ToArray();
            using (FileStream fs = File.Create(textBox2.Text + ".pdf"))
            {
               // fs.Write(bytArr, 0, (int)bytArr.Length);
            }// En el caso que estemos usando ASP.Net y querramos que el usuario lo pueda descargar
            /*HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + "carpetaYNombreDelNuevoPDF.pdf");
            HttpContext.Current.Response.BinaryWrite(m.GetBuffer());
            HttpContext.Current.Response.End();*/
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e, string sourcePdfPath, string outputPdfPath,
    int startPage, int endPage)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            try
            {
                // Intialize a new PdfReader instance with the contents of the source Pdf file:
                reader = new PdfReader("Guia_CV_2016.pdf");

                // For simplicity, I am assuming all the pages share the same size
                // and rotation as the first page:
                sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));

                // Initialize an instance of the PdfCopyClass with the source 
                // document and an output file stream:
                pdfCopyProvider = new PdfCopy(sourceDocument,
                    new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                sourceDocument.Open();

                // Walk the specified range and add the page copies to the output file:
                for (int i = startPage; i <= endPage; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label7.Text = DateTime.Now.ToString();
        }

        private void Label7_Click(object sender, EventArgs e)
        {
         
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            PdfReader reader = new PdfReader("COMPLETO.pdf");
            Document document = new Document(reader.GetPageSize(1));
            PdfCopy copier = new PdfCopy(document, new FileStream("2.pdf", FileMode.Create));

            for (int pageCounter = 1; pageCounter < reader.NumberOfPages + 1; pageCounter++)
            {
                // get page
                PdfImportedPage page = copier.GetImportedPage(reader, pageCounter);
                /*// add content to imported page
                //PageStamp ps = pdfCopy.CreatePageStamp(page);
                PdfContentByte cb = page.GetOverContent();
                // set color
                cb.SetColorFill(BaseColor.BLACK);
                // get font
                BaseFont baseFont = BaseFont.CreateFont(string.Format("{0}\\Fonts\\arialuni.ttf", Environment.GetEnvironmentVariable("windir"), BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(baseFont, 12);
                cb.BeginText();
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, printLangString, 100f, 40f, 0f);
                cb.EndText();
                // Accept changes                  
                page.AlterContents();*/
                // add page
                copier.AddPage(page);
            }

            using (var ms = new MemoryStream())
            {
                Document doc = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                writer.CloseStream = false;
                doc.Open();
                doc.NewPage();
                //doc.Add(new Paragraph(error, fontRed));
                doc.Close();
                writer.Close();
                ms.Seek(0, SeekOrigin.Begin);
                PdfReader rd = new PdfReader(ms);
                for (int pageCounter = 1; pageCounter < reader.NumberOfPages + 1; pageCounter++)
                {
                    copier.AddPage(copier.GetImportedPage(rd, pageCounter));
                }
                rd.Close();
            }

            document.Close();
            reader.Close();
        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }

        private void Button10_Click(object sender, EventArgs e)
        {
            
            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            /* MemoryStream m = new MemoryStream();///cREAR NUEVO PDF
             Document pdf = new Document();
             PdfWriter writer = PdfWriter.GetInstance(pdf, m);// Instrucción para que el PDF imprima correctamente según el tamaño de papel seleccionado.*/
            MemoryStream m = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(doc, m);
           // PdfWriter writer = PdfWriter.GetInstance(doc,new FileStream(@"C:\\", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Roberto Torres");

            // Abrimos el archivo
            doc.Open();
            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Mi primer documento PDF"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            // Llenamos la tabla con información
            clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
            clNombre.BorderWidth = 0;

            clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
            clApellido.BorderWidth = 0;
            /*
            clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
            clPais.BorderWidth = 0;
            cell = new PdfPCell(new Paragraph(writer.PageNumber))
            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);
            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();*/

        }
private void Button11_Click(object sender, EventArgs e)
        {
            var document = new Document();
            var ms = new MemoryStream();

            string[] Lista = { "Guia_CV_2016.pdf", "Guia_CV_2016.pdf" };

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
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream("COMPLETO2.pdf", FileMode.Create));
            //ms.WriteTo(new FileStream("documentoJutar.pdf", FileMode.OpenOrCreate));
            ms.WriteTo(new FileStream("Prueba.pdf", FileMode.OpenOrCreate));
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            var document = new Document();
            var ms = new MemoryStream();

            string[] Lista = { "Guia_CV_2016.pdf", "Guia_CV_2016.pdf" };

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
        public void ExtractPages(string sourcePdfPath,string outputPdfPath, int[] extractThesePages) //Extraiga varias páginas no contiguas de PDF existente a un nuevo archivo
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            try
            {
                // Intialize a new PdfReader instance with the 
                // contents of the source Pdf file:
                reader = new PdfReader(sourcePdfPath);

                // For simplicity, I am assuming all the pages share the same size
                // and rotation as the first page:
                sourceDocument = new Document(reader.GetPageSizeWithRotation(extractThesePages[0]));

                // Initialize an instance of the PdfCopyClass with the source 
                // document and an output file stream:
                pdfCopyProvider = new PdfCopy(sourceDocument,
                    new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                sourceDocument.Open();

                // Walk the array and add the page copies to the output file:
                foreach (int pageNumber in extractThesePages)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, pageNumber);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExtractPages(string sourcePdfPath, string outputPdfPath, int startPage, int endPage) //Extraiga un rango de páginas del PDF existente a un nuevo archivo
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage = null;

            try
            {
                // Intialize a new PdfReader instance with the contents of the source Pdf file:
                reader = new PdfReader(sourcePdfPath);

                // For simplicity, I am assuming all the pages share the same size
                // and rotation as the first page:
                sourceDocument = new Document(reader.GetPageSizeWithRotation(startPage));

                // Initialize an instance of the PdfCopyClass with the source 
                // document and an output file stream:
                pdfCopyProvider = new PdfCopy(sourceDocument,new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));

                sourceDocument.Open();

                // Walk the specified range and add the page copies to the output file:
                for (int i = startPage; i <= endPage; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }
                sourceDocument.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Button13_Click(object sender, EventArgs e)
        {
            // ‘ Creamos una lista de archivos para concatenar

            List<string> Lista = new List<string>();

            // ‘ Identificamos los documentos que queremos unir

            string sFile1 = @"C:\Users\Programador\Documents\Guia_CV_2016.pdf";

            string sFile2 = @"C:\Users\Programador\Documents\Guia_CV_2016.pdf";

            // ‘ Los añadimos a la lista

            Lista.Add(sFile1);

            Lista.Add(sFile2);

            // ‘ Nombre del documento resultante

            string sFileJoin = @"DocumentoJoin.pdf";

            Document Doc = new Document();

            try
            {
                FileStream fs = new FileStream(sFileJoin, FileMode.Create, FileAccess.Write, FileShare.None);

                PdfCopy copy = new PdfCopy(Doc, fs);

                Doc.Open();

                PdfReader Rd;

                int n; // ‘Número de páginas de cada pdf

                foreach (var file in Lista)
                {
                    Rd = new PdfReader(file);

                    n = Rd.NumberOfPages;

                    int page = 0;

                    while (page < n)
                    {
                        page += 1;

                        copy.AddPage(copy.GetImportedPage(Rd, page));
                    }

                    copy.FreeReader(Rd);

                    Rd.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uniendo los pdf");
               
            }

            finally
            {

                // ‘ Cerramos el documento

                Doc.Close();
            }
        }
    }
}
