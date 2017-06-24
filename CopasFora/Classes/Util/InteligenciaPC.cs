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
    public class InteligenciaPC
    {
        #region :: Members of the Class;
        #endregion

        /// <summary>
        /// Construtor padr�o, sem par�metros;
        /// </summary>
        public InteligenciaPC (  )
        {
        }

        /// <summary>
        /// Em fase de projeto!
        /// Este m�todo vai substituir o m�todo
        /// BuscaCartaMesmoNaipe()
        /// </summary>
        /// <param name="seuJogo"> O jogo que, no instante, est� na sua m�o </param>
        /// <param name="cartasDaRodada"> As cartas que, no instante, est�o na mesa </param>
        /// <returns> Retorna um objeto do tipo Carta </returns>
        public Carta GetMelhorCarta(CartasNaMao seuJogo, Carta[] cartasDaRodada, Naipe naipe_mao, 
                                                          Jogador jogador_mao, Jogador jogador_vez )
        {
            Carta retval = null;
            /// REVISAR SEMPRE ESTE SUMMARY, POIS EL S� DEVE SER APAGADO DEPOIS DE PRONTO!
            /// OBS: DEIXAR A REGION FECHADA E POUSAR O MOUSE PARA LER. ABRIR PARA REVISAR!!!
            #region :: Summary com detalhes da Implementa��o do m�todo!
            ///<summary>
            /// ** Carta m�o != (copas && espadas);
            /// 01 - Avalia se tem o naipe para servir;
            /// 02 - Caso negativo, verificar se � a primeira rodada;
            /// 03 - Caso negativo, verificar se est� com dama de espadas;
            /// 04 - Caso positivo embarcar dama de espadas;
            /// 04 - Caso negativo, verificar se copas est� aberta;
            /// 05 - Caso positivo, servir copas;
            /// 06 - No caso de embarcar copas servir sempre o maior valor na sua m�o;
            /// 07 - No caso de n�o ter o naipe m�o, mas tamb�m n�o ter nem copas e nem a dama de espadas,
            /// Escolher um naipe e embarcar o maior valor desse naipe;
            /// ** - Voc� � o m�o e n�o � a primeira rodada;
            /// 01 - Escolha um naipe != Espadas && Copas;
            /// 02 - Se houver pelo menos 5 cartas do mesmo naipe ainda a ser jogada, sem contar as suas,
            /// obviamente, Voc� deve sair com a maior carta deste naipe
            /// ** - Caso a carta m�o seja espadas:
            /// 01 - Verifica se a dama de espadas j� saiu;
            /// 02 - caso positivo, ****
            /// ** - caso a carta m�o seja copas;
            /// 01 - se vc for o �ltimo jogador da rodada avalie dois casos;
            /// 02 - se voc� n�o tem como servir uma carta menor para fugir de pegar esta rodada,
            /// ent�o sirva a maior que vc tiver de copas
            ///</summary>
            #endregion
            //Escolhe Naipe;
            switch (naipe_mao) { 
                case Naipe.Paus:
                    // Verifica se "voc�(PCn)" � o m�o!
                    //=-=-=-=-=-=-=-=-=-=-=-=-=/.
                    //Obs.: N�o � necess�ria a verifica��o
                    //de NumRodada, pois se fosse a primeira
                    //Seria disparado no m�todo Procura2Paus();
                    if (jogador_mao.Nome == jogador_vez.Nome) {
                        //Verifica se vc tem copas e tem o 
                        //dois de copas e copas est� aberta!? 
                        //(NO FUTURO AVALIAR SE TEM A "MENOR" CARTA DE COPAS)
                        if ((seuJogo.GetNumCopas() > 0) && (TemACarta("Dois de Copas", seuJogo)) && (Contador.copasAbertas)) {
                            retval = GetTheCards("Dois de Copas", seuJogo );
                        } else {
                            //Esta implementa��o deve ser OTIMIZADA,
                            //no sentido de buscar a melhor carta <> 2copas
                            retval = GetAnyCards(seuJogo);
                        }
                    } else {
                        //Verifica se tem Paus na M�o,
                        //caso em que ter� que servir!!
                        if (seuJogo.GetNumPaus() > 0) {
                            //Desenvolver: (Vc tem paus! Dever� jogar paus!!!)
                            retval = GetMelhorOpcaoServir(new Naipe[] { Naipe.Paus }, seuJogo,
                                                                    cartasDaRodada, naipe_mao, jogador_mao);
                        } else {
                            //N�o tem paus para servir.
                            //Verifica se estamos na 1� rodada, caso em que n�o poder�o
                            //ser embarcadas copas e nem a dama de espadas!!!
                            if (Contador.numRodada <= 1) {
                                //Vc vai embarcar, mas n�o pode ser copas 
                                //e nem a dama de espadas, visto que est� na primeira rodada!
                                retval = GetMelhorOpcaoEmbarcar(new Naipe[] { Naipe.Espadas, Naipe.Ouros } , seuJogo,
                                                                                                        cartasDaRodada, naipe_mao, jogador_mao);
                            } else {
                                //N�o tem paus para servir. Avalia se j� foi 
                                //aberta copas. Al�m disso, tamb�m avalia se vc tem copas,
                                // caso contr�rio essa abordagem seria in�til!
                                //Obs.: NESTA ABORDAGEM (IF), DAMOS PREFER�NCIA 
                                //� COPAS  EM  DETRIMENTO  DA  DAMA DE ESPADAS, 
                                //QUE TEM SUA IMPLEMENTA��O NA CR�TICA DO "ELSE".
                                if (Contador.copasAbertas && seuJogo.GetNumCopas() > 0) {
                                    //Vc vai jogar copas!
                                    retval = GetMelhorOpcaoEmbarcar(new Naipe[] { Naipe.Copas } , seuJogo,
                                                                                    cartasDaRodada, naipe_mao, jogador_mao);
                                } else {
                                    // Verifica se vc est� com a miquilina.
                                    // Para manter padr�o, verificar se miquilina saiu. 
                                    // N�O seria necess�rio, visto que vc avalia se EST� com ela ou n�o!
                                    if ((!Contador.miquilinaSaiu) && seuJogo.EstaComMiquilina()) {
                                        //Seta retval com dama de espadas!
                                        for (int i = 0; i < seuJogo.GetNumCartas(); i++)
                                        {
                                            if (seuJogo[i].Valor == 12 && (seuJogo[i].Naipe == (int)(Naipe.Espadas))) retval = seuJogo[i];
                                        }
                                    } else {
                                        //Vc n�o tem paus, mas tb n�o pode jogar copas e nem a miquilina!
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
                    // N�o faz nada, pois nunca deveremos chegar at� aqui!
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
        /// M�todo que retorna a "melhor" carta do mesmo naipe do m�o!
        /// Ele recebe, de uma "classe an�nima" um array com os naipes poss�veis para servir!
        /// <param name="naipes_possiveis"> Array de naipes poss�veis para servir </param>
        /// <param name="seuJogo"> O jogo que, no instante, o jogador tem na m�o! </param>
        /// <param name="cartasDaRodada"> Cartas que, no instante, est�o na mesa! </param>
        /// <param name="naipe_mao"> Naipe puxado pelo jogador mao </param>
        /// <param name="jogador_mao"> jogador que tem o dever de iniciar a jogada! </param>
        /// <returns> Objeto do tipo Carta, que na avalia��o da intelig�ncia do jogo � a melhor! </returns><summary>
        public Carta GetMelhorOpcaoServir(Naipe[] naipes_possiveis, CartasNaMao seuJogo, 
                                            Carta[] cartasDaRodada, Naipe naipe_mao, Jogador jogador_mao)
        {
            // Desenvolver!!! RETORNAR MELHOR CARTA PARA SERVIR!
            return new Carta(2, 12);
        }

        //IMPLEMENTAR!!!!
        /// <summary>
        /// M�todo que retorna a "melhor" carta do mesmo naipe do m�o!
        /// Ele recebe, de uma "classe an�nima", um array com os naipes poss�veis para embarcar.
        /// Obs: Este m�todo n�o pode retornar a Dama de Espadas (Miquilina).
        /// <param name="naipes_possiveis"> Array de naipes poss�veis para embarcarr </param>
        /// <param name="seuJogo"> O jogo que, no instante, o jogador tem na m�o! </param>
        /// <param name="cartasDaRodada"> Cartas que, no instante, est�o na mesa! </param>
        /// <param name="naipe_mao"> Naipe puxado pelo jogador mao </param>
        /// <param name="jogador_mao"> jogador que tem o dever de iniciar a jogada! </param>
        /// <returns> Objeto do tipo Carta, que na avalia��o da intelig�ncia do jogo � a melhor! </returns><summary>
        public Carta GetMelhorOpcaoEmbarcar(Naipe[] naipes_possiveis, CartasNaMao seuJogo, 
                                                 Carta[] cartasDaRodada, Naipe naipe_mao, Jogador jogador_mao) {
            /// Obs: Este m�todo n�o pode retornar a Dama de Espadas (Miquilina).
            return new Carta(2, 12);
        }

        /// <summary>
        /// M�todo que retorna a carta de maior valor,
        /// dado o naipe que � recebido como par�metro!
        /// </summary>
        /// <param name="seuJogo"> Cartas que, neste instante, est�o na sua m�o  </param>
        /// <param name="naipe"> Naipe a servir </param>
        /// <returns> Retorna um objeto carta </returns>
        private Carta GetSuaMaiorCartaDoNaipe(CartasNaMao seuJogo, Naipe naipe) {
            Carta retval = null; int Maior = 0;
            for (int i = 0; i < seuJogo.GetNumCartas(); i++) {
                if ((seuJogo[i].Valor > Maior ) && (Naipe)seuJogo[i].Naipe == naipe) retval = seuJogo[i];
            } return retval;
        }

        /// <summary>
        /// M�todo que retorna a carta de menor valor,
        /// dado o naipe que � recebido como par�metro!
        /// </summary>
        /// <param name="seuJogo"> Cartas que, neste instante, est�o na sua m�o  </param>
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
        /// A id�ia deste m�todo � retornar a carta que est� vencendo
        /// a rodada, pois assim �  poss�vel saber se �  uma boa  op��o
        /// servir, por exemplo, Dama de Espadas numa rodada de mao
        /// igual a espadas, ou servir Rei quando h� o �s para assegurar
        /// que n�o levaria a Dama de Espadas. Ou, ainda, servir a pr�pria
        /// Dama de Espadas, quando h� Rei ou �s como carta vencedora!!!
        /// Obs.: UMA L�GICA SIMILAR PODER� SER IMPLEMENTADA PARA COPAS!
        /// </summary>
        /// <param name="cartasDaRodada"> Cartas que, no momento, est�o na mesa </param>
        /// <returns> Retorna a carta que est� vencendo a rodada </returns>
        private Carta GetVencendoARodada( Carta[] cartasDaRodada ) {
            return new Carta(2, 12);
        }


    }} // Fim do namespace;

