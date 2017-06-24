using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CopasFora.Classes;
using CopasFora.Forms;

namespace CopasFora.Forms
{
    public partial class frmMDIForm : Form
    {
        public frmMDIForm()
        {
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCopas copas = new frmCopas();
            copas.MdiParent = this;
            copas.Show();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teste teste = new Teste();
            teste.MdiParent = this;
            teste.Show();
        }

        private void frmMDIForm_Load(object sender, EventArgs e)
        {
            //string path = AppDomain.CurrentDomain.BaseDirectory.ToString();
            //DialogResult resultado = MessageBox.Show(path, "Caminho do Executável", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}