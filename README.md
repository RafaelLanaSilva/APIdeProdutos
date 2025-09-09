# 🛒 APIdeProdutos

Uma API RESTful desenvolvida em **.NET 8** para gerenciamento de produtos (**CRUD completo**), utilizando **Entity Framework Core** e **SQL Server**.  
Toda a infraestrutura roda em **containers Docker**, tanto o banco de dados quanto a própria API.  

## ✨ Funcionalidades

- Criar produto
- Listar todos os produtos
- Buscar produto por ID
- Atualizar produto
- Excluir produto

---

## 🏗️ Arquitetura e Boas Práticas

- **.NET 8** como framework principal
- **Entity Framework Core** para persistência
- **SQL Server** como banco de dados
- **Princípios SOLID** aplicados:
  - **S**ingle Responsibility: classes com responsabilidades únicas  
  - **O**pen/Closed: código aberto para extensão, fechado para modificação  
  - **L**iskov Substitution: abstrações respeitando contratos  
  - **I**nterface Segregation: interfaces específicas para cada caso de uso  
  - **D**ependency Inversion: uso de injeção de dependência para baixo acoplamento  

---

## 🚀 Executando com Docker

### 1. Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (para desenvolvimento local)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) ou Docker Engine

### 2. Subir os containers
No diretório raiz do projeto (onde está o `docker-compose.yml`), execute:

```bash
docker-compose up -d

🔧 Executando as Migrations
Rodar a migration existente
dotnet ef database update

