using System;
using System.Collections.Generic;
using System.Text;
using CopasFora.Classes.Util;
using CopasFora.Indexadores;
using CopasFora.Forms;

namespace CopasFora.Classes
{
    class Contador
    {
        #region :: Campos static's da classe;
        public static Naipe NipeMao = Naipe.Paus;
        public static int numRodada=0;
        public static Jogador mao;
        public static Carta cartaJogada;
        public static Jogador vencedor;
        public static bool copasAbertas=false;
        public static bool miquilinaSaiu=false;
        public static int numPausQueSaiu=0;
        public static int numOurosQueSaiu=0;
        public static int numEspadasQueSaiu=0;
        public static int numCopasQueSaiu=0;
        public static int totalCopasJogador01 = 0;
        public static int totalCopasJogador02 = 0;
        public static int totalCopasJogador03 = 0;
        public static int totalCopasJogador04 = 0;
        public static int totalCartasNaRodada = 0;
        public static int totalJogador01 = 0;
        public static int totalJogador02 = 0;
        public static int totalJogador03 = 0;
        public static int totalJogador04 = 0;

        public static Carta cartaDoJogador01;
        public static Carta cartaDoJogador02;
        public static Carta cartaDoJogador03;
        public static Carta cartaDoJogador04;

        public static int indexAtual = 0;
        #endregion

        public Contador()
        { 
        }

    }} // Fim do namespace!
