# Azure Document Intelligence client library for .NET

> Note: on July 2023, the Azure Cognitive Services Form Recognizer service was renamed to Azure AI Document Intelligence. Any mentions of Form Recognizer or Document Intelligence in documentation refer to the same Azure service.

Azure AI Document Intelligence is a cloud service that uses machine learning to analyze text and structured data from your documents. It includes the following main features:

- Layout - Extract text, selection marks, table structures, styles, and paragraphs, along with their bounding region coordinates from documents.
- Read - Read information about textual elements, such as page words and lines in addition to text language information.
- Prebuilt - Analyze data from certain types of common documents using prebuilt models. Supported documents include receipts, invoices, business cards, identity documents, US W2 tax forms, and more.
- Custom analysis - Build custom document models to analyze text, field values, selection marks, table structures, styles, and paragraphs from documents. Custom models are built with your own data, so they're tailored to your documents.
- Custom classification - Build custom classifier models that combine layout and language features to accurately detect and identify documents you process within your application.

[Source code][docint_client_src] | [Package (NuGet)][docint_nuget_package] | [API reference documentation][docint_refdocs] | [Product documentation][docint_docs] | [Samples][docint_samples]

## Getting started

This section should include everything a developer needs to do to install and create their first client connection *very quickly*.

### Install the package

Install the Azure Document Intelligence client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.DocumentIntelligence --prerelease
```

> Note: This version of the client library defaults to the `2023-10-31-preview` version of the service.

### Prerequisites

* An [Azure subscription][azure_sub].
* A [Cognitive Services or Document Intelligence resource][cognitive_resource] to use this package.

#### Create a Cognitive Services or Document Intelligence resource

Document Intelligence supports both [multi-service and single-service access][cognitive_resource_portal]. Create a Cognitive Services resource if you plan to access multiple cognitive services under a single endpoint and key. For Document Intelligence access only, create a Document Intelligence resource. Please note that you will need a single-service resource if you intend to use [Azure Active Directory authentication](#create-documentintelligenceclient-with-azure-active-directory-credential).

You can create either resource using:

* Option 1: [Azure Portal][cognitive_resource_portal].
* Option 2: [Azure CLI][cognitive_resource_cli].

Below is an example of how you can create a Document Intelligence resource using the CLI:

```PowerShell
# Create a new resource group to hold the Document Intelligence resource
# If using an existing resource group, skip this step
az group create --name <your-resource-name> --location <location>
```

```PowerShell
# Create the Form Recognizer resource
az cognitiveservices account create \
    --name <resource-name> \
    --resource-group <resource-group-name> \
    --kind FormRecognizer \
    --sku <sku> \
    --location <location> \
    --yes
```
For more information about creating the resource or how to get the location and sku information see [here][cognitive_resource_cli].

### Authenticate the client

In order to interact with the Document Intelligence service, you'll need to create an instance of the [`DocumentIntelligenceClient`][doc_intelligence_client_class] class.
An **endpoint** and a **credential** are necessary to instantiate the client object.

#### Get the endpoint

You can find the endpoint for your Document Intelligence resource using the [Azure Portal][azure_portal_get_endpoint] or the [Azure CLI][azure_cli_endpoint_lookup]:

```PowerShell
# Get the endpoint for the Document Intelligence resource
az cognitiveservices account show --name "<resource-name>" --resource-group "<resource-group-name>" --query "properties.endpoint"
```

Either a regional endpoint or a custom subdomain can be used for authentication. They are formatted as follows:

```
Regional endpoint: https://<region>.api.cognitive.microsoft.com/
Custom subdomain: https://<resource-name>.cognitiveservices.azure.com/
```

A regional endpoint is the same for every resource in a region. A complete list of supported regional endpoints can be consulted [here][regional_endpoints]. Please note that regional endpoints do not support AAD authentication.

A custom subdomain, on the other hand, is a name that is unique to the Document Intelligence resource. They can only be used by [single-service resources][cognitive_resource_portal].

#### Get the API Key

The API key can be found in the [Azure Portal][azure_portal] or by running the following Azure CLI command:

```PowerShell
az cognitiveservices account keys list --name "<resource-name>" --resource-group "<resource-group-name>"
```

#### Create DocumentIntelligenceClient with AzureKeyCredential

Once you have the value for the API key, create an `AzureKeyCredential`. With the endpoint and key credential, you can create the [`DocumentIntelligenceClient`][doc_intelligence_client_class]:

```C# Snippet:CreateDocumentIntelligenceClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new DocumentIntelligenceClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

