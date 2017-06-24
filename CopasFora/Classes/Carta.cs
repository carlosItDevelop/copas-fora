using System;
using System.Collections.Generic;
using System.Text;

namespace CopasFora.Classes
{
    public class Carta
    {
        public const int PAUS = 1;
        public const int OUROS = 2;
        public const int ESPADAS = 3;
        public const int COPAS = 4;
        private int naipe;
        private int valor;

        public Carta(int n, int v) {
            Naipe = n;
            Valor = v;
        }

        [Obsolete("O Ás neste jogo Vale 13, mas em 21 vale 1")]
        public override string ToString()
        {
            string tmp = "";
            switch (valor) {
                case 2: tmp = "Dois"; break;
                case 3: tmp = "Três"; break;
                case 4: tmp = "Quatro"; break;
                case 5: tmp = "Cinco"; break;
                case 6: tmp = "Seis"; break;
                case 7: tmp = "Sete"; break;
                case 8: tmp = "Oito"; break;
                case 9: tmp = "Nove"; break;
                case 10: tmp = "Dez"; break;
                case 11: tmp = "Valete"; break;
                case 12: tmp = "Dama"; break;
                case 13: tmp = "Rei"; break;
                case 14: tmp = "Ás"; break;
            }
            switch (naipe) {
                case (int)Util.Naipe.Paus: tmp += " de Paus"; break;
                case OUROS: tmp += " de Ouros"; break;
                case ESPADAS: tmp += " de Espadas"; break;
                case COPAS: tmp += " de Copas"; break;
            }
            return tmp;
        }


        public int Naipe
        {
            get { return naipe; }
            set {
                    if (value >= PAUS && value <= COPAS) {
                        this.naipe = value;
                    } else {
                        this.naipe = (int)Util.Naipe.Paus;
                    }
                }}//Fim de Naipe Propertie;
        public int Valor
        {
            get { return valor; }
            set {
                    if (value >= 2 && value <= 14) {
                        this.valor = value;
                    } else {
                        this.valor = 2;
                    }
            }}//Fim de Valor Propertie;

    }} // Fim do namespace;
