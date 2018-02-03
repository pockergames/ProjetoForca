using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaWPF
{
    class Forca
    {
        public static string Resposta { get; set; }//Resposta correta da partida. Ela recebe a palavra aleatória que vem do BD e será, posteriormente, escondida pelos traços
        public static string Tema { get; set; }//Respectivo tema da palavra

        public const int PONTUACAO_POR_LETRA = 10;
        public const int PONTUACAO_PALAVRA_INTEIRA = 10;

        public static void PegarPalavraAleatoria()//Pega uma palavra aleatória do banco de dados com seu respectivo tema
        {
            Resposta = "carbono";
            Tema = "Química é louca";
        }




    }
}
