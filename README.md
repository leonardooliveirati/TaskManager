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


## Sessão de Perguntas para o Product Owner (PO)
1. Prioridades de Tarefas:
Existem critérios específicos para determinar a prioridade de uma tarefa ou isso será decidido pelo usuário?
Haverá alguma notificação ou alerta para tarefas de alta prioridade?

2. Restrições de Remoção de Projetos:
Em vez de bloquear a remoção de um projeto com tarefas pendentes, devemos permitir a exclusão condicional (como mover as tarefas para outro projeto)?
Como deve ser o fluxo de comunicação com o usuário ao tentar excluir um projeto com tarefas pendentes? Há uma mensagem específica que você gostaria de usar?

3. Histórico de Atualizações:
Que tipo de informações você gostaria de ver no histórico de alterações? Apenas mudanças em campos específicos ou todos os campos?
Existe algum requisito de auditoria ou conformidade que devemos considerar ao armazenar o histórico de alterações?

4. Limite de Tarefas por Projeto:
O limite de 20 tarefas por projeto é fixo ou será configurável no futuro?
Se um projeto atingir o limite, você gostaria de exibir alguma sugestão para o usuário (como dividir o projeto)?

5. Relatórios de Desempenho:
Que métricas específicas você gostaria de ver nos relatórios de desempenho?
Como você deseja visualizar esses relatórios (gráficos, tabelas, ambos)?
Os relatórios precisam ser exportáveis (PDF, Excel)?

6. Comentários nas Tarefas:
Você gostaria que os comentários pudessem ser editados ou excluídos após serem postados?
Devemos implementar menções (@usuário) e notificações para comentários?

7. Autenticação e Autorização:
Existem requisitos específicos de autenticação e autorização além da função "gerente" para acessar relatórios?
Você planeja ter diferentes níveis de acesso e permissões para outras funcionalidades da aplicação?

8. Notificações e Alertas:
Deve haver notificações automáticas para alterações de status de tarefa ou prazos iminentes?
Como você gostaria que os usuários fossem notificados (email, push notification, etc.)?

9. Integração com Outras Ferramentas:
Há planos para integrar esta aplicação com outras ferramentas de gerenciamento de projetos ou sistemas de comunicação?
Existe algum requisito para APIs de terceiros ou serviços de webhook?

10. Interface do Usuário e Experiência do Usuário (UI/UX):
Existem diretrizes ou preferências específicas de design que devemos seguir?
Você tem algum feedback de usuários sobre a interface atual que devemos considerar para futuras melhorias?

11. Escalabilidade e Performance:
Existem expectativas sobre a quantidade de dados que a aplicação precisará gerenciar (número de projetos, tarefas, usuários)?
Quais são suas expectativas em relação ao desempenho da aplicação sob carga pesada?