## Introdução

Este projeto é a solução de um desafio proposto pela empresa Questor.

## Instruções de instalação

<h5>Há um arquivo .sql para que você possa importar no seu postgres e ter uma pequena base de dados para teste.</h5>

1. Clone este repositório para sua máquina local

````
git clone https://github.com/icl00ud/questor-challenge.git
````
2. Configure a connection string no appsettings.json com suas credenciais

````json
"ConnectionStrings": {
    "PostgreSQLConnection": "Host=localhost;Port=5432;Database=questor_challenge;User ID=postgres;Password=1221;"
  }
````

4. Navegue até a pasta onde você clonou

````
cd ~/path/to/project
````

4. Execute a WEB Api com o seguinte comando:

````c#
dotnet run
````

## Detalhes de documentação

Para mais detalhes técnicos, está presente no swagger. Pode ser acessado depois de rodar o projeto.

<h5>URL para a documentação swagger:</h5>

````
localhost:7205/swagger/index.html
````