#### Create DocumentIntelligenceClient with Azure Active Directory Credential

`AzureKeyCredential` authentication is used in the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity]. Note that regional endpoints do not support AAD authentication. Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.

To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below, or other credential providers provided with the Azure SDK, please install the `Azure.Identity` package:

```dotnetcli
dotnet add package Azure.Identity
```

You will also need to [register a new AAD application][register_aad_app] and [grant access][aad_grant_access] to Document Intelligence by assigning the `"Cognitive Services User"` role to your service principal.

Set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

```C# Snippet:CreateDocumentIntelligenceClientTokenCredential
string endpoint = "<endpoint>";
var client = new DocumentIntelligenceClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts

### DocumentIntelligenceClient

`DocumentIntelligenceClient` provides operations for:
- Analyzing input documents using prebuilt and custom models through the `AnalyzeDocument` API.
- Detecting and identifying custom input documents with the `ClassifyDocument` API.

Sample code snippets are provided to illustrate using a DocumentIntelligenceClient [here](#examples).

More information about analyzing documents, including supported features, locales, and document types can be found in the [service documentation][docint_models].

### DocumentIntelligenceAdministrationClient

`DocumentIntelligenceAdministrationClient` provides operations for:

- Building custom models to analyze specific fields you specify by labeling your custom documents.
- Compose a model from a collection of existing models.
- Managing models created in your account.
- Copying a custom model from one Document Intelligence resource to another.
- Getting or listing operations created within the last 24 hours.
- Building and managing document classification models to accurately detect and identify documents you process within your application.

See examples for [Build a Custom Model](#build-a-custom-model), [Manage Models](#manage-models), and [Build a Document Classifier](#build-a-document-classifier).

Please note that models and classifiers can also be built using a graphical user interface such as the [Document Intelligence Studio][di_studio].

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples

The following section provides several code snippets illustrating common patterns used in the Document Intelligence .NET API. Most of the snippets below make use of asynchronous service calls, but keep in mind that the Azure.AI.DocumentIntelligence package supports both synchronous and asynchronous APIs.

* [Extract Layout](#extract-layout)
* [Use Prebuilt Models](#use-prebuilt-models)
* [Build a Custom Model](#build-a-custom-model)
* [Manage Models](#manage-models)
* [Build a Document Classifier](#build-a-document-classifier)
* [Classify a Document](#classify-a-document)

### Extract Layout

Extract text, selection marks, table structures, styles, and paragraphs, along with their bounding region coordinates from documents.

```C# Snippet:DocumentIntelligenceExtractLayoutFromUriAsync
Uri uriSource = new Uri("<uriSource>");

var content = new AnalyzeDocumentContent()
{
    UrlSource = uriSource
};

Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-layout", content);
AnalyzeResult result = operation.Value;

foreach (DocumentPage page in result.Pages)
{
    Console.WriteLine($"Document Page {page.PageNumber} has {page.Lines.Count} line(s), {page.Words.Count} word(s)," +
        $" and {page.SelectionMarks.Count} selection mark(s).");

    for (int i = 0; i < page.Lines.Count; i++)
    {
        DocumentLine line = page.Lines[i];

        Console.WriteLine($"  Line {i}:");
        Console.WriteLine($"    Content: '{line.Content}'");

        Console.Write("    Bounding polygon, with points ordered clockwise:");
        for (int j = 0; j < line.Polygon.Count; j += 2)
        {
            Console.Write($" ({line.Polygon[j]}, {line.Polygon[j + 1]})");
        }

        Console.WriteLine();
    }

    for (int i = 0; i < page.SelectionMarks.Count; i++)
    {
        DocumentSelectionMark selectionMark = page.SelectionMarks[i];

        Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
        Console.WriteLine($"    State: {selectionMark.State}");

        Console.Write("    Bounding polygon, with points ordered clockwise:");
        for (int j = 0; j < selectionMark.Polygon.Count; j++)
        {
            Console.Write($" ({selectionMark.Polygon[j]}, {selectionMark.Polygon[j + 1]})");
        }

        Console.WriteLine();
    }
}

