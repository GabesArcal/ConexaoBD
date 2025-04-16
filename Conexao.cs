using System; // Conexão com o banco
using System.Collections.Generic; // Biblioteca de listas
using System.Xml.Linq; // Biblioteca que organiza listas
using MySql.Data.MySqlClient;

namespace ConexaoBD 
{
    class Conexao
    {

        string dadosConexao = "server=localhost;user=root;database=teste_ti42;port=3306;password=";

        public void BuscaProdutos() // Para conseguir chamar essa função de fora eu preciso coloca "public"
        {

            // Abrir conexão com o banco
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            conexao.Open(); // Aqui estamos abrindo a conexão com o banco
            Console.WriteLine("Conexão realizada com sucesso!");

            // Rodar SQL dentro do banco;
            string sql = "SELECT * FROM produtos;";
            MySqlCommand comando = new MySqlCommand(sql, conexao); // Aqui ele está falando para roda esse código que está no "sql" na "conexao";
            MySqlDataReader dados = comando.ExecuteReader();

            while (dados.Read() ) // "while" é um loop de repetição; Esse "dados" é tudo o que está dentro do banco
            {
                Console.WriteLine("ID: "+dados[0]+" | Nome: "+dados[1]+" | Preço "+dados[2]); // O zero é para achar a posição "index" lembrando que sempre começa com "0";
            }

            conexao.Close(); // Esse código é para fechar a conexão para que não consuma memoria infinita do servicor

        }
    }
}