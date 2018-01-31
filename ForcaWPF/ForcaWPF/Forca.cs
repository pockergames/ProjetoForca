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

        public static void PegarPalavraAleatoria()//Pega uma palavra aleatória do banco de dados com seu respectivo tema
        {
            SqlCommand cmd = new SqlCommand()//Instancia um novo SqlCommand
            {
                Connection = new SqlConnection("Data Source=localhost; Initial Catalog=Forca; Integrated Security=SSPI"),//String de conexão
                CommandText = @"SELECT TOP 1 p.nome, t.nome FROM Palavra AS p, Tema AS t WHERE(t.id = p.tema_id) ORDER BY NEWID();"//Comando para pegar uma palavra aleatória e seu respectivo tema
            };
            cmd.Connection.Open();//Abre a conexão com o BD
            SqlDataReader reader = cmd.ExecuteReader();//Instacia um SqlDataReader para ler as colunas
            while (reader.Read())//Enquanto o reader ele pode ler
            {
                Resposta = (reader.GetString(0));//Pega o conteúdo da coluna 0 (a palavra aleatória) e põe em Resposta
                Tema = (reader.GetString(1));//Pega o conteúdo da coluna 1 (respectivo tema) e põe em Tema
            }
            cmd.Connection.Close();//Fecha a conexão com o BD.
        }




    }
}
