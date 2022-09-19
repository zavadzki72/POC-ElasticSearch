# Apresentação 
POC-ElasticSearch - API desenvolvida para a demonstração do uso do ElasticSearch com .NET.

# Configuração do ambiente

## Requisitos
1. [DOCKER](https://www.docker.com)
2. [.NET 6](https://dotnet.microsoft.com/download)

## Comandos Para subir a docker-compose
1.  Para subir a docker-compose é necessário navegar até ela e então executar o seguinte comando
    ``` bash
    docker-compose up -d
    ```
2.  Stopar os ambientes
    ``` bash
    docker-compose stop
    ```

# Executando a aplicação
- Para executar a aplicação é necessário subir a docker-compose.yml com o elastic search
- A aplicação ira abrir em uma porta, para ir até a documentação da API basta digitar `/swagger` depois da rota, por exemplo: `localhost:XXXXX/swagger`
