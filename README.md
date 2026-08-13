# Clean Architecture com .NET

Projeto de exemplo para demonstrar os conceitos básicos de **Clean Architecture** em uma API .NET.

## Arquitetura

```text
WebApi → Application → Domain
WebApi → Infrastructure → Application → Domain
```

### Responsabilidades das camadas

- **Domain:** entidades e regras de negócio.
- **Application:** casos de uso, Commands, Queries, validações e contratos.
- **Infrastructure:** Entity Framework Core, MySQL e implementações dos contratos.
- **WebApi:** endpoints HTTP, Swagger e configuração da aplicação.

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- Docker Compose
- MediatR
- FluentValidation
- Swagger

## Como executar o projeto

### 1. Subir o MySQL

```bash
docker compose up -d
```

### 2. Aplicar as migrations

```bash
dotnet ef database update \
  --project "src/CleanArchitecture.Infrastructure/CleanArchitecture.Infrastructure.csproj" \
  --startup-project "src/CleanArchitecture.WebApi/CleanArchitecture.WebApi.csproj"
```

### 3. Executar a API

```bash
dotnet run --project "src/CleanArchitecture.WebApi/CleanArchitecture.WebApi.csproj"
```

Acesse o Swagger pela URL exibida no terminal. Geralmente:

```text
http://localhost:5000/swagger
```

## Endpoints

| Método   | Rota                | Descrição                    |
|----------|---------------------|------------------------------|
| `GET`    | `/health`           | Verifica se a API está ativa |
| `GET`    | `/api/clients`      | Lista todos os clientes      |
| `GET`    | `/api/clients/{id}` | Busca um cliente pelo ID     |
| `POST`   | `/api/clients`      | Cria um cliente              |
| `PUT`    | `/api/clients/{id}` | Atualiza um cliente          |
| `DELETE` | `/api/clients/{id}` | Remove um cliente            |

## Exemplo de criação

```json
{
  "name": "Maria Silva",
  "document": "12345678901",
  "birthDate": "1990-05-15"
}
```

## Conceitos aplicados

- Clean Architecture
- CQRS
- Mediator Pattern com MediatR
- Dependency Inversion
- Repository Pattern
- DTOs
- Validação via Pipeline Behavior
- Migrations com Entity Framework Core
- Persistência em MySQL via Docker Compose
