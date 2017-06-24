#region ::: Diretivas
using System;
using System.Drawing;
using System.Windows.Forms;
using CopasFora.Classes;
using CopasFora.Indexadores;
using CopasFora.Classes.Util;

#endregion

namespace CopasFora.Forms
{
    public partial class frmCopas : Form
    {
        #region ::: Declaração das Variáveis
        // Criação dos eventos de aviso de que o jogador x jogou!
        public delegate void AlguemJogou(Object sender, EventArgs e);
        public event AlguemJogou OnAlguemJogou;
        public delegate void NewRodada(object sender, EventArgs e);
        public event NewRodada OnNewRodada;

        Jogador jogador_01;
        Jogador jogador_02;
        Jogador jogador_03;
        Jogador jogador_04;
        Estrategia estrategia = new Estrategia();

        string appImgMarcaMao; string file;

        CartasNaMao CartasDoJogador01;
        CartasNaMao CartasDoJogador02;
        CartasNaMao CartasDoJogador03;
        CartasNaMao CartasDoJogador04;

        enum objJogador { jogador01 = 1, jogador02 = 2, jogador03 = 3, jogador04 = 4 };
        Baralho baralho;  // Jogo tem Baralho;

        string fileSoundDemora = "Demora.wav";
        string fileSoundGuardaCarta = "GuardaCarta.wav";
        string fileSoundRenuncia = "Renuncia.wav";
        string fileSoundInicioJogo = "Inicio.wav"; // Mudar o arquivo!!!

        string appSoundPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\sound\";
        string appImgPath = AppDomain.CurrentDomain.BaseDirectory.ToString();

      //  D:\Desenv\JogoCartas\Copas\CopasFora

        //D:\Desenv\Ponto_Net\JogoCartas\imgCartas

        #endregion