for (int i = 0; i < result.Paragraphs.Count; i++)
{
    DocumentParagraph paragraph = result.Paragraphs[i];

    Console.WriteLine($"Paragraph {i}:");
    Console.WriteLine($"  Content: {paragraph.Content}");

    if (paragraph.Role != null)
    {
        Console.WriteLine($"  Role: {paragraph.Role}");
    }
}

foreach (DocumentStyle style in result.Styles)
{
    // Check the style and style confidence to see if text is handwritten.
    // Note that value '0.8' is used as an example.

    bool isHandwritten = style.IsHandwritten.HasValue && style.IsHandwritten == true;

    if (isHandwritten && style.Confidence > 0.8)
    {
        Console.WriteLine($"Handwritten content found:");

        foreach (DocumentSpan span in style.Spans)
        {
            var handwrittenContent = result.Content.Substring(span.Offset, span.Length);
            Console.WriteLine($"  {handwrittenContent}");
        }
    }
}

for (int i = 0; i < result.Tables.Count; i++)
{
    DocumentTable table = result.Tables[i];

    Console.WriteLine($"Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");

    foreach (DocumentTableCell cell in table.Cells)
    {
        Console.WriteLine($"  Cell ({cell.RowIndex}, {cell.ColumnIndex}) is a '{cell.Kind}' with content: {cell.Content}");
    }
}
```

For more information, see [here][extract_layout].

### Use Prebuilt Models

Analyze data from certain types of common documents using prebuilt models provided by the Document Intelligence service.

For example, to analyze fields from an invoice, use the prebuilt Invoice model provided by passing the `prebuilt-invoice` model ID to the `AnalyzeDocumentAsync` method:

```C# Snippet:DocumentIntelligenceAnalyzeWithPrebuiltModelFromUriAsync
Uri uriSource = new Uri("<uriSource>");

var content = new AnalyzeDocumentContent()
{
    UrlSource = uriSource
};

Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-invoice", content);
AnalyzeResult result = operation.Value;

// To see the list of all the supported fields returned by service and its corresponding types for the
// prebuilt-invoice model, see:
// https://aka.ms/azsdk/formrecognizer/invoicefieldschema

