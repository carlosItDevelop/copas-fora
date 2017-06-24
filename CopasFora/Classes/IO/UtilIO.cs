using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CopasFora.Classes;
using CopasFora.Forms;
using CopasFora.Indexadores;
using CopasFora.Classes.Util;

namespace CopasFora.Classes.IO
{
    class UtilIO
    {
        FileInfo arquivo;
        StreamReader reader;
        /// <summary>
        /// Construtor da Classe;
        /// </summary>
        public UtilIO() { }

        public void CriarArquivoTexto( string path, string file ) { 
        }

        /*public string LerArquivoTexto( string file ) {
            arquivo = new FileInfo(file);
            reader = arquivo.OpenText();
            string texto = "";
            do
            {
                texto += reader.ReadLine();
            } while (reader() != null);//Revisar esta linha!
            return texto;
        }*/

        public void GravaArquivoTexto(string file)
        {
        }



    }} // Fim do namespace;
