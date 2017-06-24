using System;
using System.Collections.Generic;
using System.Text;

namespace CopasFora.Classes
{
    /// <summary>
    /// Classe Jogador, que é, sem dúvida
    /// o principal objeto desse jogo!!!
    /// </summary>
    public class Jogador
    {
        string nome = "";
        int pontos = 0;

        /// <summary>
        /// Construtor da Classe/Objeto
        /// </summary>
        /// <param name="nome"> O Nome do Jogador </param>
        public Jogador(string nome)
        {
            this.nome = nome;
        }

        public override string ToString() {
            return this.nome;
        }

        #region :: Properties of the Object
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public int Pontos
        {
            get { return pontos; }
            set { pontos = value; }
        }
        #endregion

    }} // Fim do namespace;
