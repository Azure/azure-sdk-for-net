# Guide for migrating Azure.AI.FormRecognizer to version 4.0.x from versions 3.1.x and below

This guide is intended to assist in the migration to `Azure.AI.FormRecognizer (4.0.x)` from versions `3.1.x` and below. It will focus on side-by-side comparisons for similar operations between versions. Please note that version `4.0.0-beta.1` will be used for comparison with `3.1.1`.

Familiarity with `Azure.AI.FormRecognizer (3.1.x and below)` package is assumed. For those new to the Azure Form Recognizer client library for .NET please refer to the [README][readme] rather than this guide.

## Table of Contents
- [Migration benefits](#migration-benefits)
- [Important changes](#important-changes)
    - [Terminology](#terminology)
    - [Client usage](#client-usage)
    - [Analyzing documents](#analyzing-documents)
    - [Training a custom model](#training-a-custom-model)
    - [Analyzing a document with a custom model](#analyzing-a-document-with-a-custom-model)
    - [Managing models](#managing-models)
- [Additional samples](#additional-samples)

## Migration benefits

A natural question to ask when considering whether to adopt a new version of the library is what the benefits of doing so would be. As Azure Form Recognizer has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and add value to our customers.

There are many benefits to using the new design of the `Azure.AI.FormRecognizer (4.0.x)` library. This new version of the library introduces two new clients `DocumentAnalysisClient` and the `DocumentModelAdministrationClient` with unified methods for analyzing documents and provides support for the new features added by the service in API version `2021-09-30-preview` and later.

New features provided by the `DocumentAnalysisClient` include:
- One consolidated method for analyzing document layout, a general prebuilt document model type, along with the same prebuilt models that were included previously (receipts, invoices, business cards, ID documents), and custom models.
- Models introduced in the latest version of the library, such as `AnalyzeResult`, remove hierarchical dependencies between document elements and move them to a more top level and easily accessible position.
- The Form Recognizer service has further improved how to define where elements are located on documents by moving towards `BoundingRegion` definitions allowing for cross-page elements.
- Document element fields are returned with more information, such as content and spans. 

New features provided by the `DocumentModelAdministrationClient` include:
- Users can now assign their own model IDs and specify a description when building, composing, or copying models.
- Listing models now includes both prebuilt and custom models.
- When using `GetModel()`, users can get the field schema (field names and types that the model can extract) for the model they specified, including for prebuilt models. 
- Ability to get information from model operations that occurred in the last 24 hours.

The table below describes the relationship of each client and its supported API version(s):

|API version|Supported clients
|-|-
|2021-09-30-preview | DocumentAnalysisClient and DocumentModelAdministrationClient
|2.1 | FormRecognizerClient and FormTrainingClient
|2.0 | FormRecognizerClient and FormTrainingClient

Please refer to the [README][readme] for more information on these new clients.

## Important changes

### Terminology
Some terminology has changed to reflect the enhanced capabilities of the newest Form Recognizer service APIs. While the service is still called "Form Recognizer," it is capable of much more than simple recognition,
and is not limited to documents that are "forms". As a result, we've made the following broad changes to the terminology used throughout the SDK:

- The word `Document` has broadly replaced the word `Form`. The service supports a wide variety of documents and data-extraction scenarios, not merely limited to `forms`.
- The word `Analyze` has broadly replaced the word `Recognize`. The document analysis operation executes a data extraction pipeline that supports more than just recognition.
- Distinctions between `custom` and `prebuilt` models have broadly been eliminated. Prebuilt models are simply models that were created by the Form Recognizer service team and that exist within every Form Recognizer resource.
- The concept of `model training` has broadly been replaced with `model creation` or `model administration` (whatever is most appropriate in context), as not all model creation operations involve `training` a model from a data set. When referring to a model schema trained from a data set, we will use the term `document type` instead.

### Client usage

We continue to support API key and AAD authentication methods when creating the clients. Below are the differences between the two versions:

- In `4.0.x`, we have added `DocumentAnalysisClient` and `DocumentModelAdministrationClient` which support API version `2021-09-30-preview` and later.
- `FormRecognizerClient` and `FormTrainingClient` will continue to work targetting API version `2.1` and `2.0`. 
- In `DocumentAnalysisClient` all prebuilt model methods along with custom model, layout, and a prebuilt general document analysis model are unified into two methods called
`StartAnalyzeDocument` and `StartAnalyzeDocumentFromUri`.
- In `FormRecognizerClient` there are two methods (a stream and Uri method) for each of the prebuilt models supported by the service. This results in two methods for business card, receipt, identity document, and invoice models, along with a pair of methods for recognizing custom documents and for recognizing content/layout. 

Creating new clients in `3.1.x`:
```C# Snippet:CreateFormRecognizerClients
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);

var formRecognizerClient = new FormRecognizerClient(new Uri(endpoint), credential);
var formTrainingClient = new FormTrainingClient(new Uri(endpoint), credential);
```

Creating new clients in `4.0.x`:
```C# Snippet:CreateDocumentAnalysisClients
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var credential = new AzureKeyCredential(apiKey);

var documentAnalysisClient = new DocumentAnalysisClient(new Uri(endpoint), credential);
var documentModelAdministrationClient = new DocumentModelAdministrationClient(new Uri(endpoint), credential);
```

### Analyzing documents

Differences between the versions:
- `StartAnalyzeDocument` and `StartAnalyzeDocumentFromUri` accept a string with the desired model ID for analysis. The model ID can be any of the prebuilt model IDs or a custom model ID.
- Along with more consolidated analysis methods in the `DocumentAnalysisClient`, the return types have also been improved and remove the hierarchical dependencies between elements. An instance of the `AnalyzeResult` model is now returned which showcases important document elements, such as key-value pairs, entities, tables, and document fields and values, among others, at the top level of the returned model. This can be contrasted with `RecognizedForm` which included more hierarchical relationships, for instance tables were an element of a `FormPage` and not a top-level element.
- In the new version of the library, the functionality of `StartRecognizeContent` has been added as a prebuilt model and can be called in library version `Azure.AI.FormRecognizer (4.0.x)` with `StartAnalyzeDocument` by passing in the `prebuilt-layout` model ID. Similarly, to get general document information, such as key-value pairs, entities, and text layout, the `prebuilt-document` model ID can be used with `StartAnalyzeDocument`.
- When calling `StartAnalyzeDocument` and `StartAnalyzeDocumentFromUri` the returned type is an `AnalyzeResult` object, while the various methods used with `FormRecognizerClient` return a list of `RecognizedForm`.
- The optional `IncludeFieldElements` parameter is not supported with the `DocumentAnalysisClient`. Text details are automatically included with API version `2021-09-30-preview` and later.
- The optional `ReadingOrder` parameter does not exist on `StartAnalyzeDocument` and `StartAnalyzeDocumentFromUri`. The service uses `natural` reading order to return data.

Analyzing prebuilt models like business cards, identity documents, invoices, and receipts with `3.1.x`:
```C# Snippet:FormRecognizerSampleRecognizeInvoicesUri
    Uri invoiceUri = <invoiceUri>;
    var options = new RecognizeInvoicesOptions() { Locale = "en-US" };

    RecognizeInvoicesOperation operation = await client.StartRecognizeInvoicesFromUriAsync(invoiceUri, options);
    Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
    RecognizedFormCollection invoices = operationResponse.Value;

    // To see the list of all the supported fields returned by service and its corresponding types, consult:
    // https://aka.ms/formrecognizer/invoicefields

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
}
```

Analyzing prebuilt models like business cards, identity documents, invoices, and receipts with `4.0.x`:
```C# Snippet:FormRecognizerAnalyzeWithPrebuiltModelFromUriAsync
string fileUri = "<fileUri>";

AnalyzeDocumentOperation operation = await client.StartAnalyzeDocumentFromUriAsync("prebuilt-invoice", fileUri);

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

Analyzing document content with `3.1.x`:

> NOTE: With version `3.1.x` of the library this method had an optional `Language` parameter to hint at the language for the document, whereas in version `4.0.x` of the library `Locale` is used for this purpose.

```C# Snippet:FormRecognizerSampleRecognizeContentFromUri
Uri formUri = <formUri>;

Response<FormPageCollection> response = await client.StartRecognizeContentFromUriAsync(formUri).WaitForCompletionAsync();
FormPageCollection formPages = response.Value;

foreach (FormPage page in formPages)
{
    Console.WriteLine($"Form Page {page.PageNumber} has {page.Lines.Count} lines.");

    for (int i = 0; i < page.Lines.Count; i++)
    {
        FormLine line = page.Lines[i];
        Console.WriteLine($"  Line {i} has {line.Words.Count} {(line.Words.Count == 1 ? "word" : "words")}, and text: '{line.Text}'.");

        if (line.Appearance != null)
        {
            // Check the style and style confidence to see if text is handwritten.
            // Note that value '0.8' is used as an example.
            if (line.Appearance.Style.Name == TextStyleName.Handwriting && line.Appearance.Style.Confidence > 0.8)
            {
                Console.WriteLine("The text is handwritten");
            }
        }

        Console.WriteLine("    Its bounding box is:");
        Console.WriteLine($"    Upper left => X: {line.BoundingBox[0].X}, Y= {line.BoundingBox[0].Y}");
        Console.WriteLine($"    Upper right => X: {line.BoundingBox[1].X}, Y= {line.BoundingBox[1].Y}");
        Console.WriteLine($"    Lower right => X: {line.BoundingBox[2].X}, Y= {line.BoundingBox[2].Y}");
        Console.WriteLine($"    Lower left => X: {line.BoundingBox[3].X}, Y= {line.BoundingBox[3].Y}");
    }

    for (int i = 0; i < page.Tables.Count; i++)
    {
        FormTable table = page.Tables[i];
        Console.WriteLine($"  Table {i} has {table.RowCount} rows and {table.ColumnCount} columns.");
        foreach (FormTableCell cell in table.Cells)
        {
            Console.WriteLine($"    Cell ({cell.RowIndex}, {cell.ColumnIndex}) contains text: '{cell.Text}'.");
        }
    }

    for (int i = 0; i < page.SelectionMarks.Count; i++)
    {
        FormSelectionMark selectionMark = page.SelectionMarks[i];
        Console.WriteLine($"  Selection Mark {i} is {selectionMark.State}.");
        Console.WriteLine("    Its bounding box is:");
        Console.WriteLine($"      Upper left => X: {selectionMark.BoundingBox[0].X}, Y= {selectionMark.BoundingBox[0].Y}");
        Console.WriteLine($"      Upper right => X: {selectionMark.BoundingBox[1].X}, Y= {selectionMark.BoundingBox[1].Y}");
        Console.WriteLine($"      Lower right => X: {selectionMark.BoundingBox[2].X}, Y= {selectionMark.BoundingBox[2].Y}");
        Console.WriteLine($"      Lower left => X: {selectionMark.BoundingBox[3].X}, Y= {selectionMark.BoundingBox[3].Y}");
    }
}
```

Analyzing document layout with `4.0.x`:
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

Analyzing general prebuilt document types with `4.0.x`:

> NOTE: Analyzing a document with the `prebuilt-document` model replaces training without labels in version `3.1.x` of the library.

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

> NOTE: All of these samples also work with `StartAnalyzeDocument` when providing a document Stream.

### Training a custom model

Differences between the versions:
- Files for building a new model for version `4.0.x` can be created using the labeling tool found [here][fr_labeling_tool].
- In version `3.1.x` the `useTrainingLabels` parameter was used to indicate whether to use labeled data when creating the custom model.
- In version `4.0.x` the `useTrainingLabels` parameter is not supported since training must be carried out with labeled training documents. Additionally train without labels is now replaced with the prebuilt model `prebuilt-document` which extracts entities, key-value pairs, and layout from a document. 

Train a custom model with `3.1.x`:
```C# Snippet:FormRecognizerSampleTrainModelWithFormsAndLabels
// For this sample, you can use the training forms found in the `trainingFiles` folder.
// Upload the forms to your storage container and then generate a container SAS URL.
// For instructions to set up forms for training in an Azure Storage Blob Container, please see:
// https://docs.microsoft.com/azure/cognitive-services/form-recognizer/build-training-data-set#upload-your-training-data

// For instructions to create a label file for your training forms, please see:
// https://docs.microsoft.com/azure/cognitive-services/form-recognizer/label-tool?tabs=v2-1

Uri trainingFileUri = <trainingFileUri>;
string modelName = "My Model with labels";
FormTrainingClient client = new FormTrainingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

TrainingOperation operation = await client.StartTrainingAsync(trainingFileUri, useTrainingLabels: true, modelName);
Response<CustomFormModel> operationResponse = await operation.WaitForCompletionAsync();
CustomFormModel model = operationResponse.Value;

Console.WriteLine($"Custom Model Info:");
Console.WriteLine($"  Model Id: {model.ModelId}");
Console.WriteLine($"  Model name: {model.ModelName}");
Console.WriteLine($"  Model Status: {model.Status}");
Console.WriteLine($"  Is composed model: {model.Properties.IsComposedModel}");
Console.WriteLine($"  Training model started on: {model.TrainingStartedOn}");
Console.WriteLine($"  Training model completed on: {model.TrainingCompletedOn}");

foreach (CustomFormSubmodel submodel in model.Submodels)
{
    Console.WriteLine($"Submodel Form Type: {submodel.FormType}");
    foreach (CustomFormModelField field in submodel.Fields.Values)
    {
        Console.Write($"  FieldName: {field.Name}");
        if (field.Accuracy != null)
        {
            Console.Write($", Accuracy: {field.Accuracy}");
        }
        Console.WriteLine("");
    }
}
```

Train a custom model with `4.0.x`:
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

### Analyzing a document with a custom model

Differences between the versions:
- Analyzing a custom model with `DocumentAnalysisClient` uses the general `StartAnalyzeDocument` and `StartAnalyzeDocumentFromUri` methods.
- In order to analyze a custom model with `FormRecognizerClient` the `StartRecognizeCustomModels` and its corresponding Uri methods are used.
- The `IncludeFieldElements` keyword argument is not supported with the `DocumentAnalysisClient`, text details are automatically included with API version `2021-09-30-preview` and later.

Analyze a document using a custom model with `3.1.x`:
```C# Snippet:FormRecognizerSampleRecognizeCustomFormsFromUri
string modelId = "<modelId>";
Uri formUri = <formUri>;
var options = new RecognizeCustomFormsOptions() { IncludeFieldElements = true };

RecognizeCustomFormsOperation operation = await client.StartRecognizeCustomFormsFromUriAsync(modelId, formUri, options);
Response<RecognizedFormCollection> operationResponse = await operation.WaitForCompletionAsync();
RecognizedFormCollection forms = operationResponse.Value;

foreach (RecognizedForm form in forms)
{
    Console.WriteLine($"Form of type: {form.FormType}");
    if (form.FormTypeConfidence.HasValue)
        Console.WriteLine($"Form type confidence: {form.FormTypeConfidence.Value}");
    Console.WriteLine($"Form was analyzed with model with ID: {form.ModelId}");
    foreach (FormField field in form.Fields.Values)
    {
        Console.WriteLine($"Field '{field.Name}': ");

        if (field.LabelData != null)
        {
            Console.WriteLine($"  Label: '{field.LabelData.Text}'");
        }

        Console.WriteLine($"  Value: '{field.ValueData.Text}'");
        Console.WriteLine($"  Confidence: '{field.Confidence}'");
    }

    // Iterate over tables, lines, and selection marks on each page
    foreach (var page in form.Pages)
    {
        for (int i = 0; i < page.Tables.Count; i++)
        {
            Console.WriteLine($"Table {i + 1} on page {page.Tables[i].PageNumber}");
            foreach (var cell in page.Tables[i].Cells)
            {
                Console.WriteLine($"  Cell[{cell.RowIndex}][{cell.ColumnIndex}] has text '{cell.Text}' with confidence {cell.Confidence}");
            }
        }
        Console.WriteLine($"Lines found on page {page.PageNumber}");
        foreach (var line in page.Lines)
        {
            Console.WriteLine($"  Line {line.Text}");
        }

        if (page.SelectionMarks.Count != 0)
        {
            Console.WriteLine($"Selection marks found on page {page.PageNumber}");
            foreach (var selectionMark in page.SelectionMarks)
            {
                Console.WriteLine($"  Selection mark is '{selectionMark.State}' with confidence {selectionMark.Confidence}");
            }
        }
    }
}
```

Analyze a document using a custom model with `4.0.x`:
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

### Managing models

Differences between the versions:
- When using API version `2021-09-30-preview` and later models no longer include submodels, instead a model can analyze different document types.
- When building, composing, or copying models users can now assign their own model IDs and specify a description.
- In version `4.0.x` of the library, only models that build successfully can be retrieved from the get and list model calls. Unsuccessful model operations can be viewed with the `GetOperation()` and `GetOperations()` methods (note that document model operation data persists for only 24 hours). In version `3.1.x` of the library, models that had not succeeded were still created, had to be deleted by the user, and were returned in the `GetCustomModels()` response.

## Additional samples

For additional samples please take a look at the [Form Recognizer Samples][samples_readme] for more guidance.

[readme]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/README.md
[samples_readme]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/formrecognizer/Azure.AI.FormRecognizer/samples/README.md
[fr_labeling_tool]: https://aka.ms/azsdk/formrecognizer/labelingtool