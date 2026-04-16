# Azure AI Language Documents client library for .NET

The Azure AI Language Documents client library enables asynchronous document analysis for files stored in Azure Blob Storage. You can submit one or more documents as a long-running job, track job status, and retrieve analysis results. The current SDK surface includes document analysis scenarios such as PII entity recognition and abstractive summarization.

[Source code][languagedocuments_client_src] | [Package (NuGet)][languagedocuments_nuget_package] | [API reference documentation][languagedocuments_refdocs] | [Samples][languagedocuments_samples] | [Product documentation][languagedocuments_docs] | [REST API documentation][languagedocuments_rest_docs]

## Getting started

### Install the package

Install the Azure AI Language Documents client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.Language.Documents
```

### Prerequisites

- An [Azure subscription][azure_subscription]
- An existing Azure AI Language resource
- Azure Blob Storage locations for input documents and output documents
- Either:
  - SAS-protected blob/container URLs, or
  - a managed identity with access to the storage locations

### Authenticate the client

To interact with the service, create an instance of [`AnalyzeDocumentsClient`][languagedocuments_client_class]. You need a resource **endpoint** and credential to instantiate the client. The client supports both API key authentication and Microsoft Entra ID authentication.

For more information about authenticating Cognitive Services resources, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get an API key

You can get the **endpoint** and an **API key** from the Azure AI Language resource in the [Azure portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli]:

```powershell
az cognitiveservices account keys list --resource-group <resource-group-name> --name <resource-name>
```

#### Create an `AnalyzeDocumentsClient` with an API key

```csharp
using Azure;
using Azure.AI.Language.Documents;

string endpoint = "https://myaccount.cognitiveservices.azure.com";
AzureKeyCredential credential = new AzureKeyCredential("{api-key}");

AnalyzeDocumentsClient client = new AnalyzeDocumentsClient(endpoint, credential);
```

#### Create a client using Microsoft Entra ID authentication

You can also create `AnalyzeDocumentsClient` with Microsoft Entra ID. Before you can use `DefaultAzureCredential`, install the [Azure.Identity package][azure_identity_install].

```csharp
using Azure.AI.Language.Documents;
using Azure.Identity;

string endpoint = "https://myaccount.cognitiveservices.azure.com";
DefaultAzureCredential credential = new DefaultAzureCredential();

AnalyzeDocumentsClient client = new AnalyzeDocumentsClient(endpoint, credential);
```

Regional endpoints do not support Microsoft Entra ID authentication. To use Microsoft Entra ID, create a [custom domain][custom_domain] for your resource.

## Key concepts

### `AnalyzeDocumentsClient`

`AnalyzeDocumentsClient` is the primary interface for submitting document analysis jobs, checking job status, and canceling running jobs.

### `AnalyzeDocumentsOperationInput`

`AnalyzeDocumentsOperationInput` defines the request payload for a job. It includes:

- The input documents to analyze
- The analysis tasks to run
- Optional metadata such as `DisplayName` and `DefaultLanguage`

### `DocumentLocation`

Documents are referenced by Azure Blob Storage locations. The SDK provides typed models such as:

- `AzureBlobDocumentLocation`
- `AzureContainerDocumentLocation`
- `AzureContainerFolderDocumentLocation`

These can be used with SAS URLs or with a managed identity by setting `ManagedIdentityClientId`.

### Long-running operations

Document analysis is asynchronous. You submit a job, receive an operation, and then retrieve the final job state with `GetAnalyzeDocumentsJobStatus`.

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other. This ensures that reusing client instances is always safe, even across threads.

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

The Azure AI Language Documents client library provides both synchronous and asynchronous APIs.

The following examples show common scenarios using the `client` created above.

### Submit a PII analysis job

```csharp
using System;
using Azure;
using Azure.AI.Language.Documents;

AzureBlobDocumentLocation source = new AzureBlobDocumentLocation(
    "https://<storage-account>.blob.core.windows.net/input/invoice.pdf?<sas-token>");

AzureContainerFolderDocumentLocation target = new AzureContainerFolderDocumentLocation(
    "https://<storage-account>.blob.core.windows.net/output/pii?<sas-token>");

