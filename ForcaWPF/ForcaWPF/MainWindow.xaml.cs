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
        public string NomeDoJogador { get; set; }
        public string SenhaDoJogador { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void txt_nome_TextChanged(object sender, TextChangedEventArgs e)
        {
            NomeDoJogador = txt_nome.Text;
        }
        

        private void btn_cadastrar_Click(object sender, RoutedEventArgs e)
        {
            Jogador jogador = new Jogador();
            jogador.Nome = NomeDoJogador;
            jogador.Senha = SenhaDoJogador;
            MessageBox.Show("Cadastrado com sucesso!");
            Application.Current.MainWindow.Close();
        }

        private void txt_senha_TextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
        private void txt_senha_TextChanged(object sender, TextCompositionEventArgs e)
        {
         
        }
    }
}

