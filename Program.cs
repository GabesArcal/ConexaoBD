using System;
using System.Collections.Generic;

namespace ConexaoBD
{
    class Program
    {
        static void Main(string[] args)
        {

            Conexao conexao = new Conexao();
            List<Produto> lista = conexao.BuscaProdutos();

            foreach( Produto p in lista ){
                Console.WriteLine("ID: "+p.id+" nome: "+p.nome);
            }


            // Console.WriteLine("Hello World!");
            // Console.WriteLine("Olá, Digite o seu nome:");
            // string nome = Console.ReadLine(); // Esse comando significa que tudo que a pessoa escrever ele ira guardar dentro dessa string chamada "nome";
            // Console.WriteLine("Seja bem-vindo Sr. "+ nome);

            // Produto produto = new Produto();
            // produto.nome = "Lençol";
            // produto.preco = 78.90f; // Quando é número quebrado, é preciso dizer que ele é "float" colocando um "f" no final

            // Console.WriteLine("O produto é: "+produto.nome+" e o preço é "+produto.preco);

        }
    }
}
