using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForcaWPF
{
    class Jogador
    {
		// Nome do jogador
        public string Nome { get; set; }
		
		// Pontuacao do jogador
        public int Pontuacao { get; set; }
		
		// Retorna um texto com as características do jogador
		// Ex: "carlos_burrao : -5 pontos"
		public override string ToString()
		{
			// OBS: as possíveis linhas a serem puladas não devem ser colocadas nesse método.
			// O programador que vai escolher em certos pontos quantas linhas ele quer pular,
			// porque nem sempre será necessário.
			return String.Format("{0} : {1} pontos", Nome, Pontuacao);
		}
    }

}
