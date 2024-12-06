# AcademyNovaVida

![Status](https://img.shields.io/badge/Status-Concluido-Green)
![License](https://img.shields.io/badge/License-MIT-blue)

## Sobre o projeto
Um sistema web desenvolvido com ASP.NET Core MVC para gerenciar professores e alunos, incluindo cadastro, listagem e filtros.

## Tecnologias
- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server

## Como executar
1. Clone o repositório: `git clone https://github.com/pauloelzeman/AcademyNovaVida.git`
2. Configure a string de conexão no `appsettings.json`.
3. Execute o projeto no Visual Studio ou usando o comando `dotnet run`.

## Configuração do Banco de Dados
1. Instalar o SQL Server
Certifique-se de ter o SQL Server instalado e em execução na sua máquina.

2. Configurar o appsettings.json
No arquivo appsettings.json do projeto, configure a string de conexão para o banco de dados.

3. Aplicar as Migrações
O projeto utiliza o Entity Framework Core para gerenciar o banco de dados.
Execute os seguintes comandos no terminal ou na janela Package Manager Console:
- Adicionar o banco ao servidor: dotnet ef database update

4. Conferir o Banco de Dados
Após aplicar as migrações, verifique no SQL Server Management Studio (ou ferramenta equivalente) se o banco AcademyNovaVida e suas tabelas foram criados.

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.
Se precisar de mais ajustes ou melhorias no README, avise! 😊

## Status
🚧 Concluido
