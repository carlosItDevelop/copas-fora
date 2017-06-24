using CopasFora.Classes;
using CopasFora.Classes.Util;

namespace CopasFora.Indexadores
{
    public class CartasNaMao
    {
        #region :: Members of the class
        int num_paus = 0;
        int num_ouros = 0;
        int num_espadas = 0;
        int num_copas = 0;

        private Carta[] carta = null;
        private int ctr = 0;
        int numDimCarta = 13;
        #endregion

        /// <summary>
        /// Construtor padrão!
        /// </summary>
        public CartasNaMao() {
            carta = new Carta[numDimCarta];
        }

        public void Add(Carta carta) {
            if (ctr >= this.carta.Length)
            {
                // Lida com Índice Errado!
                Util.MsgErro("Índice fora do Limite!");
            }
            else
                this.carta[ctr++] = carta;
        }

        /// <summary>
        ///  Remove uma carta. Após o quê serão redirecionadas
        ///  todas as outras cartas para o index anterior, desde de
        ///  que index não seja o último do indexador!
        /// </summary>
        /// <param name="index">index da carta a ser removida</param>
        public void Remove(int index)
        {
            ctr = 0;
            Carta[] new_carta = new Carta[numDimCarta-1];
            for (int i = 0; i < numDimCarta-1; i++) {
                if (i < index)
                {
                    new_carta[i] = this[i];
                }
                else {
                    new_carta[i] = this[i+1];
                }
                ctr++;
            }
            numDimCarta--;
            carta = new_carta;
        }


        /// <summary>
        /// Organiza as cartas por nipe
        /// e depois os adiciona no indexador!
        /// </summary>
        public void Sort()
        {
            Carta[] CartasDePaus = null;
            Carta[] CartasDeOuros = null;
            Carta[] CartasDeEspadas = null;
            Carta[] CartasDeCopas = null;
            const int PAUS = 1;
            const int OUROS = 2;
            const int ESPADAS = 3;
            const int COPAS = 4;
            // Conta os naipes para formar os laços (for) depois;
            for (int i = 0; i <= 12; i++)
            {
                if (this[i].Naipe == PAUS) num_paus++;
                if (this[i].Naipe == OUROS) num_ouros++;
                if (this[i].Naipe == ESPADAS) num_espadas++;
                if (this[i].Naipe == COPAS) num_copas++;
            }
            // Se há [Naipe] guardar juntas as cartas deste naipe.
            // É assim nos próximos quatro laços!!!
            if (num_paus > 0)
            {
                int c = 0;
                CartasDePaus = new Carta[num_paus];
                for (int i = 0; i <= 12; i++) {
                    if (this[i].Naipe == PAUS) {
                        CartasDePaus[c++] = this[i]; // [c++] - Usa o contador e depois o incrementa!
                    }}
                    SortValor(CartasDePaus);
            } // Fim num_paus;
            if (num_ouros > 0) {
                int c = 0;
                CartasDeOuros = new Carta[num_ouros];
                for (int i = 0; i <= 12; i++) {
                    if (this[i].Naipe == OUROS)
                    {
                        CartasDeOuros[c++] = this[i];
                    }}
                    SortValor(CartasDeOuros);
                } // Fim num_ouros
            if (num_espadas > 0)
            {
                int c = 0;
                CartasDeEspadas = new Carta[num_espadas];
                for (int i = 0; i <= 12; i++) {
                    if (this[i].Naipe == ESPADAS)
                    {
                        CartasDeEspadas[c++] = this[i];
                    }}
                    SortValor(CartasDeEspadas);
                } // Fim num_espadas
            if (num_copas > 0)
            {
                int c = 0;
                CartasDeCopas = new Carta[num_copas];
                for (int i = 0; i <= 12; i++) {
                    if (this[i].Naipe == COPAS)
                    {
                        CartasDeCopas[c++] = this[i];
                    }}
                    SortValor(CartasDeCopas);
                } // Fim num_copas

            // Zerar a variável ctr, da instância 
            // para utilizar o método Add();
                ctr = 0;

            // Depois de zerar a variável de controle
            // de Index (ctr), Usar o método Add() para
            // Adicionar as cartas por naipe!
            if (num_paus > 0)
            {
                for (int i = 0; i < num_paus; i++)  {                    
                    this.Add(CartasDePaus[i]);
                }} // Fim Cartas de Paus;
            if (num_ouros > 0)
            {
                for (int i = 0; i < num_ouros; i++) {
                    this.Add(CartasDeOuros[i]);
                }} // Fim Cartas de Ouros;
            if (num_espadas > 0)
            {
                for (int i = 0; i < num_espadas; i++) {
                    this.Add(CartasDeEspadas[i]);
                }} // Fim Cartas de Espadas;
            if (num_copas > 0)
            {
                for (int i = 0; i < num_copas; i++) {
                    this.Add(CartasDeCopas[i]);
                }} // Fim Cartas de Copas;
        } // Fim do Método Sort();

