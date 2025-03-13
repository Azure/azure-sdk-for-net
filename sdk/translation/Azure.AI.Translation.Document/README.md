# Azure Cognitive Services Document Translation client library for .NET

Azure Cognitive Services Document Translation is a cloud service that translates documents to and from 90 languages and dialects while preserving document structure and data format. Use the client library for Document Translation to:

* Translate numerous, large files from an Azure Blob Storage container to a target container in your language of choice.
* Check the translation status and progress of each document in the translation operation.
* Apply a custom translation model or glossaries to tailor translation to your specific case.

[Source code][documenttranslation_client_src] | [Package (NuGet)][documenttranslation_nuget_package] | [API reference documentation][documenttranslation_refdocs] | [Product documentation][documenttranslation_docs] | [Samples][documenttranslation_samples]

## Getting started

### Install the package
Install the Azure Document Translation client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.Translation.Document
```

> Note: This version of the client library defaults to the `v1.0` version of the service.

### Prerequisites
* An [Azure subscription][azure_sub].
* An existing Translator resource.

#### Create a Translator resource
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
    --custom-domain <your-resource-name> \
    --resource-group <your-resource-group-name> \
    --kind TextTranslation \
    --sku S1 \
    --location <location> \
    --yes
```
For more information about creating the resource or how to get the location information see [here][cognitive_resource_cli].

#### Setup Azure Blob Storage Account
For more information about creating an Azure Blob Storage account see [here][azure_blob_storage_account]. For creating containers for your source and target files see [here][container]. Make sure to authorize your Translation resource storage access, more info [here][storage_container_authorization].

### Authenticate the client
In order to interact with the Document Translation service, you'll need to create an instance of the [DocumentTranslationClient][documenttranslation_client_class] class. You will need an **endpoint**, and either an **API key** or `TokenCredential` to instantiate a client object.  For more information regarding authenticating with cognitive services, see [Authenticate requests to Azure Cognitive Services][cognitive_auth].

#### Looking up the endpoint
For Document Translation you will need to use a [Custom Domain Endpoint][custom_domain_endpoint] using the name of you Translator resource.

#### Get API Key
You can get the `API key` from the Translator resource information in the [Azure Portal][azure_portal].

Alternatively, use the [Azure CLI][azure_cli] snippet below to get the API key from the Translator resource.

```PowerShell
az cognitiveservices account keys list --resource-group <your-resource-group-name> --name <your-resource-name>
```

#### Create DocumentTranslationClient with API Key Credential
Once you have the value for the API key, create an `AzureKeyCredential`. This will allow you to
update the API key without creating a new client.

With the value of the endpoint and an `AzureKeyCredential`, you can create the [DocumentTranslationClient][documenttranslation_client_class]:

```C# Snippet:CreateDocumentTranslationClient
string endpoint = "<Document Translator Resource Endpoint>";
string apiKey = "<Document Translator Resource API Key>";
var client = new DocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

#### Create DocumentTranslationClient with Azure Active Directory Credential

Client API key authentication is used in most of the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity].  Note that regional endpoints do not support AAD authentication.

Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.

To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below, or other credential providers provided with the Azure SDK, please install the Azure.Identity package:

```dotnetcli
dotnet add package Azure.Identity
```

You will also need to [register a new AAD application][register_aad_app] and [grant access][aad_grant_access] to your Translator resource by assigning the `"Cognitive Services User"` role to your service principal.

Set the values of the `client ID`, `tenant ID`, and `client secret` of the AAD application as environment variables: `AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, `AZURE_CLIENT_SECRET`.

