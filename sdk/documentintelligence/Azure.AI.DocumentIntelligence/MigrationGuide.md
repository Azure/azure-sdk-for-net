# Guide for migrating to Azure.AI.DocumentIntelligence from Azure.AI.FormRecognizer

This guide is intended to assist in the migration to `Azure.AI.DocumentIntelligence (1.0.0)` from `Azure.AI.FormRecognizer (4.1.0 or 4.0.0)`. It will focus on side-by-side comparisons for similar operations between libraries. Please note that version `1.0.0` will be used for comparison with `4.1.0`.

Familiarity with the `Azure.AI.FormRecognizer` package is assumed. For those new to the Document Intelligence and the Form Recognizer client libraries for .NET, please refer to the [README][readme] rather than this guide.

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

There are many benefits to using the new `Azure.AI.DocumentIntelligence` library. This new library introduces two new clients: `DocumentIntelligenceClient` and `DocumentIntelligenceAdministrationClient`, providing support for the new features added by the service in API version `2024-11-30` and higher.

New features provided by the `Azure.AI.DocumentIntelligence` library include:
- **Markdown content format:** support to output with Markdown content format along with the default plain text. This is only supported for the "prebuilt-layout" model. Markdown content format is deemed a more friendly format for LLM consumption in a chat or automation use scenario.
- **Query fields:** query fields are reintroduced as a premium add-on feature. When the `DocumentAnalysisFeature.QueryFields` argument is passed to a document analysis request, the service will further extract the values of the fields specified via the option `QueryFields` to supplement any existing fields defined by the model as fallback.
- **Split options:** in previous API versions, the document splitting and classification operation always tried to split the input file into multiple documents. To enable a wider set of scenarios, `ClassifyDocument` now supports a `Split` option. The following values are supported:
  - `Auto`: let the service determine where to split.
  - `None`: the entire file is treated as a single document. No splitting is performed.
  - `PerPage`: each page is treated as a separate document. Each empty page is kept as its own document.
- **Batch analysis:** allows you to bulk process multiple documents using a single request. Rather than having to submit documents individually, you can analyze a collection of documents like invoices, a series of a loan documents, or a group of custom documents simultaneously.

The table below describes the relationship of each client and its supported API version(s):

Package|API version|Supported clients
|-|-|-
|Azure.AI.DocumentIntelligence | 2024-11-30 | DocumentIntelligenceClient and DocumentIntelligenceAdministrationClient
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
- The type `DocumentIntelligenceClientOptions` has replaced `DocumentAnalysisClientOptions`.
- The type `DocumentIntelligenceModelFactory` has replaced `DocumentAnalysisModelFactory`.

### Client usage

In `Azure.AI.DocumentIntelligence`, we have `DocumentIntelligenceClient` and `DocumentIntelligenceAdministrationClient` which can only be used with API version `2024-11-30` and higher. We continue to support Microsoft Entra ID and API key authentication methods when creating the clients:

Creating new clients in `Azure.AI.FormRecognizer`:
```C#
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();

var documentAnalysisClient = new DocumentAnalysisClient(new Uri(endpoint), credential);
var documentModelAdministrationClient = new DocumentModelAdministrationClient(new Uri(endpoint), credential);
```

Creating new clients in `Azure.AI.DocumentIntelligence`:
```C# Snippet:Migration_CreateBothDocumentIntelligenceClients
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();

var documentIntelligenceClient = new DocumentIntelligenceClient(new Uri(endpoint), credential);
var documentIntelligenceAdministrationClient = new DocumentIntelligenceAdministrationClient(new Uri(endpoint), credential);
```

### Analyzing documents

