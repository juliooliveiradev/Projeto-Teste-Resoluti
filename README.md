# Projeto-Teste-Resoluti

**Descrição do Projeto: Sistema de Cadastro de Pessoas Físicas**

**Backend (Asp.Net Core):**
O backend deste projeto foi desenvolvido utilizando o framework Asp.Net Core. O principal objetivo é fornecer serviços de autenticação e manipulação de dados para um sistema de cadastro de pessoas físicas. Utilizando o padrão MVC (Model-View-Controller), o backend organiza a lógica de negócios, gerenciamento de usuários e interações com o banco de dados.

- **Modelo de Dados (Model):** O modelo de dados é composto por entidades como `Usuario`, `Telefone`, `PessoaFisica`, `Endereco`, e `Contato`. O Entity Framework Core é utilizado para mapear essas entidades para o banco de dados, fornecendo uma camada de abstração eficiente.

- **Autenticação e Autorização:** O sistema utiliza o ASP.NET Identity para gerenciar usuários, autenticação e autorização. As funcionalidades de autenticação são implementadas usando tokens JWT (JSON Web Tokens), permitindo a geração de tokens seguros para usuários autenticados.

- **API RESTful:** O backend expõe uma API RESTful para realizar operações CRUD (Create, Read, Update, Delete) em entidades como `PessoaFisica`. As rotas são protegidas por autenticação, garantindo que apenas usuários autenticados possam acessá-las.

**Frontend (Angular):**
O frontend do projeto é desenvolvido em Angular, um framework TypeScript mantido pelo Google. O objetivo principal é fornecer uma interface de usuário interativa e responsiva para realizar operações relacionadas ao cadastro de pessoas físicas.

- **Arquitetura de Componentes:** O Angular segue uma arquitetura de componentes, e o frontend é dividido em diversos componentes como `CadastroUsuarioComponent`, `ListaPessoaComponent`, etc. Cada componente tem uma responsabilidade específica na interface do usuário.

- **Comunicação com o Backend:** O frontend se comunica com o backend por meio de requisições HTTP utilizando o módulo `HttpClient`. As operações como cadastro, edição, listagem e exclusão de pessoas físicas são realizadas por meio das rotas da API RESTful fornecidas pelo backend.

- **Autenticação e Segurança:** O Angular utiliza o módulo `@auth0/angular-jwt` para trabalhar com tokens JWT. O serviço `AuthService` gerencia a autenticação do usuário, e as rotas são protegidas para garantir que apenas usuários autenticados tenham acesso a determinadas funcionalidades.

- **Interface de Usuário Responsiva:** A interface de usuário é desenvolvida utilizando componentes Angular Material e possui um design responsivo, proporcionando uma experiência consistente em diferentes dispositivos.

**Docker:**
O projeto também inclui suporte ao Docker para facilitar a implantação e distribuição. Um Dockerfile foi criado para construir uma imagem do contêiner contendo o frontend otimizado para produção e servido por um servidor Nginx leve.

Em resumo, o sistema de cadastro de pessoas físicas oferece uma solução completa que integra um backend robusto em Asp.Net Core com um frontend moderno e dinâmico em Angular, proporcionando uma experiência eficiente e segura para os usuários.
