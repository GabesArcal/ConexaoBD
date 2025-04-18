using System; // Conexão com o banco
using System.Collections.Generic; // Biblioteca de listas
using System.Data;
using System.Xml.Linq; // Biblioteca que organiza listas
using MySql.Data.MySqlClient;

namespace ConexaoBD 
{
    class Conexao
    {

        string dadosConexao = "server=localhost;user=root;database=teste_ti42;port=3306;password=";

        public int ExecutaComando( string query )
        {
            // Cria e abre conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open(); // Aqui estamos abrindo a conexão com o banco

            // Rodar a query dentro do banco
            MySqlCommand comando = new MySqlCommand(query, conexao); // Este comando está falando para rodar esse código que está na "query" dentro de "conexao";
            int LinhasAfetadas = comando.ExecuteNonQuery();
            conexao.Close();
            return LinhasAfetadas;
        }

        public DataTable ExecutaSelect( string query )
        {
            // Cria e abre conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open(); // Aqui estamos abrindo a conexão com o banco

            // Rodar a query dentro do banco
            MySqlCommand comando = new MySqlCommand(query, conexao); // Este comando está falando para rodar esse código que está na "query" dentro de "conexao";
            MySqlDataAdapter dados = new MySqlDataAdapter(comando);
            DataTable dt = new DataTable();
            dados.Fill(dt);
            conexao.Close();
            return dt;
        }


        public List<Produto> BuscaProdutos() // Quem chamar essa função, ele vai retornar a "List<Produtos>". E como ela é uma função que vai ser usado por outros precisa ser "public"
        {

            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open(); 
            Console.WriteLine("Conexão realizada com sucesso!");

            string sql = "SELECT * FROM produtos;";
            MySqlCommand comando = new MySqlCommand(sql, conexao);
            MySqlDataReader dados = comando.ExecuteReader();

            List<Produto> lista = new List<Produto>();
            
            while (dados.Read() ) // "while" é um loop de repetição; Esse "dados" é tudo o que está dentro do banco
            {
                // Console.WriteLine("ID: "+dados[0]+" | Nome: "+dados[1]+" | Preço "+dados[2]); // O zero é para achar a posição "index" lembrando que sempre começa com "0";
                
                Produto p = new Produto();

                p.id = dados.GetInt32("id"); // Esse "id" entre () é o nome da coluna no banco de dados, ai nesse código está falando para pegar o coluna "id" e tranformar em "int".
                p.nome = dados.GetString("nome");
                p.preco = dados.GetFloat("preco");
                p.registro = dados.GetDateTime("registro");

                lista.Add(p);
            }

            conexao.Close(); // Esse código é para fechar a conexão para que não consuma memoria infinita do servicor

            return lista; // Devolve a lista para quem chamou
        }
    }
}