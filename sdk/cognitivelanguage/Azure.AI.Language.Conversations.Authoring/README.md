# Azure Authoring client library for .NET

Azure Conversations Authoring is part of the Azure Cognitive Service for Language, a cloud-based service that provides tools for creating, managing, and deploying conversational AI solutions. This client library offers the following features:

* Creating and managing conversation projects
* Importing conversation projects
* Exporting conversation projects
* Getting project details
* Deleting projects
* Training models for conversational AI
* Canceling active training jobs
* Evaluating model summaries
* Evaluating model results
* Managing project snapshots
* Loading snapshots
* Deploying conversational AI models
* Swapping deployments for active models
* Deleting trained models
* Deleting deployments
* Assigning deployment resources
* Getting deployment resource assignment status
* Unassigning deployment resources
* Getting deployment resource unassignment status

[Source code][source_root] | [Package (NuGet)][package]| [API reference documentation][text_refdocs] | [Product documentation][text_docs] | [Samples][source_samples]

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/ ):

```dotnetcli
dotnet add package Azure.AI.Language.Conversations.Authoring --prerelease
```

|SDK version  |Supported API version of service
|-------------|----------------------------------------------------------------------
|1.0.0-beta.1 | 2023-04-01, 2023-04-15-preview, 2024-11-15-preview (default)
|1.0.0-beta.2 | 2023-04-01, 2023-04-15-preview, 2024-11-15-preview, 2025-05-15-preview (default)

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Language service resource.

### Authenticate the client

In order to interact with the Conversations Authoring service, you'll need to create an instance of the [`ConversationAnalysisAuthoringClient`][ConversationAnalysisAuthoringClient_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

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

With your endpoint and API key, you can instantiate a `ConversationAnalysisAuthoringClient` using specific service options:

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

#### Create a client using Azure Active Directory authentication

You can also create a `ConversationAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
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
Uri endpoint = new Uri("{endpoint}");
DefaultAzureCredential credential = new DefaultAzureCredential();
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential);
```

Note that regional endpoints do not support AAD authentication. Instead, create a [custom domain][custom_domain] name for your resource to use AAD authentication.

### Service API versions

The client library targets the latest service API version by default. A client instance accepts an optional service API version parameter from its options to specify which API version service to communicate.

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options. This ensures that the client can communicate with services using the specified API version.

For example,

```C# Snippet:CreateAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
ConversationAnalysisAuthoringClientOptions options = new ConversationAnalysisAuthoringClientOptions(ConversationAnalysisAuthoringClientOptions.ServiceVersion.V2024_11_15_Preview);
ConversationAnalysisAuthoringClient client = new ConversationAnalysisAuthoringClient(endpoint, credential, options);
```

When selecting an API version, it's important to verify that there are no breaking changes compared to the latest API version. If there are significant differences, API calls may fail due to incompatibility.

Always ensure that the chosen API version is fully supported and operational for your specific use case and that it aligns with the service's versioning policy.

If you do not select an api version we will default to the latest version available, which has the possibility of being a preview version.

## Key concepts

### ConversationAuthoringClientlet

The [ConversationAuthoringProject][ConversationAuthoringProject_class], [ConversationAuthoringDeployment][ConversationAuthoringDeployment_class], [ConversationAuthoringExportedModel][ConversationAuthoringExportedModel_class] and [ConversationAuthoringTrainedModel][ConversationAuthoringTrainedModel_class] are the clientlets for developers using the Azure AI Conversation Authoring client library. It provides both synchronous and asynchronous operations to access a specific use of conversation authoring, such as creating and managing conversation projects.

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
* [Import a Project (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample2_ConversationsAuthoring_Import.md)
* [Export a Project (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample3_ConversationsAuthoring_Export.md)
* [Get Project Details (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample4_ConversationsAuthoring_GetProject.md)
* [Delete a Project (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample5_ConversationsAuthoring_DeleteProject.md)
* [Train a Model (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample6_ConversationsAuthoring_Train.md)
* [Cancel Training Job (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample7_ConversationsAuthoring_CancelTrainingJob.md)
* [Get Model Evaluation Summary (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample8_ConversationsAuthoring_GetModelEvaluationSummary.md)
* [Get Model Evaluation Results (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample9_ConversationsAuthoring_GetModelEvaluationResults.md)
* [Load Snapshot (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample10_ConversationsAuthoring_LoadSnapshot.md)
* [Delete a Trained Model (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample11_ConversationsAuthoring_DeleteTrainedModel.md)
* [Swap Deployments (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample12_ConversationsAuthoring_SwapDeployments.md)
* [Delete a Deployment (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample13_ConversationsAuthoring_DeleteDeployment.md)
* [Deploy a Project (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample14_ConversationsAuthoring_DeployProject.md)
* [Assign Deployment Resources (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample16_ConversationsAuthoring_AssignDeploymentResources.md)
* [Get Assign Deployment Resources Status (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample17_ConversationsAuthoring_GetAssignDeploymentResourcesStatus.md)
* [Unassign Deployment Resources (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample18_ConversationsAuthoring_UnassignDeploymentResources.md)
* [Get Unassign Deployment Resources Status (Sync)](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/samples/Sample19_ConversationsAuthoring_GetUnassignDeploymentResourcesStatus.md)

## Troubleshooting

### General

When you interact with the Cognitive Language Services Conversations Authoring client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you attempt to create a project with an invalid configuration, a 400 error is returned indicating "Bad Request".

```C# Snippet:AuthoringClient_BadRequest
try
{
    string invalidProjectName = "InvalidProject";
    ConversationAuthoringProject projectClient = client.GetProject(invalidProjectName);
    ConversationAuthoringCreateProjectDetails projectData = new ConversationAuthoringCreateProjectDetails(
      projectKind: "Conversation",
      language: "invalid-lang"
    )
    {
        Description = "This is a test for invalid configuration."
    };
    using RequestContent content = RequestContent.Create(projectData);
    Response response = projectClient.CreateProject(content);
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
[ConversationAnalysisAuthoringClient_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/src/Generated/ConversationAnalysisAuthoringClient.cs
[ConversationAuthoringProject_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/src/Generated/ConversationAuthoringProject.cs
[ConversationAuthoringDeployment_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/src/Generated/ConversationAuthoringDeployment.cs
[ConversationAuthoringExportedModel_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/src/Generated/ConversationAuthoringExportedModel.cs
[ConversationAuthoringTrainedModel_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/src/Generated/ConversationAuthoringTrainedModel.cs
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication/
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_portal]: https://portal.azure.com
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
