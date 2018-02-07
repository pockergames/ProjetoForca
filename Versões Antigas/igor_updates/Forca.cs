using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/* TODO List (Forca.cs) */
// Pegar palavra aleatória de tema aleatório
// Pegar palavra aleatória de tema escolhido

namespace ForcaWPF
{
    class Forca
    {
		// Resposta correta da partida. Ela recebe a palavra aleatória que vem do BD e será, posteriormente, escondida pelos traços
        public static string Resposta { get; set; }
		
		// Respectivo tema da palavra
        public static string Tema { get; set; }

		// A pontuação de uma única letra
        public const int PONTUACAO_POR_LETRA = 5;
		
        //public const int PONTUACAO_PALAVRA_INTEIRA = 0;

		// Pega uma palavra aleatória do banco de dados com seu respectivo tema
        public static void PegarPalavraAleatoria()
        {
            SqlCommand cmd = new SqlCommand()
            {
				// String de conexão
                Connection = new SqlConnection("Data Source=localhost; Initial Catalog=Forca; Integrated Security=SSPI"),
				
				// Comando para pegar uma palavra aleatória e seu respectivo tema
                CommandText = @"SELECT TOP 1 p.nome, t.nome FROM Palavra AS p, Tema AS t WHERE(t.id = p.tema_id) ORDER BY NEWID();"
            };
			
			// Abre a conexão com o BD
            cmd.Connection.Open();
			
			// Instacia um SqlDataReader para ler as colunas
            SqlDataReader reader = cmd.ExecuteReader();
			
			// Enquanto o reader ele pode ler
            while (reader.Read())
            {
				// Pega o conteúdo da coluna 0 (a palavra aleatória) e põe em Resposta
                Resposta = (reader.GetString(0));
				
				// Pega o conteúdo da coluna 1 (respectivo tema) e põe em Tema
                Tema = (reader.GetString(1));
            }
			
			// Fecha a conexão com o BD.
            cmd.Connection.Close();

            //Resposta = "carbono";
            //Tema = "Química é louca";
        }




    }
}
