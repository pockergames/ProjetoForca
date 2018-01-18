using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeTemasDeveloperApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string txtTemas = "";
            Menu:
            Console.WriteLine("1 - Criar novos temas \n\n2 - Adicionar Palaras\n\n");
            Opcao1:
            if (int.Parse(Console.ReadLine()) == 1)
            {
                Console.Clear();
                Console.WriteLine("Digite o número de temas");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    txtTemas += Console.ReadLine() + '\n';
                }

                string[] temas = txtTemas.Split('\n');
                for(int i  = 0; i < n; i++)
                {
                    if (temas[i] != "\n")
                    {
                        Tema.NovoTema(temas[i]);
                        Console.WriteLine(temas[i] + " foi cadastrado\n");
                    }
                }
                Console.WriteLine("Sucesso!");
                Console.Clear();
                goto Menu;
                    
            }
            else if(int.Parse(Console.ReadLine()) == 2 && Tema.MostrarTemas() != "\n")
            {
                Console.Clear();
                Console.WriteLine("Escolha o Tema em que deseja adicionar a palavra");
                txtTemas = Tema.MostrarTemas();
                string[] temas = txtTemas.Split('\n');
                for (int i = 1; i < temas.Length - 1; i++)
                {
                    Console.WriteLine(i + " - " + temas[i]);
                }
                
                Console.WriteLine("\n");
                int idEscolhido = int.Parse(Console.ReadLine());
                Console.Clear();

                string txtPalavras = " ";

                Console.WriteLine("Digite o número de palavras");
                int numeroDePalavras = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite as palavras");
                for (int i = 0; i < numeroDePalavras; i++)
                {
                  txtPalavras += Console.ReadLine() + "\n";
                }
                string[] palavras = txtPalavras.Split('\n');
                for(int i = 0; i < palavras.Length - 1; i++)
                {
                    if (palavras[i] != "\n" || palavras[i] != "")
                    {
                        Palavra.NovaPalavra(idEscolhido, palavras[i]);
                        Console.WriteLine("\n" + palavras[i] + "foi cadastrada");
                    }
                }
                Console.WriteLine("Sucesso!");
                Console.ReadLine();
                Console.Clear();
                goto Menu;
                   

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Não há temas");
                Console.WriteLine("Digite 1 para adicionar novos temas");
                goto Opcao1;
            }

        }
        
    }
}
