# Azure Authoring client library for .NET

Azure Conversations Authoring is part of the Azure Cognitive Service for Language, a cloud-based service that provides tools for creating, managing, and deploying conversational AI solutions. This client library offers the following features:

* Creating and managing conversation projects
* Importing and exporting conversation projects
* Training models for conversational AI
* Evaluating trained models
* Deploying conversational AI models
* Swapping deployments for active models
* Canceling active training jobs
* Managing project snapshots
* Deleting trained models and deployments

[Source code][source_root] | [Package (NuGet)][package]| [API reference documentation][text_refdocs] | [Product documentation][text_docs] | [Samples][source_samples]

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Language.Conversations.Authoring --prerelease
```

|SDK version  |Supported API version of service
|-------------|-------------------------------------------------------------
|1.0.0-beta.1 | 2022-05-01, 2023-04-01, 2023-11-15-preview, 2024-11-15-preview (default)

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Language service resource.

### Authenticate the client

In order to interact with the Conversations Authoring service, you'll need to create an instance of the [`AnalyzeConversationAuthoring`][conversationalAnalysisAuthoring_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the `endpoint` and `API key` from the Cognitive Services resource or Language service resource information in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] snippet below to get the API key from the Language service resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create a AnalyzeConversationAuthoring Client

To use the AnalyzeConversationAuthoring client, include the following namespace in your project:

```C#
using Azure.AI.Language.Conversations.Authoring;
```

With your endpoint and API key, you can instantiate an AuthoringClient and create a AnalyzeConversationAuthoring client using specific service options:

```C#
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your-api-key");
AuthoringClient client = new AuthoringClient(endpoint, credential);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

#### Create a client using Azure Active Directory authentication

You can also create a `AnalyzeConversationAuthoring` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
Using the [DefaultAzureCredential] you can authenticate a service using Managed Identity or a service principal, authenticate as a developer working on an application, and more, all without changing code.

Before you can use the `DefaultAzureCredential`, or any credential type from [Azure.Identity][azure_identity], you'll first need to [install the Azure.Identity package][azure_identity_install].

To use `DefaultAzureCredential` with a client ID and secret, you'll need to set the `AZURE_TENANT_ID`, `AZURE_CLIENT_ID`, and `AZURE_CLIENT_SECRET` environment variables; alternatively, you can pass those values
to the `ClientSecretCredential` also in Azure.Identity.

Make sure you use the right namespace for `DefaultAzureCredential` at the top of your source file:

```C# Snippet:Conversations_Identity_Namespace
using Azure.Identity;
using Azure.Core;
```

Then you can create an instance of `DefaultAzureCredential` and pass it to a new instance of your client:

```C# Snippet:AnalyzeConversationAuthoring_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
DefaultAzureCredential credential = new DefaultAzureCredential();
AuthoringClient client = new AuthoringClient(endpoint, credential);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

Note that regional endpoints do not support AAD authentication. Instead, create a [custom domain][custom_domain] name for your resource to use AAD authentication.

### Service API versions

The client library targets the latest service API version by default. A client instance accepts an optional service API version parameter from its options to specify which API version service to communicate.

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options. This ensures that the client can communicate with services using the specified API version.

For example,

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("https://myaccount.cognitiveservices.azure.com");
AzureKeyCredential credential = new("your apikey");
AuthoringClientOptions options = new AuthoringClientOptions(AuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
AuthoringClient client = new AuthoringClient(endpoint, credential, options);
AnalyzeConversationAuthoring authoringClient = client.GetAnalyzeConversationAuthoringClient();
```

When selecting an API version, it's important to verify that there are no breaking changes compared to the latest API version. If there are significant differences, API calls may fail due to incompatibility.

Always ensure that the chosen API version is fully supported and operational for your specific use case and that it aligns with the service's versioning policy.

If you do not select an api version we will default to the latest version available, which has the possibility of being a preview version.

## Key concepts

### AnalyzeConversationAuthoring

The [`AnalyzeConversationAuthoring`][AnalyzeConversationAuthoring_class] is the primary interface for developers using the Azure AI Conversation Authoring client library. It provides both synchronous and asynchronous operations to access a specific use of conversation authoring, such as creating and managing conversation projects.

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples).

