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
            Forca.CadastrarJogadores(int.Parse(Console.ReadLine()));
            //Forca.MostrarJogadores();
            
            
            
        }
    }
}
