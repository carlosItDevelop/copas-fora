using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CopasFora.Forms;
using CopasFora.Classes;


namespace CopasFora.Forms
{
    public partial class frmVinteUm : Form
    {
        string appImgPath = "D:\\poeta\\Dados_320Gb\\Desenv\\JogoCartas\\";
        int posicao = 22;
        Baralho baralho = new Baralho();
        int jogador = 0;
        int pontosJogador = 0;
        int comput = 0;
        int pontoComput = 0;
        Carta[] cartaJogador = new Carta[20];
        Carta[] cartaComput = new Carta[20];
        public frmVinteUm()
        {
            InitializeComponent();             
            baralho.Embaralhar();
        }

        int num_cartas = 0;
        private void btnContinuar_Click(object sender, EventArgs e)
        {
                int aux = jogador++;
                cartaJogador[aux] = baralho.DarCarta();
                pontosJogador = this.MostraCartas(cartaJogador, jogador);
                lvCartas.Items.Add(cartaJogador[aux].ToString());
                lblTotalPontos.Text = pontosJogador.ToString();
                ++num_cartas;
                //if (num_cartas < 4)
                //{
                    posicao += 30;
                    LoadNewPict(cartaJogador[aux].ToString());
                //}
                if (pontosJogador > 21)
                {
                    MessageBox.Show("Você Perdeu, Mané!");
                    btnContinuar.Enabled = false;
                    btnPassar.Enabled = false;
                    btnNewGame.Enabled = true;
                }
        }

        PictureBox pic;
        private void LoadNewPict(string img)
        {
            // You should replace the bold image 
            // in the sample below with an icon of your own choosing.
            // Note the escape character used (@) when specifying the path.
            pic = new PictureBox();
            pic.Name = "pic-"+num_cartas;
            pic.Height = 138;
            pic.Width = 100;
            pic.Top = 46;
            pic.Left = posicao;
            string file = appImgPath + "ImgCartas" + @"\" + img + ".jpg";
            if ( System.IO.File.Exists(file) ) {
                pic.Image = Image.FromFile(file);
            }
            this.pnlCartas.Controls.Add(pic);
            pic.BringToFront();
            lblPicName.Text = pic.Name;
        }



        void GameOver() {
            comput = 0;
            jogador = 0;
            pontosJogador = 0;
            pontoComput = 0;
            lvCartas.Items.Clear();
            lvCartasComput.Items.Clear();
            lblMao.Text = "";
            lblTotalPontos.Text = "";
            lblPontosComput.Text = "";
            btnContinuar.Enabled = true;
            btnPassar.Enabled = true;
            btnNewGame.Enabled = false;
            for (int i = 0; i<pnlCartas.Controls.Count; i++) {
                pnlCartas.Controls.Remove(pnlCartas.Controls[i]);
                if ( !pnlCartas.Controls[i].IsDisposed ) pnlCartas.Controls[i].Dispose();
            }
            num_cartas = 0;
            posicao = 22;
        }

        private int MostraCartas(Carta[] mao, int quant)
        {
            int pontos = 0;
            for (int i = 0; i < quant; i++) {
                lblMao.Text = "" + mao[i].ToString();
                if (mao[i].Valor > 10)
                {
                    pontos++;
                } else {
                    pontos += mao[i].Valor;
                }
            }
            return pontos;
        }

        private void btnPassar_Click(object sender, EventArgs e)
        {
            if (pontosJogador > 0)
            {
                while (pontoComput < pontosJogador && pontoComput <= 21)
                {
                    int aux = comput++;
                    cartaComput[aux] = baralho.DarCarta();
                    pontoComput = MostraCartas(cartaComput, comput);
                    lvCartasComput.Items.Add(cartaComput[aux].ToString());
                    lblPontosComput.Text = pontoComput.ToString();
                }
                if (pontoComput >= pontosJogador && pontoComput <= 21)
                {
                    MessageBox.Show("Você Perdeu!");
                } else {
                    MessageBox.Show("Você Ganhou!");
                }
                btnPassar.Enabled = false;
                btnContinuar.Enabled = false;
                btnNewGame.Enabled = true;
            } else {
                MessageBox.Show("Jogador não tem pontuação!");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            GameOver();
        }

        /*

        public Button newPanelButton = new Button();

        public void addNewControl()
        { 
           // The Add method will accept as a parameter any object that derives
           // from the Control class. In this case, it is a Button control.
           panel1.Controls.Add(newPanelButton);
           // The event handler indicated for the Click event in the code 
           // below is used as an example. Substite the appropriate event
           // handler for your application.
           this.newPanelButton.Click += new System.EventHandler(this. NewPanelButton_Click);
        }
         
        private void removeControl(object sender, System.EventArgs e)
        {
            // NOTE: The code below uses the instance of 
            // the button (newPanelButton) from the previous example.
            if (panel1.Controls.Contains(newPanelButton))
            {
                this.newPanelButton.Click -= new System.EventHandler(this.
                   NewPanelButton_Click);
                panel1.Controls.Remove(newPanelButton);
                newPanelButton.Dispose();
            }
        }*/



    }} // Fim do namespace;