for (int i = 0; i < result.Documents.Count; i++)
{
    Console.WriteLine($"Document {i}:");

    AnalyzedDocument document = result.Documents[i];

    if (document.Fields.TryGetValue("VendorName", out DocumentField vendorNameField)
        && vendorNameField.Type == DocumentFieldType.String)
    {
        string vendorName = vendorNameField.ValueString;
        Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
    }

    if (document.Fields.TryGetValue("CustomerName", out DocumentField customerNameField)
        && customerNameField.Type == DocumentFieldType.String)
    {
        string customerName = customerNameField.ValueString;
        Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
    }

    if (document.Fields.TryGetValue("Items", out DocumentField itemsField)
        && itemsField.Type == DocumentFieldType.Array)
    {
        foreach (DocumentField itemField in itemsField.ValueArray)
        {
            Console.WriteLine("Item:");

            if (itemField.Type == DocumentFieldType.Object)
            {
                IReadOnlyDictionary<string, DocumentField> itemFields = itemField.ValueObject;

                if (itemFields.TryGetValue("Description", out DocumentField itemDescriptionField)
                    && itemDescriptionField.Type == DocumentFieldType.String)
                {
                    string itemDescription = itemDescriptionField.ValueString;
                    Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                }

                if (itemFields.TryGetValue("Amount", out DocumentField itemAmountField)
                    && itemAmountField.Type == DocumentFieldType.Currency)
                {
                    CurrencyValue itemAmount = itemAmountField.ValueCurrency;
                    Console.WriteLine($"  Amount: '{itemAmount.CurrencySymbol}{itemAmount.Amount}', with confidence {itemAmountField.Confidence}");
                }
            }
        }
    }

    if (document.Fields.TryGetValue("SubTotal", out DocumentField subTotalField)
        && subTotalField.Type == DocumentFieldType.Currency)
    {
        CurrencyValue subTotal = subTotalField.ValueCurrency;
        Console.WriteLine($"Sub Total: '{subTotal.CurrencySymbol}{subTotal.Amount}', with confidence {subTotalField.Confidence}");
    }

    if (document.Fields.TryGetValue("TotalTax", out DocumentField totalTaxField)
        && totalTaxField.Type == DocumentFieldType.Currency)
    {
        CurrencyValue totalTax = totalTaxField.ValueCurrency;
        Console.WriteLine($"Total Tax: '{totalTax.CurrencySymbol}{totalTax.Amount}', with confidence {totalTaxField.Confidence}");
    }

    if (document.Fields.TryGetValue("InvoiceTotal", out DocumentField invoiceTotalField)
        && invoiceTotalField.Type == DocumentFieldType.Currency)
    {
        CurrencyValue invoiceTotal = invoiceTotalField.ValueCurrency;
        Console.WriteLine($"Invoice Total: '{invoiceTotal.CurrencySymbol}{invoiceTotal.Amount}', with confidence {invoiceTotalField.Confidence}");
    }
}
```

You are not limited to invoices! There are a couple of prebuilt models to choose from, each of which has its own set of supported fields. More information about the supported document types can be found in the [service documentation][docint_models].

For more information, see [here][analyze_prebuilt].

### Build a Custom Model

Build a custom model on your own document type. The resulting model can be used to analyze values from the types of documents it was built on.

```C# Snippet:DocumentIntelligenceSampleBuildModel
// For this sample, you can use the training documents found in the `trainingFiles` folder.
// Upload the documents to your storage container and then generate a container SAS URL. Note
// that a container URI without SAS is accepted only when the container is public or has a
// managed identity configured.

// For instructions to set up documents for training in an Azure Blob Storage Container, please see:
// https://aka.ms/azsdk/formrecognizer/buildcustommodel

string modelId = "<modelId>";
Uri blobContainerUri = new Uri("<blobContainerUri>");

// We are selecting the Template build mode in this sample. For more information about the available
// build modes and their differences, see:
// https://aka.ms/azsdk/formrecognizer/buildmode

var content = new BuildDocumentModelContent(modelId, DocumentBuildMode.Template)
{
    AzureBlobSource = new AzureBlobContentSource(blobContainerUri)
};

Operation<DocumentModelDetails> operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, content);
DocumentModelDetails model = operation.Value;

Console.WriteLine($"Model ID: {model.ModelId}");
Console.WriteLine($"Created on: {model.CreatedDateTime}");

Console.WriteLine("Document types the model can recognize:");
foreach (KeyValuePair<string, DocumentTypeDetails> docType in model.DocTypes)
{
    Console.WriteLine($"  Document type: '{docType.Key}', which has the following fields:");
    foreach (KeyValuePair<string, DocumentFieldSchema> schema in docType.Value.FieldSchema)
    {
        Console.WriteLine($"    Field: '{schema.Key}', with confidence {docType.Value.FieldConfidence[schema.Key]}");
    }
}
```

For more information, see [here][build_a_custom_model].

### Manage Models

Manage the models stored in your account.

```C# Snippet:DocumentIntelligenceSampleManageModelsAsync
// Check number of custom models in the Document Intelligence resource, and the maximum number
// of custom models that can be stored.

ResourceDetails resourceDetails = await client.GetResourceInfoAsync();

Console.WriteLine($"Resource has {resourceDetails.CustomDocumentModels.Count} custom models.");
Console.WriteLine($"It can have at most {resourceDetails.CustomDocumentModels.Limit} custom models.");

