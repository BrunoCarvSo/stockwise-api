# StockWise - Web API

Este projeto é uma Web API desenvolvida em .NET para o gerenciamento de estoque. A aplicação foi construída utilizando a **Arquitetura em Camadas (Layered Architecture)**, também conhecida como **Separação de Responsabilidades (Separation of Concerns)**, um padrão que promove a robustez, testabilidade e facilidade de manutenção do código.

---

##  Arquitetura do Projeto

A solução é dividida em três projetos principais, cada um com uma responsabilidade bem definida:

* **StockWise.API**: Expõe os **Controllers** que lidam com as requisições HTTP e as respostas, servindo como a porta de entrada da aplicação.
* **StockWise.Infrastructure**: Contém toda a lógica de acesso e configuração do banco de dados, incluindo o **DbContext** e as configurações do **Entity Framework Core**.
* **StockWise.Domain**: Contém apenas as **entidades** (POCOs) que representam as tabelas do banco de dados, sem nenhuma dependência de infraestrutura.

---

## Tecnologias Principais

* **C#** / **.NET 8** (ou superior)
* **ASP.NET Core**
* **Entity Framework Core** para ORM
* **PostgreSQL** como banco de dados
* **EFCore.NamingConventions** para mapeamento automático `PascalCase` -> `snake_case`
* **Swagger (Swashbuckle)** para documentação e testes da API

---

## 🚀 Como Rodar o Projeto Localmente

Siga os passos abaixo para configurar e executar a API em seu ambiente de desenvolvimento.

### Pré-requisitos

* [.NET SDK](https://dotnet.microsoft.com/download)
* [Git](https://git-scm.com/downloads)
* [PostgreSQL](https://www.postgresql.org/download/)

### Passo 1: Clonar o Repositório

```bash
git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/seu-usuario/seu-repositorio.git)
cd seu-repositorio
```

### Passo 2: Criar e Configurar o Banco de Dados

1.  Certifique-se de que seu serviço do PostgreSQL está em execução.
2.  Crie um banco de dados vazio para o projeto. Ex: `CREATE DATABASE stockwise_db;`
3.  **Configure a Conexão (Modo Seguro):** A configuração da conexão é feita via **Injeção de Dependência** no `Program.cs`, lendo a string de forma segura através do **User Secrets**. Na pasta do projeto **StockWise.API**, execute o comando abaixo, substituindo pelos seus dados:

    ```bash
    dotnet user-secrets set "ConnectionStrings:PostgreSQL" "Host=localhost;Port=5432;Database=stockwise_db;Username=postgres;Password=sua-senha"
    ```
    *Isso garante que suas senhas nunca sejam expostas no código-fonte.*

### Passo 3: Aplicar as Migrations

O projeto utiliza **EF Core Migrations** para criar a estrutura do banco de dados. Este comando lê as migrações existentes no projeto e cria todas as tabelas para você.

Na **pasta raiz da solução** (a pasta que contém os 3 projetos), execute:

```bash
dotnet ef database update --project StockWise.Infrastructure --startup-project StockWise.API
```
Ao final, seu banco de dados estará com o schema pronto e todas as tabelas criadas.

### Passo 4: Executar a API

Na pasta do projeto **StockWise.API**, execute a aplicação:

```bash
dotnet run
```
A API estará rodando. O terminal informará o endereço, geralmente `https://localhost:7001`.

---

## Uso da API

Com a API em execução, acesse a documentação interativa do **Swagger UI** no seu navegador para explorar e testar todos os endpoints disponíveis:

**`https://localhost:7001/swagger/index.html`** (ajuste a porta se necessário)

---

## Visão Geral do Banco de Dados

O banco de dados em PostgreSQL é composto por quatro tabelas principais no padrão `snake_case`:

* **products**: A tabela central que armazena informações detalhadas sobre cada item (nome, preço, SKU e quantidade em estoque).
* **suppliers**: Contém informações sobre os fornecedores dos produtos.
* **categories**: Permite a categorização dos produtos.
* **stock_movements**: Tabela de auditoria que registra cada entrada e saída de produto, garantindo um histórico completo de transações.

As tabelas se relacionam através de chaves estrangeiras para garantir a integridade dos dados.