* [Create a New Project (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample1_ConversationsAuthoring_CreateProject.md)
* [Create a New Project (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample1_ConversationsAuthoring_CreateProjectAsync.md)
* [Import a Project (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample2_ConversationsAuthoring_Import.md)
* [Import a Project (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample2_ConversationsAuthoring_ImportAsync.md)
* [Export a Project (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample3_ConversationsAuthoring_Export.md)
* [Export a Project (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample3_ConversationsAuthoring_ExportAsync.md)
* [Get Project Details (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample4_ConversationsAuthoring_GetProject.md)
* [Get Project Details (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample4_ConversationsAuthoring_GetProjectAsync.md)
* [Delete a Project (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample5_ConversationsAuthoring_DeleteProject.md)
* [Delete a Project (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample5_ConversationsAuthoring_DeleteProjectAsync.md)
* [Train a Model (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample6_ConversationsAuthoring_Train.md)
* [Train a Model (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample6_ConversationsAuthoring_TrainAsync.md)
* [Cancel Training Job (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample7_ConversationsAuthoring_CancelTrainingJob.md)
* [Cancel Training Job (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample7_ConversationsAuthoring_CancelTrainingJobAsync.md)
* [Get Model Evaluation Summary (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample8_ConversationsAuthoring_GetModelEvaluationSummary.md)
* [Get Model Evaluation Summary (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample8_ConversationsAuthoring_GetModelEvaluationSummaryAsync.md)
* [Get Model Evaluation Results (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample9_ConversationsAuthoring_GetModelEvaluationResults.md)
* [Get Model Evaluation Results (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample9_ConversationsAuthoring_GetModelEvaluationResultsAsync.md)
* [Load Snapshot (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample10_ConversationsAuthoring_LoadSnapshot.md)
* [Load Snapshot (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample10_ConversationsAuthoring_LoadSnapshotAsync.md)
* [Delete a Trained Model (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample11_ConversationsAuthoring_DeleteTrainedModel.md)
* [Delete a Trained Model (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample11_ConversationsAuthoring_DeleteTrainedModelAsync.md)
* [Swap Deployments (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample12_ConversationsAuthoring_SwapDeployments.md)
* [Swap Deployments (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample12_ConversationsAuthoring_SwapDeploymentsAsync.md)
* [Delete a Deployment (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample13_ConversationsAuthoring_DeleteDeployment.md)
* [Delete a Deployment (Async)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample13_ConversationsAuthoring_DeleteDeploymentAsync.md)

## Troubleshooting

### General

When you interact with the Cognitive Language Services Conversations Authoring client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you attempt to create a project with an invalid configuration, a 400 error is returned indicating "Bad Request".

```C# Snippet:AuthoringClient_BadRequest
try
{
    string invalidProjectName = "InvalidProject";

    var projectData = new
    {
        projectName = invalidProjectName,
        language = "invalid-lang", // Invalid language code
        projectKind = "Conversation",
        description = "This is a test for invalid configuration."
    };

    using RequestContent content = RequestContent.Create(projectData);
    Response response = authoringClient.CreateProject(invalidProjectName, content);
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
Azure.RequestFailedException: Invalid Request.
Status: 400 (Bad Request)
ErrorCode: InvalidRequest

Content:
{"error":{"code":"InvalidRequest","message":"Invalid Request.","innererror":{"code":"LanguageCodeInvalid","message":"The language code is invalid. Possible values are: en, es, fr, ..."}}}

Headers:
Transfer-Encoding: chunked
x-envoy-upstream-service-time: REDACTED
apim-request-id: REDACTED
Strict-Transport-Security: REDACTED
X-Content-Type-Options: REDACTED
x-ms-region: REDACTED
Date: Wed, 24 Jul 2024 13:39:00 GMT
Content-Type: application/json; charset=utf-8
```

### Setting up console logging

The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][logging].

## Next steps

* View our [samples][source_samples].
* Read about the different [features][text_docs] of the Conversations Authoring.

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md
[azure_identity_install]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#install-the-package
[custom_domain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[source_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples
[source_migration]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/MigrationGuide.md
[source_root]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/src
[package]: https://www.nuget.org/packages/
[text_refdocs]: https://learn.microsoft.com/dotnet/
[text_docs]: https://learn.microsoft.com/azure/ai-services/language-service/conversational-language-understanding/overview
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[conversationalAnalysisAuthoring_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/src/Generated/AnalyzeConversationAuthoring.cs
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication/
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_portal]: https://portal.azure.com
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/README.png)
