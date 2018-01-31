using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesForca
{
    class Forca
    {
        public static string Resposta { get; set; }

        public static void Menu() //Chama a tela de ínicio do jogo
        {
            string head = String.Format("-------------------------------    FORCA v1.0 APLHA    -------------------------\n");
            Console.WriteLine(head + "1 - Jogar!\n0 - Sair");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                Console.Clear();
                Console.WriteLine(head);
                Console.WriteLine("Digite o número de Jogadores (Máximo de 50 jogadores)");//Não podem ser infinitos jogadores pois o vetor precisa de um tamanho definido
            }
            else
                Environment.Exit(0);//Se o jogador pressionar 0, ele fecha o jogo
        }
        public static void MostrarPalavra()
        {
            string tema =  "";
            char[] palavraEscondida = new char[Resposta.Length];
            SqlCommand cmd = new SqlCommand()
            {
                Connection = new SqlConnection("Data Source=localhost; Initial Catalog=Forca; Integrated Security=SSPI"),
                CommandText = @"SELECT TOP 1 p.nome, t.nome FROM Palavra AS p, Tema AS t WHERE(t.id = p.tema_id) ORDER BY NEWID();"
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Resposta = (reader.GetString(0));
                tema = (reader.GetString(1));
            }
            
            for(int i = 0; i < Resposta.Length; i++)
            {
                palavraEscondida[i] = '_';
            }
            Console.WriteLine(palavraEscondida);

            cmd.Connection.Close();
            Console.WriteLine("Tema: {0}\n ", tema);

        }




    }
}

