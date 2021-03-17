# Azure Cognitive Services Document Translation client library for .NET
Document Translation is a cloud-based feature of the Azure Translator service and is part of the Azure Cognitive Service family of REST APIs. The Document Translation API translates documents to and from 90 languages and dialects while preserving document structure and data format.

[Source code][documenttranslation_client_src] | [Package (NuGet)][documenttranslation_nuget_package] | [API reference documentation][documenttranslation_refdocs] | [Product documentation][documenttranslation_docs] | [Samples][documenttranslation_samples]

## Getting started

### Install the package
Install the Azure Document Translation client library for .NET with [NuGet][nuget]:

```PowerShell
dotnet add package Azure.AI.DocumentTranslation
```

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Cognitive Services or Translator resource.

#### Create a Cognitive Services or Translator resource
Translator supports both [multi-service and single-service access][cognitive_resource_portal]. Create a Cognitive Services resource if you plan to access multiple cognitive services under a single endpoint/key. For Translator access only, create a Translator resource.

You can create either resource using: 

**Option 1:** [Azure Portal][cognitive_resource_portal].

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
    --kind Translator \
    --sku <sku> \
    --location <location> \
    --yes
```
For more information about creating the resource or how to get the location and sku information see [here][cognitive_resource_cli].

### Authenticate the client
In order to interact with the Document Translation service, you'll need to create an instance of the [DocumentTranslationClient][documenttranslation_client_class] class. You will need an **endpoint**, and either an **API key** or ``TokenCredential`` to instantiate a client object.  For more information regarding authenticating with cognitive services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Get API Key
You can get the `endpoint` and `API key` from the Cognitive Services resource or Translator resource information in the [Azure Portal][azure_portal].

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

#### Create DocumentTranslationClient with Azure Active Directory Credential

Client API key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity].  Note that regional endpoints do not support AAD authentication. Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.  

To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below,
or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```PowerShell
Install-Package Azure.Identity
```

You will also need to [register a new AAD application][register_aad_app] and [grant access][aad_grant_access] to Translator by assigning the `"Cognitive Services User"` role to your service principal.

Set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

```C# Snippet:CreateDocumentTranslationClientTokenCredential
string endpoint = "<endpoint>";
var client = new DocumentTranslationClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts

### DocumentTranslationClient
A `DocumentTranslationClient` is the primary interface for developers using the Document Translation client library.  It provides both synchronous and asynchronous operations to access the Document Translation service.

### Long-Running Operations

Document Translation is implemented as a [**long-running operation**][dotnet_lro_guidelines].  Long-running operations consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed successfully or failed.

For long running operations in the Azure SDK, the client exposes a `Start<operation-name>` method that returns an `Operation<T>`.  You can use the extension method `WaitForCompletionAsync()` to wait for the operation to complete and obtain its result.  A sample code snippet is provided to illustrate using long-running operations [below](#recognize-healthcare-entities-asynchronously).

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

## Examples
The following section provides several code snippets using the `client` [created above](#create-documenttranslationclient-with-azure-active-directory-credential), and covers the main functions of Document Translation.

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
var input = new TranslationConfiguration(sourceUrl, targetUrl, "es");

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
var configuration1 = new TranslationConfiguration(sourceUrl1, targetUrl1_1, "es", new TranslationGlossary(glossaryUrl));
configuration1.AddTarget(targetUrl1_2, "it");

var configuration2 = new TranslationConfiguration(sourceUrl2, targetUrl2_1, "it");
configuration2.AddTarget(targetUrl2_2, "es", new TranslationGlossary(glossaryUrl));

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

```C# Snippet:StartTranslation
var input = new TranslationConfiguration(sourceUrl, targetUrl, "es");

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

### Get Operations History Asynchronously
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

### Start Translation with Multiple Configurations Asynchronously
Start a translation operation to translate documents in multiple source containers to multiple target containers in different languages. `DocumentTranslationOperation` allows you to poll the status of the translation operation and get the status of the individual documents.

```C# Snippet:MultipleConfigurations
var configuration1 = new TranslationConfiguration(sourceUrl1, targetUrl1_1, "es", new TranslationGlossary(glossaryUrl));
configuration1.AddTarget(targetUrl1_2, "it");

var configuration2 = new TranslationConfiguration(sourceUrl2, targetUrl2_1, "it");
configuration2.AddTarget(targetUrl2_2, "es", new TranslationGlossary(glossaryUrl));

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

## Troubleshooting

## Next steps

## Contributing
See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- TODO: Add link -->
![Impressions]()


<!-- LINKS -->
[documenttranslation_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/src
[documenttranslation_docs]: https://docs.microsoft.com/en-us/azure/cognitive-services/translator/document-translation/
<!-- TODO: Add correct link -->
[documenttranslation_refdocs]: https://aka.ms/azsdk-net-documenttranslation-ref-docs
<!-- TODO: Add correct link -->
[documenttranslation_nuget_package]: https://www.nuget.org/packages/Azure.AI.DocumentTranslation
[documenttranslation_samples]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/samples/README.md
<!-- TODO: Add correct link -->
[documenttranslation_rest_api]: https://docs.microsoft.com/en-us/rest/api/cognitiveservices/translator/documenttranslation
[cognitive_resource_portal]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[cognitive_resource_cli]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[dotnet_lro_guidelines]: https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning

[documenttranslation_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/documenttranslation/Azure.AI.DocumentTranslation/src/DocumentTranslationClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity
[cognitive_auth]: https://docs.microsoft.com/azure/cognitive-services/authentication
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/identity/Azure.Identity/README.md
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/samples/Diagnostics.md
<!-- TODO: Add correct link -->
[data_limits]: https://docs.microsoft.com/azure/cognitive-services/document-translation/overview
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/master/CONTRIBUTING.md

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
[moq]: https://github.com/Moq/moq4/

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com