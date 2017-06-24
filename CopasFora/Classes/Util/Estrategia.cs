using System;
using System.Collections.Generic;
using System.Text;
using CopasFora.Classes;
using CopasFora.Indexadores;
using System.Collections;
using System.Windows.Forms;
using CopasFora.Forms;
using System.Drawing;

namespace CopasFora.Classes.Util
{
    /// <summary>
    /// Classe com o objetivo de controlar a estat�stica do jogo
    /// em curso, assim como receber uma rodada e devolver a melhor resposta!
    /// </summary>
    public class Estrategia
    {
        #region :: Members of the Class;
        string appImgPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
        #endregion

        /// <summary>
        /// Construtor padr�o, sem par�metros;
        /// </summary>
        public Estrategia() {
        }

        Jogador retVal;
        /// <summary>
        /// Verifica qual � a maior carta dentro todas as servidas na rodada,
        /// considerando, apenas, as que servirem ao nipe, que est� representado
        /// pela vari�vel NMao, que � um objeto do tipo Naipe {enum}!!!
        /// </summary>
        /// <param name="cartas_rodada">As 4 Cartas da rodada</param>
        /// <param name="totais">Os valores de cada uma das cartas</param>
        /// <param name="NMao">Naipe servido pelo jogador m�o</param>
        /// <returns></returns>
        public Jogador GetVencedorDaRodada(Carta[] cartas_rodada, int[] totais, Naipe NMao, Jogador[] jogadores)
        {
            int maior = 0;
            for (int i = 0; i < 4; i++) {
                if ( ( totais[i] > maior ) && cartas_rodada[i].Naipe == (int)NMao ) {
                    maior = totais[i];
                    retVal = jogadores[i];
                }}
            TotalizaRodada(retVal, cartas_rodada);
            return retVal;
        }// Fim do M�todo GetVencedorDaRodada;

        /// <summary>
        /// M�todo privado, que � chamado pelo m�todo p�blico
        /// GetVencedorDaRodada para guardar as copas e dama de espada p/cd Jogador!
        /// </summary>
        /// <param name="vencedor">Vencedor da jogada, que recolher� as copas</param>
        /// <param name="cartas">Cartas da rodada</param>
        void TotalizaRodada( Jogador vencedor, Carta[] cartas ) {
            int total = 0;
            for (int i = 0; i < cartas.Length; i++) {
                if ((Naipe)cartas[i].Naipe == Naipe.Copas)
                {
                    total++;
                } else {
                    if (cartas[i].ToString().Equals("Dama de Espadas")) total += 13;
                }
            }
            vencedor.Pontos += total;
        }


        /// <summary>
        /// Toda vez que uma rodada � iniciada este m�todo tenta
        /// encontrar uma carta do mesmo nipe para acompanhar a jogada!
        /// </summary>
        /// <param name="cartas">Cartas do jogador da vex</param>
        /// <param name="nipeMao">Nipe da Carta do m�o</param>
        /// <param name="NumCartas">N�mero de Cartas na m�o do jogador</param>
        /// <returns></returns>
        public Carta BuscaCartaMesmoNaipe(CartasNaMao cartas, Naipe nipeMao, int NumCartas)
        {
            for (int i = 0; i < NumCartas; i++) {
                if (nipeMao == (Naipe)cartas[i].Naipe) {
                    Contador.indexAtual = i;
                    return cartas[Contador.indexAtual];
                }}
                Contador.indexAtual = 0;
                return cartas[0];
        } // Fim do m�todo BuscaCartaMesmoNaipe;