        #region ::: Construtor da Classe
        public frmCopas()
        {
            InitializeComponent();
            // ====================================== //
            OnAlguemJogou += new AlguemJogou(frmCopas_OnAlguemJogou);
            OnNewRodada += new NewRodada(frmCopas_OnNewRodada);
            string img = "ContraCapa";
            picPc1.Image = Image.FromFile(appImgPath + @"imgCartas\" + img + ".jpg");
            picPc2.Image = Image.FromFile(appImgPath + @"imgCartas\" + img + ".jpg");
            picPc3.Image = Image.FromFile(appImgPath + @"imgCartas\" + img + ".jpg");
            ///<summary>Seta as variáveis para a picture de Marca Mao!</summary>
            appImgMarcaMao = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\img\";
            file = appImgMarcaMao + "picMarcaMao.jpg";
            picMarcaMao.Image = Image.FromFile(file);
            ///======================= *
        }
        #endregion

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            btnNewGame.Enabled = false;
            Iniciar();
        }// Fim do Método btnNewGame_Click;

        public void Iniciar()
        {
            ///<sumary>As próximas 9 linhas estão aqui, pois
            /// é necessário que estes objetos sejam renovados
            /// a cada nopa partida. Por isso não estão no construtor!
            ///</summary>
            CartasDoJogador01 = new CartasNaMao();
            CartasDoJogador02 = new CartasNaMao();
            CartasDoJogador03 = new CartasNaMao();
            CartasDoJogador04 = new CartasNaMao();
            /// ----------------------------------------------/.
            baralho = new Baralho();
            jogador_01 = new Jogador("USER01");
            jogador_02 = new Jogador("USER02");
            jogador_03 = new Jogador("USER03");
            jogador_04 = new Jogador("USER04");
            /// ----------------------------------------/.
            estrategia.ZerarContadores();
            baralho.Embaralhar();
            DistribuirCartas();
            CartasDoJogador01.Sort();
            Procurar2Paus();
            ControlTag(true);
            PreencheMao();
        } // Fim do Método Iniciar;

        /// <summary>
        /// Evento gerado ao final de cada rodada.
        /// Ou seja, a cada 4 cartas jogadas, é gerado este evento!
        /// </summary>
        /// <param name="sender">Objeto gerador</param>
        /// <param name="e">Parâmetro de evento</param>
        void frmCopas_OnNewRodada(object sender, EventArgs e)
        {
            timer.Interval = 3000;
            timer.Enabled = true;
        }

        Carta cartaNipe;
        /// <summary>
        /// Evento disparado sempre que alguém faz uma cartada.
        /// </summary>
        /// <param name="sender">Objeto (jogador) que disparou o evento</param>
        /// <param name="e">Parâmetro do evento!</param>
        void frmCopas_OnAlguemJogou(object sender, EventArgs e)
        {
            int numRod = Contador.totalCartasNaRodada;
            if (numRod == 4)
            {
                #region :: Prepara totais e cartas da rodada p/determ. Vencedor!
                int tt01 = Contador.totalJogador01;
                int tt02 = Contador.totalJogador02;
                int tt03 = Contador.totalJogador03;
                int tt04 = Contador.totalJogador04;
                Carta carta01 = Contador.cartaDoJogador01;
                Carta carta02 = Contador.cartaDoJogador02;
                Carta carta03 = Contador.cartaDoJogador03;
                Carta carta04 = Contador.cartaDoJogador04;
                Carta[] cartasDaRodada = new Carta[4] { carta01, carta02, carta03, carta04 };
                int[] totais = new int[4] { tt01, tt02, tt03, tt04 };
                Jogador[] jogadores = new Jogador[4] { jogador_01, jogador_02, jogador_03, jogador_04 };
                Contador.vencedor = estrategia.GetVencedorDaRodada(cartasDaRodada, totais, Contador.NipeMao, jogadores);
                Contador.mao = Contador.vencedor;
                if (Contador.mao.ToString() == "USER01") tmEsperaDeJogador01.Enabled = true;
                #endregion

                btnMostraMsg.Enabled = true;
                Contador.totalCartasNaRodada = 0;
                Contador.numRodada++;                
                if (Contador.numRodada == 13)
                {
                    #region :: Guarda as Cartas e Finaliza o jogo;
                    btnMostraMsg_Click(sender, e);
                    GuardaCartasVencedor(Contador.mao);
                    //Este Timer vai disparar a msg de Game Over
                    //Após o Interval especificado aí em cima. Isto uma vez, e depois se auto desliga!!!
                    btnMostraMsg.Enabled = false;
                    jogador_01.Pontos = 0;
                    jogador_02.Pontos = 0;
                    jogador_03.Pontos = 0;
                    jogador_04.Pontos = 0;
                    btnNewGame.Enabled = true;
                    #endregion
                } else {
                    #region :: Zera Totalizadores da Cartada
                    Contador.totalJogador01 = 0;
                    Contador.totalJogador02 = 0;
                    Contador.totalJogador03 = 0;
                    Contador.totalJogador04 = 0;
                    #endregion
                    OnNewRodada(this, new EventArgs());
                }
            } else {
                btnMostraMsg.Enabled = false;
                // Este, apesar de ser um objeto, é passado como Jogador!
                // O  método ToString() é comum às duas implementações!!!
                switch (sender.ToString())
                {
                    case "jogador01": // Se foi USER01 quem jogou o 2 deve jogar em seguida, e assim por diante!
                        this.possoJogar = false;
                        cartaNipe = estrategia.BuscaCartaMesmoNaipe(CartasDoJogador02, Contador.NipeMao, CartasDoJogador02.GetNumCartas());
                        Jogada(jogador_02, cartaNipe, Contador.indexAtual,111,12);  // Otimizar 2 últimos parâm.
                        break;
                    case "jogador02":
                        cartaNipe = estrategia.BuscaCartaMesmoNaipe(CartasDoJogador03, Contador.NipeMao, CartasDoJogador03.GetNumCartas());
                        Jogada(jogador_03, cartaNipe, Contador.indexAtual, 48, 220);  // Otimizar 2 últimos parâm.
                        break;
                    case "jogador03":
                        cartaNipe = estrategia.BuscaCartaMesmoNaipe(CartasDoJogador04, Contador.NipeMao, CartasDoJogador04.GetNumCartas());
                        Jogada(jogador_04, cartaNipe, Contador.indexAtual, 48, 773);  // Otimizar 2 últimos parâm.
                        break;
                    case "jogador04":
                        cartaNipe = estrategia.BuscaCartaMesmoNaipe(CartasDoJogador01, Contador.NipeMao, CartasDoJogador01.GetNumCartas());
                        // Não faz nada, pois é a vez do jogador01 interagir com o pc;
                        this.possoJogar = true;
                        tmEsperaDeJogador01.Enabled = true;
                        break;
                }}
            }// Fim do Evento frmCopas_OnAlguemJogou;

        #region :: Eventos Click das cartas do Jogador_01
        private void picUser0_Click(object sender, EventArgs e) {
            Click_Img( CartasDoJogador01.GetNumCartas(), picUser0);
        }
        private void picUser1_Click(object sender, EventArgs e) {
            Click_Img( CartasDoJogador01.GetNumCartas(), picUser1);
        }
        private void picUser2_Click(object sender, EventArgs e) {
            Click_Img( CartasDoJogador01.GetNumCartas(), picUser2);
        }
        private void picUser3_Click(object sender, EventArgs e) {
            Click_Img( CartasDoJogador01.GetNumCartas(), picUser3);
        }
        private void picUser4_Click(object sender, EventArgs e) {
            Click_Img( CartasDoJogador01.GetNumCartas(), picUser4);
        }
        private void picUser5_Click(object sender, EventArgs e) {
            Click_Img(CartasDoJogador01.GetNumCartas(), picUser5);
        }
        private void picUser6_Click(object sender, EventArgs e) {
            Click_Img(CartasDoJogador01.GetNumCartas(), picUser6);
        }
        private void picUser7_Click(object sender, EventArgs e) {
            Click_Img(CartasDoJogador01.GetNumCartas(), picUser7);
        }
        private void picUser8_Click(object sender, EventArgs e) {
            Click_Img(CartasDoJogador01.GetNumCartas(), picUser8);
        }
        private void picUser9_Click(object sender, EventArgs e) {
            Click_Img(CartasDoJogador01.GetNumCartas(), picUser9);
        }
        private void picUser10_Click(object sender, EventArgs e) {
            Click_Img(CartasDoJogador01.GetNumCartas(), picUser10);
        }
        private void picUser11_Click(object sender, EventArgs e) {
            Click_Img(CartasDoJogador01.GetNumCartas(), picUser11);
        }
        private void picUser12_Click(object sender, EventArgs e) {
            Click_Img(CartasDoJogador01.GetNumCartas(), picUser12);
        }
        #endregion

        /// <summary>
        ///  Método de otimização, pois cuida de centralizar, ou unificar, 
        ///  os procedimentos dos eventos Click de cada Picture (carta)!!!
        /// </summary>
        /// <param name="NumCartas">Número de Cartas no Monte do 01</param>
        /// <param name="pic">Variável que representa um controle específica</param>
        void Click_Img(int NumCartas, PictureBox pic)
        {
            int index = Int32.Parse(pic.Tag.ToString());
            if (index > -1 && possoJogar)
            {
                Carta carta = estrategia.BuscaCartaMesmoNaipe(CartasDoJogador01, Contador.NipeMao, NumCartas);
                ///<summary> Verifica se o jogador01 nega o naipe, tendo-o em mão.
                /// Isso se jogador01 não for o mão, caso em que ele tem de puxar 2 de paus!!!</summary>
                if (( Contador.mao.Nome != "USER01" && (carta.Naipe == (int)Contador.NipeMao) && carta.Naipe != CartasDoJogador01[index].Naipe)) {
                    Util.TocaWav(appSoundPath + fileSoundRenuncia);
                    lblMsgRenuncia.Text = Environment.UserName.ToString() + ", Você não deve fazer renúncia!!!";
                    lblMsgRenuncia.Visible = true; lblSombraMsgRenuncia.Visible = true; tmMsgRenuncia.Enabled = true;
                } else {
                    ///<summary>Verifica se o Jogador 01 tentou jogar outra carta que não o Dois de Paus
                    ///quando ele é o Mão. Em caso afirmativo, o sistema mostra uma msg na tela por "n" segundos!</summary>
                    if ((Contador.mao.ToString() == "USER01" && CartasDoJogador01[index].ToString() != "Dois de Paus") && Contador.numRodada == 0)
                    {
                        Util.TocaWav(appSoundPath + fileSoundInicioJogo);
                        lblMsg2Paus.Text = "Você é o Mão e jogo deve ser iniciado com o Dois de Paus!";
                        lblMsg2Paus.Visible = true; lblSombra2Paus.Visible = true;
                        tm2Paus.Enabled = true;
                    } else {
                        pic.Tag = -1;
                        pic.Visible = false;
                        ///<summary>Carta Ok, então apaga as msg's!</summary>
                        lblSombraMsgRenuncia.Visible = false; lblMsgRenuncia.Visible = false;
                        lblSombra.Visible = false; lblMsgTempoEspera.Visible = false;
                        tmEsperaDeJogador01.Enabled = false; tmMsgRenuncia.Enabled = false;
                        ///<summary>Carta Ok, então dispara a jogada!</summary>
                        Jogada(this.jogador_01, CartasDoJogador01[index], index, pic.Top, pic.Left);
                        PreencheMao();
                        possoJogar = false;
                    }}
            }}//Fim do Método Click_Img;

        void NovaRodada(Jogador mao, bool copasAberta, CartasNaMao cartasDoVencedor)
        {
            picCartadaPc01.Visible = false;
            picCartadaPc02.Visible = false;
            picCartadaPc03.Visible = false;
            picCartadaPc04.Visible = false;
            // Se o mão for eu, não é para 
            // haver jogada automática!
            if (mao.Nome != "USER01")
            {
                Jogada(mao, cartasDoVencedor[0], 0,0,0); // Depois mudar isso de acordo com o jogador
                                                                                  //que for o mão!
            }
        }

        /// <summary>
        /// Método responsável por causar o efeito de carta
        /// sendo recolhida pelo jogador vencedor da rodada.
        /// No futuro é possível que ele implemente outras funcionalidades!!!
        /// </summary>
        /// <param name="vencedor">Jogador vencedor da rodada</param>
        void GuardaCartasVencedor(Jogador vencedor) {
            Util.TocaWav(appSoundPath + fileSoundGuardaCarta);
            switch (vencedor.ToString()) { 
                case "USER01":
                    picCartadaPc02.Visible = false;
                    picCartadaPc03.Visible = false;
                    picCartadaPc04.Visible = false;
                    for (int i = 211; i < 800; i++)
                    {
                        if ((i % 30) == 0)
                        {
                            picCartadaPc01.Top = i;
                        }
                    }
                    possoJogar = true;
                    break;
                case "USER02":
                    picCartadaPc01.Visible = false;
                    picCartadaPc03.Visible = false;
                    picCartadaPc04.Visible = false;
                    for (int i = 359; i > -100; i--)
                    {
                        if ((i % 30) == 0)
                        {
                            picCartadaPc02.Left = i;
                        }
                    }
                    break;
                case "USER03":
                    picCartadaPc01.Visible = false;
                    picCartadaPc02.Visible = false;
                    picCartadaPc04.Visible = false;
                    for (int i = 108; i > -100; i--)
                    {
                        if ((i % 30) == 0)
                        {
                            picCartadaPc03.Top = i;
                        }
                    }
                    break;
                case "USER04":
                    picCartadaPc01.Visible = false;
                    picCartadaPc02.Visible = false;
                    picCartadaPc03.Visible = false;
                    for (int i = 456; i < 1100; i++)
                    {
                        if ((i % 30) == 0)
                        {
                            picCartadaPc04.Left = i;
                        }
                    }
                    break;
            }} // Fim do Método: GuardaCartasVencedor;

        private void btnMostraMsg_Click(object sender, EventArgs e)
        {
             string msg = "Vencedor da Rodada: " + Contador.vencedor.ToString() + "\n";
             msg += "\nJogador Mão: " + Contador.mao.ToString() + "\n";
             msg += "Nipe / Mão: " + Contador.NipeMao.ToString() + "\n";
             /*msg += "Posso Jogar? " + (this.possoJogar ? "Sim" : "Não") + "\n";
             msg += "Total do Jogador 01: " + Contador.totalJogador01.ToString() + "\n";
             msg += "Total do Jogador 02: " + Contador.totalJogador02.ToString() + "\n";
             msg += "Total do Jogador 03: " + Contador.totalJogador03.ToString() + "\n";
             msg += "Total do Jogador 04: " + Contador.totalJogador04.ToString() + "\n";*/
             msg+= "\nNúmero de Rodadas: " + Contador.numRodada.ToString()+"\n";
             msg+= "Número de Cartas na Mão do J01: "+CartasDoJogador01.GetNumCartas().ToString()+"\n";
             msg += "Número de Cartas na Mão do J02: " + CartasDoJogador02.GetNumCartas().ToString() + "\n";
             msg += "Número de Cartas na Mão do J03: " + CartasDoJogador03.GetNumCartas().ToString() + "\n";
             msg += "Número de Cartas na Mão do J04: " + CartasDoJogador04.GetNumCartas().ToString() + "\n";
             //msg += "Carta Jogada: " + Contador.cartaJogada.ToString() + "\n";
             msg+="\nCopas Abertas: "+ (Contador.copasAbertas ? "Sim": "Não")+"\n";
             msg+="Miquilina Saiu: "+ (Contador.miquilinaSaiu ? "Sim": "Não")+"\n";
             msg+="\nQtde q/Saiu de Paus: "+Contador.numPausQueSaiu.ToString()+"\n";
             msg+="Qtde q/Saiu de Ouros: "+Contador.numOurosQueSaiu.ToString()+"\n";
             msg+="Qtde q/Saiu de Espadas: "+Contador.numEspadasQueSaiu.ToString()+"\n";
             msg+="Qtde q/Saiu de Copas: "+Contador.numCopasQueSaiu.ToString()+"\n";
             //msg += "IndexAtual: " + Contador.indexAtual.ToString() + "\n";
             msg += "\nQtde. de Paus do Jogador 02:  [" + CartasDoJogador02.GetNumPaus().ToString()+"]\n";
             msg += "Qtde. de Ouros do Jogador 02:  [" + CartasDoJogador02.GetNumOuros().ToString() + "]\n";
             msg += "Qtde. de Espadas do Jogador 02:  [" + CartasDoJogador02.GetNumEspadas().ToString() + "]\n";
             msg += "Qtde. de Copas do Jogador 02:  [" + CartasDoJogador02.GetNumCopas().ToString() + "]\n";
             msg += "\nQtde. de Paus do Jogador 03:  [" + CartasDoJogador03.GetNumPaus().ToString() + "]\n";
             msg += "Qtde. de Ouros do Jogador 03:  [" + CartasDoJogador03.GetNumOuros().ToString() + "]\n";
             msg += "Qtde. de Espadas do Jogador 03:  [" + CartasDoJogador03.GetNumEspadas().ToString() + "]\n";
             msg += "Qtde. de Copas do Jogador 03:  [" + CartasDoJogador03.GetNumCopas().ToString() + "]\n";
             msg += "\nQtde. de Paus do Jogador 04:  [" + CartasDoJogador04.GetNumPaus().ToString() + "]\n";
             msg += "Qtde. de Ouros do Jogador 04:  [" + CartasDoJogador04.GetNumOuros().ToString() + "]\n";
             msg += "Qtde. de Espadas do Jogador 04:  [" + CartasDoJogador04.GetNumEspadas().ToString() + "]\n";
             msg += "Qtde. de Copas do Jogador 04:  [" + CartasDoJogador04.GetNumCopas().ToString() + "]\n";
             msg += "\nTotal de Copas Recolhidas do Jogador 01: [" + jogador_01.Pontos.ToString() + "]\n";
             msg += "Total de Copas Recolhidas do Jogador 02: [" + jogador_02.Pontos.ToString() + "]\n";
             msg += "Total de Copas Recolhidas do Jogador 03: [" + jogador_03.Pontos.ToString() + "]\n";
             msg += "Total de Copas Recolhidas do Jogador 04: [" + jogador_04.Pontos.ToString() + "]\n";
             //msg += "\nCartas da Rodada: \n[" + Contador.cartaDoJogador01.ToString() + "]\n[" + Contador.cartaDoJogador02.ToString() + "]\n[" +
                                                                       //Contador.cartaDoJogador03.ToString() + "]\n[" + Contador.cartaDoJogador04.ToString() + "]";
             Util.Msg(msg);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Código aqui para verificar se todos os Jogadores Jogaram!!!
            // **************************************************** ///
            Jogador mao = Contador.vencedor;
            switch (mao.Nome)
            {
                case "USER01": cartasNew = CartasDoJogador01; break;
                case "USER02": cartasNew = CartasDoJogador02; break;
                case "USER03": cartasNew = CartasDoJogador03; break;
                case "USER04": cartasNew = CartasDoJogador04; break;
            }
            GuardaCartasVencedor(mao);
            MarcarJogadorMao(mao);
            NovaRodada(mao, Contador.copasAbertas, cartasNew);
            //picMarcaMao.Visible = false;
            timer.Enabled = false;
        } // Fim do método timer_Tick;

        private void tmEsperaDeJogador01_Tick(object sender, EventArgs e)
        {
            Util.TocaWav(appSoundPath + fileSoundDemora);
            possoJogar = true;
            lblMsgTempoEspera.Text = "Sua vez de jogar, " + Environment.UserName.ToString() + ". Estamos todos aguardando!!!";
            lblMsgTempoEspera.Visible = true;
            lblSombra.Visible = true;
            tmEsperaDeJogador01.Enabled = false;
        }

        private void tmMsgRenuncia_Tick(object sender, EventArgs e)
        {
            lblSombraMsgRenuncia.Visible = false;
            lblMsgRenuncia.Visible = false;
            tmMsgRenuncia.Enabled = false;
        }

        private void tm2Paus_Tick(object sender, EventArgs e)
        {
            lblMsg2Paus.Visible = false; lblSombra2Paus.Visible = false;
            tm2Paus.Enabled = false;
        }

        CartasNaMao cartasNew;
        bool possoJogar = true;

        #region :: Properties of the Class

        public bool PossoJogar
        {
            get { return possoJogar; }
            set { possoJogar = value; }
        }
        public Jogador Jogador_01
        {
            get { return jogador_01; }
            set { jogador_01 = value; }
        }
        public Jogador Jogador_02
        {
            get { return jogador_02; }
            set { jogador_02 = value; }
        }
        public Jogador Jogador_03
        {
            get { return jogador_03; }
            set { jogador_03 = value; }
        }
        public Jogador Jogador_04
        {
            get { return jogador_04; }
            set { jogador_04 = value; }
        }

        #endregion

        private void frmCopas_Load( object sender, EventArgs e ) {
        }


    }} // Fim do Namespace;