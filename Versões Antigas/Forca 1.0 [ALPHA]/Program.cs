using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestesForca
{
    class Program
    {
        static void Main(string[] args)
        {
            Forca.Menu();
            int numeroDeJogadores = int.Parse(Console.ReadLine());//Numero de jogadores da PARTIDA
            for (int i = 0; i < numeroDeJogadores; i++)
            {
                Jogador.CadastrarJogador(i);
            }
            //Jogador.MostrarJogadores();
            Forca.MostrarPalavra();

        }
    }
}
