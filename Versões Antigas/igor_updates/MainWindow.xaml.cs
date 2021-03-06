﻿using System;
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

/* TODO List (MainWindow.xaml.cs) */
// Finalizar método AcertouLetra()
// Checar se a variável nJog é realmente necessária (já que é equivalente ao tamanho do List)


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
        private int maxDeJogadores = 100; 

		// List que vai alocar os jogadores da partida
        private List<Jogador> jogadores = new List<Jogador>();

		// Este vai ser o jogador que receberá os pontos quando uma palavra ou letra estiver certa e vai ter o nome marcado
        //Jogador JogadorAtual = new Jogador(); 

        public MainWindow()
        {
            InitializeComponent();
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
				scroll_pontuacao.Content += jogadores[nJog].ToString();
				
				// Incrementa o numero de jogadores.
				// Isto serve para que, na próxima vez que o usuário pressionar o botão "Adicionar Jogador", o array de jogadores mude de posição 
                nJog++;
            }           
        }

		//Inicia uma nova partida
        private void btn_novaPartida_Click(object sender, RoutedEventArgs e)
        {
			// Inicializa o label que mostra a palavra da partida(não é muito necessário, pois ele provavelmente faz isso sozinho)
            txt_palavra.Text = "";
            

			// Se não houver ao menos 1 jogador cadastrado
            if (nJog == 0)
                MessageBox.Show("É preciso haver no mínimo 1 jogador!");
            else
            {
				// Executa um método da classe Forca que busca, do banco de dados, um palavra aleatória e seu respectivo tema
                Forca.PegarPalavraAleatoria(); 
				
                for (int i = 0; i < Forca.Resposta.Length; i++)
                {
					// O label exibe "- " no mesmo n° de letras da palavra, como se tivesse escondendo as letras
                    txt_palavra.Text += "- ";
                }
				
				//O label menor, tema, recebe o tema da respectiva palavra
                lbl_tema.Content = Forca.Tema; 
				
                //MessageBox.Show(Forca.Resposta); //Uma MessageBox que, ao começar uma nova partida, diz a resposta.
				
				// Põe o nome do jogador atual em cima no placar(a ScrollBox).
				// A ideia inicial era mudar a cor do nome e da pontuação do jogador atual para vermelho, mas não consegui.
                MarcarJogador(); 
                ZerarPontuacao();
            }
        }
		
		// Limpa a pontuação de todos os jogadores e atualiza no placar
        private void ZerarPontuacao()
        {
            for(int i = 0; i < nJog; i++)
            {
                jogador[i].Pontuacao = 0;
            }
            AtualizarPlacar();
        }

        private void btn_chute_Click(object sender, RoutedEventArgs e)
        {
            
            // se a pessoa chutar a palavra inteira
            if (AcertouPalavra() && txt_palavra.Text.ToString() != Forca.Resposta)
            {
				// Alterei o nome para um mais intuitivo
                DarPontuacaoPalavra();
				
				// Mostra a palavra
                txt_palavra.Text = Forca.Resposta;
            }

            // quando chutar uma só letra
            else if (AcertouLetra())
            {
                // A palavra Resposta transformada em array de chars. Ex: ['c', 'a', 'r', 'b', 'o', 'n', 'o']
                char[] respostaArray = Forca.Resposta.ToCharArray();

                // A letra chutada
                char chute = txt_chute.Text[0];

                // O resultado (ainda em array) que vai ser mostrado na tela. Ex: ['c', '-', '-', 'b', '-', '-', '-']
                char[] mostrarArray = txt_palavra.Text.ToString().ToCharArray();

                // Quantidade de vezes que a letra que o jogador disse aparece. Ex: carbono, se o jogador falar 'o' -> qtdAcertos = 2
                int qtdAcertos = 0;

                // Substitui '-' pela letra acertada e soma a quantidade de letras acertadas
                for (int i = 0; i < Forca.Resposta.Length; i++)
                {
                    if (chute == respostaArray[i] || chute == Char.ToLower(respostaArray[i]) && chute != mostrarArray[i * 2])
                    {
                        mostrarArray[i * 2] = chute;
                        qtdAcertos++;
                    }
                }

                // Soma à pontuação 
                jogador[vez].Pontuacao += Forca.PONTUACAO_POR_LETRA * qtdAcertos;

                // String que aparece na tela. Ex "c-rbono"
                string mostrar = "";

                // passando o array de chars para string
                foreach (char letra in mostrarArray)
                    mostrar += letra;

                // alterando o valor do label 
                txt_palavra.Text = mostrar;
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
                Jogador jogadorAtual = jogador[i];
                string linha = jogadorAtual.ToString();
                resultado += linha;
            
			
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
            lbl_jogadorAtual.Content = String.Format("Vez de {0}!", jogador[vez].Nome);
        }
		
		// Avalia se a pessoa acertou a palavra inteira
        private bool AcertouPalavra()
        {
            if (txt_chute.Text.ToLower() == Forca.Resposta.ToLower() && txt_chute.Text.Length > 1)
                return true;
			
			// Só vai ser executado se a condição retornar falso
            return false;
        }
		
		// Avalia se a pessoa acertou uma letra da palavra
		private bool AcertouLetra()
        {
            if (txt_chute.Text.Length == 1)
                return true;
			
			// Só vai ser executado se a condição retornar falso
            return false;
        }

		
        private void btn_sair_Click(object sender, RoutedEventArgs e)
        {
            jogador.RemoveAt(vez);
            nJog--;
            vez++;
            MarcarJogador();
            AtualizarPlacar();
        }

		// Soma à pontuação do jogador
        private void DarPontuacaoPalavra()
        {
            int qtdFaltam = Forca.Resposta.Length;
            for (int i = 0; i < txt_palavra.Text.ToString().Length; i += 2)
            {
                if (txt_palavra.Text.ToString()[i] != '-')
                    qtdFaltam--;
            }
            jogador[vez].Pontuacao += Forca.PONTUACAO_POR_LETRA * qtdFaltam;
        }
        
        /*private void MostrarLetra()//"Desvenda" uma letra da resposta (Feito por Carlos Miranda)
        {
            StringBuilder palavra = new StringBuilder (lbl_palavra.Content.ToString());//Cria um StringBuilder para manipular o texto contido no label palavra

            char letra = Convert.ToChar(txt_chute.Text);//Pega a letra digitada pelo jogador, converte para char e põe na variável letra.
            //string s = lbl_palavra.Content.ToString();//Outra form de manipular a string do label palavra usando array de char.
            //char[] palavra = s.ToCharArray();
            
            for(int i = 0; i < Forca.Resposta.Length; i++)//Repete isso para cada letra da resposta
            {
                if (letra == Forca.Resposta[i] || letra == Forca.Resposta.ToLower()[i])//Verifica se a letra é igual a qualquer caractere da resposta.
                {
                    palavra.Remove(i * 2, 1);//Aqui, ele remove o traço que corresponde a letra da palavra, para entender esta parte, é importante que comprenda a explicação abaixo:
                                             //O conteúdo do label está no seguine formato("_ _ _ _ ..."). Ou seja, entre cada traço há um espaço. Isso significa que a posição de uma letra da Resposta corresponde a ao dobro desta posição no label palavra
                                             //Ex.: Resposta: VACA; Lab: V A C A. posição do 'V' em Resposta = 0; posição do 'V' no label = 2 * 0 = 0
                                             //posição do 'C' em Resp = 2; posição do 'C' no label = 2 * 2 = 4.
                                             //Isto serve para que cada letra substitua um traço e os espaços permaneçam
                    palavra.Insert(i * 2, letra);//Aqui ele insere a letra no lugar que o traço foi removido
                    
                    //palavra[i * 2] = letra;//Usando array de char.
                }
            }
            lbl_palavra.Content = palavra.ToString();//Atribui ao label palavra, a nova string com as letras acertadas no lugar dos traços...ou deveria.
            
            //lbl_palavra.Content = new string(palavra);//Usando array de char.
        }*/

    }
}