Differences between the versions:
- The former `AnalyzeDocument` method taking a `Stream` as the input document is still not supported in `Azure.AI.DocumentIntelligence` 1.0.0. As a workaround you will need to use a URI input or the new binary data input option, which is described later in this guide ([Analyzing and classifying documents from a stream](#analyzing-and-classifying-documents-from-a-stream)).
- `AnalyzeDocumentFromUri` has been renamed to `AnalyzeDocument`.
  - The `modelId` and the `documentUri` parameters have been moved into `AnalyzeDocumentOptions`, which is now required. The desired input type must be selected when creating the options object: URI or binary data.
- Overloads of `AnalyzeDocument` have been added to support simpler scenarios without creating an `AnalyzeDocumentOptions` object.
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
Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-invoice", uriSource);
AnalyzeResult result = operation.Value;

// To see the list of all the supported fields returned by service and its corresponding types for the
// prebuilt-invoice model, see:
// https://aka.ms/azsdk/formrecognizer/invoicefieldschema

for (int i = 0; i < result.Documents.Count; i++)
{
    Console.WriteLine($"Document {i}:");

    AnalyzedDocument document = result.Documents[i];

    if (document.Fields.TryGetValue("VendorName", out DocumentField vendorNameField)
        && vendorNameField.FieldType == DocumentFieldType.String)
    {
        string vendorName = vendorNameField.ValueString;
        Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
    }

    if (document.Fields.TryGetValue("CustomerName", out DocumentField customerNameField)
        && customerNameField.FieldType == DocumentFieldType.String)
    {
        string customerName = customerNameField.ValueString;
        Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
    }

    if (document.Fields.TryGetValue("Items", out DocumentField itemsField)
        && itemsField.FieldType == DocumentFieldType.List)
    {
        foreach (DocumentField itemField in itemsField.ValueList)
        {
            Console.WriteLine("Item:");

            if (itemField.FieldType == DocumentFieldType.Dictionary)
            {
                IReadOnlyDictionary<string, DocumentField> itemFields = itemField.ValueDictionary;

                if (itemFields.TryGetValue("Description", out DocumentField itemDescriptionField)
                    && itemDescriptionField.FieldType == DocumentFieldType.String)
                {
                    string itemDescription = itemDescriptionField.ValueString;
                    Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                }

                if (itemFields.TryGetValue("Amount", out DocumentField itemAmountField)
                    && itemAmountField.FieldType == DocumentFieldType.Currency)
                {
                    CurrencyValue itemAmount = itemAmountField.ValueCurrency;
                    Console.WriteLine($"  Amount: '{itemAmount.CurrencySymbol}{itemAmount.Amount}', with confidence {itemAmountField.Confidence}");
                }
            }
        }
    }

    if (document.Fields.TryGetValue("SubTotal", out DocumentField subTotalField)
        && subTotalField.FieldType == DocumentFieldType.Currency)
    {
        CurrencyValue subTotal = subTotalField.ValueCurrency;
        Console.WriteLine($"Sub Total: '{subTotal.CurrencySymbol}{subTotal.Amount}', with confidence {subTotalField.Confidence}");
    }

    if (document.Fields.TryGetValue("TotalTax", out DocumentField totalTaxField)
        && totalTaxField.FieldType == DocumentFieldType.Currency)
    {
        CurrencyValue totalTax = totalTaxField.ValueCurrency;
        Console.WriteLine($"Total Tax: '{totalTax.CurrencySymbol}{totalTax.Amount}', with confidence {totalTaxField.Confidence}");
    }

    if (document.Fields.TryGetValue("InvoiceTotal", out DocumentField invoiceTotalField)
        && invoiceTotalField.FieldType == DocumentFieldType.Currency)
    {
        CurrencyValue invoiceTotal = invoiceTotalField.ValueCurrency;
        Console.WriteLine($"Invoice Total: '{invoiceTotal.CurrencySymbol}{invoiceTotal.Amount}', with confidence {invoiceTotalField.Confidence}");
    }
}
```

### Classifying documents

Differences between the versions:
- The former `ClassifyDocument` method taking a `Stream` as the input document is still not supported in `Azure.AI.DocumentIntelligence` 1.0.0. As a workaround you will need to use a URI input or the new binary data input option, which is described later in this guide ([Analyzing and classifying documents from a stream](#analyzing-and-classifying-documents-from-a-stream)).
- `ClassifyDocumentFromUri` has been renamed to `ClassifyDocument`:
  - The `classifierId` and the `documentUri` parameters have been moved into a new `ClassifyDocumentOptions` property bag. The desired input type must be selected when creating the options object: URI or binary data.

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

var options = new ClassifyDocumentOptions(classifierId, uriSource);

Operation<AnalyzeResult> operation = await client.ClassifyDocumentAsync(WaitUntil.Completed, options);
AnalyzeResult result = operation.Value;

Console.WriteLine($"Input was classified by the classifier with ID '{result.ModelId}'.");

foreach (AnalyzedDocument document in result.Documents)
{
    Console.WriteLine($"Found a document of type: {document.DocumentType}");
}
```

### Building a document model

Differences between the versions:
- Parameters `trainingDataSource`, `buildMode`, `modelId` have moved into `BuildDocumentModelOptions`, which is now required.
- When creating a `BuildDocumentModelOptions` instance, either property `BlobSource` or `BlobFileListSource` must be set depending on your data source.

Building a document model with `Azure.AI.FormRecognizer`:
```C#
Uri blobContainerUri = new Uri("<blobContainerUri>");
var client = new DocumentModelAdministrationClient(new Uri(endpoint), new DefaultAzureCredential());

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

var blobSource = new BlobContentSource(blobContainerUri);
var options = new BuildDocumentModelOptions(modelId, DocumentBuildMode.Template, blobSource);

Operation<DocumentModelDetails> operation = await client.BuildDocumentModelAsync(WaitUntil.Completed, options);
DocumentModelDetails model = operation.Value;

Console.WriteLine($"Model ID: {model.ModelId}");
Console.WriteLine($"Created on: {model.CreatedOn}");

Console.WriteLine("Document types the model can recognize:");
foreach (KeyValuePair<string, DocumentTypeDetails> docType in model.DocumentTypes)
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

Currently neither `AnalyzeDocument` nor `ClassifyDocument` support submitting a document from a `Stream` input. As a temporary workaround, you can make use of the new binary data input option. The following example illustrates how to submit a local file for analysis:

```C# Snippet:DocumentIntelligenceAnalyzeWithPrebuiltModelFromBytesAsync
string filePath = "<filePath>";
byte[] fileBytes = File.ReadAllBytes(filePath);

BinaryData bytesSource = BinaryData.FromBytes(fileBytes);
Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, "prebuilt-invoice", bytesSource);
AnalyzeResult result = operation.Value;

// To see the list of all the supported fields returned by service and its corresponding types for the
// prebuilt-invoice model, see:
// https://aka.ms/azsdk/formrecognizer/invoicefieldschema

for (int i = 0; i < result.Documents.Count; i++)
{
    Console.WriteLine($"Document {i}:");

    AnalyzedDocument document = result.Documents[i];

    if (document.Fields.TryGetValue("VendorName", out DocumentField vendorNameField)
        && vendorNameField.FieldType == DocumentFieldType.String)
    {
        string vendorName = vendorNameField.ValueString;
        Console.WriteLine($"Vendor Name: '{vendorName}', with confidence {vendorNameField.Confidence}");
    }

    if (document.Fields.TryGetValue("CustomerName", out DocumentField customerNameField)
        && customerNameField.FieldType == DocumentFieldType.String)
    {
        string customerName = customerNameField.ValueString;
        Console.WriteLine($"Customer Name: '{customerName}', with confidence {customerNameField.Confidence}");
    }

    if (document.Fields.TryGetValue("Items", out DocumentField itemsField)
        && itemsField.FieldType == DocumentFieldType.List)
    {
        foreach (DocumentField itemField in itemsField.ValueList)
        {
            Console.WriteLine("Item:");

            if (itemField.FieldType == DocumentFieldType.Dictionary)
            {
                IReadOnlyDictionary<string, DocumentField> itemFields = itemField.ValueDictionary;

                if (itemFields.TryGetValue("Description", out DocumentField itemDescriptionField)
                    && itemDescriptionField.FieldType == DocumentFieldType.String)
                {
                    string itemDescription = itemDescriptionField.ValueString;
                    Console.WriteLine($"  Description: '{itemDescription}', with confidence {itemDescriptionField.Confidence}");
                }

                if (itemFields.TryGetValue("Amount", out DocumentField itemAmountField)
                    && itemAmountField.FieldType == DocumentFieldType.Currency)
                {
                    CurrencyValue itemAmount = itemAmountField.ValueCurrency;
                    Console.WriteLine($"  Amount: '{itemAmount.CurrencySymbol}{itemAmount.Amount}', with confidence {itemAmountField.Confidence}");
                }
            }
        }
    }

    if (document.Fields.TryGetValue("SubTotal", out DocumentField subTotalField)
        && subTotalField.FieldType == DocumentFieldType.Currency)
    {
        CurrencyValue subTotal = subTotalField.ValueCurrency;
        Console.WriteLine($"Sub Total: '{subTotal.CurrencySymbol}{subTotal.Amount}', with confidence {subTotalField.Confidence}");
    }

    if (document.Fields.TryGetValue("TotalTax", out DocumentField totalTaxField)
        && totalTaxField.FieldType == DocumentFieldType.Currency)
    {
        CurrencyValue totalTax = totalTaxField.ValueCurrency;
        Console.WriteLine($"Total Tax: '{totalTax.CurrencySymbol}{totalTax.Amount}', with confidence {totalTaxField.Confidence}");
    }

    if (document.Fields.TryGetValue("InvoiceTotal", out DocumentField invoiceTotalField)
        && invoiceTotalField.FieldType == DocumentFieldType.Currency)
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

var options = new AnalyzeDocumentOptions("prebuilt-invoice", uriSource);

Operation<AnalyzeResult> operation = await client.AnalyzeDocumentAsync(WaitUntil.Completed, options);
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

With the exception of the new batch analysis API, storing the ID of a long-running operation to retrieve its status at a later point in time is still not supported in `Azure.AI.DocumentIntelligence` 1.0.0. There are no straightforward workarounds to support this scenario.

## Additional samples

For additional samples please take a look at the [Document Intelligence Samples][samples_readme] for more guidance.

[readme]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/README.md
[changelog]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/CHANGELOG.md
[samples_readme]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/documentintelligence/Azure.AI.DocumentIntelligence/samples/README.md
