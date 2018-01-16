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
        public string Resposta { get; set; }

        public static int NumeroDeJogadores { get; set; }//Numero de jogadores da PARTIDA


        private static Jogador[] jogadores = new Jogador[50];//Cinquenta é um n° razoável. Poderia ser maior, porém não pode ser uma variável.

        public static void Menu() //Chama a tela de ínicio do jogo
        {
            string head = String.Format("-------------------------------    FORCA v1.0 APLHA    -------------------------\n");
            Console.WriteLine(head + "1 - Jogar!\n0 - Sair");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                Console.Clear();
                Console.WriteLine(head);
                Console.WriteLine("Digite o número de Usuários (Máximo de 50 Usuários)");//Não podem ser infinitos jogadores pois o vetor precisa de um tamanho definido
            }
            else
                Environment.Exit(0);//Se o jogador pressionar 0, ele fecha o jogo
        }
        
        public static void CadastrarJogadores(int n)//Cadastra os jogadores no Bando de Dados
        {

            NumeroDeJogadores = n;
            for (int i = 0; i < NumeroDeJogadores; i++)
            {
                Console.WriteLine("Nome do Jogador {0}", i + 1);
                jogadores[i] = new Jogador();//inicialização do array de jogadores(note que são os jogadores da partida e não TODOS os jogadores cadastrados
                jogadores[i].Nome = Console.ReadLine();


                SqlCommand cmd = new SqlCommand()
                {
                    Connection = new SqlConnection("Data Source=localhost; Initial Catalog=Forca;Integrated Security=SSPI"),
                    CommandText = String.Format(@"INSERT INTO Jogador(nome, pontuacao) values('{0}', 0);", jogadores[i].Nome)
                    //Cadastra os jogadores no Banco de Dados
                    //Ainda é preciso fazer possível "logar em sua conta" sem cadastrar uma nova
                };
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
        }

        public static void MostrarJogadores()//Mostra o nome dos Jogadores dentro do array jogadores
        {
            for (int i = 0; i < NumeroDeJogadores; i++)
            {
                Console.WriteLine("\nJogador{0}: {1}", i + 1, jogadores[i].Nome);
            }
        }
        
    }
}

