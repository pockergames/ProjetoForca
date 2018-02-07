using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesForca
{
    class Jogador
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Chute { get; set; }
        public int Pontuacao { get; set; }

        private static Jogador[] jogadoresDaPartida = new Jogador[50];//Cinquenta é um n° razoável. Poderia ser maior, porém não pode ser uma variável.

        public static void CadastrarJogador(int i)//Cadastra os jogadores no Bando de Dados
        {
            Console.WriteLine("Nome do Jogador {0}", i + 1);
            jogadoresDaPartida[i] = new Jogador();//inicialização do array de jogadores(note que são os jogadores da partida e não TODOS os jogadores cadastrados
            jogadoresDaPartida[i].Nome = Console.ReadLine();


            SqlCommand cmd = new SqlCommand()
            {
                Connection = new SqlConnection("Data Source=localhost; Initial Catalog=Forca;Integrated Security=SSPI"),
                CommandText = String.Format(@"INSERT INTO Jogador(nome, pontuacao) values('{0}', 0);", jogadoresDaPartida[i].Nome)
                //Cadastra os jogadores no Banco de Dados
                //Ainda é preciso fazer possível "logar em sua conta" sem cadastrar uma nova
            };
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static void MostrarJogadores()//Mostra o nome dos Jogadores dentro do array jogadores
        {

            for (int i = 0; i < jogadoresDaPartida.Length; i++)
            {
                Console.WriteLine("\nJogador{0}: {1}", i + 1, jogadoresDaPartida[i].Nome);
            }
        }
    }
}