MultiLanguageDocumentInput documents = new MultiLanguageDocumentInput();
documents.Documents.Add(new MultiLanguageInput("document-1", source, target)
{
    Language = "en"
});

PiiLROTask piiTask = new PiiLROTask
{
    Name = "pii-task",
    Parameters = new PiiActionContent
    {
        LoggingOptOut = true,
        StringIndexType = StringIndexType.Utf16CodeUnit
    }
};

AnalyzeDocumentsOperationInput request = new AnalyzeDocumentsOperationInput(
    documents,
    new AnalyzeDocumentsOperationAction[] { piiTask })
{
    DisplayName = "sample-pii-job",
    DefaultLanguage = "en"
};

Operation operation = client.AnalyzeDocumentsSubmitOperation(WaitUntil.Completed, request);
Guid jobId = Guid.Parse(operation.Id);

Response<AnalyzeDocumentsJobState> response = client.GetAnalyzeDocumentsJobStatus(jobId, showStats: true);
AnalyzeDocumentsJobState job = response.Value;

Console.WriteLine($"Job status: {job.Status}");
Console.WriteLine($"Completed tasks: {job.Tasks.Completed}");

foreach (AnalyzeDocumentsLROResult task in job.Tasks.Items)
{
    if (task is PiiEntityRecognitionOperationResult piiResult)
    {
        foreach (DocumentAnalysisDocumentResult document in piiResult.Results.Documents)
        {
            Console.WriteLine($"Document ID: {document.Id}");

            foreach (DocumentLocation output in document.Target)
            {
                Console.WriteLine($"Output location: {output.Location}");
            }
        }
    }
}
```

> [!NOTE]
> If you want the service to access storage using a user-assigned managed identity instead of SAS tokens, set `ManagedIdentityClientId` on the document location objects.

### Cancel a running job

```csharp
using System;
using Azure;

Operation operation = client.AnalyzeDocumentsSubmitOperation(WaitUntil.Started, request);
Guid jobId = Guid.Parse(operation.Id);

client.AnalyzeDocumentsCancelOperation(WaitUntil.Completed, jobId);

Response<AnalyzeDocumentsJobState> cancelledJob = client.GetAnalyzeDocumentsJobStatus(jobId);
Console.WriteLine($"Job status: {cancelledJob.Value.Status}");
```

## Troubleshooting

### General

When you interact with the Azure AI Language Documents client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned by the REST API.

For example, requesting a job that does not exist returns a service error:

```csharp
using System;
using Azure;

try
{
    client.GetAnalyzeDocumentsJobStatus(Guid.Parse("00000000-0000-0000-0000-000000000000"));
}
catch (RequestFailedException ex)
{
    Console.WriteLine($"Status: {ex.Status}");
    Console.WriteLine($"ErrorCode: {ex.ErrorCode}");
    Console.WriteLine(ex.Message);
}
```

### Setting up console logging

The simplest way to see SDK logs is to enable console logging:

```csharp
using Azure.Core.Diagnostics;

using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms, see [Diagnostics][core_logging].

## Next steps

- View the [samples][languagedocuments_samples]
- Read the [product documentation][languagedocuments_docs]
- Review the [REST API documentation][languagedocuments_rest_docs]

## Contributing

See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately. Simply follow the instructions provided by the bot. You only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information, see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

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
[nuget]: https://www.nuget.org/

[languagedocuments_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/cognitivelanguage/Azure.AI.Language.Documents/src/Generated/AnalyzeDocumentsClient.cs
[languagedocuments_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Documents/src/
[languagedocuments_docs]: https://learn.microsoft.com/azure/cognitive-services/language-service/overview
[languagedocuments_nuget_package]: https://www.nuget.org/packages/Azure.AI.Language.Documents/
[languagedocuments_refdocs]: https://learn.microsoft.com/dotnet/api/Azure.AI.Language.Documents/
[languagedocuments_rest_docs]: https://learn.microsoft.com/rest/api/language/
[languagedocuments_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/cognitivelanguage/Azure.AI.Language.Documents/samples/README.md
