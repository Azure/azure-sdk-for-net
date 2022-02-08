# Azure Cognitive Services Form Recognizer client library for .NET

Azure Cognitive Services Form Recognizer is a cloud service that uses machine learning to analyze text and structured data from your documents. It includes the following main features:

- Layout - Extract text, selection marks, and table structures, along with their bounding region coordinates, from documents.
- Document - Analyze key-value pairs and entities in addition to general layout from documents.
- Prebuilt - Analyze data from certain types of common documents (such as receipts, invoices, business cards, or identity documents) using prebuilt models.
- Custom - Build custom models to analyze text, field values, selection marks, and tabular data from documents. Custom models are trained with your own data, so they're tailored to your documents.

[Source code][formreco_client_src] | [Package (NuGet)][formreco_nuget_package] | [API reference documentation][formreco_refdocs] | [Product documentation][formreco_docs] | [Samples][formreco_samples]

## Getting started

### Install the package
Install the Azure Form Recognizer client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.FormRecognizer
``` 

> Note: This version of the client library defaults to the `2021-09-30-preview` version of the service.

This table shows the relationship between SDK versions and supported API versions of the service:

|SDK version|Supported API version of service
|-|-
|4.0.0-beta.X | 2.0, 2.1, 2021-09-30-preview
|3.1.X        | 2.0, 2.1
|3.0.X        | 2.0

> Note: Starting with version `2021-09-30-preview`, a new set of clients were introduced to leverage the newest features of the Form Recognizer service. Please see the [Migration Guide][migration_guide] for detailed instructions on how to update application code from client library version `3.1.X` or lower to the latest version. Additionally, see the [Changelog][formreco_changelog] for more detailed information. The below table describes the relationship of each client and its supported API version(s):

|API version|Supported clients
|-|-
|2021-09-30-preview|DocumentAnalysisClient and DocumentModelAdministrationClient
|2.1|FormRecognizerClient and FormTrainingClient
|2.0|FormRecognizerClient and FormTrainingClient

### Prerequisites
* An [Azure subscription][azure_sub].
* A [Cognitive Services or Form Recognizer resource][cognitive_resource] to use this package.

#### Create a Cognitive Services or Form Recognizer resource
Form Recognizer supports both [multi-service and single-service access][cognitive_resource_portal]. Create a Cognitive Services resource if you plan to access multiple cognitive services under a single endpoint/key. For Form Recognizer access only, create a Form Recognizer resource. Please note that you will need a single-service resource if you intend to use [Azure Active Directory authentication](#create-formrecognizerclient-with-azure-active-directory-credential).

You can create either resource using: 

* Option 1: [Azure Portal][cognitive_resource_portal].
* Option 2: [Azure CLI][cognitive_resource_cli]. 

Below is an example of how you can create a Form Recognizer resource using the CLI:

```PowerShell
# Create a new resource group to hold the form recognizer resource
# if using an existing resource group, skip this step
az group create --name <your-resource-name> --location <location>
```

```PowerShell
# Create form recognizer 
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
In order to interact with the Form Recognizer service, you'll need to create an instance of the [`DocumentAnalysisClient`][doc_analysis_client_class] class.
An **endpoint** and **credential** are necessary to instantiate the client object.

#### Get the endpoint

You can find the endpoint for your Form Recognizer resource using the
[Azure Portal][azure_portal_get_endpoint]
or [Azure CLI][azure_cli_endpoint_lookup]:

```PowerShell
# Get the endpoint for the form recognizer resource
az cognitiveservices account show --name "<resource-name>" --resource-group "<resource-group-name>" --query "properties.endpoint"
```

Either a regional endpoint or a custom subdomain can be used for authentication. They are formatted as follows:

```
Regional endpoint: https://<region>.api.cognitive.microsoft.com/
Custom subdomain: https://<resource-name>.cognitiveservices.azure.com/
```

A regional endpoint is the same for every resource in a region. A complete list of supported regional endpoints can be consulted [here][regional_endpoints]. Please note that regional endpoints do not support AAD authentication.

A custom subdomain, on the other hand, is a name that is unique to the Form Recognizer resource. They can only be used by [single-service resources][cognitive_resource_portal].

#### Get the API Key

The API key can be found in the [Azure Portal][azure_portal] or by running the following Azure CLI command:

```PowerShell
az cognitiveservices account keys list --name "<resource-name>" --resource-group "<resource-group-name>"
```

