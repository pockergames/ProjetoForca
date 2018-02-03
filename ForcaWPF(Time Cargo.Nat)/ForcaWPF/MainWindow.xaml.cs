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

namespace ForcaWPF
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        //O código começa aqui!
        int nJog = 0, vez = 0, pontuacaoInicial = 0;//respectivamente: n° de jogadores adicionados, indíce do jogador atual, pontuacao com a qual todos jogadores iniciam no jogo

        private static int maxDeJogadores = 100; //n° máximo de jogadores na partida. Escolhi 100 , mas este valor pode ser alterado

        private static Jogador[] jogadores = new Jogador[maxDeJogadores];//Array que vai alocar os jogadores da partida

        Jogador JogadorAtual = new Jogador(); //Este vai ser o jogador que receberá os pontos quando uma palavra ou letra estiver certa e vai ter o nome marcado

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_addJogador_Click(object sender, RoutedEventArgs e)//Este botão adiciona um jogador
        {
            if (txt_nome.Text == "") //Se a caixa de texto que recebe o nome estiver vazia,
                txt_nome.Focus();    //mude o foco para ela
            else                     //Se não,
            {
                jogadores[nJog] = new Jogador(); //cria uma instância do objeto jogador dentro do Array jogadores na posicao nJog(que tem como primeiro valor, 0)

                jogadores[nJog].Nome = txt_nome.Text; //Atribui ao Nome do jogador o texto digitado na textbox acima

                jogadores[nJog].Pontuacao = pontuacaoInicial; //Inicializa a pontuação do jogador que está sendo instanciado com a pontuacao inicial

                txt_nome.Clear();//Limpa a textBox que recebe o nome

                scroll_pontuacao.Content += String.Format("{0} : {1} pontos\n\n", jogadores[nJog].Nome, jogadores[nJog].Pontuacao);//Escreve o nome do Jogador e sua pontuacao na caixa cinzenta com scroll abaixo do botão "Nova Partida"

                nJog++;//Incremente o numero de jogadores. Isto serve para que, na próxima vez que o usuário pressionar o botão "Adicionar Jogador", o array de jogadores mude de posição 
            }           
        }

        private void btn_novaPartida_Click(object sender, RoutedEventArgs e)//Inicia uma nova partida
        {
            lbl_palavra.Content = "";//Inicializa o label que mostra a palavra da partida(não é muito necessário, pois ele provavelmente faz isso sozinho)
            

            if (nJog == 0)//Se não houver ao menos 1 jogador cadastrado,
                MessageBox.Show("É preciso haver no mínimo 1 jogador!"); //Mostra esta mensagem
            else
            {
                Forca.PegarPalavraAleatoria(); //Executa um método da classe Forca que busca, do banco de dados, um palavra aleatória e seu respectivo tema
                for (int i = 0; i < Forca.Resposta.Length; i++)
                {
                    lbl_palavra.Content += "- ";// O label exibe o caractere "_" no mesmo n° de letras da palavra, como se tivesse escondendo as letras
                }
                lbl_tema.Content = Forca.Tema; //O label menor, tema, recebe o tema da respectiva palavra
                //MessageBox.Show(Forca.Resposta); //Uma MessageBox que, ao começar uma nova partida, diz a resposta.
                MarcarJogador(); //Põe o nome do jogador atual em cima no placar(a ScrollBox). A ideia inicial era mudar a cor do nome e da pontuação do jogador atual para vermelho, mas não consegui.
                ZerarPontuacao();
            }
           
            
        }
        private void ZerarPontuacao()
        {
            for(int i = 0; i < nJog; i++)
            {
                jogadores[i].Pontuacao = 0;
            }
            AtualizarPlacar();
        }

        private void btn_chute_Click(object sender, RoutedEventArgs e)//Botão que o usuário clica após digitar o chute na textBox inferior
        {
            
            // se a pessoa chutar a palavra inteira
            if (txt_chute.Text.Length > 1)
            {
                if (txt_chute.Text == Forca.Resposta)
                {
                    int qtdFaltam = Forca.Resposta.Length;
                    for (int i=0; i< lbl_palavra.Content.ToString().Length; i+=2)
                    {
                        if (lbl_palavra.Content.ToString()[i] == '-')
                            qtdFaltam--;
                    }
                    jogadores[vez].Pontuacao += txt_chute.Text.Length * pontuacaoInicial;
                    lbl_palavra.Content = Forca.Resposta;
                    jogadores[vez].Pontuacao += Forca.PONTUACAO_POR_LETRA;                    
                }
            }

            // quando chutar uma só letra
            else if (txt_chute.Text.Length == 1)
            {
                // A palavra Resposta transformada em array de chars. Ex: ['c', 'a', 'r', 'b', 'o', 'n', 'o']
                char[] respostaArray = Forca.Resposta.ToCharArray();

                // A letra chutada
                char chute = txt_chute.Text[0];

                // O resultado (ainda em array) que vai ser mostrado na tela. Ex: ['c', '-', '-', 'b', '-', '-', '-']
                char[] mostrarArray = lbl_palavra.Content.ToString().ToCharArray();

                // Quantidade de vezes que a letra que o jogador disse aparece. Ex: carbono, se o jogador falar 'o' -> qtdAcertos = 2
                int qtdAcertos = 0;

                // Substitui '-' pela letra acertada e soma a quantidade de letras acertadas
                for (int i = 0; i < Forca.Resposta.Length; i++)
                {
                    if (chute == respostaArray[i])
                    {
                        mostrarArray[i * 2] = chute;
                        qtdAcertos++;
                    }
                }

                // Soma à pontuação 
                jogadores[vez].Pontuacao += Forca.PONTUACAO_POR_LETRA * qtdAcertos;

                // String que aparece na tela
                string mostrar = "";

                // passando o array de chars para string
                foreach (char letra in mostrarArray)
                    mostrar += letra;

                // alterando o valor do label 
                lbl_palavra.Content = mostrar;
            }

            else 
            {
                txt_chute.Focus();// A pessoa não escreveu nada e botou chutar
            }

            txt_chute.Text = "";

            //Atualiza a pontuação do jogador diretamente no scrollbar
            AtualizarPlacar();

            //Muda o índice do jogador atual para o do próximo jogador
            PassarVez();

            //Marca o próximo jogador
            MarcarJogador();
        }

        private void AtualizarPlacar()
        {
            string resultado = "";
            for (int i=0; i<nJog; i++)
            {
                Jogador jogador = jogadores[i];
                string linha = String.Format("{0} : {1} pontos\n\n", jogador.Nome, jogador.Pontuacao);
                resultado += linha;
            }
            scroll_pontuacao.Content = resultado;
            
        }

        private void txt_chute_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btn_chute_Click(sender, e);
            }
        }

        private void txt_nome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
                btn_addJogador_Click(sender, e);
        }

        private void PassarVez()//Incrementa a variável "vez" até que alcance o n° de jogadores. Quando isso acontecer, volta a 0.
        {
            if (vez == nJog - 1)//Se "vez" for igual ao número de jogadores - 1
                vez = 0;//volta ao jogador de índice 0
            else
                vez++;//Passa para o próximo jogador
        }
        private void MarcarJogador()//Este método representa qualquer evento que indique o jogador atual
            //Neste caso, ele escreve num label em cima do placar o nome do jogador atual.
        {
            lbl_jogadorAtual.Content = String.Format("Vez de {0}!", jogadores[vez].Nome);//Escreve no label acima do placar o texto "Vez do 'Jogador Atual'!"
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
