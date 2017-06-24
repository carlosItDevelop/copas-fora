using System;
using System.Collections.Generic;
using System.Text;

namespace JogoCartas.Classes
{
    class Baralho
    {
        private Carta[] monte;
        private int topo;
        public Baralho() { 
            monte = new Carta[52];
            topo = 0;
            for ( int n=1; n<5; n++){
                for ( int v=1; v<14; v++ ) {
                    monte[topo++] = new Carta(n,v);
                }
            }
        }

        public bool TemCarta() {
            return topo > 0;
        }
        public Carta DarCarta() {
            Carta tmp = null;
            if ( topo > 0 ) tmp = monte[--topo];
                return tmp;            
        }
        Random random = new Random();
        public void Embaralhar()
        {
            for ( int c=1; c<52; c++) {
                int i = (int)random.Next( 1, 52 );
                Carta tmp = monte[i];
                monte[i] = monte[c];
                monte[c]=tmp;
            }
        }

    }} // Fim do namespace;