// Get a model by ID.
string modelId = "<modelId>";
DocumentModelDetails model = await client.GetModelAsync(modelId);

Console.WriteLine($"Details about model with ID '{model.ModelId}':");
Console.WriteLine($"  Created on: {model.CreatedDateTime}");
Console.WriteLine($"  Expires on: {model.ExpirationDateTime}");

// List up to 10 models currently stored in the resource.
int count = 0;

await foreach (DocumentModelDetails modelItem in client.GetModelsAsync())
{
    Console.WriteLine($"Model details:");
    Console.WriteLine($"  Model ID: {modelItem.ModelId}");
    Console.WriteLine($"  Description: {modelItem.Description}");
    Console.WriteLine($"  Created on: {modelItem.CreatedDateTime}");
    Console.WriteLine($"  Expires on: {model.ExpirationDateTime}");

    if (++count == 10)
    {
        break;
    }
}
```

For more information, see [here][manage_models].

### Build a Document Classifier

Build a document classifier by uploading custom training documents.

```C# Snippet:DocumentIntelligenceSampleBuildClassifier
// For this sample, you can use the training documents found in the `classifierTrainingFiles` folder.
// Upload the documents to your storage container and then generate a container SAS URL. Note
// that a container URI without SAS is accepted only when the container is public or has a
// managed identity configured.

// For instructions to set up documents for training in an Azure Blob Storage Container, please see:
// https://aka.ms/azsdk/formrecognizer/buildclassifiermodel

string classifierId = "<classifierId>";
Uri blobContainerUri = new Uri("<blobContainerUri>");
var sourceA = new AzureBlobContentSource(blobContainerUri) { Prefix = "IRS-1040-A/train" };
var sourceB = new AzureBlobContentSource(blobContainerUri) { Prefix = "IRS-1040-B/train" };
var docTypeA = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceA };
var docTypeB = new ClassifierDocumentTypeDetails() { AzureBlobSource = sourceB };
var docTypes = new Dictionary<string, ClassifierDocumentTypeDetails>()
{
    { "IRS-1040-A", docTypeA },
    { "IRS-1040-B", docTypeB }
};

var content = new BuildDocumentClassifierContent(classifierId, docTypes);

Operation<DocumentClassifierDetails> operation = await client.BuildClassifierAsync(WaitUntil.Completed, content);
DocumentClassifierDetails classifier = operation.Value;

Console.WriteLine($"Classifier ID: {classifier.ClassifierId}");
Console.WriteLine($"Created on: {classifier.CreatedDateTime}");

Console.WriteLine("Document types the classifier can recognize:");
foreach (KeyValuePair<string, ClassifierDocumentTypeDetails> docType in classifier.DocTypes)
{
    Console.WriteLine($"  {docType.Key}");
}
```

For more information, see [here][build_a_document_classifier].

### Classify a Document

Use document classifiers to accurately detect and identify documents you process within your application.

```C# Snippet:DocumentIntelligenceClassifyDocumentFromUriAsync
string classifierId = "<classifierId>";
Uri uriSource = new Uri("<uriSource>");

var content = new ClassifyDocumentContent()
{
    UrlSource = uriSource
};

Operation<AnalyzeResult> operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, classifierId, content);
AnalyzeResult result = operation.Value;

Console.WriteLine($"Input was classified by the classifier with ID '{result.ModelId}'.");

foreach (AnalyzedDocument document in result.Documents)
{
    Console.WriteLine($"Found a document of type: {document.DocType}");
}
```

For more information, see [here][classify_document].

## Troubleshooting

### General

When you interact with the Document Intelligence client library using the .NET SDK, errors returned by the service will result in a `RequestFailedException` with the same HTTP status code returned by the [REST API][docint_rest_api] request.

For example, if you submit a receipt image with an invalid `Uri`, a `400` error is returned, indicating "Bad Request".

```C# Snippet:DocumentIntelligenceBadRequest
var content = new AnalyzeDocumentContent()
{
    UrlSource = new Uri("http://invalid.uri")
};

