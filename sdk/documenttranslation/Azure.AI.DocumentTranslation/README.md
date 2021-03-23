# Azure Cognitive Services Document Translation client library for .NET

Azure Cognitive Services Document Translation is a cloud service that translates documents to and from 90 languages and dialects while preserving document structure and data format. Use the client library for Document Translation to:

* Translate numerous, large files from an Azure Blob Storage container to a target container in your language of choice.
* Check the translation status and progress of each document in the translation job.
* Apply a custom translation model or glossaries to tailor translation to your specific case.

[Source code][documenttranslation_client_src] | [Package (NuGet)][documenttranslation_nuget_package] | [API reference documentation][documenttranslation_refdocs] | [Product documentation][documenttranslation_docs] | [Samples][documenttranslation_samples]

## Getting started

### Install the package
Install the Azure Document Translation client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.AI.DocumentTranslation --prerelease
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Translator resource.

#### Create a Cognitive Services or Translator resource
Document Translation supports [single-service access][single_service] only.
To access the service, create a Translator resource.

You can create either resource using: 

**Option 1:** [Azure Portal][azure_portal_create_DT_resource].

**Option 2:** [Azure CLI][cognitive_resource_cli]. 

Below is an example of how you can create a Translator resource using the CLI:

```PowerShell
# Create a new resource group to hold the Translator resource -
# if using an existing resource group, skip this step
az group create --name <your-resource-name> --location <location>
```

```PowerShell
# Create Translator
az cognitiveservices account create \
    --name <your-resource-name> \
    --resource-group <your-resource-group-name> \
    --kind TextTranslation \
    --sku <sku> \
    --location <location> \
    --yes
```
For more information about creating the resource or how to get the location and sku information see [here][cognitive_resource_cli].

### Authenticate the client
In order to interact with the Document Translation service, you'll need to create an instance of the [DocumentTranslationClient][documenttranslation_client_class] class. You will need an **endpoint**, and an **API key** to instantiate a client object.  For more information regarding authenticating with cognitive services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Looking up the endpoint
For Document Translation you will need to use a [Custom Domain Endpoint][custom_domain_endpoint] using the name of you Translator resource.

#### Get API Key
You can get the `endpoint` and `API key` from the Translator resource information in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] snippet below to get the API key from the Translator resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create DocumentTranslationClient with API Key Credential
Once you have the value for the API key, create an `AzureKeyCredential`. This will allow you to
update the API key without creating a new client.

With the value of the endpoint and an `AzureKeyCredential`, you can create the [DocumentTranslationClient][documenttranslation_client_class]:

```C# Snippet:CreateDocumentTranslationClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Key concepts

### DocumentTranslationClient
A `DocumentTranslationClient` is the primary interface for developers using the Document Translation client library.  It provides both synchronous and asynchronous methods to perform the following operations:

 - Creating a translation job to translate documents in your source container(s) and write results to you target container(s).
 - Enumerating all past and current translation jobs.
 - Identifying supported glossary and document formats.

### Translation Input
To start a translation operation you need to create one instance or a list of `DocumentTranslationConfiguration`. 

A single source URL to documents can be translated to many different languages:

```C# Snippet:DocumentTranslationSingleInput
var input = new TranslationConfiguration(sourceSasUri, frenchTargetSasUri, "fr");
input.AddTarget(arabicTargetSasUri, "ar");
input.AddTarget(spanishTargetSasUri, "es", new TranslationGlossary(spanishGlossarySasUri));
```

Or multiple different sources can be provided each with their own targets.

```C# Snippet:DocumentTranslationMultipleInputs
var inputs = new List<TranslationConfiguration>
{
    new TranslationConfiguration(source1SasUri, spanishTargetSasUri, "es"),
    new TranslationConfiguration(
        source: new TranslationSource(source2SasUri),
        targets: new List<TranslationTarget>
        {
            new TranslationTarget(frenchTargetSasUri, "fr"),
            new TranslationTarget(spanishTargetSasUri, "es")
        }),
    new TranslationConfiguration(source1SasUri, spanishTargetSasUri, "es", new TranslationGlossary(spanishGlossarySasUri)),
};
```

### Long-Running Operations

Document Translation is implemented as a [**long-running operation**][dotnet_lro_guidelines].  Long-running operations consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed successfully or failed.

For long running operations in the Azure SDK, the client exposes a `Start<operation-name>` method that returns a `PageableOperation<T>`.  You can use the extension method `WaitForCompletionAsync()` to wait for the operation to complete and obtain its result.  A sample code snippet is provided to illustrate using long-running operations [below](#start-translation-asynchronously).

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.


### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples
The following section provides several code snippets using the `client` [created above](#create-documenttranslationclient-with-api-key-credential), and covers the main functions of Document Translation.

### Sync Examples
* [Start Translation](#start-translation)
* [Operations History](#get-operations-hisotry)
* [Multiple Configurations](#start-translation-with-multiple-configurations)

### Async Examples
* [Start Translation Asynchronously](#start-translation-asynchronously)
* [Operations History Asynchronously](#get-operations-hisotry-asynchronously)
* [Multiple Configurations Asynchronously](#start-translation-with-multiple-configurations-asynchronously)

### Start Translation
Start a translation operation to translate documents in the source container and write the translated files to the target container. `DocumentTranslationOperation` allows you to poll the status of the translation operation and get the status of the individual documents.

```C# Snippet:StartTranslation
var input = new TranslationConfiguration(sourceUri, targetUri, "es");

