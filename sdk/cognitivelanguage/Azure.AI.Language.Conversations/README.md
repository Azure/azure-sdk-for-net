# Azure Cognitive Language Services Conversations client library for .NET

The Azure.AI.Language.Conversations client library provides a suite of APIs for conversational language analysis capabilities like conversation language understanding and orchestration, conversational summarization and conversational personally identifiable information (PII) detection.

Conversation Language Understanding - aka CLU for short - is a cloud-based conversational AI service which provides many language understanding capabilities like:
- Conversation App: It's used in extracting intents and entities in conversations
- Workflow app: Acts like an orchestrator to select the best candidate to analyze conversations to get best response from apps like Qna, Luis, and Conversation App

Conversation Summarization is one feature offered by Azure AI Language, which is a combination of generative Large Language models and task-optimized encoder models that offer summarization solutions with higher quality, cost efficiency, and lower latency.

Conversation PII detection another feature offered by Azure AI Language, which is a collection of machine learning and AI algorithms to identify, categorize, and redact sensitive information in text. The Conversational PII model is a specialized model for handling speech transcriptions and the more informal, conversational tone of meeting and call transcripts.

[Source code][conversationanalysis_client_src] | [Package (NuGet)][conversationanalysis_nuget_package] | [API reference documentation][conversationanalysis_refdocs] | [Samples][conversationanalysis_samples] | [Product documentation][conversationanalysis_docs] | [Analysis REST API documentation][conversationanalysis_restdocs]

> [!NOTE]
> Conversational Authoring is not supported in version 2.0.0-beta.1. If you use Conversational Authoring, please continue to use version 1.1.0. You can find the [samples][conversationalauthoring_samples] here.

## Getting started

### Install the package

Install the Azure Cognitive Language Services Conversations client library for .NET with [NuGet][nuget]:

```powershell
dotnet add package Azure.AI.Language.Conversations
```

### Prerequisites

- An [Azure subscription][azure_subscription]
- An existing Azure Language Service Resource

Though you can use this SDK to create and import conversation projects, [Azure AI Foundry][azure_AI_foundry] is the preferred method for creating projects.

### Authenticate the client

In order to interact with the Conversations service, you'll need to create an instance of the [`ConversationAnalysisClient`][conversationanalysis_client_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the **endpoint** and an **API key** from the Cognitive Services resource in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] command shown below to get the API key from the Cognitive Service resource.

```powershell
az cognitiveservices account keys list --resource-group <resource-group-name> --name <resource-name>
```

#### Namespaces

Start by importing the namespace for the [`ConversationAnalysisClient`][conversationanalysis_client_class] and related class:

```C# Snippet:ConversationAnalysisClient_Namespaces
using Azure.Core;
using Azure.Core.Serialization;
using Azure.AI.Language.Conversations;
using Azure.AI.Language.Conversations.Models;
```

#### Create a ConversationAnalysisClient

Once you've determined your **endpoint** and **API key** you can instantiate a `ConversationAnalysisClient`:

```C# Snippet:ConversationAnalysisClient_Create
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

#### Create a client using Azure Active Directory authentication

You can also create a `ConversationAnalysisClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
Using the [DefaultAzureCredential] you can authenticate a service using Managed Identity or a service principal, authenticate as a developer working on an application, and more all without changing code.

Before you can use the `DefaultAzureCredential`, or any credential type from [Azure.Identity][azure_identity], you'll first need to [install the Azure.Identity package][azure_identity_install].

To use `DefaultAzureCredential` with a client ID and secret, you'll need to set the `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, and `AZURE_CLIENT_SECRET` environment variables; alternatively, you can pass those values
to the `ClientSecretCredential` also in Azure.Identity.

Make sure you use the right namespace for `DefaultAzureCredential` at the top of your source file:

```C# Snippet:Conversation_Identity_Namespace
using Azure.Identity;
```

Then you can create an instance of `DefaultAzureCredential` and pass it to a new instance of your client:

```C# Snippet:ConversationAnalysisClient_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("{endpoint}");
DefaultAzureCredential credential = new DefaultAzureCredential();

ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential);
```

Note that regional endpoints do not support AAD authentication. Instead, create a [custom domain][custom_domain] name for your resource to use AAD authentication.

### Service API versions

The client library targets the latest service API version by default. A client instance accepts an optional service API version parameter from its options to specify which API version service to communicate.

|SDK version  |Supported API version of service
|-------------|---------------------------------------------------------------------------------------------------------------------------
|2.0.0-beta.3 | 2022-05-01, 2023-04-01, 2024-05-01, 2024-05-15-preview, 2024-11-01, 2024-11-15-preview, 2025-05-15-preview (default)
|2.0.0-beta.2 | 2022-05-01, 2023-04-01, 2024-05-01, 2024-05-15-preview, 2024-11-01, 2024-11-15-preview (default)
|2.0.0-beta.1 | 2022-05-01, 2023-04-01, 2024-05-01, 2024-05-15-preview (default)
|1.1.0 | 2022-05-01, 2023-04-01 (default)
|1.0.0 | 2022-05-01 (default)

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options. This ensures that the client can communicate with services using the specified API version.

For example,

```C# Snippet:CreateConversationAnalysisClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationsClientOptions options = new ConversationsClientOptions(ConversationsClientOptions.ServiceVersion.V2025_05_15_Preview);
ConversationAnalysisClient client = new ConversationAnalysisClient(endpoint, credential, options);
```

When selecting an API version, it's important to verify that there are no breaking changes compared to the latest API version. If there are significant differences, API calls may fail due to incompatibility.

Always ensure that the chosen API version is fully supported and operational for your specific use case and that it aligns with the service's versioning policy.

If you do not select an api version we will default to the latest version available, which has the possibility of being a preview version.

## Key concepts

### ConversationAnalysisClient

The [`ConversationAnalysisClient`][conversationanalysis_client_class] is the primary interface for making predictions using your deployed Conversations models. It provides both synchronous and asynchronous APIs to submit queries.

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

You can familiarize yourself with different APIs using [Samples](https://github.com/amber-ccc/azure-sdk-for-net/tree/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples).

* [Analyze a conversation - Conversation project](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample1_AnalyzeConversation_ConversationPrediction.md)
* [Analyze a conversation - Orchestration project](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample2_AnalyzeConversation_OrchestrationPrediction.md)
* [Analyze a conversation in a different language](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample3_AnalyzeConversationWithLanguage.md)
* [Analyze a conversation using extra options](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample4_AnalyzeConversationWithOptions.md)
* [Analyze a conversation - Conversational AI project](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample10_AnalyzeConversation_ConversationalAIPrediction.md)
* [Analyze a conversation with Conversation Summarization](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample5_AnalyzeConversation_ConversationSummarization.md)
* [Analyze a conversation with Conversation PII](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample6_AnalyzeConversation_ConversationPii.md)
* [Analyze a Conversation for PII Using Character Masking](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample7_AnalyzeConversation_ConversationPiiWithCharacterMaskPolicy.md)
* [Analyze a Conversation for PII Using Entity Masking](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample8_AnalyzeConversation_ConversationPiiWithEntityMaskPolicy.md)
* [Analyze a Conversation for PII With No Masking](https://github.com/amber-ccc/azure-sdk-for-net/blob/amber/create_conversation_runtime_sdk_preview_20250515/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/Sample9_AnalyzeConversation_ConversationPiiWithNoMaskPolicy.md)

## Troubleshooting

### General

When you interact with the Cognitive Language Services Conversations client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you submit a utterance to a non-existant project, a `400` error is returned indicating "Bad Request".

```C# Snippet:ConversationAnalysisClient_BadRequest
try
{
    var data = new
    {
        analysisInput = new
        {
            conversationItem = new
            {
                text = "Send an email to Carol about tomorrow's demo",
                id = "1",
                participantId = "1",
            }
        },
        parameters = new
        {
            projectName = "invalid-project",
            deploymentName = "production",

            // Use Utf16CodeUnit for strings in .NET.
            stringIndexType = "Utf16CodeUnit",
        },
        kind = "Conversation",
    };

    Response response = client.AnalyzeConversation(RequestContent.Create(data));
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```text
Azure.RequestFailedException: The input parameter is invalid.
Status: 400 (Bad Request)
ErrorCode: InvalidArgument

Content:
{
  "error": {
    "code": "InvalidArgument",
    "message": "The input parameter is invalid.",
    "innerError": {
      "code": "InvalidArgument",
      "message": "The input parameter \"payload\" cannot be null or empty."
    }
  }
}

Headers:
Transfer-Encoding: chunked
pragma: no-cache
request-id: 0303b4d0-0954-459f-8a3d-1be6819745b5
apim-request-id: 0303b4d0-0954-459f-8a3d-1be6819745b5
x-envoy-upstream-service-time: 15
Strict-Transport-Security: max-age=31536000; includeSubDomains; preload
x-content-type-options: nosniff
Cache-Control: no-store, proxy-revalidate, no-cache, max-age=0, private
Content-Type: application/json
```

### Setting up console logging

The simplest way to see the logs is to enable console logging. To create an Azure SDK log listener that outputs messages to the console use the `AzureEventSourceListener.CreateConsoleLogger` method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][core_logging].

## Next steps

- View our [samples][conversationanalysis_samples].
- Read about the different [features][conversationanalysis_docs_features] of the Conversations service.
- Try our service [demos][conversationanalysis_docs_demos].

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
[azure_AI_foundry]: https://ai.azure.com/
[nuget]: https://www.nuget.org/

[conversationanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/src/ConversationAnalysisClient.cs
[conversationanalysis_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/src/
[conversationanalysis_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations/samples/
[conversationanalysis_nuget_package]: https://www.nuget.org/packages/Azure.AI.Language.Conversations/
[conversationanalysis_docs]: https://learn.microsoft.com/azure/cognitive-services/language-service/conversational-language-understanding/overview
[conversationanalysis_docs_demos]: https://learn.microsoft.com/azure/cognitive-services/language-service/conversational-language-understanding/quickstart
[conversationanalysis_docs_features]: https://learn.microsoft.com/azure/cognitive-services/language-service/conversational-language-understanding/overview
[conversationanalysis_refdocs]: https://learn.microsoft.com/dotnet/api/azure.ai.language.conversations
[conversationanalysis_restdocs]: https://learn.microsoft.com/rest/api/language/
[conversationalauthoring_samples]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/README.md
