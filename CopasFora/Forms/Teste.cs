using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CopasFora.Classes;

namespace CopasFora.Forms
{
    public partial class Teste : Form
    {
        public Teste()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Carta carta = new Carta(1,2);
            MessageBox.Show(carta.ToString());
        }

        private void btnMostraJogador_Click(object sender, EventArgs e)
        {
            Jogador jogador = new Jogador(txtJogador.Text);
            MessageBox.Show(jogador.ToString());
        }
    }
}