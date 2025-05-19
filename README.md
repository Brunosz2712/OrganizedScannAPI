# 🏍️ OrganizedScann API

API RESTful desenvolvida em **ASP.NET Core** para gerenciamento de motocicletas e autenticação com **JWT**. Utiliza banco de dados **Oracle** integrado via **Entity Framework Core**, com suporte a operações CRUD e documentação automática via **Swagger**.

## 📖 Descrição do Projeto

O OrganizedScann API oferece funcionalidades para:
- Gerenciar dados de motocicletas (CRUD completo)
- Autenticação segura de usuários com tokens JWT
- Controle de permissões baseado em roles de usuário (`ADMIN`, `SUPERVISOR`, `OPERATOR`, `USER`)
- Integração com banco de dados Oracle utilizando migrations EF Core
- Documentação da API acessível via Swagger UI

## 🚀 Rotas Principais da API

### Motocicletas (Motorcycle)

| Método | Endpoint               | Descrição                                                         |
|--------|------------------------|------------------------------------------------------------------|
| GET    | `/api/motorcycle`      | Lista todas as motos, com filtros opcionais por `brand` e `year` |
| GET    | `/api/motorcycle/{id}` | Obtém a motocicleta pelo ID                                      |
| POST   | `/api/motorcycle`      | Cria uma nova motocicleta                                        |
| PUT    | `/api/motorcycle/{id}` | Atualiza uma motocicleta existente                               |
| DELETE | `/api/motorcycle/{id}` | Remove a motocicleta pelo ID                                     |

### Autenticação (Auth)

| Método | Endpoint    | Descrição                           |
|--------|-------------|-------------------------------------|
| POST   | `/api/auth` | Realiza login e retorna token JWT   |

## ⚙️ Como Rodar o Projeto

### Pré-requisitos
- [.NET 7 SDK](https://dotnet.microsoft.com/download)
- Banco de dados Oracle configurado
- Visual Studio 2022 ou outro editor de sua preferência
- Ferramenta de gerenciamento do Oracle (ex: SQL Developer)

### Passo a passo

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/organizedscann-api.git
   cd organizedscann-api
   ```

2. Configure a string de conexão Oracle no arquivo appsettings.json:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "User Id=SEU_USUARIO;Password=SUA_SENHA;Data Source=SEU_SERVIDOR_ORACLE"
     }
   }
   ```

3. Aplique as migrations para criar as tabelas no banco:
   ```bash
   dotnet ef database update
   ```

4. Execute a aplicação localmente:
   ```bash
   dotnet run
   ```

5. Acesse a documentação Swagger no navegador:
   ```
   https://localhost:5001/swagger/index.html
   ```

## 📌 Funcionalidades Extras

- Filtro por parâmetros nas rotas GET (ex: GET /api/motorcycle?brand=Honda&year=2020)
- Hash de senhas com PasswordHasher do ASP.NET Core para maior segurança
- Tratamento global de erros via middleware personalizado
- Middleware para validação e autenticação de tokens JWT

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 7.0
- Entity Framework Core 7.0
- Oracle Database
- JWT para autenticação e autorização
- Swagger para documentação da API
- C# 11

## 🤝 Contribuição

- RM 94346 Bruno Da Silva Souza 2TDSPG
- RM 557453 Julio Samuel De Oliveira 2TDSPG
- RM 557598 Leonardo Da Silva Pereira 2TDSPG