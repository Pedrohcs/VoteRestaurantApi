# VoteRestaurantApi
Tem como objetivo demonstrar uma API em .NET onde podemos cadastra restaurantes e efetuamos votações no dia para escolhemos o restaurante que desejamos ir:<br>
- Cadastrar restaurantes
  - POST
    - Código do restaurante (sequencial)
    - Nome do restaurante
  - GET (Retorna todos os restaurantes)
- Votar no restaurante do dia
  - POST
    - Restaurante
    - Data da votação
    - Nome da pessoa que está efetuando votação
    - Hora da votação
  - GET (Retorna todos os dados da votação do dia)
  - GET (Retorna o restaurante mais votado)

Onde o sistema deve atender aos seguintes requisitos:
- A votação só pode ser feita até 11:50 da manha;
- A votação só pode iniciar as 9 da manha;
- Uma pessoa só pode fazer uma única votação por vez no dia;

OBS: para ter uma  estrutura mais organizada e um nível de segurança maior foram criadas mais estruturas do que as pedidas inicialmente, como por exemplo: existe o model de Users para controlar as pessoas que podem votar.

## Pre requisitos
É necessário ter instalado na sua máquina o .NET, e como facilitador o Microsoft Visual Studio:
- [.NET v3.1](https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/pt-br/)

## Mais informações
Para simplificação o sistema esta utilizando o framework Entity e esta utilizando o modulo EntityFramework.InMemory, que cria um banco de dados sequel em tempo de execução.<br>
Logo para uma carga inicial foram criados dois mocks de dados iniciais que rodam assim que o sistema é iniciado e criam uma massa de dados de três restaurantes e quatro usuários;
