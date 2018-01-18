using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeTemasDeveloperApp
{
    class Tema
    {
        public string Nome { get; set; }

        public static void NovoTema(string txt)
        {
            SqlCommand cmd = new SqlCommand()
            {
                Connection = new SqlConnection("Data Source=localhost; Initial Catalog=Forca; Integrated Security=SSPI"),
                CommandText = String.Format(@"INSERT INTO Tema(nome) values ('{0}');", txt)
            };
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }
        public static string MostrarTemas()
        {
            string nomesDosTemas = "\n";

            SqlCommand cmd = new SqlCommand()
            {
                Connection = new SqlConnection("Data Source=localhost; Initial Catalog=Forca; Integrated Security=SSPI"),
                CommandText = String.Format(@"SELECT * FROM Tema;")
            };
            cmd.Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                nomesDosTemas += reader.GetString(1) + "\n";
            }
            cmd.Connection.Close();
            int i = 0;
            
            return nomesDosTemas;
        }
    }


}

