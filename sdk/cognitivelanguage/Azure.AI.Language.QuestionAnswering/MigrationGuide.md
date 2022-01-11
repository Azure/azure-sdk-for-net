# Migrate from Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker to Azure.AI.Language.QuestionAnswering

This guide is intended to assist in the migration to the new Question Answering client library [`Azure.AI.Language.QuestionAnswering`](https://www.nuget.org/packages/Azure.AI.Language.QuestionAnswering) from the old one [`Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker`](https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker). It will focus on side-by-side comparisons for similar operations between the two packages.

Familiarity with the `Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker` library is assumed. For those new to the Question Answering client library for .NET, please refer to the [`Azure.AI.Language.QuestionAnswering` README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/README.md) and [`Azure.AI.Language.QuestionAnswering` samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/samples) for the `Azure.AI.Language.QuestionAnswering` library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and namespaces](#package-and-namespaces)
  - [Authenticating](#authenticating)
  - [Querying a question](#querying-a-question)
  - [Chatting](#chatting)

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Question Answering, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

## General changes

### Package and namespaces

Package names and the namespace root for the modern Azure client libraries for .NET have changed. Each will follow the pattern `Azure.[Area].[Services]` where the legacy clients followed the pattern `Microsoft.Azure.[Service]`. This provides a quick and accessible means to help understand, at a glance, whether you are using the modern or legacy clients.

In the case of Question Answering, the modern client libraries have packages and namespaces that begin with `Azure.AI.Language.QuestionAnswering` and were released beginning with version 1. The legacy client libraries have packages and namespaces that begin with `Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker` and a version of 2.x.x or below.

### Authenticating

Previously in `Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker`, you could create a `QnAMakerRuntimeClient` along with `EndpointKeyServiceClientCredentials`:

```C# Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
EndpointKeyServiceClientCredentials credential = new EndpointKeyServiceClientCredentials("{api-key}");

QnAMakerRuntimeClient client = new QnAMakerRuntimeClient(credential)
{
    RuntimeEndpoint = "{endpoint}"
};
```

Now in `Azure.AI.Language.QuestionAnswering`, you create a `QuestionAnsweringClient` along with `AzureKeyCredential` from the package `Azure.Core`:

```C# Snippet:Language_QnA_Maker_Snippets_MigrationGuide_CreateRuntimeClient
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
```

### Querying a question

Previously in `Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker`, you could query for a question using `QueryDTO`:

```C# Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
QueryDTO queryDTO = new QueryDTO();
queryDTO.Question = "{question}";

QnASearchResultList response = await client.Runtime.GenerateAnswerAsync("{knowladgebase-id}", queryDTO);
```

Now in `Azure.AI.Language.QuestionAnswering` you use `client.QueryKnowledgeBaseAsync`:

```C# Snippet:Language_QnA_Maker_Snippets_MigrationGuide_QueryKnowledgeBase
QuestionAnsweringProject project = new QuestionAnsweringProject("{project-name}", "{deployment-name}");
Response<AnswersResult> response = await client.GetAnswersAsync("{question}", project);
```

### Chatting

 Previously in `Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker`, you could chat using `QueryDTO` along with setting the `context` to have `previousQnaId`:

```C# Snippet:CognitiveServices_QnA_Maker_Snippets_MigrationGuide_Chat
QueryDTO queryDTOFollowUp = new QueryDTO();
queryDTOFollowUp.Context = new QueryDTOContext(previousQnaId: 1);

QnASearchResultList responseFollowUp = await client.Runtime.GenerateAnswerAsync("{knowladgebase-id}", queryDTO);
```

Now in `Azure.AI.Language.QuestionAnswering`, you use `QueryKnowledgeBaseOptions` to set `projectName`, `deploymentName`, and `question` along with setting the `context` to have `previousQnaId`:

```C# Snippet:Language_QnA_Maker_Snippets_MigrationGuide_Chat
QuestionAnsweringProject project = new QuestionAnsweringProject("{project-name}", "{deployment-name}");
AnswersOptions options = new AnswersOptions
{
    AnswerContext = new KnowledgeBaseAnswerContext(1)
};

Response<AnswersResult> responseFollowUp = await client.GetAnswersAsync("{question}", project, options);
```
