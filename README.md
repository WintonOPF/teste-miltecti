# Teste MiltecTI

## 1. Tecnologias Utilizadas

Este projeto utiliza as seguintes tecnologias e frameworks:

- **C#**: Linguagem principal para desenvolvimento do backend.
- **ASP.NET Core**: Framework para cria��o de APIs RESTful.
- **Entity Framework Core**: ORM para acesso e manipula��o do banco de dados.
- **SQL Server**: Banco de dados utilizado para persist�ncia de dados.
- **Swagger/OpenAPI**: Para documenta��o e teste dos endpoints da API.

## 2. Passos para Rodar o Projeto

### Pr�-requisitos

Certifique-se de ter os seguintes itens instalados em sua m�quina:

1. **.NET SDK**: Vers�o 6.0 ou superior.
2. **SQL Server**: Para executar o banco de dados localmente.
3. **Visual Studio** ou **Visual Studio Code**: IDE para edi��o e execu��o do c�digo.
4. **Angular CLI** instale com (instale com: npm install -g @angular/cli).

### Passo a Passo

1. Clone o reposit�rio:
   ```bash
   git clone https://github.com/WintonOPF/teste-miltecti.git
   cd teste-miltecti
   ```

2. Restaure as depend�ncias do projeto:
   ```bash
   dotnet restore
   ```

3. Configure o banco de dados no arquivo `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost;Database=MiltecTI;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

4. Execute as migra��es para criar o banco de dados:
   ```bash
   cd miltecti-api
   dotnet ef migrations add InitialCreate --context AnuncioContext
   dotnet ef database update
   ```

5. Execute o projeto:
   ```bash
   dotnet run
   ```

6. Acesse a documenta��o da API no navegador com a porta dada pelo terminal:
   ```
   https://localhost:xxxx/swagger/index.html
   ```
7. Acesse a pasta do front-end:
   ```bash
    cd ..
    cd miltecti-frontend
   ```
8. Instale as depend�ncias:
   ```bash
    npm install
   ```
9. Inicie o servidor:
   ```bash
    ng serve
   ``` 
10. Acesse o servidor:
   ```bash
    http://localhost:xxxx/
   ``` 

## 3. Endpoints da API

### Endpoint: `/api/anuncio`
**M�todo**: GET

**Descri��o**: Retorna uma lista de anuncios. 

**Exemplo de Requisi��o**:
```http
GET /api/Anuncio/anuncio HTTP/1.1
Host: localhost:xxxx
```

**Exemplo de Resposta**:
```json
{
  "data": {
    "id": 0,
    "nomeAnuncio": "string",
    "dataPublicacao": "2025-01-29T00:08:33.868Z",
    "valor": 0,
    "cidade": "string",
    "tipoAnuncio": "produto"
  }
}
```

## 4. Observa��es

- O projeto foi desenvolvido para um front-end "burro" onde as valida��es sao feitas pelo back-end.
