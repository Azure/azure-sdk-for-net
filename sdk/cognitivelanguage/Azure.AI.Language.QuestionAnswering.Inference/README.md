# Azure Cognitive Language Services Question Answering (Inference) client library for .NET

The Question Answering service lets you build a conversational question–answering layer over your data. It can extract questions and answers from semi‑structured content (FAQs, manuals, documents) and improve relevance over time.

[Source code][questionanswering_client_src] | [Samples][questionanswering_samples] | [Product documentation][questionanswering_docs] | [REST API documentation][questionanswering_rest_docs]

> This package provides **runtime inference (querying)** only.  
> To create/update/deploy projects (authoring operations), use the Authoring package `Azure.AI.Language.QuestionAnswering.Authoring` (namespace: `Azure.AI.Language.QuestionAnswering.Authoring`).

## Getting started

Service API version targeted: `2025-05-15-preview`  
Package version: `1.0.0-beta.1` (preview).

### Install the package

```dotnetcli
dotnet add package Azure.AI.Language.QuestionAnswering.Inference --prerelease
```

### Prerequisites

* An [Azure subscription][azure_subscription]
* A Cognitive Services Language resource with a deployed Question Answering project (created via Authoring SDK or Language Studio)
* Endpoint (e.g. `https://<resource>.cognitiveservices.azure.com/`)
* API key or AAD credential (Reader role)

Language Studio remains the preferred experience for creating and managing projects; the Authoring SDK enables CI/CD automation.

### Authenticate the client

You need an endpoint plus either an API key or AAD credential.

#### API key

```C# Snippet:QuestionAnsweringClient_Namespaces_Inference
using Azure.Core;
using Azure.AI.Language.QuestionAnswering;
```

```C# Snippet:QuestionAnsweringClient_Create_Inference
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com/");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
```

#### Azure Active Directory (AAD)

```C# Snippet:QuestionAnswering_Identity_Namespace_Inference
using Azure.Identity;
```

```C# Snippet:QuestionAnsweringClient_CreateWithDefaultAzureCredential_Inference
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
DefaultAzureCredential credential = new DefaultAzureCredential();

QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
```

> Regional endpoints do not support AAD directly; configure a [custom domain][custom_domain] to use AAD authentication.

## Key concepts

- `QuestionAnsweringClient`: asks questions against a deployed project (knowledge base).
- `QuestionAnsweringProject`: identifies the project and deployment.
- `AnswersOptions`: optional tuning (top answers, confidence threshold, follow‑up context).
- `AnswersResult` / `KnowledgeBaseAnswer`: structured answers (confidence, source, answer text, optional short answer).
- Follow‑up (chit‑chat) uses `KnowledgeBaseAnswerContext(previousAnswer.QnaId.Value)` for dialog continuity.
- This package does **not** include project creation, source ingestion, QnA editing, deployment operations.

### Thread safety

Client instances are thread‑safe; reuse them across threads and requests.

### Additional concepts

<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

### Ask a question

```C# Snippet:QuestionAnsweringClient_GetAnswers_Inference
string projectName = "{ProjectName}";
string deploymentName = "{DeploymentName}";
QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
Response<AnswersResult> response = client.GetAnswers("How long should my Surface battery last?", project);

foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
{
    Console.WriteLine($"({answer.Confidence:P2}) {answer.Answer}");
    Console.WriteLine($"Source: {answer.Source}");
    Console.WriteLine();
}
```

### Ask a follow‑up question (chit‑chat)

```C# Snippet:QuestionAnsweringClient_Chat_Inference
string projectName = "{ProjectName}";
string deploymentName = "{DeploymentName}";
// Answers are ordered by their ConfidenceScore so assume the user choose the first answer below:
KnowledgeBaseAnswer previousAnswer = answers.Answers.First();
QuestionAnsweringProject project = new QuestionAnsweringProject(projectName, deploymentName);
AnswersOptions options = new AnswersOptions
{
    AnswerContext = new KnowledgeBaseAnswerContext(previousAnswer.QnaId.Value)
};

Response<AnswersResult> response = client.GetAnswers("How long should charging take?", project, options);

foreach (KnowledgeBaseAnswer answer in response.Value.Answers)
{
    Console.WriteLine($"({answer.Confidence:P2}) {answer.Answer}");
    Console.WriteLine($"Source: {answer.Source}");
    Console.WriteLine();
}
```

## Troubleshooting

Common HTTP status codes map directly from service responses (e.g. 400 invalid project/deployment, 404 not found).

Bad request example:

```C# Snippet:QuestionAnsweringClient_BadRequest_Inference
try
{
    QuestionAnsweringProject project = new QuestionAnsweringProject("invalid-knowledgebase", "test");
    Response<AnswersResult> response = client.GetAnswers("Does this knowledge base exist?", project);
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

Enable console diagnostics:

```csharp
using Azure.Core.Diagnostics;
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

## Next steps

* Explore [samples][questionanswering_samples].
* Use Authoring SDK or Language Studio to evolve your knowledge base.
* Review the migration guide

## Contributing

See [CONTRIBUTING.md][contributing]. This project follows the Microsoft Open Source Code of Conduct.

<!-- LINKS -->
[questionanswering_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Inference/src/
[questionanswering_refdocs]: https://learn.microsoft.com/dotnet/api/Azure.AI.Language.QuestionAnswering.Inference
[questionanswering_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Inference/samples/README.md
[questionanswering_docs]: https://learn.microsoft.com/azure/ai-services/language-service/question-answering/overview
[questionanswering_docs_chat]: https://learn.microsoft.com/azure/ai-services/language-service/question-answering/how-to/chit-chatview=rest-language-question-answering-2025-05-15-preview
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[custom_domain]: https://learn.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
