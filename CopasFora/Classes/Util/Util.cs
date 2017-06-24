/*
 * Class/Objeto Util;
 * By: Carlos Alberto
 * 
 * - Esta classe agrega algumas funçoes
 * úteis ao projeto. Não só a este, mas a
 * muitos outros, pois ela pode ser cada 
 * vez mais generalida.
 * IMPORTANTE: E desaconselhável a utilização
 * indiscriminada de métodos "static", pois
 * eles não são instanciáveis, e quebra um
 * pouco o padrão do desenvolvimento em OOP.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Media;

namespace CopasFora.Classes.Util
{
    
    class Util
    {
        #region :: Members of the class;
        public const MessageBoxButtons icoOk = MessageBoxButtons.OK;
        public const MessageBoxIcon icoErro = MessageBoxIcon.Error;
        public const MessageBoxIcon icoInfo = MessageBoxIcon.Information;

        private static String user;
        private static String date;
        private static String referencia;

        public enum Banco { SQLServer=1, Oracle=2, Access=3 };
        #endregion

        /// <summary>
        /// Construtor da Classe/Objeto
        /// </summary>
        public Util()
        { 
        }

        /// <summary>
        /// Método que visa substituir a
        /// utilização cansativa do objeto: MessageBox
        /// </summary>
        /// <param name="mensagem">Mensagem a ser impressa em box</param>
        public static void MsgErro(string mensagem)
        {
            MessageBox.Show(mensagem, Application.ProductName + " - " +
                            Application.ProductVersion,
                            icoOk,
                            icoErro);
        }

        public static void MsgInfo(string mensagem)
        {
            MessageBox.Show(mensagem, Application.ProductName + " - " +
                            Application.ProductVersion,
                            icoOk,
                            icoInfo);
        }

        public static void Msg(string mensagem)
        {
            MessageBox.Show(mensagem, Application.ProductName + " - " +
                            Application.ProductVersion,
                            icoOk,
                            icoInfo);
        }

        /* AINDA NÃO FOI IMPLEMENTADO, E NEM USADO!
        public static string FormataData(string data) {
            string strdata = "";
            return strdata;
        }*/

        /// <summary>
        /// Método para tocar um .wav pequeno
        /// em situações específicas, como por exemplo, RENÚCIA!
        /// </summary>
        /// <param name="path"></param>
        public static void TocaWav( string path ) {
            try
            {
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = path;

                // Load the .wav file.
                player.Load();
                player.Play();
            }
            catch (Exception ex)
            {
                MsgErro(ex.Message);
            }

        }
        /* ESTE MÉTODO EU ACHEI NA INTERNET.
         * PERDOEM-ME POR NÃO ME LEMBRAR DA FONTE.
         * AINDA VOU ENCONTRAR PARA CITÁ-LA!!!
         */
        /// <summary>
        /// Método sobrecarregado, que gera um novo Id para
        /// inserção de novos registros nas tabelas especificadas!
        /// </summary>
        /// <param name="cn">Connexão aberta</param>
        /// <param name="banco">Tipo enumerado Banco</param>
        /// <param name="tabela">Tabela que controla os Id's</param>
        /// <returns>Retorna um valor inteiro único!</returns>
        public static string GerarID(SqlConnection cn, Banco banco , string tabela)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            string Resultado;
            SqlDataReader Leitor;
            if (banco == Banco.Oracle) {
                cmd.CommandText = "SELECT " + tabela + ".NEXTVAL FROM DUAL";
                Leitor = cmd.ExecuteReader();
                Leitor.Read();
                Resultado = Leitor[0].ToString();
                Leitor.Close();
                // No Oracle, não precisa haver exclusão
            } else {
                cmd.CommandText = "INSERT INTO " + tabela + " ( Inutil ) VALUES( 'X' )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@identity";
                Leitor = cmd.ExecuteReader();
                // É comum usar um while mas, no nosso caso,
                // temos certeza absoluta de que só há um
                // único registro a ser lido
                Leitor.Read();
                Resultado = Leitor[0].ToString();
                Leitor.Close();
                cmd.CommandText = "DELETE FROM " + tabela + " WHERE ID = " + Resultado;
                cmd.ExecuteNonQuery();
            }
            return Resultado;
        }

        /* ESTE EU ADAPTEI (SOBREGARREGUEI) */
        /// <summary>
        /// Método sobrecarregado, que usa 
        /// string ao invéz de enum para Banco!
        /// </summary>
        /// <param name="cn"></param>
        /// <param name="banco"></param>
        /// <param name="tabela"></param>
        /// <returns></returns>
        public static string GerarID(SqlConnection cn, string banco, string tabela)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            string Resultado;
            SqlDataReader Leitor;
            if (banco == "Oracle")
            {
                cmd.CommandText = "SELECT " + tabela + ".NEXTVAL FROM DUAL";
                Leitor = cmd.ExecuteReader();
                Leitor.Read();
                Resultado = Leitor[0].ToString();
                Leitor.Close();
                // No Oracle, não precisa haver exclusão
            } else {
                cmd.CommandText = "INSERT INTO " + tabela + " ( Inutil ) VALUES( 'X' )";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT @@identity";
                Leitor = cmd.ExecuteReader();
                // É comum usar um while mas, no nosso caso,
                // temos certeza absoluta de que só há um
                // único registro a ser lido
                Leitor.Read();
                Resultado = Leitor[0].ToString();
                Leitor.Close();
                cmd.CommandText = "DELETE FROM " + tabela + " WHERE ID = " + Resultado;
                cmd.ExecuteNonQuery();
            }
            return Resultado;
        }

        /// <summary>
        /// Método generalizado para preenchimento de ComboBox.
        /// </summary>
        /// <param name="cn">Objeto SQLConnection de System.Data.SQLClient</param>
        /// <param name="cbo">ComboBox (Passem o objeto e não o conteúdo)</param>
        /// <param name="tabela">Nome da Tabela que tem os dados para a listas</param>
        /// <param name="campo">Campo com o conteúdo, que será listado de forma distinta (Distinct)</param>
        public static void PreencheCombo(SqlConnection cn, ComboBox cbo, String tabela, String campo)
        {
            String cmdString = "select distinct " + campo + " from " + tabela + " order by " + campo;
            SqlCommand cmd = new SqlCommand(cmdString, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            cbo.Items.Clear();
            while (dr.Read())
            {
                cbo.Items.Add(dr[campo]);
            }
            dr.Close();
        }

        public static void SetaValGlobal(SqlConnection cn)
        {
            String strconn = "select referencia from indice";
            SqlCommand cmd = new SqlCommand(strconn, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Referencia = dr["referencia"].ToString();
            }
            dr.Close();
            // Setar data global;
            Date = System.DateTime.Now.ToShortDateString();
        }


        #region ::: Rotina TeclaDigitada
        /*
         * Rotina para verificar se um dado digitado
         * é numérico. Esta rotina é chamada no evento
         * KeyDown de um TextBox e é útil ao evento
         * KeyPress do mesmo.
         */
        public static string TeclaDigitada(KeyEventArgs e)
        {
            // Determina se foi pressionada uma tecla numérica de cima do
            // do teclado ou se foi pressionada uma tecla do NumPad!
            if ( (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) 
                                        || (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) )
            {
                return "numero";
            } else if ( e.KeyCode == Keys.Back ) {
                return "back";
            } else {
                return "";
            }
        }
        #endregion


        #region :: Propriedades do Objeto!
        public static String Referencia
        {
            get { return Util.referencia; }
            set { Util.referencia = value; }
        }
        public static String User
        {
            get { return Util.user; }
            set { Util.user = value; }
        }
        public static String Date
        {
            get { return Util.date; }
            set { Util.date = value; }
        }
        #endregion


    } // Fim da Classe;
} // Fim do Namespace;

