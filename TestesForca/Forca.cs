using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesForca
{
    class Forca
    {
        public string Resposta { get; set; }

        public static int NumeroDeJogadores { get; set; }
        

        private static Jogador[] jogador = new Jogador[50];

        public static void CadastrarUsuarios(int n)
        {
            NumeroDeJogadores = n;
            for (int i = 0; i < NumeroDeJogadores; i++)
            {
                Console.WriteLine("Nome do Jogador {0}", i + 1);
                jogador[i] = new Jogador();
                jogador[i].Nome = Console.ReadLine();
                
            }
        }

        public static void MostrarUsuarios()
        {
            for (int i = 0; i < NumeroDeJogadores; i++)
            {
                Console.WriteLine("\nJogador{0}: {1}", i + 1, jogador[i].Nome);
            }
        }
    }
}