DocumentTranslationOperation operation = client.StartTranslation(input);

TimeSpan pollingInterval = new TimeSpan(1000);

while (!operation.HasCompleted)
{
    Thread.Sleep(pollingInterval);
    operation.UpdateStatus();

    Console.WriteLine($"  Status: {operation.Status}");
    Console.WriteLine($"  Created on: {operation.CreatedOn}");
    Console.WriteLine($"  Last modified: {operation.LastModified}");
    Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
    Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
    Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
    Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
    Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");
}

foreach (DocumentStatusDetail document in operation.GetValues())
{
    Console.WriteLine($"Document with Id: {document.DocumentId}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == TranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Location: {document.LocationUri}");
        Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
    }
    else
    {
        Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

### Get Operations History
Get History of all submitted translation operations

```C# Snippet:OperationsHistory
Pageable<TranslationStatusDetail> operationsStatus = client.GetTranslations();

int operationsCount = 0;
int totalDocs = 0;
int docsCancelled = 0;
int docsSucceeded = 0;
int maxDocs = 0;
TranslationStatusDetail largestOperation = null;

foreach (TranslationStatusDetail operationStatus in operationsStatus)
{
    operationsCount++;
    totalDocs += operationStatus.DocumentsTotal;
    docsCancelled += operationStatus.DocumentsCancelled;
    docsSucceeded += operationStatus.DocumentsSucceeded;
    if (totalDocs > maxDocs)
    {
        maxDocs = totalDocs;
        largestOperation = operationStatus;
    }
}

Console.WriteLine($"# of operations: {operationsCount}");
Console.WriteLine($"Total Documents: {totalDocs}");
Console.WriteLine($"DocumentsSucceeded: {docsSucceeded}");
Console.WriteLine($"Cancelled Documents: {docsCancelled}");

Console.WriteLine($"Largest operation is {largestOperation.TranslationId} and has the documents:");

DocumentTranslationOperation operation = new DocumentTranslationOperation(largestOperation.TranslationId, client);

Pageable<DocumentStatusDetail> docs = operation.GetAllDocumentsStatus();

foreach (DocumentStatusDetail docStatus in docs)
{
    Console.WriteLine($"Document {docStatus.LocationUri} has status {docStatus.Status}");
}
```

### Start Translation with Multiple Configurations
Start a translation operation to translate documents in multiple source containers to multiple target containers in different languages. `DocumentTranslationOperation` allows you to poll the status of the translation operation and get the status of the individual documents.

```C# Snippet:MultipleConfigurations
var configuration1 = new TranslationConfiguration(sourceUri1, targetUri1_1, "es", new TranslationGlossary(glossaryUrl));
configuration1.AddTarget(targetUri1_2, "it");

var configuration2 = new TranslationConfiguration(sourceUri2, targetUri2_1, "it");
configuration2.AddTarget(targetUri2_2, "es", new TranslationGlossary(glossaryUrl));

var inputs = new List<TranslationConfiguration>()
    {
        configuration1,
        configuration2
    };

DocumentTranslationOperation operation = client.StartTranslation(inputs);

TimeSpan pollingInterval = new TimeSpan(1000);

while (!operation.HasCompleted)
{
    Thread.Sleep(pollingInterval);
    operation.UpdateStatus();

    Console.WriteLine($"  Status: {operation.Status}");
    Console.WriteLine($"  Created on: {operation.CreatedOn}");
    Console.WriteLine($"  Last modified: {operation.LastModified}");
    Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
    Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
    Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
    Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
    Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");
}

foreach (DocumentStatusDetail document in operation.GetValues())
{
    Console.WriteLine($"Document with Id: {document.DocumentId}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == TranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Location: {document.LocationUri}");
        Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
    }
    else
    {
        Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

### Start Translation Asynchronously
Start a translation operation to translate documents in the source container and write the translated files to the target container. `DocumentTranslationOperation` allows you to poll the status of the translation operation and get the status of the individual documents.

```C# Snippet:StartTranslationAsync
var input = new TranslationConfiguration(sourceUri, targetUri, "es");

DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

Response<AsyncPageable<DocumentStatusDetail>> operationResult = await operation.WaitForCompletionAsync();

Console.WriteLine($"  Status: {operation.Status}");
Console.WriteLine($"  Created on: {operation.CreatedOn}");
Console.WriteLine($"  Last modified: {operation.LastModified}");
Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");

await foreach (DocumentStatusDetail document in operationResult.Value)
{
    Console.WriteLine($"Document with Id: {document.DocumentId}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == TranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Location: {document.LocationUri}");
        Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
    }
    else
    {
        Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

### Get Operations History Asynchronously
Get History of all submitted translation operations

```C# Snippet:OperationsHistoryAsync
AsyncPageable<TranslationStatusDetail> operationsStatus = client.GetTranslationsAsync();

int operationsCount = 0;
int totalDocs = 0;
int docsCancelled = 0;
int docsSucceeded = 0;
int maxDocs = 0;
TranslationStatusDetail largestOperation = null;

await foreach (TranslationStatusDetail operationStatus in operationsStatus)
{
    operationsCount++;
    totalDocs += operationStatus.DocumentsTotal;
    docsCancelled += operationStatus.DocumentsCancelled;
    docsSucceeded += operationStatus.DocumentsSucceeded;
    if (totalDocs > maxDocs)
    {
        maxDocs = totalDocs;
        largestOperation = operationStatus;
    }
}

Console.WriteLine($"# of operations: {operationsCount}");
Console.WriteLine($"Total Documents: {totalDocs}");
Console.WriteLine($"DocumentsSucceeded: {docsSucceeded}");
Console.WriteLine($"Cancelled Documents: {docsCancelled}");

Console.WriteLine($"Largest operation is {largestOperation} and has the documents:");

DocumentTranslationOperation operation = new DocumentTranslationOperation(largestOperation.TranslationId, client);

AsyncPageable<DocumentStatusDetail> docs = operation.GetAllDocumentsStatusAsync();

await foreach (DocumentStatusDetail docStatus in docs)
{
    Console.WriteLine($"Document {docStatus.LocationUri} has status {docStatus.Status}");
}
```

### Start Translation with Multiple Configurations Asynchronously
Start a translation operation to translate documents in multiple source containers to multiple target containers in different languages. `DocumentTranslationOperation` allows you to poll the status of the translation operation and get the status of the individual documents.

```C# Snippet:MultipleConfigurationsAsync
var configuration1 = new TranslationConfiguration(sourceUri1, targetUri1_1, "es", new TranslationGlossary(glossaryUrl));
configuration1.AddTarget(targetUri1_2, "it");

var configuration2 = new TranslationConfiguration(sourceUri2, targetUri2_1, "it");
configuration2.AddTarget(targetUri2_2, "es", new TranslationGlossary(glossaryUrl));

var inputs = new List<TranslationConfiguration>()
    {
        configuration1,
        configuration2
    };

DocumentTranslationOperation operation = await client.StartTranslationAsync(inputs);

TimeSpan pollingInterval = new TimeSpan(1000);

while (!operation.HasCompleted)
{
    await Task.Delay(pollingInterval);
    await operation.UpdateStatusAsync();

    Console.WriteLine($"  Status: {operation.Status}");
    Console.WriteLine($"  Created on: {operation.CreatedOn}");
    Console.WriteLine($"  Last modified: {operation.LastModified}");
    Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
    Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
    Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
    Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
    Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");
}

await foreach (DocumentStatusDetail document in operation.GetValuesAsync())
{
    Console.WriteLine($"Document with Id: {document.DocumentId}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == TranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Location: {document.LocationUri}");
        Console.WriteLine($"  Translated to language: {document.TranslateTo}.");
    }
    else
    {
        Console.WriteLine($"  Error Code: {document.Error.ErrorCode}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

## Troubleshooting

### General
When you interact with the Cognitive Services Document Translation client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][textanalytics_rest_api] requests.

For example, if you submit a request with an empty targets list, a `400` error is returned, indicating "Bad Request".

```C# Snippet:BadRequest
try
{
    DocumentTranslationOperation operation = client.StartTranslation(invalidConfiguration);
}
catch (RequestFailedException e)
{
    Console.WriteLine(e.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```
Message:
    Azure.RequestFailedException: Service request failed.
    Status: 400 (Bad Request)

Content:
    {"error":{"code":"InvalidRequest","message":"No translation target found.","target":"TargetInput","innerError":{"code":"NoTranslationTargetFound","message":"No translation target found."}}}

Headers:
    Transfer-Encoding: chunked
    X-RequestId: REDACTED
    Content-Type: application/json; charset=utf-8
    Set-Cookie: REDACTED
    X-Powered-By: REDACTED
    apim-request-id: REDACTED
    Strict-Transport-Security: REDACTED
    x-content-type-options: REDACTED
    Date: Mon, 22 Mar 2021 11:54:58 GMT
```

### Setting up console logging
The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use AzureEventSourceListener.CreateConsoleLogger method.

```
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [here][logging].

## Next steps

Samples showing how to use the Cognitive Services Document Translation library are available in this GitHub repository.

- [Start Translation][start_translation_sample]
- [Poll Documents Status][documents_status_sample]
- [Operations History][operations_history_sample]

### Advanced samples
- [Multiple Configurations][multiple_configurations_sample]

## Contributing
See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- TODO: Add correct link -->
![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Ftemplate%2FAzure.Template%2FREADME.png)


<!-- LINKS -->
[documenttranslation_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/src
<!--TODO: remove /overview -->
[documenttranslation_docs]: https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview
<!-- TODO: Add correct link -->
[documenttranslation_refdocs]: https://aka.ms/azsdk-net-documenttranslation-ref-docs
<!-- TODO: Add correct link -->
[documenttranslation_nuget_package]: https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview
[documenttranslation_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/samples/README.md
<!-- TODO: Add correct link -->
[documenttranslation_rest_api]: https://docs.microsoft.com/rest/api/cognitiveservices/translator/documenttranslation
[custom_domain_endpoint]: https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/get-started-with-document-translation?tabs=csharp#what-is-the-custom-domain-endpoint
[single_service]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account?tabs=singleservice%2Cwindows
[azure_portal_create_DT_resource]: https://ms.portal.azure.com/#create/Microsoft.CognitiveServicesTextTranslation
[cognitive_resource_cli]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[dotnet_lro_guidelines]: https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning

[documenttranslation_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/src/DocumentTranslationClient.cs
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md
<!-- TODO: Add correct link -->
[data_limits]: https://docs.microsoft.com/azure/cognitive-services/document-translation/overview
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/master/CONTRIBUTING.md

[start_translation_sample]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/samples/Sample1_StartTranslation.md
[documents_status_sample]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/samples/Sample2_PollIndividualDocuments.md
[operations_history_sample]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/samples/Sample3_OperationsHistory.md
[multiple_configurations_sample]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/samples/Sample4_MultipleConfigurations.md

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
[moq]: https://github.com/Moq/moq4/

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
