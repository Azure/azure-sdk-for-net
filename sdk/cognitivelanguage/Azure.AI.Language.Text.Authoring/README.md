# Azure Authoring client library for .NET

Azure Text Authoring is part of the Azure Cognitive Service for Language, a cloud-based service that provides tools for creating, managing, and deploying text processing and AI solutions. This client library offers the following features:

* Creating and managing text analysis projects
* Importing data into text analysis projects
* Exporting text analysis projects
* Retrieving project details
* Deleting projects
* Training models
* Canceling training jobs
* Retrieving model evaluation summaries
* Retrieving model evaluation results
* Managing project snapshots
* Deleting trained models
* Swapping deployments
* Deleting deployments
* Deploying trained models
* Retrieving deployment details
* Assigning deployment resources
* Checking the status of assigned resource operations
* Unassigning deployment resources
* Checking the status of unassigned resource operations

[Source code][source_root] | [Package (NuGet)][package] | [API reference documentation][text_refdocs] | [Product documentation][text_docs] | [Samples][source_samples]

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.Language.Text.Authoring --prerelease
```

|SDK version  |Supported API version of service
|-------------|------------------------------------------------------------------------------
|1.0.0-beta.1 | 2023-04-01, 2023-04-15-preview, 2024-11-15-preview (default)
|1.0.0-beta.2 | 2023-04-01, 2023-04-15-preview, 2024-11-15-preview, 2025-05-15-preview (default)

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Language service resource.

### Authenticate the client

In order to interact with the Text Authoring service, you'll need to create an instance of the [`TextAnalysisAuthoringClient`][TextAnalysisAuthoringClient_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object. For more information regarding authenticating with Cognitive Services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the `endpoint` and `API key` from the Cognitive Services resource or Language service resource information in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] snippet below to get the API key from the Language service resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create a TextAnalysisAuthoringClient

To use the TextAnalysisAuthoringClient, include the following namespace in your project:

```C#
using Azure.AI.Language.Text.Authoring;
```

With your endpoint and API key, you can instantiate a TextAnalysisAuthoringClient using specific service options:

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

#### Create a client using Azure Active Directory authentication

You can also create a `TextAnalysisAuthoringClient` using Azure Active Directory (AAD) authentication. Your user or service principal must be assigned the "Cognitive Services Language Reader" role.
Using the [DefaultAzureCredential], you can authenticate a service using Managed Identity or a service principal, authenticate as a developer working on an application, and more, all without changing code.

Before you can use the `DefaultAzureCredential`, or any credential type from [Azure.Identity][azure_identity], you'll first need to [install the Azure.Identity package][azure_identity_install].

To use DefaultAzureCredential with a client ID and secret, you'll need to set the AZURE_TENANT_ID, AZURE_CLIENT_ID, and AZURE_CLIENT_SECRET environment variables; alternatively, you can pass those values to the ClientSecretCredential also in Azure.Identity.

Make sure you use the right namespace for DefaultAzureCredential at the top of your source file:

```C# Snippet:TextAuthoring_Identity_Namespace
using Azure.Identity;
using Azure.Core;
using Microsoft.Extensions.Options;
```

Then you can create an instance of DefaultAzureCredential and pass it to a new instance of your client:

```C# Snippet:TextAnalysisAuthoring_CreateWithDefaultAzureCredential
Uri endpoint = new Uri("{endpoint}");;
DefaultAzureCredential credential = new DefaultAzureCredential();
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential);
```

Note that regional endpoints do not support AAD authentication. Instead, create a [custom domain][custom_domain] name for your resource to use AAD authentication.

### Service API versions

The client library targets the latest service API version by default. A client instance accepts an optional service API version parameter from its options to specify which API version service to communicate.

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options. This ensures that the client can communicate with services using the specified API version.

For example:

```C# Snippet:CreateTextAuthoringClientForSpecificApiVersion
Uri endpoint = new Uri("{endpoint}");
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");
TextAnalysisAuthoringClientOptions options = new TextAnalysisAuthoringClientOptions(TextAnalysisAuthoringClientOptions.ServiceVersion.V2025_05_15_Preview);
TextAnalysisAuthoringClient client = new TextAnalysisAuthoringClient(endpoint, credential, options);
```

When selecting an API version, it's important to verify that there are no breaking changes compared to the latest API version. If there are significant differences, API calls may fail due to incompatibility.

Always ensure that the chosen API version is fully supported and operational for your specific use case and that it aligns with the service's versioning policy.

If you do not select an API version, we will default to the latest version available, which has the possibility of being a preview version.

## Key concepts

### TextAuthoringClientlet

The [TextAuthoringProject][TextAuthoringProject_class], [TextAuthoringDeployment][TextAuthoringDeployment_class], [TextAuthoringExportedModel][TextAuthoringExportedModel_class] and [TextAuthoringTrainedModel][TextAuthoringTrainedModel_class] are the clientlets for developers using the Azure AI Text Authoring client library. It provides both synchronous and asynchronous operations to access a specific use of text authoring, such as creating and managing text analysis projects.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other (guideline). This ensures that the recommendation of reusing client instances is always safe, even across threads.

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

You can familiarize yourself with different APIs using [Samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples).

* [Create a New Project](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample1_TextAuthoring_CreateProject.md)
* [Import a Project](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample2_TextAuthoring_Import.md)
* [Export a Project](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample3_TextAuthoring_Export.md)
* [Get Project Details](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample4_TextAuthoring_GetProject.md)
* [Delete a Project](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample5_TextAuthoring_DeleteProject.md)
* [Train a Model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample6_TextAuthoring_Train.md)
* [Cancel Training Job](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample7_TextAuthoring_CancelTrainingJob.md)
* [Get Model Evaluation Summary](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample8_TextAuthoring_GetModelEvaluationSummary.md)
* [Get Model Evaluation Results](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample9_TextAuthoring_GetModelEvaluationResults.md)
* [Load Snapshot](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample10_TextAuthoring_LoadSnapshot.md)
* [Delete a Trained Model](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample11_TextAuthoring_DeleteTrainedModel.md)
* [Swap Deployments](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample12_TextAuthoring_SwapDeployments.md)
* [Delete a Deployment](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample13_TextAuthoring_DeleteDeployment.md)
* [Deploy a Project](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample14_TextAuthoring_DeployProject.md)
* [Get Deployment Details](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample15_TextAuthoring_GetDeployment.md)
* [Assign Deployment Resources](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample16_TextAuthoring_AssignDeploymentResources.md)
* [Get Deployment Resources Assignment Status](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample17_TextAuthoring_GetAssignDeploymentResourcesStatus.md)
* [Unassign Deployment Resources](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample18_TextAuthoring_UnassignDeploymentResources.md)
* [Get Deployment Resources Unassignment Status](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples/Sample19_TextAuthoring_GetUnassignDeploymentResourcesStatus.md)

## Troubleshooting

### General

When you interact with the Cognitive Language Services Text Authoring client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests.

For example, if you attempt to create a project with an invalid configuration, a 400 error is returned indicating "Bad Request".

```C# Snippet:TextAuthoringClient_BadRequest
try
{
    string invalidProjectName = "InvalidProject";
    TextAuthoringProject projectClient = client.GetProject(invalidProjectName);
    var projectData = new TextAuthoringCreateProjectDetails(
        projectKind: "Text",
        storageInputContainerName: "e2e0test0data",
        language: "invalid-lang" // Invalid language code
    )
    {
        Description = "This is a test for invalid configuration."
    };

    Response response = projectClient.CreateProject(projectData);
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
To create an Azure SDK log listener that outputs messages to the console, use AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms, see [here][logging].

## Next steps

View our [samples][source_samples].
Read about the different [features][text_docs] of the Text Authoring.

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
[source_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/samples
[source_migration]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/MigrationGuide.md
[source_root]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/src
[package]: https://www.nuget.org/packages/
[text_refdocs]: https://learn.microsoft.com/dotnet/
[text_docs]: https://learn.microsoft.com/azure/ai-services/language-service/conversational-language-understanding/overview
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[TextAnalysisAuthoringClient_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/src/Generated/TextAnalysisAuthoringClient.cs
[TextAuthoringProject_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/src/Generated/TextAuthoringProject.cs
[TextAuthoringDeployment_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/src/Generated/TextAuthoringDeployment.cs
[TextAuthoringExportedModel_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/src/Generated/TextAuthoringExportedModel.cs
[TextAuthoringTrainedModel_class]: https://github.com/azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/src/Generated/TextAuthoringTrainedModel.cs
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication/
[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_portal]: https://portal.azure.com
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
