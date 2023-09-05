# BanksTransactions.API
 Bem-vindo ao repositório, BanksTransactions.API! Esta é uma API de exemplo desenvolvida em .NET Core 3.1 e EF Core que demonstra o uso de Mediator, injeção de dependência, CQRS, banco em memória e Swagger para gerenciar transações bancárias.
# Visão Geral
Esta API tem como objetivo fornecer endpoints para realizar operações comuns em uma aplicação bancária, como criar transações, consultar transações, atualizar transações e deletar transações. Ela utiliza a arquitetura CQRS (Command Query Responsibility Segregation) para separar as operações de comando das operações de consulta.
# Recursos Principais
Mediator: Utilizamos o padrão Mediator para facilitar a comunicação entre os diferentes componentes da aplicação. Isso ajuda a manter o código organizado e desacoplado.

Injeção de Dependência: A API utiliza a injeção de dependência do .NET Core para gerenciar as dependências e facilitar a manutenção e teste.

Banco em Memória: Para fins de demonstração, utilizo um banco de dados em memória que simula o armazenamento de transações bancárias. Isso permite a execução da API sem a necessidade de um banco de dados real.

Swagger: A documentação da API é gerada automaticamente com o Swagger, facilitando o teste e a compreensão dos endpoints disponíveis.

# Configuração
Antes de começar, você precisará das seguintes ferramentas instaladas:

Visual Studio 2019 ou posterior (ou Visual Studio Code)
.NET Core 3.1 SDK
Postman ou outra ferramenta de API para testar os endpoints

# Passos para Executar o Projeto
Clone este repositório:

- git clone https://github.com/seu-usuario/BanksTransactions.API.git

Navegue até o diretório do projeto:
- cd BanksTransactions.API

Abra o projeto no Visual Studio ou Visual Studio Code.
- Execute a aplicação. 

O Swagger estará disponível em http://localhost:5000/swagger (ou http://localhost:5001/swagger se estiver usando o HTTPS).

# Uso
Agora que a API está em execução, você pode usar o Swagger ou Postman para explorar os endpoints e testar as operações disponíveis. Aqui estão alguns dos principais endpoints:

- POST /api/transactions: Crie uma nova transação bancária.
- GET /api/transactions: Consulte todas as transações bancárias.
- GET /api/transactions/{Id}: Consulte os detalhes de uma transação bancária.
- PUT /api/transactions/{Id}: Atualize uma transação bancária.
- DELETE/api/transactions/{Id}: Delete uma transação bancária.

# Licença
Este projeto é distribuído sob a licença MIT. Consulte o arquivo LICENSE para obter mais detalhes.


