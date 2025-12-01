💜✨ DreamQuest – Agência de Viagens (ASP.NET Core MVC)
<p align="center"> <img src="https://img.shields.io/badge/Status-Funcional-CEA7F5?style=for-the-badge" /> <img src="https://img.shields.io/badge/.NET-8.0-DAA2F1?style=for-the-badge" /> <img src="https://img.shields.io/badge/ASP.NET%20Core-MVC-D9A7FF?style=for-the-badge" /> </p>

Bem-vindo ao DreamQuest, uma aplicação web de gestão de viagens desenvolvida em ASP.NET Core MVC (.NET 8).
O projeto foi construído com foco numa Agência de Viagens moderna, permitindo reservas, gestão de voos e uma experiência fluida tanto para Passageiros como Administradores.

🎀 Índice

💫 Introdução

🪄 Tecnologias Utilizadas

📌 Requisitos

⚙️ Instalação

📂 Estrutura

✈️ Funcionalidades

📋 Requisitos Implementados

🖊️ Autora

💫 1. Introdução

O DreamQuest é uma aplicação totalmente funcional, criada com arquitetura MVC e integração com Entity Framework Core, oferecendo:

Sistema de autenticação

Catálogo de destinos

Reservas automatizadas

Painel administrativo completo

🪄 2. Tecnologias Utilizadas

💜 ASP.NET Core MVC (NET 8.0)
💜 C#
💜 Entity Framework Core
💜 SQL Server LocalDB
💜 Bootstrap
💜 HTML • CSS • Razor

📌 3. Requisitos do Sistema
Recurso	Detalhe
.NET SDK	8.0+
Base de Dados	SQL Server LocalDB
EF Core Tools	dotnet-ef
IDE (opcional)	Visual Studio 2022 / VS Code
⚙️ 4. Instalação e Configuração
📁 4.1. Extração

Extrair o arquivo do projeto

Abrir a pasta AgenciaViagensFinal

🛢️ 4.2. Banco de Dados

A conexão já está definida no appsettings.json:

"AgenciaDbConnection": 
"Server=(localdb)\\MSSQLLocalDB;Database=DreamQuestDB;Trusted_Connection=True;MultipleActiveResultSets=true"


Criar a base de dados:

dotnet ef database update

📦 4.3. Restaurar dependências
dotnet restore

▶️ 4.4. Executar
dotnet run


A app abrirá em:

http://localhost:5000

https://localhost:7000

📂 5. Estrutura do Projeto
Pasta	Função
Controllers	Lógica das rotas
Models	Entidades e estrutura de dados
Views	Interface (Razor)
Data	Configuração do EF Core
Migrations	Histórico do BD
wwwroot	CSS, JS, imagens
✈️ 6. Funcionalidades
👤 Passageiros

Criar conta e fazer login

Consultar catálogo de destinos

Reservar voos

Visualizar histórico de viagens

🛠️ Administrador

Painel de gestão

Criar voos

Editar voos

Apagar voos

Gerir reservas

📋 7. Tabela de Requisitos
Requisito	Feito
Registo de utilizadores	✔️
Atribuição de role "Passageiro"	✔️
Login	✔️
Roles e controlo	✔️
CRUD de voos	✔️
Gestão de reservas	✔️
Catálogo de voos	✔️
Histórico de viagens	✔️
🖊️ 8. Autora

💜 Júlia Amaral de Souza
TGPSI – Gestão de Programação e Sistemas Informáticos
Projeto: DreamQuest – Agência de Viagens
