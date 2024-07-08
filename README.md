# TaskManager API

## Sumário

- [Descrição](#descrição)
- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração do Banco de Dados](#configuração-do-banco-de-dados)
- [Executando a Aplicação](#executando-a-aplicação)
- [Rodando Migrações](#rodando-migrações)
- [Endpoints da API](#endpoints-da-api)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Descrição

TaskManager é uma API RESTful desenvolvida em .NET C# que permite aos usuários organizar e monitorar suas tarefas diárias, bem como colaborar com colegas de equipe. O sistema gerencia usuários, projetos e tarefas com funcionalidades básicas e avançadas, incluindo a geração de relatórios de desempenho e histórico de atualizações.

## Pré-requisitos

- .NET SDK 6.0 ou superior
- SQL Server
- Docker (opcional, para rodar o projeto em container)

## Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/taskmanager.git
   cd taskmanager
