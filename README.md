# Documentação para Execução da API

## Introdução

Este documento fornece instruções detalhadas sobre como configurar e executar a API `VaccinationStationRegistrationSystem` desenvolvida em C# com .NET Framework, utilizando Entity Framework com banco de dados NoSQL SQLite, e integrada com Swagger para documentação de API.

### Requisitos

Antes de começar, certifique-se de ter os seguintes requisitos instalados em seu ambiente de desenvolvimento:

- [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) versão 8 ou superior
- [Git](https://git-scm.com/) para clonar o repositório
- [Postman](https://www.postman.com/) ou similar para testar a API

## Passos para Execução

1. **Clonando o Repositório**

   Abra o terminal e execute o seguinte comando para clonar o repositório da API:

```

git clone https://github.com/levilimas/VaccinationStationRegistrationSystem.git

```

2. **Configurando o Ambiente de Desenvolvimento**

- Abra o projeto utilizando o Visual Studio ou outro IDE compatível com .NET Framework.
- Certifique-se de que o Entity Framework está configurado para utilizar o SqLite como banco de dados SQL. Verifique o arquivo de configuração `app.config` ou `web.config` para ajustes necessários.

3. **Instalando Pacotes Necessários**

No gerenciador de pacotes NuGet do Visual Studio, ou via linha de comando:
- Pacotes do entityFramework e Sqlite, sendo esse o Banco relacional utilizado.

```

dotnet add package Microsoft.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet add package Microsoft.EntityFrameworkCore.UseSqlite


```

4. **Executando a API**

Compile e execute a aplicação. Certifique-se de que a aplicação está configurada para iniciar o serviço da API. Normalmente, isso é feito pressionando F5 no Visual Studio ou através de linha de comando após a compilação:

```

dotnet run

```

5. **Explorando a Documentação da API**

Agora, com o navegador já aberto e acesse a URL abaixo para visualizar a documentação da API no Swagger:
A API estará disponível em <https://localhost:7158/swagger/>.

- Imagens do teste no Swagger com passo a passo <https://imgur.com/a/JxkHBFe>

6. **Testando a API**

Utilize o Swagger, para enviar requisições à API e verificar se está funcionando corretamente.
As imagens contidas no passo acima podem mostrar o funcionamento da API corretamente.

## Conclusão

Agora você configurou e executou a API `VaccinationStationRegistrationSystem` desenvolvida em C# com .NET Framework, integrada com Entity Framework usando SQLite como banco SQL, e documentada com Swagger. Para mais detalhes sobre os endpoints disponíveis, consulte a documentação do Swagger fornecida.







