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
            Console.WriteLine("Digite o número de Usuários (Máximo de 30 Usuários)");
            Forca.CadastrarUsuarios(int.Parse(Console.ReadLine()));
            Forca.MostrarUsuarios();
        }
    }
}
