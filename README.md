# Projeto Geladeira - API para Controle de Itens

//Atividade feita por ALine dos Santos Araújo e Lillyan de Santana Rodrigues Teixeira.

Este projeto implementa uma API para gerenciar itens dentro de uma geladeira utilizando Entity Framework Core.

## Funcionalidades

- Adicionar item
- Remover item
- Atualizar item
- Buscar item por ID
- Listar todos os itens

## Tecnologias Utilizadas

- ASP.NET Core
- Entity Framework Core
- SQL Server

## Configuração do Projeto

### 1. Configuração do Banco de Dados

Crie a tabela `APIGeladeira` no banco de dados SQL Server utilizando o script abaixo:

```sql
CREATE TABLE APIGeladeira (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome NVARCHAR(100) NOT NULL,
    Descricao NVARCHAR(255),
    Quantidade INT NOT NULL,
    Andar INT NOT NULL,
    Container INT NOT NULL,
    Posicao INT NOT NULL
);