```C# Snippet:CreateDocumentTranslationClientTokenCredential
string endpoint = "<Document Translator Resource Endpoint>";
var client = new DocumentTranslationClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts
The Document Translation service requires that you upload your files to an Azure Blob Storage source container and provide
a target container where the translated documents can be written. SAS tokens to the containers (or files) are used to
access the documents and create the translated documents in the target container. Additional information about setting this up can be found in
the service documentation:

- [Set up Azure Blob Storage containers][source_containers] with your documents.
- Optionally apply [glossaries][glossary] or a [custom model for translation][custom_model].
- Generate [SAS tokens][sas_token] to your containers (or files) with the appropriate [permissions][sas_token_permissions].

### DocumentTranslationClient
A `DocumentTranslationClient` is the primary interface for developers using the Document Translation client library.  It provides both synchronous and asynchronous methods to perform the following operations:

 - Creating a translation operation to translate documents in your source container(s) and write results to you target container(s).
 - Enumerating all past and current translation operations.
 - Identifying supported glossary and document formats.

### Translation Input
To start a translation operation you need to create one instance or a list of `DocumentTranslationInput`.

A single source URL to documents can be translated to many different languages:

```C# Snippet:DocumentTranslationSingleInput
Uri sourceSasUri = new Uri("<source SAS URI>");
Uri frenchTargetSasUri = new Uri("<french target SAS URI>");
var input = new DocumentTranslationInput(sourceSasUri, frenchTargetSasUri, "fr");
```

Or multiple different sources can be provided each with their own targets.

```C# Snippet:DocumentTranslationMultipleInputs
Uri arabicTargetSasUri = new Uri("<arabic target SAS URI>");
Uri spanishTargetSasUri = new Uri("<spanish target SAS URI>");
Uri source1SasUri = new Uri("<source1 SAS URI>");
Uri source2SasUri = new Uri("<source2 SAS URI>");

var inputs = new List<DocumentTranslationInput>
{
    new DocumentTranslationInput(source1SasUri, spanishTargetSasUri, "es"),
    new DocumentTranslationInput(
        source: new TranslationSource(source2SasUri),
        targets: new List<TranslationTarget>
        {
            new TranslationTarget(frenchTargetSasUri, "fr"),
            new TranslationTarget(arabicTargetSasUri, "ar")
        }),
};
```

Note that documents written to a target container must have unique names. So you can't translate a source container into a target container twice or have sources with the same documents translated into the same target container.

If "Allow Storage Account Key Access" is disabled on the storage account , Managed Identity is enabled on the Translator resource and it is assigned the role "Storage Blob Data Contributor" on the storage account, then you can use the container URLs directly and no SAS URIs will be needed.

### Long-Running Operations

Document Translation is implemented as a [**long-running operation**][dotnet_lro].  Long-running operations consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed successfully or failed.

For long running operations in the Azure SDK, the client exposes a `Start<operation-name>` method that returns a `PageableOperation<T>`.  You can use the extension method `WaitForCompletionAsync()` to wait for the operation to complete and obtain its result.  A sample code snippet is provided to illustrate using long-running operations [below](#start-translation-asynchronously).

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.


### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples
The following section provides several code snippets using the `client` [created above](#create-documenttranslationclient-with-api-key-credential), and covers the main functions of Document Translation.
Note: our `DocumentTranslationClient` provides both synchronous and asynchronous methods.

### Async Examples
* [Start Translation Asynchronously](#start-translation-asynchronously)
* [Operations History Asynchronously](#get-operations-history-asynchronously)
* [Multiple Inputs Asynchronously](#start-translation-with-multiple-inputs-asynchronously)

### Sync Examples
Note: our `DocumentTranslationClient` provides both synchronous and asynchronous methods.
* [Start Translation](#start-translation)

### Start Translation Asynchronously
Start a translation operation to translate documents in the source container and write the translated files to the target container. `DocumentTranslationOperation` allows you to poll the status of the translation operation and get the status of the individual documents.

```C# Snippet:StartTranslationAsync
Uri sourceUri = new Uri("<source SAS URI>");
Uri targetUri = new Uri("<target SAS URI>");
var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

DocumentTranslationOperation operation = await client.StartTranslationAsync(input);

await operation.WaitForCompletionAsync();

