using System;
using System.Collections.Generic;
using System.Text;

namespace CopasFora.Classes
{
    public class Baralho
    {
        public Carta carta = new Carta(1, 2); // Baralho tem Carata!
        private Carta[] monte;
        private int topo;
        public Baralho() { 
            monte = new Carta[52];
            topo = 0;
            for ( int n=1; n<5; n++){
                for ( int v=2; v<15; v++ ) {
                    monte[topo++] = new Carta(n, v);
                }}} // Fim do Construtor;

        public bool TemCarta() {
            return topo > 0;
        }
        public Carta DarCarta() {
            Carta tmp = null;
            if ( TemCarta() ) tmp = monte[--topo];
            return tmp;            
        } // Fim do Método DarCarta;

        Random random = new Random();
        public void Embaralhar()
        {
            for ( int c=0; c<52; c++) {
                int i = (int)random.Next( 0, 51 );
                Carta tmp = monte[i];
                monte[i] = monte[c];
                monte[c]=tmp;
            }} // Fim do Método Embaralhar;

    }} // Fim do namespace;
