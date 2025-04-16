# Projeto ConexaoBD

Este projeto mostra como criar e rodar uma aplicação C# que se conecta com um banco de dados.

---

## 🗃️ Banco de Dados

- A tabela possui uma coluna do tipo `datetime` chamada `current_time`.
- Quando nenhum valor é inserido nessa coluna, o banco define automaticamente o valor com a **data e hora atuais** (timestamp do momento do insert).

---

## ⚙️ Comandos para configurar e rodar o projeto

```bash
# Cria o projeto com o nome "ConexaoBD"
dotnet new console -n ConexaoBD

# Entra na pasta do projeto
cd ConexaoBD

# Instala o pacote necessário para conexão com MySQL
dotnet add package MySql.Data

# Roda o projeto
dotnet run
