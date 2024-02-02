# Guide for migrating to Azure.AI.DocumentIntelligence from Azure.AI.FormRecognizer

This guide is intended to assist in the migration to `Azure.AI.DocumentIntelligence (1.0.0-beta.1)` from `Azure.AI.FormRecognizer (4.1.0 or 4.0.0)`. It will focus on side-by-side comparisons for similar operations between libraries. Please note that version `1.0.0-beta.1` will be used for comparison with `4.1.0`.

Familiarity with the `Azure.AI.FormRecognizer` package is assumed. For those new to the Document Intelligence and the Form Recognizer client libraries for .NET, please refer to the [README][readme] rather than this guide. For an exhaustive list of breaking changes between the packages, see the [CHANGELOG][changelog].

## Table of Contents
- [Migration benefits](#migration-benefits)
- [Important changes](#important-changes)
    - [Rebranding](#rebranding)
    - [Client usage](#client-usage)
    - [Analyzing documents](#analyzing-documents)
    - [Classifying documents](#classifying-documents)
    - [Building a document model](#building-a-document-model)
- [Missing features](#missing-features)
    - [Analyzing and classifying documents from a stream](#analyzing-and-classifying-documents-from-a-stream)
    - [Extracting words from a line](#extracting-words-from-a-line)
    - [Accessing an existing long-running operation](#accessing-an-existing-long-running-operation)
- [Additional samples](#additional-samples)

## Migration benefits

A natural question to ask when considering whether to adopt a new version of a library is what the benefits of doing so would be. As Azure Document Intelligence has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and add value to our customers.

There are many benefits to using the new `Azure.AI.DocumentIntelligence` library. This new library introduces two new clients: `DocumentIntelligenceClient` and `DocumentIntelligenceAdministrationClient`, providing support for the new features added by the service in API version `2023-10-31-preview` and higher.

New features provided by the `Azure.AI.DocumentIntelligence` library include:
- **Markdown content format:** support to output with Markdown content format along with the default plain text. This is only supported for the "prebuilt-layout" model. Markdown content format is deemed a more friendly format for LLM consumption in a chat or automation use scenario.
- **Query fields:** query fields are reintroduced as a premium add-on feature. When the `DocumentAnalysisFeature.QueryFields` argument is passed to a document analysis request, the service will further extract the values of the fields specified via the parameter `queryFields` to supplement any existing fields defined by the model as fallback.
- **Split options:** in previous API versions, the document splitting and classification operation always tried to split the input file into multiple documents. To enable a wider set of scenarios, `ClassifyDocument` now supports a `split` parameter. The following values are supported:
  - `Auto`: let the service determine where to split.
  - `None`: the entire file is treated as a single document. No splitting is performed.
  - `PerPage`: each page is treated as a separate document. Each empty page is kept as its own document.

The table below describes the relationship of each client and its supported API version(s):

Package|API version|Supported clients
|-|-|-
|Azure.AI.DocumentIntelligence | 2023-10-31-preview | DocumentIntelligenceClient and DocumentIntelligenceAdministrationClient
|Azure.AI.FormRecognizer |2023-07-31 | DocumentAnalysisClient and DocumentModelAdministrationClient
|Azure.AI.FormRecognizer |2022-08-31 | DocumentAnalysisClient and DocumentModelAdministrationClient
|Azure.AI.FormRecognizer |2.1 | FormRecognizerClient and FormTrainingClient
|Azure.AI.FormRecognizer |2.0 | FormRecognizerClient and FormTrainingClient

Please refer to the [README][readme] for more information on these new clients.

## Important changes

### Rebranding
Some terminology has changed to reflect the enhanced capabilities of the latest service APIs. The "Azure Cognitive Services Form Recognizer" service has been rebranded to "Azure AI Document Intelligence", reflecting the fact that it is capable of much more than simple recognition, and is not limited to documents that are "forms". Similarly, we've made the following broad changes to the terminology used throughout the SDK:

- The namespace `Azure.AI.DocumentIntelligence` has replaced `Azure.AI.FormRecognizer.DocumentAnalysis`.
- The client `DocumentIntelligenceClient` has replaced `DocumentAnalysisClient`.
- The client `DocumentIntelligenceAdministrationClient` has replaced `DocumentModelAdministrationClient`.
- The type `AzureAIDocumentIntelligenceClientOptions` has replaced `DocumentAnalysisClientOptions`.
- The type `AIDocumentIntelligenceModelFactory` has replaced `DocumentAnalysisModelFactory`.

### Client usage

We continue to support API key and AAD authentication methods when creating the clients. Below are the differences between the two versions:

- In `Azure.AI.DocumentIntelligence`, we have `DocumentIntelligenceClient` and `DocumentIntelligenceAdministrationClient` which support API version `2023-10-31-preview` and higher.
- Some client methods have been renamed. See the [CHANGELOG][changelog] for an exhaustive list of changes.

Creating new clients in `Azure.AI.FormRecognizer`:
```C#
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);

var documentAnalysisClient = new DocumentAnalysisClient(new Uri(endpoint), credential);
var documentModelAdministrationClient = new DocumentModelAdministrationClient(new Uri(endpoint), credential);
```

Creating new clients in `Azure.AI.DocumentIntelligence`:
```C# Snippet:Migration_CreateBothDocumentIntelligenceClients
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);

var documentIntelligenceClient = new DocumentIntelligenceClient(new Uri(endpoint), credential);
var documentIntelligenceAdministrationClient = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), credential);
```

### Analyzing documents

Differences between the versions:
- The former `AnalyzeDocument` method taking a `Stream` as the input document is still not supported in `Azure.AI.DocumentIntelligence` 1.0.0-beta.1. As a workaround you will need to use a URI input or the new Base64 input option, which is described later in this guide ([Analyzing and classifying documents from a stream](#analyzing-and-classifying-documents-from-a-stream)).
- `AnalyzeDocumentFromUri` has been renamed to `AnalyzeDocument` and its input arguments have been reorganized:
  - The `documentUri` parameter has been removed. Instead, an `AnalyzeDocumentContent` object must be passed to the method to select the desired input type: URI or Base64 binary data.
  - The `options` parameter has been removed. Instead, `pages`, `locale`, and `features` options can be passed directly as method parameters.
- The property `DocumentField.Value` has been removed. A field's value can now be extracted from one of the its new value properties, depending on the type of the field: `ValueAddress` for type `Address`, `ValueBoolean` for type `Boolean`, and so on.

Analyzing documents with `Azure.AI.FormRecognizer`:
```C#
Uri invoiceUri = new Uri("<invoiceUri>");
var options = new RecognizeInvoicesOptions() { Locale = "en-US" };

RecognizeInvoicesOperation operation = await client.StartRecognizeInvoicesFromUriAsync(invoiceUri, options);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection invoices = operationResponse.Value;

RecognizedForm invoice = invoices.Single();

if (invoice.Fields.TryGetValue("InvoiceId", out FormField invoiceIdField))
{
    if (invoiceIdField.Value.ValueType == FieldValueType.String)
    {
        string invoiceId = invoiceIdField.Value.AsString();
        Console.WriteLine($"Invoice Id: '{invoiceId}', with confidence {invoiceIdField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("VendorName", out FormField vendorNameField))
{
    if (vendorNameField.Value.ValueType == FieldValueType.String)
    {
        string vendorName = vendorNameField.Value.AsString();
        Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("CustomerName", out FormField customerNameField))
{
    if (customerNameField.Value.ValueType == FieldValueType.String)
    {
        string customerName = customerNameField.Value.AsString();
        Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("Items", out FormField itemsField))
{
    if (itemsField.Value.ValueType == FieldValueType.List)
    {
        foreach (FormField itemField in itemsField.Value.AsList())
        {
            Console.WriteLine("Item:");

            if (itemField.Value.ValueType == FieldValueType.Dictionary)
            {
                IReadOnlyDictionary<string, FormField> itemFields = itemField.Value.AsDictionary();

                if (itemFields.TryGetValue("Description", out FormField itemDescriptionField))
                {
                    if (itemDescriptionField.Value.ValueType == FieldValueType.String)
                    {
                        string itemDescription = itemDescriptionField.Value.AsString();

                        Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                    }
                }

                if (itemFields.TryGetValue("UnitPrice", out FormField itemUnitPriceField))
                {
                    if (itemUnitPriceField.Value.ValueType == FieldValueType.Float)
                    {
                        float itemUnitPrice = itemUnitPriceField.Value.AsFloat();

                        Console.WriteLine($"  UnitPrice: '{itemUnitPrice}', with confidence {itemUnitPriceField.Confidence}");
                    }
                }

                if (itemFields.TryGetValue("Quantity", out FormField itemQuantityField))
                {
                    if (itemQuantityField.Value.ValueType == FieldValueType.Float)
                    {
                        float quantityAmount = itemQuantityField.Value.AsFloat();

                        Console.WriteLine($"  Quantity: '{quantityAmount}', with confidence {itemQuantityField.Confidence}");
                    }
                }

                if (itemFields.TryGetValue("Amount", out FormField itemAmountField))
                {
                    if (itemAmountField.Value.ValueType == FieldValueType.Float)
                    {
                        float itemAmount = itemAmountField.Value.AsFloat();

                        Console.WriteLine($"  Amount: '{itemAmount}', with confidence {itemAmountField.Confidence}");
                    }
                }
            }
        }
    }
}

if (invoice.Fields.TryGetValue("SubTotal", out FormField subTotalField))
{
    if (subTotalField.Value.ValueType == FieldValueType.Float)
    {
        float subTotal = subTotalField.Value.AsFloat();
        Console.WriteLine($"Sub Total: '{subTotal}', with confidence {subTotalField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("TotalTax", out FormField totalTaxField))
{
    if (totalTaxField.Value.ValueType == FieldValueType.Float)
    {
        float totalTax = totalTaxField.Value.AsFloat();
        Console.WriteLine($"Total Tax: '{totalTax}', with confidence {totalTaxField.Confidence}");
    }
}

if (invoice.Fields.TryGetValue("InvoiceTotal", out FormField invoiceTotalField))
{
    if (invoiceTotalField.Value.ValueType == FieldValueType.Float)
    {
        float invoiceTotal = invoiceTotalField.Value.AsFloat();
        Console.WriteLine($"Invoice Total: '{invoiceTotal}', with confidence {invoiceTotalField.Confidence}");
    }
}
```

Analyzing documents with `Azure.AI.DocumentIntelligence`:
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

### Classifying documents

Differences between the versions:
- The former `ClassifyDocument` method taking a `Stream` as the input document is still not supported in `Azure.AI.DocumentIntelligence` 1.0.0-beta.1. As a workaround you will need to use a URI input or the new Base64 input option, which is described later in this guide ([Analyzing and classifying documents from a stream](#analyzing-and-classifying-documents-from-a-stream)).
- `ClassifyDocumentFromUri` has been renamed to `ClassifyDocument` and its input arguments have been reorganized. The `documentUri` parameter has been removed. Instead, a `ClassifyDocumentContent` object must be passed to the method to select the desired input type: URI or Base64 binary data.

Classifying documents with `Azure.AI.FormRecognizer`:
```C#
string classifierId = "<classifierId>";
Uri fileUri = new Uri("<fileUri>");

ClassifyDocumentOperation operation = await client.ClassifyDocumentFromUriAsync(WaitUntil.Completed, classifierId, fileUri);
AnalyzeResult result = operation.Value;

Console.WriteLine($"Document was classified by classifier with ID: {result.ModelId}");

foreach (AnalyzedDocument document in result.Documents)
{
    Console.WriteLine($"Document of type: {document.DocumentType}");
}
```

Classifying documents with `Azure.AI.DocumentIntelligence`:
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

### Building a document model

Differences between the versions:
- Parameters `trainingDataSource`, `buildMode`, `modelId`, and `options` have been removed. The method now takes a `buildRequest` parameter of type `BuildDocumentModelContent` containing all the removed options.
- After creating a `BuildDocumentModelContent` instance, either property `AzureBlobSource` or `AzureBlobFileListSource` must be set depending on your data source.

Building a document model with `Azure.AI.FormRecognizer`:
```C#
Uri blobContainerUri = new Uri("<blobContainerUri>");
var client = new DocumentModelAdministrationClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

BuildDocumentModelOperation operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, blobContainerUri, DocumentBuildMode.Template);
DocumentModelDetails model = operation.Value;

Console.WriteLine($"  Model Id: {model.ModelId}");
Console.WriteLine($"  Created on: {model.CreatedOn}");

Console.WriteLine("  Document types the model can recognize:");
foreach (KeyValuePair<string, DocumentTypeDetails> documentType in model.DocumentTypes)
{
    Console.WriteLine($"    Document type: {documentType.Key} which has the following fields:");
    foreach (KeyValuePair<string, DocumentFieldSchema> schema in documentType.Value.FieldSchema)
    {
        Console.WriteLine($"    Field: {schema.Key} with confidence {documentType.Value.FieldConfidence[schema.Key]}");
    }
}
```

Building a document model with `Azure.AI.DocumentIntelligence`:
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

## Missing features

### Analyzing and classifying documents from a stream

Currently neither `AnalyzeDocument` nor `ClassifyDocument` support submitting a document from a `Stream` input. As a temporary workaround, you can make use of the new Base64 input option. The following example illustrates how to submit a local file for analysis:

```C# Snippet:DocumentIntelligenceAnalyzeWithPrebuiltModelWithBase64Async
string filePath = "<filePath>";
byte[] fileBytes = File.ReadAllBytes(filePath);

var content = new AnalyzeDocumentContent()
{
    Base64Source = BinaryData.FromBytes(fileBytes)
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

### Extracting words from a line

Currently the `DocumentLine.GetWords` method is not supported. As a temporary workaround, you can add the following implementation to your code:

```C# Snippet:Migration_DocumentIntelligenceGetWords
private IReadOnlyList<DocumentWord> GetWords(DocumentLine line, DocumentPage containingPage)
{
    var words = new List<DocumentWord>();

    foreach (DocumentWord word in containingPage.Words)
    {
        DocumentSpan wordSpan = word.Span;

        foreach (DocumentSpan lineSpan in line.Spans)
        {
            if (wordSpan.Offset >= lineSpan.Offset
                && wordSpan.Offset + wordSpan.Length <= lineSpan.Offset + lineSpan.Length)
            {
                words.Add(word);
            }
        }
    }

    return words;
}
```

Note that it's necessary to pass the `DocumentPage` containing the line to the method. The method above can be used as follows:

```C# Snippet:Migration_DocumentIntelligenceGetWordsUsage
Uri uriSource = new Uri("<uriSource>");

var content = new AnalyzeDocumentContent()
{
    UrlSource = uriSource
};

Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-invoice", content);
AnalyzeResult result = operation.Value;

DocumentPage firstPage = result.Pages[0];

foreach (DocumentLine line in firstPage.Lines)
{
    IReadOnlyList<DocumentWord> words = GetWords(line, firstPage);

    Console.WriteLine(line.Content);
    Console.WriteLine("The line above contains the following words:");

    foreach (DocumentWord word in words)
    {
        Console.WriteLine($"  {word.Content}");
    }
}
```

### Accessing an existing long-running operation

Storing the ID of a long-running operation to retrieve its status at a later point in time is still not supported in `Azure.AI.DocumentIntelligence` 1.0.0-beta.1. There are no straightforward workarounds to support this scenario.

## Additional samples

For additional samples please take a look at the [Document Intelligence Samples][samples_readme] for more guidance.

[readme]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/README.md
[changelog]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/CHANGELOG.md
[samples_readme]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/README.md
