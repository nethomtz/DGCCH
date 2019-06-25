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
using System.Data.SqlTypes;
using System.Data.Sql;




namespace Loginprueba
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Dim conexion As String = "Data Source=(localdb)\Servidor;Initial Catalog=registroprueba;Integrated Security=True";
            Dim net As New SqlDataAdapter;
            Dim dt As DataTable;
            Dim comando As String = "select *from datosUsuario where idtrabajador = '" & Textidusuario.Text & "' and RFC = '" & TextRFC.Text & ""
            
            Try
                net = New SqlDataAdapter(comando, conexion)
            Catch ex As Exception
                MsgBox(ex.)
                   

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