Console.WriteLine($"  Status: {operation.Status}");
Console.WriteLine($"  Created on: {operation.CreatedOn}");
Console.WriteLine($"  Last modified: {operation.LastModified}");
Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");

await foreach (DocumentStatusResult document in operation.Value)
{
    Console.WriteLine($"Document with Id: {document.Id}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == DocumentTranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
        Console.WriteLine($"  Translated to language code: {document.TranslatedToLanguageCode}.");
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
    }
    else
    {
        Console.WriteLine($"  Error Code: {document.Error.Code}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

### Get Operations History Asynchronously
Get History of submitted translation operations from the last 7 days. The options parameter can be ommitted if the user would like to return all submitted operations.

```C# Snippet:OperationsHistoryAsync
int operationsCount = 0;
int totalDocs = 0;
int docsCanceled = 0;
int docsSucceeded = 0;
int docsFailed = 0;

DateTimeOffset lastWeekTimestamp = DateTimeOffset.Now.AddDays(-7);

var options = new GetTranslationStatusesOptions
{
    CreatedAfter = lastWeekTimestamp
};

await foreach (TranslationStatusResult translationStatus in client.GetTranslationStatusesAsync(options))
{
    if (translationStatus.Status == DocumentTranslationStatus.NotStarted ||
        translationStatus.Status == DocumentTranslationStatus.Running)
    {
        DocumentTranslationOperation operation = new DocumentTranslationOperation(translationStatus.Id, client);
        await operation.WaitForCompletionAsync();
    }

    operationsCount++;
    totalDocs += translationStatus.DocumentsTotal;
    docsCanceled += translationStatus.DocumentsCanceled;
    docsSucceeded += translationStatus.DocumentsSucceeded;
    docsFailed += translationStatus.DocumentsFailed;
}

Console.WriteLine($"# of operations: {operationsCount}");
Console.WriteLine($"Total Documents: {totalDocs}");
Console.WriteLine($"Succeeded Document: {docsSucceeded}");
Console.WriteLine($"Failed Document: {docsFailed}");
Console.WriteLine($"Canceled Documents: {docsCanceled}");
```

### Start Translation with Multiple Inputs Asynchronously
Start a translation operation to translate documents in multiple source containers to multiple target containers in different languages. `DocumentTranslationOperation` allows you to poll the status of the translation operation and get the status of the individual documents.

```C# Snippet:MultipleInputsAsync
Uri source1SasUri = new Uri("<source1 SAS URI>");
Uri source2SasUri = new Uri("<source2 SAS URI>");
Uri frenchTargetSasUri = new Uri("<french target SAS URI>");
Uri arabicTargetSasUri = new Uri("<arabic target SAS URI>");
Uri spanishTargetSasUri = new Uri("<spanish target SAS URI>");
Uri frenchGlossarySasUri = new Uri("<french glossary SAS URI>");

var glossaryFormat = "TSV";

var input1 = new DocumentTranslationInput(source1SasUri, frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri, glossaryFormat));
input1.AddTarget(spanishTargetSasUri, "es");

var input2 = new DocumentTranslationInput(source2SasUri, arabicTargetSasUri, "ar");
input2.AddTarget(frenchTargetSasUri, "fr", new TranslationGlossary(frenchGlossarySasUri, glossaryFormat));

var inputs = new List<DocumentTranslationInput>()
    {
        input1,
        input2
    };

DocumentTranslationOperation operation = await client.StartTranslationAsync(inputs);

await operation.WaitForCompletionAsync();

await foreach (DocumentStatusResult document in operation.GetValuesAsync())
{
    Console.WriteLine($"Document with Id: {document.Id}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == DocumentTranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
        Console.WriteLine($"  Translated to language code: {document.TranslatedToLanguageCode}.");
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
    }
    else
    {
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
        Console.WriteLine($"  Error Code: {document.Error.Code}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```

### Start Translation
Start a translation operation to translate documents in the source container and write the translated files to the target container. `DocumentTranslationOperation` allows you to poll the status of the translation operation and get the status of the individual documents.

```C# Snippet:StartTranslation
Uri sourceUri = new Uri("<source SAS URI>");
Uri targetUri = new Uri("<target SAS URI>");
var input = new DocumentTranslationInput(sourceUri, targetUri, "es");

DocumentTranslationOperation operation = client.StartTranslation(input);

TimeSpan pollingInterval = new(1000);

while (true)
{
    operation.UpdateStatus();

    Console.WriteLine($"  Status: {operation.Status}");
    Console.WriteLine($"  Created on: {operation.CreatedOn}");
    Console.WriteLine($"  Last modified: {operation.LastModified}");
    Console.WriteLine($"  Total documents: {operation.DocumentsTotal}");
    Console.WriteLine($"    Succeeded: {operation.DocumentsSucceeded}");
    Console.WriteLine($"    Failed: {operation.DocumentsFailed}");
    Console.WriteLine($"    In Progress: {operation.DocumentsInProgress}");
    Console.WriteLine($"    Not started: {operation.DocumentsNotStarted}");

    if (operation.HasCompleted)
    {
        break;
    }
    else
    {
        if (operation.GetRawResponse().Headers.TryGetValue("Retry-After", out string value))
        {
            pollingInterval = TimeSpan.FromSeconds(Convert.ToInt32(value));
        }
        Thread.Sleep(pollingInterval);
    }
}

foreach (DocumentStatusResult document in operation.GetValues())
{
    Console.WriteLine($"Document with Id: {document.Id}");
    Console.WriteLine($"  Status:{document.Status}");
    if (document.Status == DocumentTranslationStatus.Succeeded)
    {
        Console.WriteLine($"  Translated Document Uri: {document.TranslatedDocumentUri}");
        Console.WriteLine($"  Translated to language code: {document.TranslatedToLanguageCode}.");
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
    }
    else
    {
        Console.WriteLine($"  Document source Uri: {document.SourceDocumentUri}");
        Console.WriteLine($"  Error Code: {document.Error.Code}");
        Console.WriteLine($"  Message: {document.Error.Message}");
    }
}
```
#### Create SingleDocumentTranslationClient with API Key Credential
Once you have the value for the API key, create an `AzureKeyCredential`. This will allow you to
update the API key without creating a new client.

With the value of the endpoint and an `AzureKeyCredential`, you can create the [SingleDocumentTranslationClient][documenttranslation_client_class]:

```C# Snippet:CreateSingleDocumentTranslationClient
string endpoint = "<Document Translator Resource Endpoint>";
string apiKey = "<Document Translator Resource API Key>";
SingleDocumentTranslationClient client = new SingleDocumentTranslationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

### Single Document Translation
Start a single document translation.

```C# Snippet:StartSingleDocumentTranslation
try
{
    string filePath = Path.Combine("TestData", "test-input.txt");
    using Stream fileStream = File.OpenRead(filePath);
    var sourceDocument = new MultipartFormFileData(Path.GetFileName(filePath), fileStream, "text/html");
    DocumentTranslateContent content = new DocumentTranslateContent(sourceDocument);
    var response = await client.TranslateAsync("hi", content).ConfigureAwait(false);

    var requestString = File.ReadAllText(filePath);
    var responseString = Encoding.UTF8.GetString(response.Value.ToArray());

    Console.WriteLine($"Request string for translation: {requestString}");
    Console.WriteLine($"Response string after translation: {responseString}");
}
catch (RequestFailedException exception)
{
    Console.WriteLine($"Error Code: {exception.ErrorCode}");
    Console.WriteLine($"Message: {exception.Message}");
}
```

## Troubleshooting

### General
When you interact with the Cognitive Services Document Translation client library using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][documenttranslation_rest_api] requests.

For example, if you submit a request with an empty targets list, a `400` error is returned, indicating "Bad Request".

```C# Snippet:BadRequest
var invalidInput = new DocumentTranslationInput(new TranslationSource(new Uri(endpoint)), new List<TranslationTarget>());

try
{
    DocumentTranslationOperation operation = client.StartTranslation(invalidInput);
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
- [Start Translation with SourceInput][start_translation_with_sourceInput_sample]
- [Multiple Inputs][multiple_Inputs_sample]
- [Create Storage Containers and start translation][using_storage_sample]

## Contributing
See the [CONTRIBUTING.md][contributing] for details on building, testing, and contributing to this library.

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[documenttranslation_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Document/src
[documenttranslation_docs]: https://learn.microsoft.com/azure/cognitive-services/translator/document-translation/overview
[documenttranslation_refdocs]: https://aka.ms/azsdk/net/docs/documenttranslation
[documenttranslation_nuget_package]: https://www.nuget.org/packages/Azure.AI.Translation.Document
[documenttranslation_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Document/samples/README.md
[documenttranslation_rest_api]: https://github.com/Azure/azure-rest-api-specs/blob/master/specification/cognitiveservices/data-plane/TranslatorText/stable/v1.0/TranslatorBatch.json
[custom_domain_endpoint]: https://learn.microsoft.com/azure/ai-services/translator/document-translation/quickstarts/document-translation-rest-api?pivots=programming-language-csharp#what-is-the-custom-domain-endpoint
[single_service]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account?tabs=singleservice%2Cwindows
[azure_portal_create_DT_resource]: https://ms.portal.azure.com/#create/Microsoft.CognitiveServicesTextTranslation
[cognitive_resource_cli]: https://learn.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[dotnet_lro]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt
[source_containers]: https://learn.microsoft.com/azure/ai-services/translator/document-translation/quickstarts/document-translation-rest-api?pivots=programming-language-csharp#create-azure-blob-storage-containers
[custom_model]: https://learn.microsoft.com/azure/cognitive-services/translator/custom-translator/quickstart-build-deploy-custom-model
[glossary]: https://learn.microsoft.com/azure/cognitive-services/translator/document-translation/overview#supported-glossary-formats
[sas_token]: https://learn.microsoft.com/azure/cognitive-services/translator/document-translation/create-sas-tokens?tabs=Containers#create-your-sas-tokens-with-azure-storage-explorer
[sas_token_permissions]: https://aka.ms/azsdk/documenttranslation/sas-permissions
[azure_blob_storage_account]: https://ms.portal.azure.com/#create/Microsoft.StorageAccount
[container]: https://learn.microsoft.com/azure/storage/blobs/storage-quickstart-blobs-portal#create-a-container
[storage_container_authorization]: https://learn.microsoft.com/azure/ai-services/translator/document-translation/quickstarts/client-library-sdks?tabs=dotnet&pivots=programming-language-csharp#storage-container-authorization

[documenttranslation_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Document/src/DocumentTranslationClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[register_aad_app]: https://learn.microsoft.com/azure/app-service/configure-authentication-provider-aad?tabs=workforce-tenant#--option-1-create-a-new-app-registration-automatically
[aad_grant_access]: https://learn.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://learn.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[cognitive_auth]: https://learn.microsoft.com/azure/cognitive-services/authentication
[logging]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md
[contributing]: https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md

[start_translation_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/samples/Sample1_StartTranslation.md
[documents_status_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/samples/Sample2_PollIndividualDocuments.md
[operations_history_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/samples/Sample3_OperationsHistory.md
[multiple_inputs_sample]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/translation/Azure.AI.Translation.Document/samples/Sample4_MultipleInputs.md
[using_storage_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Document/tests/samples/Sample_StartTranslationWithAzureBlob.cs
[start_translation_with_sourceInput_sample]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/translation/Azure.AI.Translation.Document/tests/samples/Sample_StartTranslationWithSourceInput.cs

[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com
[moq]: https://github.com/Moq/moq4/

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
