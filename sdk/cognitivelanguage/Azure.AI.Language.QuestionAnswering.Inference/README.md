# Azure Cognitive Language Services Question Answering client library for .NET

The Question Answering service is a cloud-based API service that lets you create a conversational question-and-answer layer over your existing data. Use it to build a knowledge base by extracting questions and answers from your semi-structured content, including FAQ, manuals, and documents. Answer users’ questions with the best answers from the QnAs in your knowledge base—automatically. Your knowledge base gets smarter, too, as it continually learns from user behavior.

[Source code][questionanswering_client_src] | [Package (NuGet)][questionanswering_nuget_package] | [API reference documentation][questionanswering_refdocs] | [Samples][questionanswering_samples] | [Migration guide][migration_guide] | [Product documentation][questionanswering_docs] | [REST API documentation][questionanswering_rest_docs]
## Getting started

### Install the package

Install the Azure Cognitive Language Services Question Answering client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.Language.QuestionAnswering
```

### Prerequisites

* An [Azure subscription][azure_subscription]
* An existing Question Answering resource

Though you can use this SDK to create and import conversation projects, [Language Studio][language_studio] is the preferred method for creating projects.

### Authenticate the client

In order to interact with the Question Answering service, you'll need to either create an instance of the [`QuestionAnsweringClient`][questionanswering_client_class] class for querying existing projects within your resource. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the **endpoint** and an **API key** from the Cognitive Services resource or Question Answering resource in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] command shown below to get the API key from the Question Answering resource.

```powershell
az cognitiveservices account keys list --resource-group <resource-group-name> --name <resource-name>
```

#### Create a QuestionAnsweringClient

To use the `QuestionAnsweringClient`, make sure you use the right namespaces:

```C# Snippet:QuestionAnsweringClient_Namespaces
using Azure.Core;
using Azure.AI.Language.QuestionAnswering;
```

With your **endpoint** and **API key** you can instantiate a `QuestionAnsweringClient`:

```C# Snippet:QuestionAnsweringClient_Create
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com/");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
```

#### Create a client using Azure Active Directory authentication

You can also create a `QuestionAnsweringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
Using the [DefaultAzureCredential] you can authenticate a service using Managed Identity or a service principal, authenticate as a developer working on an application, and more all without changing code.

Before you can use the `DefaultAzureCredential`, or any credential type from [Azure.Identity][azure_identity], you'll first need to [install the Azure.Identity package][azure_identity_install].

To use `DefaultAzureCredential` with a client ID and secret, you'll need to set the `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, and `AZURE_CLIENT_SECRET` environment variables; alternatively, you can pass those values
to the `ClientSecretCredential` also in Azure.Identity.

Make sure you use the right namespace for `DefaultAzureCredential` at the top of your source file:

```C# Snippet:QuestionAnswering_Identity_Namespace
using Azure.Identity;
```

Then you can create an instance of `DefaultAzureCredential` and pass it to a new instance of your client:

```C# Snippet:QuestionAnsweringClient_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
DefaultAzureCredential credential = new DefaultAzureCredential();

QuestionAnsweringClient client = new QuestionAnsweringClient(endpoint, credential);
```

Note that regional endpoints do not support AAD authentication. Instead, create a [custom domain][custom_domain] name for your resource to use AAD authentication.

## Key concepts

### QuestionAnsweringClient

The [`QuestionAnsweringClient`][questionanswering_client_class] is the primary interface for asking questions using a knowledge base with your own information, or text input using pre-trained models. It provides both synchronous and asynchronous APIs to ask questions.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

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

### QuestionAnsweringClient

The Azure.AI.Language.QuestionAnswering client library provides both synchronous and asynchronous APIs.

The following examples show common scenarios using the `client` [created above](#create-a-questionansweringclient).

#### Ask a question

The only input required to a ask a question using an existing knowledge base is just the question itself:

```C# Snippet:QuestionAnsweringClient_GetAnswers
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

You can set additional properties on `QuestionAnsweringClientOptions` to limit the number of answers, specify a minimum confidence score, and more.

#### Ask a follow-up question

If your knowledge base is configured for [chit-chat][questionanswering_docs_chat], you can ask a follow-up question provided the previous question-answering ID and, optionally, the exact question the user asked:

```C# Snippet:QuestionAnsweringClient_Chat
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

### General

When you interact with the Cognitive Language Services Question Answering client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][questionanswering_rest_docs] requests.

For example, if you submit a question to a non-existant knowledge base, a `400` error is returned indicating "Bad Request".

```C# Snippet:QuestionAnsweringClient_BadRequest
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

You will notice that additional information is logged, like the client request ID of the operation.

```text
Azure.RequestFailedException: Please verify azure search service is up, restart the WebApp and try again
Status: 400 (Bad Request)
ErrorCode: BadArgument

Content:
{
    "error": {
    "code": "BadArgument",
    "message": "Please verify azure search service is up, restart the WebApp and try again"
    }
}

Headers:
x-envoy-upstream-service-time: 23
apim-request-id: 76a83876-22d1-4977-a0b1-559a674f3605
Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
X-Content-Type-Options: nosniff
Date: Wed, 30 Jun 2021 00:32:07 GMT
Content-Length: 139
Content-Type: application/json; charset=utf-8
```

### Setting up console logging

The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console use the `AzureEventSourceListener.CreateConsoleLogger` method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][core_logging].

## Next steps

* View our [samples][questionanswering_samples].
* Read about the different [features][questionanswering_docs_features] of the Question Answering service.
* Try our service [demos][questionanswering_docs_demos].

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_cli]: https://learn.microsoft.com/cli/azure/
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[azure_identity_install]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#install-the-package
[azure_portal]: https://portal.azure.com/
[azure_subscription]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[coc_contact]: mailto:opencode@microsoft.com
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[cognitive_auth]: https://learn.microsoft.com/azure/cognitive-services/authentication/
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[core_logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[custom_domain]: https://learn.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[language_studio]: https://language.cognitive.azure.com/
[nuget]: https://www.nuget.org/

[questionanswering_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/src/QuestionAnsweringClient.cs
[questionanswering_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/src/
[questionanswering_docs]: https://learn.microsoft.com/azure/cognitive-services/qnamaker/
[questionanswering_docs_chat]: https://learn.microsoft.com/azure/cognitive-services/qnamaker/how-to/chit-chat-knowledge-base
[questionanswering_docs_demos]: https://azure.microsoft.com/services/cognitive-services/qna-maker/#demo
[questionanswering_docs_features]: https://azure.microsoft.com/services/cognitive-services/qna-maker/#features
[questionanswering_nuget_package]: https://nuget.org/packages/Azure.AI.Language.QuestionAnswering/
[questionanswering_refdocs]: https://learn.microsoft.com/dotnet/api/Azure.AI.Language.QuestionAnswering/
[questionanswering_rest_docs]: https://learn.microsoft.com/rest/api/language/question-answering
[questionanswering_rest_docs_projects]: https://learn.microsoft.com/rest/api/language/question-answering-projects
[questionanswering_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/samples/README.md
[migration_guide]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/MigrationGuide.md
