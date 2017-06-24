using System;
using System.Collections.Generic;
using System.Text;
using CopasFora.Forms;
using CopasFora.Classes;
using CopasFora.Indexadores;
using CopasFora.Classes.Util;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;

namespace CopasFora.Forms
{
    /// <summary>
    /// Classe criada por mim, como partial da classe
    /// do mesmo nome, mas outro nome de arquivo.
    /// A idéia é dividir o código-fonte, pois o arquivo
    /// está grande demais.  É bom  manter  somente 
    /// métodos personalizados neste arquivo!
    /// </summary>
    partial class frmCopas
    {

        /// <summary>
        ///  Este método distribui as cartas entre os quatro jogadores: 
        /// User e os PC's. Isto depois das mesmas terem sido embaralhadas!!!
        /// </summary>
        private void DistribuirCartas()
        {
            for (int i = 1; i <= 13; i++)
            {
                CartasDoJogador01.Add(baralho.DarCarta());
                CartasDoJogador02.Add(baralho.DarCarta());
                CartasDoJogador03.Add(baralho.DarCarta());
                CartasDoJogador04.Add(baralho.DarCarta());
            }} // DistribuirCartas;

        /// <summary>
        /// Ao iniciar o jogo, é necessário que se ache 
        /// qual dos jogadores está com o 2 de paus, pois
        /// é ele quem deve iniciar a primeira rodada!!!
        /// </summary>
        public void Procurar2Paus() {
            bool achou = false;
            if (!achou) {
                achou = FindFirstCards(CartasDoJogador01, jogador_01);
            }  if (!achou) {
                achou = FindFirstCards(CartasDoJogador02, jogador_02);
            }  if (!achou) {
                achou = FindFirstCards(CartasDoJogador03, jogador_03);
            }  if (!achou) {
                achou = FindFirstCards(CartasDoJogador04, jogador_04);
            }
        } // Fim da Classe Procurar2Paus();
        bool FindFirstCards(CartasNaMao cartas, Jogador jogador) {
            bool achou = false;
            for (int i = 0; i < cartas.GetNumCartas(); i++) {
                if (cartas[i].Valor == 2 && cartas[i].Naipe == (int)Naipe.Paus) {
                    achou = true;
                    Contador.NipeMao = Naipe.Paus;
                    Contador.mao = jogador;
                    if (jogador.ToString() != "USER01")
                    {
                        Jogada(jogador, cartas[i], i, 0, 0);
                    } else {
                        tmEsperaDeJogador01.Enabled = true;
                    }
                }} return achou;
        }// Fim do método FindFirstCards;

