# MVP Project

[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://docs.microsoft.com/pt-br/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)](https://www.microsoft.com/pt-br/sql-server)
[![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)](https://www.docker.com/)

## Sobre o Projeto
O MVP Project é um projeto de demonstração que implementa uma arquitetura limpa e moderna utilizando .NET 9.0. O objetivo é demonstrar as melhores práticas de desenvolvimento e padrões de arquitetura em aplicações .NET.

## Tecnologias Implementadas

### Backend
- ASP.NET Core 9.0
  - ASP.NET WebApi Core
  - ASP.NET Identity Core
- Entity Framework Core 9.0
- SQL Server
- Swagger UI
- MediatR para CQRS
- FluentValidation
- AutoMapper

### Frontend
- React 18
- TypeScript
- Material-UI (MUI)
- React Query
- React Router
- Axios

## Arquitetura

### Princípios e Padrões
- Domain-Driven Design (DDD)
- Clean Architecture
- SOLID Principles
  - Single Responsibility Principle (SRP)
  - Open/Closed Principle (OCP)
  - Liskov Substitution Principle (LSP)
  - Interface Segregation Principle (ISP)
  - Dependency Inversion Principle (DIP)
- CQRS (Command Query Responsibility Segregation)
- Event Sourcing
- Repository Pattern
- Unit of Work Pattern

### Camadas da Aplicação
- Domain Layer
  - Entidades
  - Interfaces
  - Eventos de Domínio
  - Agregados
  - Value Objects
- Application Layer
  - Casos de Uso
  - DTOs
  - Commands e Queries
  - Event Handlers
- Infrastructure Layer
  - Repositórios
  - Contexto EF
  - Serviços Externos
- Presentation Layer
  - Controllers
  - Configurações
  - Middlewares

### Frontend
- Arquitetura Baseada em Componentes
- Gerenciamento de Estado com React Query
- Roteamento com React Router
- UI Components com Material-UI
- TypeScript para Type Safety

## Estrutura do Projeto

```
MVP.Project/
├── src/
│   ├── MVP.Project.Domain/           # Entidades e Interfaces
│   ├── MVP.Project.Application/      # Casos de Uso e DTOs
│   ├── MVP.Project.Infra.Data/       # Implementação do Repositório
│   ├── MVP.Project.Infra.CrossCutting/ # Serviços Compartilhados
│   └── MVP.Project.Services.Api/     # API REST
├── tests/
│   ├── MVP.Project.Tests.Unit/       # Testes Unitários
│   └── MVP.Project.Tests.Integration/# Testes de Integração
└── frontend/                         # Aplicação React
```

## Como Executar

### Pré-requisitos
- .NET 9.0 SDK
- Node.js 18+
- SQL Server
- Visual Studio 2022 ou VS Code
- Docker e Docker Compose (opcional)

### Usando Docker (Recomendado)
1. Certifique-se de ter o Docker e Docker Compose instalados
2. Na raiz do projeto, execute:
```bash
docker-compose up -d
```
3. Acesse:
   - Frontend: http://localhost:3000
   - API: http://localhost:5000
   - Swagger: http://localhost:5000/swagger

### Execução Local

#### Backend
1. Restaure os pacotes NuGet:
```bash
dotnet restore
```

2. Execute as migrações do banco de dados:
```bash
dotnet ef database update --project src/MVP.Project.Infra.Data --startup-project src/MVP.Project.Services.Api
```

3. Execute a API:
```bash
dotnet run --project src/MVP.Project.Services.Api
```

#### Frontend
1. Instale as dependências:
```bash
cd frontend
npm install
```

2. Execute a aplicação:
```bash
npm start
```

## Documentação da API
A documentação da API está disponível através do Swagger UI em:
```
https://localhost:5001/swagger
```

## Autor
**Raul Lima**
- Email: raul.fml@outlook.com.br
- LinkedIn: [@raullima01](https://www.linkedin.com/in/raullima01)

## Licença
Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
