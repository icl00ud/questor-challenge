## Introdução

Este projeto é a solução de um desafio proposto pela empresa Questor.

## Instruções de instalação

<h5>Há um arquivo .sql para que você possa importar no seu postgres e ter uma pequena base de dados para teste.</h5>

1. Clone este repositório para sua máquina local

````git
git clone https://github.com/icl00ud/questor-challenge.git
````
2. Configure a connection string no appsettings.json com suas credenciais

````json
"ConnectionStrings": {
    "PostgreSQLConnection": "Host=localhost;Port=PostgresPort;Database=YourDatabase;User ID=YourUserID;Password=YourPassword;"
}
````

3. Navegue até a pasta onde você clonou

````
cd ~/path/to/project
````
4. Atualize ou instale as dependências

````c#
dotnet restore
````

5. Execute a WEB Api

````c#
dotnet run
````

## Detalhes de documentação

Para mais detalhes técnicos, está presente no swagger. Pode ser acessado depois de rodar o projeto.

<h5>URL para a documentação swagger:</h5>

````
localhost:7205/swagger/index.html
````
