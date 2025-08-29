# StockWise - Web API

Este projeto é uma Web API desenvolvida em .NET para o gerenciamento de estoque. A aplicação foi construída utilizando a **Arquitetura em Camadas (Layered Architecture)**, também conhecida como **Separação de Responsabilidades (Separation of Concerns)**, um padrão que promove a robustez, testabilidade e facilidade de manutenção do código.

---

## Arquitetura do Projeto

A solução é dividida em três projetos principais, cada um com uma responsabilidade bem definida:

* **StockWise.API**: O projeto principal da Web API. Sua única função é expor os **Controllers** que lidam com as requisições HTTP da web e retornam as respostas. Esta camada não tem conhecimento sobre a lógica de acesso ao banco de dados.
* **StockWise.Infrastructure**: Uma biblioteca de classes responsável por toda a lógica de acesso e configuração do banco de dados. É nesta camada que reside o **DbContext** e a configuração do **Entity Framework Core**.
* **StockWise.Domain**: Uma biblioteca de classes que contém apenas as **entidades** (classes) que representam as tabelas do banco de dados. Esta camada não possui nenhuma lógica de banco de dados.

---

## Tecnologias e Pacotes Principais

* Linguagem: **C#**
* Framework: **.NET**
* Banco de Dados: **PostgreSQL**
* ORM: **Entity Framework Core**
* Driver PostgreSQL: **Npgsql.EntityFrameworkCore.PostgreSQL**

---

## Configuração do Projeto

### Conexão com o Banco de Dados

A string de conexão com o banco de dados é lida do arquivo `appsettings.json` localizado no projeto **StockWise.API**. A configuração é injetada no **StockWiseDbContext** (localizado na camada `Infrastructure`) usando o processo de **Injeção de Dependência (Dependency Injection - DI)**.

**Exemplo de appsettings.json:**

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "TypeDatabase": "PostgreSQL",
  "ConnectionStrings": {
    "PostgreSQL": "Host=localhost;Port=porta-que-voce-usa-no-banco;Pooling=true;Database=nome_da_tabela;User Id=postgres;Password=sua-senha;"
  }
}
```

O método OnConfiguring na classe StockWiseDbContext utiliza a IConfiguration para determinar o tipo de banco de dados e a string de conexão correspondente.

--- 

Geração de Entidades (Scaffolding)
As classes de entidade na camada StockWise.Domain são geradas automaticamente a partir do esquema do banco de dados existente utilizando o comando scaffold do Entity Framework Core. Este processo garante que as classes C# reflitam com precisão a estrutura das tabelas.

O comando abaixo, executado a partir do terminal no projeto StockWise.Domain, gera as entidades no diretório Entities e não sobrescreve o DbContext existente.

```dotnet ef dbcontext scaffold "Host=localhost;Port=8888;Database=Bruno;Username=postgres;Password=Elefante" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir ../StockWise.Domain/Entities --no-dbcontext --force```

---

Estrutura do Banco de Dados
O banco de dados da API StockWise é construído em PostgreSQL e foi projetado para ser um sistema de gerenciamento de estoque simples e eficiente. A estrutura é composta por quatro tabelas principais que se relacionam para rastrear produtos, fornecedores e movimentações de estoque.

### Products:  
A tabela central que armazena informações detalhadas sobre cada item (nome, preço, SKU e quantidade em estoque).

### Suppliers: 
Contém informações sobre os fornecedores dos produtos.

### Categories: 
Permite a categorização dos produtos.

### StockMovements: 
Uma tabela crucial para auditoria, que registra cada entrada e saída de produto do estoque, garantindo um histórico completo de transações.

As tabelas de Products, Suppliers e Categories são interligadas por chaves estrangeiras, enquanto a tabela de StockMovements mantém um registro de todas as alterações na quantidade de produtos.

