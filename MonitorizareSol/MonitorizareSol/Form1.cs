using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorizareSol
{
    public partial class Pagina_Principala : Form
    {
        public Pagina_Principala()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectie = comboBox1.SelectedItem.ToString();
            MessageBox.Show("Ai selectat: " + selectie);        
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ExportPDF_Click(object sender, EventArgs e)
        {

        }

        private void B_Verificare_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void B_Refesh_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void B_Salvare_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                MessageBox.Show("Datele au fost salvate cu succes!");
            }
            else
            {
                MessageBox.Show("Datele nu au fost salvate!");
            }
        }
    }
}