        /// <summary>
        /// Move a carta at� sua posi��o na mesa.
        /// A id�ia � simular o movimento da carta!
        /// </summary>
        /// <param name="pic">Picture que cont�m a imagem da carta</param>
        /// <param name="carta">Carta a mover</param>
        /// <param name="topIni">Posi��o (Top) do monte origem da carta</param>
        /// <param name="leftIni">Posi��o (Left) do monte origem da carta</param>
        /// <param name="topFim">Posi��o (Top) destino final da carta na mesa</param>
        /// <param name="leftFim">Posi��o (Left) destino final da carta na mesa</param>
        public void MoveCarta(PictureBox pic, Carta carta, int topIni, int leftIni, int topFim, int leftFim)
        {
            //Posiciona a carta no monte de partida.
            pic.Top = topIni; pic.Left = leftIni;
            pic.Image = Image.FromFile(appImgPath + "ImgCartas" + @"\" + carta.ToString() + ".jpg");
            pic.Visible = true;
            int quintoTop, quintoLeft = 0;
            int diferencaTop, diferencaLeft = 0;
            ///<summary>Retorna apenas resultado positivo!</summary>
            diferencaTop = (topFim - topIni) >= 0 ? (topFim - topIni) : (topFim - topIni)*-1;
            diferencaLeft = (leftFim - leftIni) >= 0 ? (leftFim - leftIni) : (leftFim - leftIni) * -1;
            ///<summary>Divide a diferen�a entre origem e destino em 
            ///quintos para permitir a itera��o em 5 passos!!!</summary>
            quintoTop = diferencaTop / 5;
            quintoLeft = diferencaLeft / 5;
            //=================//
            for (int i = 1; i < 6; i++) {
                if (topIni < topFim) {
                    pic.Top = topIni + (i * quintoTop);
                } else {
                    pic.Top = topIni - (i * quintoTop);
                }
                if (leftIni < leftFim) {
                    pic.Left = leftIni + (i * quintoLeft);
                } else {
                    pic.Left = leftIni - (i * quintoLeft);
                } Application.DoEvents(); // Libera recursos!
            }
        }//Fim do M�todo MoveCarta;

        // TESTE, usando a t�cnica da fun��o de 1� grau e gr�fico carteziano!
        //********************************************************* /.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pic"></param>
        /// <param name="carta"></param>
        /// <param name="topIni"></param>
        /// <param name="topFim"></param>
        /// <param name="leftFim"></param>
        public void MoveCarta(PictureBox pic, Carta carta, int topIni, int topFim, int leftFim)
        {
            int razao = topFim / leftFim;
            //Posiciona a carta no monte de partida.
            pic.Top = topIni; pic.Left = topIni/razao;
            pic.Image = Image.FromFile(appImgPath + "ImgCartas" + @"\" + carta.ToString() + ".jpg");
            pic.Visible = true;
            int quinto = 0;
            int diferenca = 0;
            diferenca = topIni - topFim;
            quinto = diferenca / 5;
            //===========//
            for (int i = 1; i < 6; i++)
            {
                pic.Top = (topIni + (i * quinto));
                pic.Left = (topIni + (i * quinto)) / razao;
                Application.DoEvents(); // Libera recursos!
            }
        }//Fim do M�todo MoveCarta;


        /// <summary>
        /// Tem o �nico intuito de inicializar
        /// as vari�veis est�ticas da classe Contador!
        /// </summary>
        public void ZerarContadores() { 
            Contador.NipeMao = Naipe.Paus;
            Contador.numRodada=0;
            Contador.mao=null;
            Contador.cartaJogada=null;
            Contador.vencedor=null;
            Contador.copasAbertas=false;
            Contador.miquilinaSaiu=false;
            Contador.numPausQueSaiu=0;
            Contador.numOurosQueSaiu=0;
            Contador.numEspadasQueSaiu=0;
            Contador.numCopasQueSaiu=0;
            Contador.totalCopasJogador01 = 0;
            Contador.totalCopasJogador02 = 0;
            Contador.totalCopasJogador03 = 0;
            Contador.totalCopasJogador04 = 0;
            Contador.totalCartasNaRodada = 0;
            Contador.totalJogador01 = 0;
            Contador.totalJogador02 = 0;
            Contador.totalJogador03 = 0;
            Contador.totalJogador04 = 0;

            Contador.cartaDoJogador01=null;
            Contador.cartaDoJogador02=null;
            Contador.cartaDoJogador03=null;
            Contador.cartaDoJogador04=null;

            Contador.indexAtual = 0;
        }

    }} // Fim do namespace;