#### Create DocumentAnalysisClient with AzureKeyCredential
Once you have the value for the API key, create an `AzureKeyCredential`.  With the endpoint and key credential, you can create the [`DocumentAnalysisClient`][doc_analysis_client_class]:

```C# Snippet:CreateDocumentAnalysisClient
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);
var client = new DocumentAnalysisClient(new Uri(endpoint), credential);
```

#### Create DocumentAnalysisClient with Azure Active Directory Credential

`AzureKeyCredential` authentication is used in the examples in this getting started guide, but you can also authenticate with Azure Active Directory using the [Azure Identity library][azure_identity]. Note that regional endpoints do not support AAD authentication. Create a [custom subdomain][custom_subdomain] for your resource in order to use this type of authentication.

To use the [DefaultAzureCredential][DefaultAzureCredential] provider shown below, or other credential providers provided with the Azure SDK, please install the `Azure.Identity` package:

```PowerShell
Install-Package Azure.Identity
```

You will also need to [register a new AAD application][register_aad_app] and [grant access][aad_grant_access] to Form Recognizer by assigning the `"Cognitive Services User"` role to your service principal.

Set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables: AZURE_CLIENT_ID, AZURE_TENANT_ID, AZURE_CLIENT_SECRET.

```C# Snippet:CreateDocumentAnalysisClientTokenCredential
string endpoint = "<endpoint>";
var client = new DocumentAnalysisClient(new Uri(endpoint), new DefaultAzureCredential());
```

## Key concepts

### DocumentAnalysisClient

`DocumentAnalysisClient` provides operations for analyzing input documents using prebuilt and custom models through the `StartAnalyzeDocument` and `StartAnalyzeDocumentFromUri` APIs. Use the `modelId` parameter to select the type of model for analysis.

|Model ID|Features
|-|-
|`prebuilt-layout`| Text extraction, selection marks, tables
|`prebuilt-document`| Text extraction, selection marks, tables, key-value pairs and entities
|`prebuilt-invoices`| Text extraction, selection marks, tables, and pre-trained fields and values pertaining to invoices
|`prebuilt-businessCard`| Text extraction and pre-trained fields and values pertaining to business cards
|`prebuilt-idDocument`| Text extraction and pre-trained fields and values pertaining to driver licenses and international passports
|`prebuilt-receipt`| Text extraction and pre-trained fields and values pertaining to sales receipts
|`{custom-model-id}`| Text extraction, selection marks, tables, labeled fields and values from your custom documents

