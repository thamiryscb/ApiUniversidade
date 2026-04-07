# 🎓 API Universidade

Uma API RESTful desenvolvida em **C# / .NET** para gerenciar recursos e operações de um sistema universitário.

---

## 🚀 Tecnologias Utilizadas

Este projeto foi construído utilizando as seguintes tecnologias:

* **[.NET](https://dotnet.microsoft.com/)** (C#)
* **[Entity Framework Core](https://learn.microsoft.com/pt-br/ef/core/)** (ORM para persistência de dados)
* **Swagger / OpenAPI** (Para documentação e teste dos endpoints)

---

## 📁 Estrutura do Projeto

O projeto foi organizado para manter uma separação clara de responsabilidades:

* **`Controllers/`**: Contém os controladores da API que gerenciam as requisições HTTP e definem os endpoints.
* **`Model/`**: Contém as classes que representam as entidades de domínio do banco de dados (ex: Alunos, Cursos, Professores).
* **`DTO/`**: *Data Transfer Objects*, utilizados para padronizar e trafegar os dados das requisições e respostas, separando-os dos modelos de banco de dados.
* **`Context/`**: Contém a classe de contexto do banco de dados (DbContext) que faz a ponte entre a aplicação e o banco via Entity Framework.
* **`Migrations/`**: Contém o histórico de versionamento do esquema do banco de dados gerado pelo EF Core.
* **`appsettings.json`**: Arquivo para configurações da aplicação, como a string de conexão com o banco de dados.
