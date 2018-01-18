using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeTemasDeveloperApp
{
    class Palavra
    {
        public string Nome { get; set; }
        public string Tema { get; set; }

        public static void NovaPalavra(int idDoTema, string txt)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = new SqlConnection("Data Source=localhost; Initial Catalog=Forca; Integrated Security=SSPI"),
                CommandText = String.Format(@"INSERT INTO Palavra(nome, tema_id) values('{0}',{1});", txt, idDoTema)
            };
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
    }
}