        /// <summary>
        ///  Método responsável pelo preenchimento correto
        ///  dos pictures das cartas após cada rodada. A variável
        ///  ctr e proximo_left controlam a qtde e a posição esquerda
        ///  de cada controle, para mantê-los sempre juntos e alinhados!!!
        /// </summary>
        void PreencheMao() {
            int ctr = 0;
            ///<summary>proximo_left é a posição inicial da lista,
            ///que contém a primeira carta do jogador 01</summary>
            int proximo_left = 220;
            ArrayList lista = new ArrayList();
            foreach (PictureBox pic in new PictureBox[13]{picUser0, picUser1, picUser2, picUser3, picUser4, 
                                picUser5, picUser6, picUser7, picUser8, picUser9, picUser10, picUser11, picUser12})
            {
                lista.Add(pic);
            }
            foreach (PictureBox pic in lista) {
                if (Int32.Parse(pic.Tag.ToString()) > -1) {
                    pic.Left = proximo_left;
                    pic.Image = Image.FromFile(appImgPath + "ImgCartas" + @"\" + CartasDoJogador01[ctr].ToString() + ".jpg");
                    pic.BringToFront();
                    pic.Tag = ctr.ToString();
                    ctr++;
                    //Havendo mais carta, a mesma 
                    //devem ficar à 22 pixel's à esquerda!
                    proximo_left += 22;
                }}
        } // Fim do Método PreencheMao();

        /// <summary>
        /// Desloca o Picture marcador de Mão para 
        /// a posição do jogador que, agora, é o mão!
        /// </summary>
        /// <param name="mao">Jogador Vencedor da mão!</param>
        void MarcarJogadorMao(Jogador mao)
        {
            switch (mao.Nome)
            {
                case "USER01": picMarcaMao.Top = 313; picMarcaMao.Left = 300; break;
                case "USER02": picMarcaMao.Top = 71; picMarcaMao.Left = 100; break;
                case "USER03": picMarcaMao.Top = 12; picMarcaMao.Left = 300; break;
                case "USER04": picMarcaMao.Top = 14; picMarcaMao.Left = 695; break;
            }
            picMarcaMao.Visible = true;
        }// Fim da classe MarcarJogadorMao;

        /// <summary>
        ///  Método inicial de configuração das cartas do jogador 01.
        ///  Ele serve de base para iniciar as tag's com a sequência de
        ///  0 a 12 para servir de índice inicial aos controles que representam as cartas.
        /// </summary>
        /// <param name="OnOff"> Variável que cuida da visibilidade dos controls </param>
        void ControlTag(bool OnOff)
        {
            ArrayList lista = new ArrayList();
            foreach (PictureBox pic in new PictureBox[13]{picUser0, picUser1, picUser2, picUser3, picUser4, 
                            picUser5, picUser6, picUser7, picUser8, picUser9, picUser10, picUser11, picUser12})
            {
                lista.Add(pic);
            }
            int ctr = 0;
            foreach (PictureBox pic in lista)
            {
                pic.Tag = ctr.ToString();
                pic.Visible = OnOff;
                pic.Top = 348;
                ctr++;
            }} // Fim do Método ControlTag;

        /// <summary>
        /// Método que registra a jogada de um determinado
        /// jogador. Ele dispara o evento OnAlguemJogou, que 
        /// controla quem deve jogar depois, quem é o mão, entre outras coisas!
        /// </summary>
        /// <param name="jogador">Jogador da jogada</param>
        /// <param name="carta">Carta jogada</param>
        /// <param name="index">Index que determina a posição da carta em CartasNaMao</param>
        void Jogada(Jogador jogador, Carta carta, int index, int pTop, int pLeft)
        {
            Contador.cartaJogada = carta;
            Contador.totalCartasNaRodada++;
            switch (carta.Naipe)
            {
                case 1: Contador.numPausQueSaiu++; break;
                case 2: Contador.numOurosQueSaiu++; break;
                case 3: Contador.numEspadasQueSaiu++; break;
                case 4:
                    Contador.numCopasQueSaiu++;
                    Contador.copasAbertas = true;
                    break;
            }
            if (carta.Valor == 12 && carta.Naipe == 3) {
                Contador.numCopasQueSaiu += 13;
                Contador.miquilinaSaiu = true;
            }
            if ( Contador.totalCartasNaRodada == 1 ) {
                Contador.NipeMao = (Naipe)carta.Naipe;
            }
            switch (jogador.Nome) {
                case "USER01":
                    CartasDoJogador01.Remove(index);
                    estrategia.MoveCarta(picCartadaPc01, carta, pTop, pLeft, 211, 431);
                    Contador.totalJogador01 += carta.Valor;
                    Contador.cartaDoJogador01 = carta;
                    OnAlguemJogou(objJogador.jogador01, new EventArgs());
                    break;
                case "USER02":
                    CartasDoJogador02.Remove(index);
                    estrategia.MoveCarta(picCartadaPc02, carta, 111, 12, 184, 359);// Otimizar parâm. top e left
                    Contador.totalJogador02 += carta.Valor;
                    Contador.cartaDoJogador02 = carta;
                    OnAlguemJogou(objJogador.jogador02, new EventArgs());
                    break;
                case "USER03":
                    CartasDoJogador03.Remove(index);
                    estrategia.MoveCarta(picCartadaPc03, carta, 48, 220, 108, 405);// Otimizar parâm. top e left
                    Contador.totalJogador03 += carta.Valor;
                    Contador.cartaDoJogador03 = carta;
                    OnAlguemJogou(objJogador.jogador03, new EventArgs());
                    break;
                case "USER04":
                    CartasDoJogador04.Remove(index);
                    estrategia.MoveCarta(picCartadaPc04, carta, 99, 781, 148, 456);// Otimizar parâm. top e left
                    Contador.totalJogador04 += carta.Valor;
                    Contador.cartaDoJogador04 = carta;
                    OnAlguemJogou(objJogador.jogador04, new EventArgs());
                    break;
            }
        }// Fim do método Rodada!!!    


    }}//Fim do namespace