        /// <summary>
        /// Método privado que ordena as cartas
        /// por valor. É chamado pelo método público 
        /// Sort, que ordena os naipes!!!
        /// </summary>
        /// <param name="carta">Objeto carta criado em Sort, 
        /// que representa um Array de cartas de um determinado nipe!</param>
        void SortValor(Carta[] carta)
        {
            int len = carta.Length;
            int auxMax; int index_max=0; int fim; Carta aux;

            while (len > 1) {
                fim = len - 1;
                auxMax = 0;
                for (int i = 0; i <= fim; i++) {
                    if (carta[i].Valor > auxMax)
                    {
                        auxMax = carta[i].Valor;
                        index_max = i;
                    }
                }
                if (index_max != fim)
                {
                    aux = carta[fim];
                    carta[fim] = carta[index_max];
                    carta[index_max] = aux;
                }

                len--;
            }} // Fim do Método SortValor();

        public int GetNumPaus() {
            int countPaus = 0;
            for (int i = 0; i < ctr; i++) {
                if ((Naipe)this[i].Naipe == Naipe.Paus) countPaus++;
            }
            return countPaus;
        }

        public int GetNumOuros() {
            int countOuros = 0;
            for (int i = 0; i < ctr; i++)
            {
                if ((Naipe)this[i].Naipe == Naipe.Ouros) countOuros++;
            }
            return countOuros;
        }

        public int GetNumEspadas() {
            int countEspadas = 0;
            for (int i = 0; i < ctr; i++)
            {
                if ((Naipe)this[i].Naipe == Naipe.Espadas) countEspadas++;
            }
            return countEspadas;
        }

        public int GetNumCopas() {
            int countCopas = 0;
            for (int i = 0; i < ctr; i++)
            {
                if ((Naipe)this[i].Naipe == Naipe.Copas) countCopas++;
            }
            return countCopas;
        }

        public bool EstaComMiquilina() {
            bool retval = false;
            for (int i = 0; i < ctr; i++) {
                if (((Naipe)this[i].Naipe == Naipe.Espadas) && (this[i].Valor == 12)) retval = true;
            }
            return retval;
        }


        /// <summary>
        ///  Propriedade única - Indexador.
        ///  Ela armazena as cartas para cada
        ///  um dos jogadores - Objeto: CartasNaMao!
        /// </summary>
        /// <param name="index"> Índice </param>
        /// <returns> Retorna um objeto Carta! </returns>
        public Carta this[int index]
        { 
            get {
                if ( index < 0 || index >= numDimCarta ) {
                    // Lida com Índice Errado!
                    Util.MsgErro("Índice fora do Limite!");
                    return null;
                }
                return carta[index];
            }
            set {
                //Adiciona somente através do método Add;
                if ( index >= ctr )
                {
                    Util.MsgErro("Índice fora do Limite!");
                    carta[index] = null;
                }
                carta[index] = value;
            }
        }

        /// <summary>
        /// Retorna um inteiro que controla o número
        /// de objetos adicionados ao indexador!!!
        /// </summary>
        /// <returns>Retorna ctr: Indicador de Número de elementos!</returns>
        public int GetNumCartas() {
            return ctr;
        }


    }} // Fim do namespace;
