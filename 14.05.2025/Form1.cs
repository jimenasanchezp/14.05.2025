using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace _14._05._2025
{
    public partial class Form1: Form
    {
        string nombredearchivo;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstLista.View = View.Details;
            lstLista.LabelEdit = true;
            lstLista.GridLines = true;
            lstLista.FullRowSelect = true;
            lstLista.Columns.Add("Nombre", -2, HorizontalAlignment.Left);

            //Obtener la ruta donde se ejecuta el programa
            string ruta = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo dir = new DirectoryInfo(ruta);

            foreach (var fil in dir.GetFiles("*.txt"))
            {
                lstLista.Items.Add(fil.Name);
            }
            //foreach (var fil in dir.GetFiles("*.txt"))
            //{
            //    MessageBox.Show(fil.Name);
            //}
            //foreach (var fil in dir.GetFiles("h?.*"))
            //{
            //    MessageBox.Show(fil.Name);
            //}
            //foreach (var fil in dir.GetDirectories())
            //{
            //    MessageBox.Show(fil.Name);
            //}
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstLista_DoubleClick(object sender, EventArgs e)
        {
            //StreamReader archivo;
            //string linea; 
            //archivo = File.OpenText(lstLista.SelectedItems[0].Text);
            //linea = archivo.ReadToEnd();
            //lstVerArchivo.Items.Add(linea);

            nombredearchivo = lstLista.SelectedItems[0].Text;
            txtLectura.Clear();
            StreamReader archivo;
            archivo = File.OpenText(nombredearchivo);
            while (!archivo.EndOfStream)
                txtLectura.Text += archivo.ReadLine() + "\r\n";
            archivo.Close();
        }

        private void txtGuardar_Click(object sender, EventArgs e)
        {
            StreamWriter fichero;
            fichero = File.CreateText("Fichero1.txt");
            fichero.Close();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            txtLectura.Enabled = true;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            txtLectura.Enabled = false;
        }
    }
}