Sample code snippets are provided to illustrate using a DocumentAnalysisClient [here](#examples).
More information about analyzing documents, including supported features, locales, and document types can be found in the [service documentation][formreco_models].

### DocumentModelAdministrationClient

`DocumentModelAdministrationClient` provides operations for:

- Building custom models to analyze specific fields you specify by labeling your custom documents. A `DocumentModel` is returned indicating the document type(s) the model can analyze, the fields it can analyze for each document type,
as well as the estimated confidence for each field. See the [service documentation][formreco_build_model] for a more detailed explanation.
- Creating a composed model from a collection of existing models.
- Managing models created in your account.
- Listing document model operations or getting a specific model operation created within the last 24 hours.
- Copying a custom model from one Form Recognizer resource to another.

See examples for [Build a Custom Model](#build-a-custom-model) and [Manage Models](#manage-models).

Please note that models can also be built using a graphical user interface such as the [Form Recognizer Labeling Tool][labeling_tool].

### Long-Running Operations

Because analyzing documents and building models take time, these operations are implemented as [**long-running operations**][dotnet_lro_guidelines].  Long-running operations consist of an initial request sent to the service to start an operation, followed by polling the service at intervals to determine whether the operation has completed or failed, and if it has succeeded, to get the result.

For long running operations in the Azure SDK, the client exposes a `Start<operation-name>` method that returns an `Operation<T>`.  You can use the extension method `WaitForCompletionAsync()` to wait for the operation to complete and obtain its result.  A sample code snippet is provided to illustrate using long-running operations [below](#extract-layout).

### Thread safety
We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts
<!-- CLIENT COMMON BAR -->
[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)
<!-- CLIENT COMMON BAR -->

## Examples
The following section provides several code snippets illustrating common patterns used in the Form Recognizer .NET API. Most of the snippets below make use of asynchronous service calls, but keep in mind that the Azure.AI.FormRecognizer package supports both synchronous and asynchronous APIs.

### Async examples
* [Extract Layout](#extract-layout)
* [Use the General Prebuilt Document Model](#use-the-general-prebuilt-document-model)
* [Use Prebuilt Models](#use-prebuilt-models)
* [Build a Custom Model](#build-a-custom-model)
* [Analyze Custom Documents](#analyze-custom-documents)
* [Manage Models](#manage-models)

### Sync examples
* [Manage Models Synchronously](#manage-models-synchronously)

> Note that these samples use SDK `V4.0.0-beta.X`. For lower versions of the SDK, please see [Form Recognizer Samples for V3.1.X][formrecov3_samples].

### Extract Layout
Extract text, selection marks, text styles, and table structures, along with their bounding region coordinates from documents.

```C# Snippet:FormRecognizerExtractLayoutFromUriAsync
string fileUri = "<fileUri>";

AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-layout", fileUri);

await operation.WaitForCompletionAsync();

AnalyzeResult result = operation.Value;

foreach (DocumentPage page in result.Pages)
{
    Console.WriteLine($"Document Page {page.PageNumber} has {page.Lines.Count} line(s), {page.Words.Count} word(s),");
    Console.WriteLine($"and {page.SelectionMarks.Count} selection mark(s).");

    for (int i = 0; i < page.Lines.Count; i++)
    {
        DocumentLine line = page.Lines[i];
        Console.WriteLine($"  Line {i} has content: '{line.Content}'.");

        Console.WriteLine($"    Its bounding box is:");
        Console.WriteLine($"      Upper left => X: {line.BoundingBox[0].X}, Y= {line.BoundingBox[0].Y}");
        Console.WriteLine($"      Upper right => X: {line.BoundingBox[1].X}, Y= {line.BoundingBox[1].Y}");
        Console.WriteLine($"      Lower right => X: {line.BoundingBox[2].X}, Y= {line.BoundingBox[2].Y}");
        Console.WriteLine($"      Lower left => X: {line.BoundingBox[3].X}, Y= {line.BoundingBox[3].Y}");
    }

    for (int i = 0; i < page.SelectionMarks.Count; i++)
    {
        DocumentSelectionMark selectionMark = page.SelectionMarks[i];

        Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
        Console.WriteLine($"    Its bounding box is:");
        Console.WriteLine($"      Upper left => X: {selectionMark.BoundingBox[0].X}, Y= {selectionMark.BoundingBox[0].Y}");
        Console.WriteLine($"      Upper right => X: {selectionMark.BoundingBox[1].X}, Y= {selectionMark.BoundingBox[1].Y}");
        Console.WriteLine($"      Lower right => X: {selectionMark.BoundingBox[2].X}, Y= {selectionMark.BoundingBox[2].Y}");
        Console.WriteLine($"      Lower left => X: {selectionMark.BoundingBox[3].X}, Y= {selectionMark.BoundingBox[3].Y}");
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
            Console.WriteLine($"  Content: {result.Content.Substring(span.Offset, span.Length)}");
        }
    }
}

Console.WriteLine("The following tables were extracted:");

for (int i = 0; i < result.Tables.Count; i++)
{
    DocumentTable table = result.Tables[i];
    Console.WriteLine($"  Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");

    foreach (DocumentTableCell cell in table.Cells)
    {
        Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) has kind '{cell.Kind}' and content: '{cell.Content}'.");
    }
}
```

For more information and samples see [here][extract_layout].

### Use the General Prebuilt Document Model
Analyze key-value pairs, entities, tables, and selection marks from documents using the general prebuilt document model.

```C# Snippet:FormRecognizerAnalyzePrebuiltDocumentFromUriAsync
string fileUri = "<fileUri>";

AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-document", fileUri);

await operation.WaitForCompletionAsync();

AnalyzeResult result = operation.Value;

Console.WriteLine("Detected key-value pairs:");

foreach (DocumentKeyValuePair kvp in result.KeyValuePairs)
{
    if (kvp.Value.Content == null)
    {
        Console.WriteLine($"  Found key with no value: '{kvp.Key.Content}'");
    }
    else
    {
        Console.WriteLine($"  Found key-value pair: '{kvp.Key.Content}' and '{kvp.Value.Content}'");
    }
}

Console.WriteLine("Detected entities:");

foreach (DocumentEntity entity in result.Entities)
{
    if (entity.SubCategory == null)
    {
        Console.WriteLine($"  Found entity '{entity.Content}' with category '{entity.Category}'.");
    }
    else
    {
        Console.WriteLine($"  Found entity '{entity.Content}' with category '{entity.Category}' and sub-category '{entity.SubCategory}'.");
    }
}

foreach (DocumentPage page in result.Pages)
{
    Console.WriteLine($"Document Page {page.PageNumber} has {page.Lines.Count} line(s), {page.Words.Count} word(s),");
    Console.WriteLine($"and {page.SelectionMarks.Count} selection mark(s).");

    for (int i = 0; i < page.Lines.Count; i++)
    {
        DocumentLine line = page.Lines[i];
        Console.WriteLine($"  Line {i} has content: '{line.Content}'.");

        Console.WriteLine($"    Its bounding box is:");
        Console.WriteLine($"      Upper left => X: {line.BoundingBox[0].X}, Y= {line.BoundingBox[0].Y}");
        Console.WriteLine($"      Upper right => X: {line.BoundingBox[1].X}, Y= {line.BoundingBox[1].Y}");
        Console.WriteLine($"      Lower right => X: {line.BoundingBox[2].X}, Y= {line.BoundingBox[2].Y}");
        Console.WriteLine($"      Lower left => X: {line.BoundingBox[3].X}, Y= {line.BoundingBox[3].Y}");
    }

    for (int i = 0; i < page.SelectionMarks.Count; i++)
    {
        DocumentSelectionMark selectionMark = page.SelectionMarks[i];

        Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
        Console.WriteLine($"    Its bounding box is:");
        Console.WriteLine($"      Upper left => X: {selectionMark.BoundingBox[0].X}, Y= {selectionMark.BoundingBox[0].Y}");
        Console.WriteLine($"      Upper right => X: {selectionMark.BoundingBox[1].X}, Y= {selectionMark.BoundingBox[1].Y}");
        Console.WriteLine($"      Lower right => X: {selectionMark.BoundingBox[2].X}, Y= {selectionMark.BoundingBox[2].Y}");
        Console.WriteLine($"      Lower left => X: {selectionMark.BoundingBox[3].X}, Y= {selectionMark.BoundingBox[3].Y}");
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
            Console.WriteLine($"  Content: {result.Content.Substring(span.Offset, span.Length)}");
        }
    }
}

Console.WriteLine("The following tables were extracted:");

for (int i = 0; i < result.Tables.Count; i++)
{
    DocumentTable table = result.Tables[i];
    Console.WriteLine($"  Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");

    foreach (DocumentTableCell cell in table.Cells)
    {
        Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) has kind '{cell.Kind}' and content: '{cell.Content}'.");
    }
}
```

For more information and samples see [here][analyze_prebuilt_document].



### Use Prebuilt Models
Analyze data from certain types of common documents using pre-trained models provided by the Form Recognizer service.

For example, to analyze fields from an invoice, use the prebuilt Invoice model provided by passing the `prebuilt-invoice` model ID into the `StartAnalyzeDocumentAsync` method:

```C# Snippet:FormRecognizerAnalyzeWithPrebuiltModelFromFileAsync
string filePath = "<filePath>";

using var stream = new FileStream(filePath, FileMode.Open);

AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentAsync("prebuilt-invoice", stream);

await operation.WaitForCompletionAsync();

AnalyzeResult result = operation.Value;

// To see the list of all the supported fields returned by service and its corresponding types for the
// prebuilt-invoice model, consult:
// https://aka.ms/azsdk/formrecognizer/invoicefieldschema

for (int i = 0; i < result.Documents.Count; i++)
{
    Console.WriteLine($"Document {i}:");

    AnalyzedDocument document = result.Documents[i];

    if (document.Fields.TryGetValue("VendorName", out DocumentField vendorNameField))
    {
        if (vendorNameField.ValueType == DocumentFieldType.String)
        {
            string vendorName = vendorNameField.AsString();
            Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
        }
    }

    if (document.Fields.TryGetValue("CustomerName", out DocumentField customerNameField))
    {
        if (customerNameField.ValueType == DocumentFieldType.String)
        {
            string customerName = customerNameField.AsString();
            Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
        }
    }

    if (document.Fields.TryGetValue("Items", out DocumentField itemsField))
    {
        if (itemsField.ValueType == DocumentFieldType.List)
        {
            foreach (DocumentField itemField in itemsField.AsList())
            {
                Console.WriteLine("Item:");

                if (itemField.ValueType == DocumentFieldType.Dictionary)
                {
                    IReadOnlyDictionary<string, DocumentField> itemFields = itemField.AsDictionary();

                    if (itemFields.TryGetValue("Description", out DocumentField itemDescriptionField))
                    {
                        if (itemDescriptionField.ValueType == DocumentFieldType.String)
                        {
                            string itemDescription = itemDescriptionField.AsString();

                            Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                        }
                    }

                    if (itemFields.TryGetValue("Amount", out DocumentField itemAmountField))
                    {
                        if (itemAmountField.ValueType == DocumentFieldType.Double)
                        {
                            double itemAmount = itemAmountField.AsDouble();

                            Console.WriteLine($"  Amount: '{itemAmount}', with confidence {itemAmountField.Confidence}");
                        }
                    }
                }
            }
        }
    }

    if (document.Fields.TryGetValue("SubTotal", out DocumentField subTotalField))
    {
        if (subTotalField.ValueType == DocumentFieldType.Double)
        {
            double subTotal = subTotalField.AsDouble();
            Console.WriteLine($"Sub Total: '{subTotal}', with confidence {subTotalField.Confidence}");
        }
    }

    if (document.Fields.TryGetValue("TotalTax", out DocumentField totalTaxField))
    {
        if (totalTaxField.ValueType == DocumentFieldType.Double)
        {
            double totalTax = totalTaxField.AsDouble();
            Console.WriteLine($"Total Tax: '{totalTax}', with confidence {totalTaxField.Confidence}");
        }
    }

    if (document.Fields.TryGetValue("InvoiceTotal", out DocumentField invoiceTotalField))
    {
        if (invoiceTotalField.ValueType == DocumentFieldType.Double)
        {
            double invoiceTotal = invoiceTotalField.AsDouble();
            Console.WriteLine($"Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
        }
    }
}
```

You are not limited to invoices! There are a few prebuilt models to choose from, each of which has its own set of supported fields:
- Analyze business cards using the `prebuilt-businessCard` model. [Supported fields][businessCard_fields].
- Analyze driver licenses and international passports using the `prebuilt-idDocument` model. [Supported fields][idDocument_fields].
- Analyze invoices using the `prebuilt-invoice` model. [Supported fields][invoice_fields].
- Analyze receipts using the `prebuilt-receipt` model. [Supported fields][receipt_fields].

For more samples and information about which types of documents are supported, see [here][analyze_prebuilt].

### Build a Custom Model
Build a custom model on your own document type. The resulting model can be used to analyze values from the types of documents it was built on.

```C# Snippet:FormRecognizerSampleBuildModel
// For this sample, you can use the training documents found in the `trainingFiles` folder.
// Upload the forms to your storage container and then generate a container SAS URL.
// For instructions to set up forms for training in an Azure Storage Blob Container, please see:
// https://aka.ms/azsdk/formrecognizer/buildtrainingset

Uri trainingFileUri = <trainingFileUri>;
var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// We are selecting the Template build mode in this sample. For more information about the available
// build modes and their differences, please see:
// https://aka.ms/azsdk/formrecognizer/buildmode

BuildModelOperation operation = await client.StartBuildModelAsync(trainingFileUri, DocumentBuildMode.Template);
Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
DocumentModel model = operationResponse.Value;

Console.WriteLine($"  Model Id: {model.ModelId}");
if (string.IsNullOrEmpty(model.Description))
    Console.WriteLine($"  Model description: {model.Description}");
Console.WriteLine($"  Created on: {model.CreatedOn}");
Console.WriteLine("  Doc types the model can recognize:");
foreach (KeyValuePair<string, DocTypeInfo> docType in model.DocTypes)
{
    Console.WriteLine($"    Doc type: {docType.Key} which has the following fields:");
    foreach (KeyValuePair<string, DocumentFieldSchema> schema in docType.Value.FieldSchema)
    {
        Console.WriteLine($"    Field: {schema.Key} with confidence {docType.Value.FieldConfidence[schema.Key]}");
    }
}
```

For more information and samples see [here][build_a_custom_model].

### Analyze Custom Documents
Analyze text, field values, selection marks, and table data from custom documents, using models you build with your own document types.

```C# Snippet:FormRecognizerAnalyzeWithCustomModelFromUriAsync
string modelId = "<modelId>";
string fileUri = "<fileUri>";

AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentFromUriAsync(modelId, fileUri);

await operation.WaitForCompletionAsync();

AnalyzeResult result = operation.Value;

Console.WriteLine($"Document was analyzed with model with ID: {result.ModelId}");

foreach (AnalyzedDocument document in result.Documents)
{
    Console.WriteLine($"Document of type: {document.DocType}");

    foreach (KeyValuePair<string, DocumentField> fieldKvp in document.Fields)
    {
        string fieldName = fieldKvp.Key;
        DocumentField field = fieldKvp.Value;

        Console.WriteLine($"Field '{fieldName}': ");

        Console.WriteLine($"  Content: '{field.Content}'");
        Console.WriteLine($"  Confidence: '{field.Confidence}'");
    }
}
```

For more information and samples see [here][analyze_custom].

### Manage Models
Manage the models stored in your account.

```C# Snippet:FormRecognizerSampleManageModelsAsync
var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// Check number of custom models in the FormRecognizer account, and the maximum number of models that can be stored.
AccountProperties accountProperties = await client.GetAccountPropertiesAsync();
Console.WriteLine($"Account has {accountProperties.Count} models.");
Console.WriteLine($"It can have at most {accountProperties.Limit} models.");

// List the first ten or fewer models currently stored in the account.
AsyncPageable<DocumentModelInfo> models = client.GetModelsAsync();

int count = 0;
await foreach (DocumentModelInfo modelInfo in models)
{
    Console.WriteLine($"Custom Model Info:");
    Console.WriteLine($"  Model Id: {modelInfo.ModelId}");
    if (string.IsNullOrEmpty(modelInfo.Description))
        Console.WriteLine($"  Model description: {modelInfo.Description}");
    Console.WriteLine($"  Created on: {modelInfo.CreatedOn}");
    if (++count == 10)
        break;
}

// Create a new model to store in the account
Uri trainingFileUri = <trainingFileUri>;
BuildModelOperation operation = await client.StartBuildModelAsync(trainingFileUri, DocumentBuildMode.Template);
Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
DocumentModel model = operationResponse.Value;

// Get the model that was just created
DocumentModel newCreatedModel = await client.GetModelAsync(model.ModelId);

Console.WriteLine($"Custom Model with Id {newCreatedModel.ModelId} has the following information:");

Console.WriteLine($"  Model Id: {newCreatedModel.ModelId}");
if (string.IsNullOrEmpty(newCreatedModel.Description))
    Console.WriteLine($"  Model description: {newCreatedModel.Description}");
Console.WriteLine($"  Created on: {newCreatedModel.CreatedOn}");

// Delete the model from the account.
await client.DeleteModelAsync(newCreatedModel.ModelId);
```

For more information and samples see [here][manage_models].

### Manage Models Synchronously
Manage the models stored in your account with a synchronous API. Note that we are still making an asynchronous call to `WaitForCompletionAsync` when building a model, since this method does not have a synchronous counterpart. For more information on long-running operations, see [Long-Running Operations](#long-running-operations).

```C# Snippet:FormRecognizerSampleManageModels
var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

// Check number of custom models in the FormRecognizer account, and the maximum number of models that can be stored.
AccountProperties accountProperties = client.GetAccountProperties();
Console.WriteLine($"Account has {accountProperties.Count} models.");
Console.WriteLine($"It can have at most {accountProperties.Limit} models.");

// List the first ten or fewer models currently stored in the account.
Pageable<DocumentModelInfo> models = client.GetModels();

foreach (DocumentModelInfo modelInfo in models.Take(10))
{
    Console.WriteLine($"Custom Model Info:");
    Console.WriteLine($"  Model Id: {modelInfo.ModelId}");
    if (string.IsNullOrEmpty(modelInfo.Description))
        Console.WriteLine($"  Model description: {modelInfo.Description}");
    Console.WriteLine($"  Created on: {modelInfo.CreatedOn}");
}

// Create a new model to store in the account

Uri trainingFileUri = <trainingFileUri>;
BuildModelOperation operation = client.StartBuildModel(trainingFileUri, DocumentBuildMode.Template);
Response<DocumentModel> operationResponse = await operation.WaitForCompletionAsync();
DocumentModel model = operationResponse.Value;

// Get the model that was just created
DocumentModel newCreatedModel = client.GetModel(model.ModelId);

Console.WriteLine($"Custom Model with Id {newCreatedModel.ModelId} has the following information:");

Console.WriteLine($"  Model Id: {newCreatedModel.ModelId}");
if (string.IsNullOrEmpty(newCreatedModel.Description))
    Console.WriteLine($"  Model description: {newCreatedModel.Description}");
Console.WriteLine($"  Created on: {newCreatedModel.CreatedOn}");

// Delete the created model from the account.
client.DeleteModel(newCreatedModel.ModelId);
```

## Troubleshooting

### General
When you interact with the Cognitive Services Form Recognizer client library using the .NET SDK, errors returned by the service will result in a `RequestFailedException` with the same HTTP status code returned by the [REST API][formreco_rest_api] request.

For example, if you submit a receipt image with an invalid `Uri`, a `400` error is returned, indicating "Bad Request".

```C# Snippet:DocumentAnalysisBadRequest
try
{
    AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-receipt", new Uri("http://invalid.uri"));
    await operation.WaitForCompletionAsync();
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

Error codes and messages raised by the Form Recognizer service can be found in the [service documentation][formreco_errors].

### Setting up console logging
The simplest way to see the logs is to enable the console logging.
To create an Azure SDK log listener that outputs messages to console use the AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [Diagnostics Samples][logging].

## Next steps

Samples showing how to use the Cognitive Services Form Recognizer library are available in this GitHub repository. Samples are provided for each main functional area:

- [Extract the layout of a document][extract_layout]
- [Analyze with the prebuilt document model][analyze_prebuilt_document]
- [Analyze a document with a custom model][analyze_custom]
- [Analyze a document with a prebuilt model][analyze_prebuilt]
- [Build a custom model][build_a_custom_model]
- [Manage models][manage_models]
- [Get and List document model operations][get_and_list]
- [Create a composed model][composed_model]
- [Copy a custom model between Form Recognizer resources][copy_custom_models]

> Note that these samples use SDK `V4.0.0-beta.X`. For lower versions of the SDK, please see [Form Recognizer Samples for V3.1.X][formrecov3_samples].

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fformrecognizer%2FAzure.AI.FormRecognizer%2FREADME.png)


<!-- LINKS -->
[formreco_client_src]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/src
[formreco_docs]: https://docs.microsoft.com/azure/cognitive-services/form-recognizer/
[formreco_refdocs]: https://aka.ms/azsdk/net/docs/ref/formrecognizer
[formreco_nuget_package]: https://www.nuget.org/packages/Azure.AI.FormRecognizer
[formreco_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/README.md
[formrecov3_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/V3.1/README.md
[formreco_changelog]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/formrecognizer/Azure.AI.FormRecognizer/CHANGELOG.md
[formreco_rest_api]: https://aka.ms/azsdk/formrecognizer/restapi
[formreco_models]: https://aka.ms/azsdk/formrecognizer/models
[formreco_errors]: https://aka.ms/azsdk/formrecognizer/errors
[formreco_build_model]: https://aka.ms/azsdk/formrecognizer/buildmodel
[migration_guide]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/MigrationGuide.md
[cognitive_resource]: https://docs.microsoft.com/azure/cognitive-services/cognitive-services-apis-create-account


[doc_analysis_client_class]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/src/DocumentAnalysisClient.cs
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


[labeling_tool]: https://aka.ms/azsdk/formrecognizer/labelingtool
[businessCard_fields]: https://aka.ms/azsdk/formrecognizer/businesscardfieldschema
[idDocument_fields]: https://aka.ms/azsdk/formrecognizer/iddocumentfieldschema
[invoice_fields]: https://aka.ms/azsdk/formrecognizer/invoicefieldschema
[receipt_fields]: https://aka.ms/azsdk/formrecognizer/receiptfieldschema
[dotnet_lro_guidelines]: https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-longrunning

[logging]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/samples/Diagnostics.md

[extract_layout]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ExtractLayout.md
[analyze_prebuilt_document]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzePrebuiltDocument.md
[analyze_custom]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzeWithCustomModel.md
[analyze_prebuilt]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_AnalyzeWithPrebuiltModel.md
[build_a_custom_model]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_BuildCustomModel.md
[manage_models]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ManageModels.md
[copy_custom_models]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_CopyCustomModel.md
[composed_model]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_ModelCompose.md
[get_and_list]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/Sample_GetAndListOperations.md

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[nuget]: https://www.nuget.org/
[azure_portal]: https://portal.azure.com

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
