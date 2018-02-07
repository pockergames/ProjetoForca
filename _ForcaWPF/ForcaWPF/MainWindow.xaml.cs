using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

/* TO-DO List (MainWindow.xaml.cs) */
// Checar se a variável nJog é realmente necessária (já que é equivalente ao tamanho do List)
// Consertar pontuação para não aumentar quando colocaram a mesma letra 

namespace ForcaWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
		// n° de jogadores adicionados
        private int nJog = 0;
		
		// indíce do jogador atual
		private int vez = 0;
		
		// pontuacao com a qual todos jogadores iniciam no jogo
		private int pontuacaoInicial = 0;
		
		// n° máximo de jogadores na partida. Escolhi 100 , mas este valor pode ser alterado
        //private int maxDeJogadores = 100; 

		// List que vai alocar os jogadores da partida
        private List<Jogador> jogadores = new List<Jogador>();

        // As corres do texto "Vez de <jogador>!"
        private Brush[] coresArcoIris;
        
        // Índice da cor 
        private int corAtualIndex = 0;

        private List<char> letrasCertas = new List<char>();

        private List<char> letrasErradas = new List<char>();

        // Este vai ser o jogador que receberá os pontos quando uma palavra ou letra estiver certa e vai ter o nome marcado
        //Jogador JogadorAtual = new Jogador(); 

        public MainWindow()
        {
            InitializeComponent();
            Forca.PegarTemas();
            combo_Temas.Items.Add("Tema Aleatório");
            for(int i = 1; i < Forca.Temas.Count; i++)
            {
                combo_Temas.Items.Add(Forca.Temas[i]);
            }
            coresArcoIris = new Brush[9]
            {
                Brushes.Red,
                Brushes.DarkOrange,
                Brushes.Yellow,
                Brushes.YellowGreen,
                Brushes.Green,
                Brushes.Cyan,
                Brushes.Blue,
                Brushes.Purple,
                Brushes.Pink
            };
        }

        private void btn_addJogador_Click(object sender, RoutedEventArgs e)
        {
			// Se a caixa de texto que recebe o nome estiver vazia,
			// mude o foco para ela
            if (txt_nome.Text == "") 
                txt_nome.Focus();    
			
			// Se tiver algo na caixa de texto
            else                     
            {
				// cria uma instância do objeto jogador dentro do Array jogadores na posicao nJog(que tem como primeiro valor, 0)
                jogadores.Add(new Jogador()); 

				// Atribui ao Nome do jogador o texto digitado na textField acima
                jogadores[nJog].Nome = txt_nome.Text; 

				// Inicializa a pontuação do jogador que está sendo instanciado com a pontuacao inicial
                jogadores[nJog].Pontuacao = pontuacaoInicial; 

				// Limpa a textField que recebe o nome
                txt_nome.Clear();

				// Escreve o nome do Jogador e sua pontuacao na caixa cinzenta com scroll abaixo do botão "Nova Partida"
                //scroll_pontuacao.Content += String.Format("{0} : {1} pontos\n\n", jogadores[nJog].Nome, jogadores[nJog].Pontuacao);
				//scroll_pontuacao.Content += jogadores[nJog].ToString();
                
				// Incrementa o numero de jogadores.
				// Isto serve para que, na próxima vez que o usuário pressionar o botão "Adicionar Jogador", o array de jogadores mude de posição 
                nJog++;
                AtualizarPlacar();
            }           
        }

		//Inicia uma nova partida
        private void btn_novaPartida_Click(object sender, RoutedEventArgs e)
        {
			// Inicializa o label que mostra a palavra da partida(não é muito necessário, pois ele provavelmente faz isso sozinho)
            txt_palavra.Content = "";
            

			// Se não houver ao menos 1 jogador cadastrado
            if (nJog == 0)
                MessageBox.Show("É preciso haver no mínimo 1 jogador!");

            else if (combo_Temas.SelectedItem.ToString() == "Tema Aleatório")
            {

				// Executa um método da classe Forca que busca, do banco de dados, um palavra aleatória e seu respectivo tema
                Forca.PegarPalavraAleatoria();

                EsconderPalavra();
				
				//O label menor, o tema, recebe o tema da respectiva palavra
                lbl_tema.Content = Forca.Tema; 

            }
            else
            {

                Forca.PegarPalavraDeTema(combo_Temas.SelectedIndex);

                EsconderPalavra();

                lbl_tema.Content = Forca.Temas[combo_Temas.SelectedIndex];

            }
           
            // Põe o nome do jogador atual em cima no placar(a ScrollBox).
            MarcarJogador();

            ZerarPontuacao();

            Forca.JogoRolando = true;

            lbl_jogadorAtual.Foreground = coresArcoIris[0];

            letrasErradas.Clear();
            txtLetrasErradas.Text = "";

            
        }
        
		
		// Limpa a pontuação de todos os jogadores e atualiza no placar
        private void ZerarPontuacao()
        {
            for(int i = 0; i < nJog; i++)
            {
                jogadores[i].Pontuacao = 0;
            }
            AtualizarPlacar();
        }

        private void btn_chute_Click(object sender, RoutedEventArgs e)
        {

            txt_chute.Text = txt_chute.Text.ToLower();

            if (txt_chute.Text.Length > 1)
            {
                // se a pessoa chutar a palavra inteira
                if (AcertouPalavra() && Forca.JogoRolando)
                {
                    // Alterei o nome para um mais intuitivo
                    DarPontuacaoPalavra();

                    // Mostra a palavra
                    txt_palavra.Content = Forca.Resposta;

                    Forca.JogoRolando = false;
                }

                else if (!AcertouPalavra() && Forca.JogoRolando)
                    TirarPontuacaoPalavra();
            }


            // Se a pessoa digitar uma única letra
            else if (txt_chute.Text.Length == 1 && Forca.JogoRolando)
            {
                // A palavra Resposta transformada em array de chars. Ex: ['c', 'a', 'r', 'b', 'o', 'n', 'o']
                char[] respostaArray = Forca.Resposta.ToCharArray();

                // A letra chutada
                char chute = txt_chute.Text[0];

                // O resultado (ainda em array) que vai ser mostrado na tela. Ex: ['c', '-', '-', 'b', '-', '-', '-']
                char[] mostrarArray = txt_palavra.Content.ToString().ToCharArray();

                // Quantidade de vezes que a letra que o jogador disse aparece. Ex: carbono, se o jogador falar 'o' -> qtdAcertos = 2
                int qtdAcertos = 0;

                // Substitui '-' pela letra acertada e soma a quantidade de letras acertadas
                for (int i = 0; i < Forca.Resposta.Length; i++)
                {
                    if (chute == respostaArray[i] || chute == Char.ToLower(respostaArray[i]) && chute != mostrarArray[i * 2])
                    {
                        letrasCertas.Add(chute);
                        mostrarArray[i * 2] = chute;
                        qtdAcertos++;
                        DarPontuacaoLetra();
                    }
                }

                // String que aparece na tela. Ex "c-rbono"
                string mostrar = "";

                // passando o array de chars para string
                foreach (char letra in mostrarArray)
                    mostrar += letra;

                // alterando o valor do label 
                txt_palavra.Content = mostrar;

                if (!letrasErradas.Contains(chute) && !letrasCertas.Contains(chute))
                {
                    letrasErradas.Add(chute);
                    TirarPontuacaoLetra();
                }

                else if (Forca.Resposta == (string)txt_palavra.Content)
                {
                    Forca.JogoRolando = false;
                    qtdAcertos = 0;
                }

                else
                    qtdAcertos = 0;

                // Soma à pontuação 
                jogadores[vez].Pontuacao += Forca.PONTUACAO_POR_LETRA * qtdAcertos;

                TrocarCorDoAtual();
                AtualizarLetrasErradas();
            }

            else
            {
                // A pessoa não escreveu nada e botou chutar
                txt_chute.Focus();
            }

			// Limpar o textBox onde será escrita a palavra de chute
            txt_chute.Text = "";

            // Atualiza a pontuação do jogador diretamente no scrollbar
            AtualizarPlacar();

            // Muda o índice do jogador atual para o do próximo jogador
            PassarVez();

            // Marca o próximo jogador
            MarcarJogador();

            // Testar se o jogo acabou
            if (txt_palavra.Content.ToString() == Forca.Resposta)
            {
                Forca.JogoRolando = false;
            }
        }
        
        private void AtualizarPlacar()
        {
            string resultado = "";
			
			// Vai adicionar a "descrição" de cada jogador.
			/* Ex:
			* igor : 2 pontos
			* natralha : -1 pontos
			* carlos : -230 pontos
			*/
            for (int i = 0; i < nJog; i++)
            {
                Jogador jogadorAtual = jogadores[i];
                string linha = jogadorAtual.ToString()+ "\n";
                resultado += linha;
            }
			
			// Atualiza os valores da pontuações no scroll
            scroll_pontuacao.Content = resultado;
        }

		// Se a pessoa precionar enter com foco no textField de chute
        private void txt_chute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btn_chute_Click(sender, e);
            }
        }
		
		// Se a pessoa precionar enter com foco no textField de nome do jogador
        private void txt_nome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                btn_addJogador_Click(sender, e);
        }

		//Incrementa a variável "vez" até que alcance o n° de jogadores. Quando isso acontecer, volta a 0.
        private void PassarVez()
        {
			vez = (vez + 1) % nJog;
        }
		
		//Este método representa qualquer evento que indique o jogador atual.
        private void MarcarJogador()
        {
			//Escreve no label acima do placar o texto "Vez do 'Jogador Atual'!"
            lbl_jogadorAtual.Content = String.Format("Vez de {0}!", jogadores[vez].Nome);
        }
		
		// Avalia se a pessoa acertou a palavra inteira
        private bool AcertouPalavra()
        {
            if (txt_chute.Text.ToLower() == Forca.Resposta.ToLower())
                return true;
			
			// Só vai ser executado se a condição retornar falso
            return false;
        }
		
		// Avalia se a pessoa acertou uma letra da palavra
		
        private void btn_sair_Click(object sender, RoutedEventArgs e)
        {
            jogadores.RemoveAt(vez);
            nJog--;
            vez++;
            MarcarJogador();
            AtualizarPlacar();
        }

        private void EsconderPalavra()
        {
            for (int i = 0; i < Forca.Resposta.Length; i++)
            {
                // O label exibe "- " no mesmo n° de letras da palavra, como se tivesse escondendo as letras
                txt_palavra.Content += "- ";
            }
        }

		// Soma à pontuação do jogador
        private void DarPontuacaoPalavra()
        {
            int qtdFaltam = Forca.Resposta.Length;
            for (int i = 0; i < txt_palavra.Content.ToString().Length; i += 2)
            {
                if (txt_palavra.Content.ToString()[i] != '-')
                    qtdFaltam--;
            }
            jogadores[vez].Pontuacao += (Forca.PONTUACAO_POR_LETRA * qtdFaltam)*4/3;
        }

        private void TirarPontuacaoPalavra()
        {
            int qtdFaltam = Forca.Resposta.Length;
            for (int i = 0; i < txt_palavra.Content.ToString().Length; i += 2)
            {
                if (txt_palavra.Content.ToString()[i] != '-')
                    qtdFaltam--;
            }
            jogadores[vez].Pontuacao -= (Forca.PONTUACAO_POR_LETRA * qtdFaltam) * 3 / 4;
        }

        private void DarPontuacaoLetra()
        {
            jogadores[vez].Pontuacao += Forca.PONTUACAO_POR_LETRA;
        }

        private void TirarPontuacaoLetra()
        {
            jogadores[vez].Pontuacao -= Forca.PONTUACAO_POR_LETRA;
        }

        private void TrocarCorDoAtual()
        {
            corAtualIndex++;
            corAtualIndex %= coresArcoIris.Length;
            lbl_jogadorAtual.Foreground = coresArcoIris[corAtualIndex];
        }

        private void AtualizarLetrasErradas()
        {
            txtLetrasErradas.Text = "";
             foreach (char letra in letrasErradas)
            {
                txtLetrasErradas.Text += letra + " ";
            }
        }
        

    }
}