try
{
    Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-receipt", content);
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
    ErrorCode: InvalidRequest

Content:
    {"error":{"code":"InvalidRequest","message":"Invalid request.","innererror":{"code":"InvalidContent","message":"The file is corrupted or format is unsupported. Refer to documentation for the list of supported formats."}}}

Headers:
    Transfer-Encoding: chunked
    x-envoy-upstream-service-time: REDACTED
    apim-request-id: REDACTED
    Strict-Transport-Security: REDACTED
    X-Content-Type-Options: REDACTED
    Date: Fri, 01 Oct 2021 02:55:44 GMT
    Content-Type: application/json; charset=utf-8
```

Error codes and messages raised by the Document Intelligence service can be found in the [service documentation][docint_errors].

### Setting up console logging

The simplest way to see the logs is to enable the console logging.

To create an Azure SDK log listener that outputs messages to console use the AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [Diagnostics Samples][logging].

## Next steps

Samples showing how to use the Document Intelligence library are available in this GitHub repository. Samples are provided for each main functional area:

- [Extract the layout of a document][extract_layout]
- [Analyze a document with a prebuilt model][analyze_prebuilt]
- [Build a custom model][build_a_custom_model]
- [Manage models][manage_models]
- [Classify a document][classify_document]
- [Build a document classifier][build_a_document_classifier]
- [Get and List document model operations][get_and_list]
- [Compose a model][compose_model]
- [Copy a custom model between Document Intelligence resources][copy_custom_models]
- [Analyze a document with add-on capabilities][analyze_with_addons]
- [Extract the layout of a document as Markdown][extract_layout_markdown]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fdocumentintelligence%2FAzure.AI.DocumentIntelligence%2FREADME.png)

<!-- LINKS -->
[docint_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/src
[docint_docs]: https://docs.microsoft.com/azure/cognitive-services/form-recognizer/
[docint_refdocs]: https://aka.ms/azsdk/net/docs/ref/formrecognizer
[docint_nuget_package]: https://www.nuget.org/packages/Azure.AI.FormRecognizer
[docint_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/README.md
[docint_rest_api]: https://aka.ms/azsdk/formrecognizer/restapi
[docint_models]: https://aka.ms/azsdk/formrecognizer/models
[docint_errors]: https://aka.ms/azsdk/formrecognizer/errors
[docint_build_model]: https://aka.ms/azsdk/formrecognizer/buildmodel
[cognitive_resource]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account


[doc_intelligence_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/src/DocumentIntelligenceClient.cs
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[register_aad_app]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[aad_grant_access]: https://docs.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal
[custom_subdomain]: https://docs.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity/README.md
[cognitive_resource_portal]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account
[cognitive_resource_cli]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account-cli
[regional_endpoints]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-custom-subdomains#is-there-a-list-of-regional-endpoints
[azure_cli_endpoint_lookup]: https://docs.microsoft.com/cli/azure/cognitiveservices/account?view=azure-cli-latest#az-cognitiveservices-account-show
[azure_portal_get_endpoint]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account?tabs=multiservice%2Cwindows#get-the-keys-for-your-resource


[di_studio]: https://aka.ms/azsdk/formrecognizer/formrecognizerstudio

[logging]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/samples/Diagnostics.md

[extract_layout]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_ExtractLayout.md
[analyze_prebuilt]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_AnalyzeWithPrebuiltModel.md
[build_a_custom_model]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_BuildCustomModel.md
[build_a_document_classifier]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_BuildDocumentClassifier.md
[classify_document]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_ClassifyDocument.md
[manage_models]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_ManageModels.md
[copy_custom_models]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_CopyCustomModel.md
[compose_model]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_ModelCompose.md
[get_and_list]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_GetAndListOperations.md
[analyze_with_addons]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_AddOnCapabilities.md
[extract_layout_markdown]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/Sample_ExtractLayoutAsMarkdown.md

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/documentintelligence/Azure.AI.DocumentIntelligence/README.png)
