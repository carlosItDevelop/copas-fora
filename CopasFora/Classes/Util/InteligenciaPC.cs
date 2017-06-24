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
    /// Classe com o objetivo de controlar a estatística do jogo
    /// em curso, assim como receber uma rodada e devolver a melhor resposta!
    /// </summary>
    public class InteligenciaPC
    {
        #region :: Members of the Class;
        #endregion

        /// <summary>
        /// Construtor padrão, sem parâmetros;
        /// </summary>
        public InteligenciaPC (  )
        {
        }

        /// <summary>
        /// Em fase de projeto!
        /// Este método vai substituir o método
        /// BuscaCartaMesmoNaipe()
        /// </summary>
        /// <param name="seuJogo"> O jogo que, no instante, está na sua mão </param>
        /// <param name="cartasDaRodada"> As cartas que, no instante, estão na mesa </param>
        /// <returns> Retorna um objeto do tipo Carta </returns>
        public Carta GetMelhorCarta(CartasNaMao seuJogo, Carta[] cartasDaRodada, Naipe naipe_mao, 
                                                          Jogador jogador_mao, Jogador jogador_vez )
        {
            Carta retval = null;
            /// REVISAR SEMPRE ESTE SUMMARY, POIS EL SÓ DEVE SER APAGADO DEPOIS DE PRONTO!
            /// OBS: DEIXAR A REGION FECHADA E POUSAR O MOUSE PARA LER. ABRIR PARA REVISAR!!!
            #region :: Summary com detalhes da Implementação do método!
            ///<summary>
            /// ** Carta mão != (copas && espadas);
            /// 01 - Avalia se tem o naipe para servir;
            /// 02 - Caso negativo, verificar se é a primeira rodada;
            /// 03 - Caso negativo, verificar se está com dama de espadas;
            /// 04 - Caso positivo embarcar dama de espadas;
            /// 04 - Caso negativo, verificar se copas está aberta;
            /// 05 - Caso positivo, servir copas;
            /// 06 - No caso de embarcar copas servir sempre o maior valor na sua mão;
            /// 07 - No caso de não ter o naipe mão, mas também não ter nem copas e nem a dama de espadas,
            /// Escolher um naipe e embarcar o maior valor desse naipe;
            /// ** - Você é o mão e não é a primeira rodada;
            /// 01 - Escolha um naipe != Espadas && Copas;
            /// 02 - Se houver pelo menos 5 cartas do mesmo naipe ainda a ser jogada, sem contar as suas,
            /// obviamente, Você deve sair com a maior carta deste naipe
            /// ** - Caso a carta mão seja espadas:
            /// 01 - Verifica se a dama de espadas já saiu;
            /// 02 - caso positivo, ****
            /// ** - caso a carta mão seja copas;
            /// 01 - se vc for o último jogador da rodada avalie dois casos;
            /// 02 - se você não tem como servir uma carta menor para fugir de pegar esta rodada,
            /// então sirva a maior que vc tiver de copas
            ///</summary>
            #endregion
            //Escolhe Naipe;
            switch (naipe_mao) { 
                case Naipe.Paus:
                    // Verifica se "você(PCn)" é o mão!
                    //=-=-=-=-=-=-=-=-=-=-=-=-=/.
                    //Obs.: Não é necessária a verificação
                    //de NumRodada, pois se fosse a primeira
                    //Seria disparado no método Procura2Paus();
                    if (jogador_mao.Nome == jogador_vez.Nome) {
                        //Verifica se vc tem copas e tem o 
                        //dois de copas e copas está aberta!? 
                        //(NO FUTURO AVALIAR SE TEM A "MENOR" CARTA DE COPAS)
                        if ((seuJogo.GetNumCopas() > 0) && (TemACarta("Dois de Copas", seuJogo)) && (Contador.copasAbertas)) {
                            retval = GetTheCards("Dois de Copas", seuJogo );
                        } else {
                            //Esta implementação deve ser OTIMIZADA,
                            //no sentido de buscar a melhor carta <> 2copas
                            retval = GetAnyCards(seuJogo);
                        }
                    } else {
                        //Verifica se tem Paus na Mão,
                        //caso em que terá que servir!!
                        if (seuJogo.GetNumPaus() > 0) {
                            //Desenvolver: (Vc tem paus! Deverá jogar paus!!!)
                            retval = GetMelhorOpcaoServir(new Naipe[] { Naipe.Paus }, seuJogo,
                                                                    cartasDaRodada, naipe_mao, jogador_mao);
                        } else {
                            //Não tem paus para servir.
                            //Verifica se estamos na 1ª rodada, caso em que não poderão
                            //ser embarcadas copas e nem a dama de espadas!!!
                            if (Contador.numRodada <= 1) {
                                //Vc vai embarcar, mas não pode ser copas 
                                //e nem a dama de espadas, visto que está na primeira rodada!
                                retval = GetMelhorOpcaoEmbarcar(new Naipe[] { Naipe.Espadas, Naipe.Ouros } , seuJogo,
                                                                                                        cartasDaRodada, naipe_mao, jogador_mao);
                            } else {
                                //Não tem paus para servir. Avalia se já foi 
                                //aberta copas. Além disso, também avalia se vc tem copas,
                                // caso contrário essa abordagem seria inútil!
                                //Obs.: NESTA ABORDAGEM (IF), DAMOS PREFERÊNCIA 
                                //À COPAS  EM  DETRIMENTO  DA  DAMA DE ESPADAS, 
                                //QUE TEM SUA IMPLEMENTAÇÃO NA CRÍTICA DO "ELSE".
                                if (Contador.copasAbertas && seuJogo.GetNumCopas() > 0) {
                                    //Vc vai jogar copas!
                                    retval = GetMelhorOpcaoEmbarcar(new Naipe[] { Naipe.Copas } , seuJogo,
                                                                                    cartasDaRodada, naipe_mao, jogador_mao);
                                } else {
                                    // Verifica se vc está com a miquilina.
                                    // Para manter padrão, verificar se miquilina saiu. 
                                    // NÃO seria necessário, visto que vc avalia se ESTÁ com ela ou não!
                                    if ((!Contador.miquilinaSaiu) && seuJogo.EstaComMiquilina()) {
                                        //Seta retval com dama de espadas!
                                        for (int i = 0; i < seuJogo.GetNumCartas(); i++)
                                        {
                                            if (seuJogo[i].Valor == 12 && (seuJogo[i].Naipe == (int)(Naipe.Espadas))) retval = seuJogo[i];
                                        }
                                    } else {
                                        //Vc não tem paus, mas tb não pode jogar copas e nem a miquilina!
                                        retval = GetMelhorOpcaoEmbarcar(new Naipe[] { Naipe.Espadas, Naipe.Ouros }, seuJogo,
                                                                                                                cartasDaRodada, naipe_mao, jogador_mao);
                                    }
                                }// if (Contador.copasAbertas && seuJogo.GetNumCopas() > 0)
                            }// if ( Contador.numRodada <= 1 )
                        }// if ( seuJogo.GetNumPaus() > 0 ) 
                    } // if ( jogador_mao.Nome == vez.Nome )
                    break;
                case Naipe.Ouros:
                    break;
                case Naipe.Espadas:
                    break;
                case Naipe.Copas:
                    break;
                default:
                    // Não faz nada, pois nunca deveremos chegar até aqui!
                    break;
            }
            return retval;
        }

        public bool TemACarta(string nome_da_carta, CartasNaMao seuJogo) {
            bool retval = false;
            for (int i = 0; i < seuJogo.GetNumCartas(); i++) {
                if ( seuJogo[i].ToString() == nome_da_carta ) retval = true;
            } return retval;
        }

        public Carta GetTheCards(string nome_da_carta, CartasNaMao seuJogo) {
            Carta retval = null;
            for (int i = 0; i < seuJogo.GetNumCartas(); i++) {
                if ( seuJogo[i].ToString() == nome_da_carta ) retval = seuJogo[i];
            } return retval;
        }

       ///IMPLEMENTAR!!!
       ///
        public Carta GetAnyCards(CartasNaMao seuJogo)
        { 
            // Desenvolver!!! RETORNAR A MELHOR CARTA NO MOMENTO!
            return new Carta(2, 12);
        }

        //IMPLEMENTAR!!!
        /// <summary>
        /// Método que retorna a "melhor" carta do mesmo naipe do mão!
        /// Ele recebe, de uma "classe anônima" um array com os naipes possíveis para servir!
        /// <param name="naipes_possiveis"> Array de naipes possíveis para servir </param>
        /// <param name="seuJogo"> O jogo que, no instante, o jogador tem na mão! </param>
        /// <param name="cartasDaRodada"> Cartas que, no instante, estão na mesa! </param>
        /// <param name="naipe_mao"> Naipe puxado pelo jogador mao </param>
        /// <param name="jogador_mao"> jogador que tem o dever de iniciar a jogada! </param>
        /// <returns> Objeto do tipo Carta, que na avaliação da inteligência do jogo é a melhor! </returns><summary>
        public Carta GetMelhorOpcaoServir(Naipe[] naipes_possiveis, CartasNaMao seuJogo, 
                                            Carta[] cartasDaRodada, Naipe naipe_mao, Jogador jogador_mao)
        {
            // Desenvolver!!! RETORNAR MELHOR CARTA PARA SERVIR!
            return new Carta(2, 12);
        }

        //IMPLEMENTAR!!!!
        /// <summary>
        /// Método que retorna a "melhor" carta do mesmo naipe do mão!
        /// Ele recebe, de uma "classe anônima", um array com os naipes possíveis para embarcar.
        /// Obs: Este método não pode retornar a Dama de Espadas (Miquilina).
        /// <param name="naipes_possiveis"> Array de naipes possíveis para embarcarr </param>
        /// <param name="seuJogo"> O jogo que, no instante, o jogador tem na mão! </param>
        /// <param name="cartasDaRodada"> Cartas que, no instante, estão na mesa! </param>
        /// <param name="naipe_mao"> Naipe puxado pelo jogador mao </param>
        /// <param name="jogador_mao"> jogador que tem o dever de iniciar a jogada! </param>
        /// <returns> Objeto do tipo Carta, que na avaliação da inteligência do jogo é a melhor! </returns><summary>
        public Carta GetMelhorOpcaoEmbarcar(Naipe[] naipes_possiveis, CartasNaMao seuJogo, 
                                                 Carta[] cartasDaRodada, Naipe naipe_mao, Jogador jogador_mao) {
            /// Obs: Este método não pode retornar a Dama de Espadas (Miquilina).
            return new Carta(2, 12);
        }

        /// <summary>
        /// Método que retorna a carta de maior valor,
        /// dado o naipe que é recebido como parâmetro!
        /// </summary>
        /// <param name="seuJogo"> Cartas que, neste instante, estão na sua mão  </param>
        /// <param name="naipe"> Naipe a servir </param>
        /// <returns> Retorna um objeto carta </returns>
        private Carta GetSuaMaiorCartaDoNaipe(CartasNaMao seuJogo, Naipe naipe) {
            Carta retval = null; int Maior = 0;
            for (int i = 0; i < seuJogo.GetNumCartas(); i++) {
                if ((seuJogo[i].Valor > Maior ) && (Naipe)seuJogo[i].Naipe == naipe) retval = seuJogo[i];
            } return retval;
        }

        /// <summary>
        /// Método que retorna a carta de menor valor,
        /// dado o naipe que é recebido como parâmetro!
        /// </summary>
        /// <param name="seuJogo"> Cartas que, neste instante, estão na sua mão  </param>
        /// <param name="naipe"> Naipe a servir </param>
        /// <returns> Retorna um objeto carta </returns>
        private Carta GetSuaMenorCartaDoNaipe(CartasNaMao seuJogo, Naipe naipe)
        {
            Carta retval = null; int Menor = 14;
            for (int i = 0; i < seuJogo.GetNumCartas(); i++) {
                if ( (seuJogo[i].Valor < Menor) && (Naipe)seuJogo[i].Naipe == naipe ) retval = seuJogo[i];
            }  return retval;
        }

        //IMPLEMENTAR!!!
        /// <summary>
        /// A idéia deste método é retornar a carta que está vencendo
        /// a rodada, pois assim é  possível saber se é  uma boa  opção
        /// servir, por exemplo, Dama de Espadas numa rodada de mao
        /// igual a espadas, ou servir Rei quando há o Ás para assegurar
        /// que não levaria a Dama de Espadas. Ou, ainda, servir a própria
        /// Dama de Espadas, quando há Rei ou Ás como carta vencedora!!!
        /// Obs.: UMA LÓGICA SIMILAR PODERÁ SER IMPLEMENTADA PARA COPAS!
        /// </summary>
        /// <param name="cartasDaRodada"> Cartas que, no momento, estão na mesa </param>
        /// <returns> Retorna a carta que está vencendo a rodada </returns>
        private Carta GetVencendoARodada( Carta[] cartasDaRodada ) {
            return new Carta(2, 12);
        }


    }} // Fim do namespace;

