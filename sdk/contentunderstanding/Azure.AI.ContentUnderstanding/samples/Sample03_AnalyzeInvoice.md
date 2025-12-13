# Analyze an invoice using prebuilt analyzer

This sample demonstrates how to analyze an invoice from a URL using the `prebuilt-invoice` analyzer and extract structured fields from the result.

## About analyzing invoices

Content Understanding provides a rich set of prebuilt analyzers that are ready to use without any configuration. These analyzers are powered by knowledge bases of thousands of real-world document examples, enabling them to understand document structure and adapt to variations in format and content.

Prebuilt analyzers are ideal for:
- **Content ingestion** in search and retrieval-augmented generation (RAG) workflows
- **Intelligent document processing (IDP)** to extract structured data from common document types
- **Agentic flows** as tools for extracting structured representations from input files

### The `prebuilt-invoice` analyzer

The `prebuilt-invoice` analyzer is a domain-specific analyzer optimized for processing invoices, utility bills, sales orders, and purchase orders. It automatically extracts structured fields including:

- **Customer/Vendor information**: Name, address, contact details
- **Invoice metadata**: Invoice number, date, due date, purchase order number
- **Line items**: Description, quantity, unit price, total for each item
- **Financial totals**: Subtotal, tax amount, shipping charges, total amount
- **Payment information**: Payment terms, payment method, remittance address

The analyzer works out of the box with various invoice formats and requires no configuration. It's part of the **financial documents** category of prebuilt analyzers, which also includes:
- `prebuilt-receipt` - Sales receipts from retail and dining establishments
- `prebuilt-creditCard` - Credit card statements
- `prebuilt-bankStatement.us` - US bank statements
- `prebuilt-check.us` - US bank checks
- `prebuilt-creditMemo` - Credit memos and refund documents

For a complete list of available prebuilt analyzers, see the [Prebuilt analyzers documentation][prebuilt-analyzers-docs].

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

## Creating a `ContentUnderstandingClient`

For full client setup details, see [Sample 00: Configure model deployment defaults][sample00]. Quick reference snippets are below—pick the one that matches the authentication method you plan to use.

```C# Snippet:CreateContentUnderstandingClient
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

```C# Snippet:CreateContentUnderstandingClientApiKey
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
string apiKey = "<apiKey>";
var client = new ContentUnderstandingClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
```

## Analyze invoice from URL

Analyze an invoice from a URL using the `prebuilt-invoice` analyzer:

```C# Snippet:ContentUnderstandingAnalyzeInvoice
// You can replace this URL with your own invoice file URL
Uri invoiceUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-dotnet/main/ContentUnderstanding.Common/data/invoice.pdf");
Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-invoice",
    inputs: new[] { new AnalyzeInput { Url = invoiceUrl } });

AnalyzeResult result = operation.Value;
```

## Extract invoice fields

The `prebuilt-invoice` analyzer returns **fields**, which are extracted structured data from the document. Fields can be accessed via `MediaContent.Fields`, which is an `IDictionary<string, ContentField>` where the key is the field name and the value is a `ContentField` object. Fields come in different types derived from `ContentField`:

- **Simple field types**: `StringField`, `NumberField`, `IntegerField`, `DateField`, `TimeField`, `BooleanField`, `JsonField`
- **Complex field types**: `ObjectField`, `ArrayField`

The following code snippet shows small examples of extracting some of the many fields available from a `prebuilt-invoice` result:

```C# Snippet:ContentUnderstandingExtractInvoiceFields
// Get the document content (invoices are documents)
DocumentContent documentContent = (DocumentContent)result.Contents!.First();

// Print document unit information
// The unit indicates the measurement system used for coordinates in the source field
Console.WriteLine($"Document unit: {documentContent.Unit ?? "unknown"}");
Console.WriteLine($"Pages: {documentContent.StartPageNumber} to {documentContent.EndPageNumber}");
if (documentContent.Pages != null && documentContent.Pages.Count > 0)
{
    var page = documentContent.Pages[0];
    var unit = documentContent.Unit?.ToString() ?? "units";
    Console.WriteLine($"Page dimensions: {page.Width} x {page.Height} {unit}");
}
Console.WriteLine();

// Extract simple string fields
var customerNameField = documentContent.Fields["CustomerName"];
Console.WriteLine($"Customer Name: {customerNameField.Value ?? "(None)"}");
Console.WriteLine($"  Confidence: {customerNameField.Confidence?.ToString("F2") ?? "N/A"}");
Console.WriteLine($"  Source: {customerNameField.Source ?? "N/A"}");
if (customerNameField.Spans?.Count > 0)
{
    var span = customerNameField.Spans[0];
    Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
}

// Extract simple date field
var invoiceDateField = documentContent.Fields.GetFieldOrDefault("InvoiceDate");
Console.WriteLine($"Invoice Date: {invoiceDateField?.Value ?? "(None)"}");
Console.WriteLine($"  Confidence: {invoiceDateField?.Confidence?.ToString("F2") ?? "N/A"}");
Console.WriteLine($"  Source: {invoiceDateField?.Source ?? "N/A"}");
if (invoiceDateField?.Spans?.Count > 0)
{
    var span = invoiceDateField.Spans[0];
    Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
}

// Extract object fields (nested structures)
if (documentContent.Fields.GetFieldOrDefault("TotalAmount") is ObjectField totalAmountObj)
{
    var amount = totalAmountObj.ValueObject?.GetFieldOrDefault("Amount")?.Value as double?;
    var currency = totalAmountObj.ValueObject?.GetFieldOrDefault("CurrencyCode")?.Value;
    Console.WriteLine($"Total: {currency ?? "$"}{amount?.ToString("F2") ?? "(None)"}");
    Console.WriteLine($"  Confidence: {totalAmountObj.Confidence?.ToString("F2") ?? "N/A"}");
    Console.WriteLine($"  Source: {totalAmountObj.Source ?? "N/A"}");
}

// Extract array fields (collections like line items)
if (documentContent.Fields.GetFieldOrDefault("LineItems") is ArrayField lineItems)
{
    Console.WriteLine($"Line Items ({lineItems.Count}):");
    for (int i = 0; i < lineItems.Count; i++)
    {
        if (lineItems[i] is ObjectField item)
        {
            var description = item.ValueObject?.GetFieldOrDefault("Description")?.Value;
            var quantity = item.ValueObject?.GetFieldOrDefault("Quantity")?.Value as double?;
            Console.WriteLine($"  Item {i + 1}: {description ?? "N/A"} (Qty: {quantity?.ToString() ?? "N/A"})");
            Console.WriteLine($"    Confidence: {item.Confidence?.ToString("F2") ?? "N/A"}");
        }
    }
}
```

## Understanding fields

### Field categories

Fields are organized into three categories that can be combined to form complex data structures:

- **Simple fields** - Single values of primitive types. Access values using type-specific properties:
  - `StringField.ValueString` - Returns `string` (non-nullable)
  - `NumberField.ValueNumber` - Returns `double?` (nullable)
  - `IntegerField.ValueInteger` - Returns `long?` (nullable)
  - `DateField.ValueDate` - Returns `DateTimeOffset?` (nullable, ISO 8601 YYYY-MM-DD format)
  - `TimeField.ValueTime` - Returns `TimeSpan?` (nullable, ISO 8601 hh:mm:ss format)
  - `BooleanField.ValueBoolean` - Returns `bool?` (nullable)
  - `JsonField.ValueJson` - Returns `BinaryData` (non-nullable)

  Alternatively, use the convenience property `ContentField.Value` which returns the value as an `object` (automatically converts to the appropriate type).
- **Object fields** - Nested structures containing multiple fields. Access nested fields via `ObjectField.ValueObject`, which returns `IDictionary<string, ContentField>` (non-nullable) where the key is the nested field name and the value is a `ContentField` object. The dictionary can contain any `ContentField`-derived classes, including simple fields (e.g., `StringField`, `NumberField`), object fields (`ObjectField`), or array fields (`ArrayField`), allowing for arbitrarily nested and complex data structures. Use `GetFieldOrDefault()` or the indexer to retrieve individual nested fields (see sample code below).
- **Array fields** - Collections of fields (can contain simple fields, object fields, or other arrays). Access elements via `ArrayField.ValueArray`, which returns `IList<ContentField>` (non-nullable). Alternatively, use the convenience `Count` property (returns `int`) and indexer `[i]` (returns `ContentField`) to access elements. Each element can be cast to the appropriate field type.

### Accessing field values

For **simple fields**, use the `ContentField.Value` convenience property to get the value without needing to know the specific field type. Alternatively, you can access type-specific properties directly for each field type:
- `StringField.ValueString` - Returns `string` (non-nullable)
- `NumberField.ValueNumber` - Returns `double?` (nullable)
- `IntegerField.ValueInteger` - Returns `long?` (nullable)
- `DateField.ValueDate` - Returns `DateTimeOffset?` (nullable, ISO 8601 YYYY-MM-DD format)
- `TimeField.ValueTime` - Returns `TimeSpan?` (nullable, ISO 8601 hh:mm:ss format)
- `BooleanField.ValueBoolean` - Returns `bool?` (nullable)
- `JsonField.ValueJson` - Returns `BinaryData` (non-nullable)

For **object fields**, access nested fields through `ValueObject` (an `IDictionary<string, ContentField>`). The dictionary can contain any `ContentField`-derived classes, including simple fields, object fields, or array fields. See the sample code above for examples.

For **array fields**, access elements via `ValueArray` (returns `IList<ContentField>`) or use the convenience `Count` property and indexer. See the sample code above for examples.

### Understanding field metadata

Each extracted field provides metadata to help you understand the extraction quality:

- **Confidence**: A float value between 0.0 and 1.0 indicating how certain the analyzer is about the extracted value. Higher values indicate higher confidence. Use this to filter or flag low-confidence extractions for manual review.
- **Source**: An encoded identifier that contains bounding box coordinates identifying the position of the field value in the original document. The format is `D(pageNumber, x1, y1, x2, y2, x3, y3, x4, y4)` where:
  - `pageNumber`: The page number (1-indexed) where the field was found
  - `x1, y1, x2, y2, x3, y3, x4, y4`: The four corner coordinates of the bounding box
  - Coordinates are in the document's unit (typically "inch" for US documents, as indicated by `DocumentContent.Unit`)

  For example, a source value like `D(1,1.265,1.0836,2.4972,1.0816,2.4964,1.4117,1.2645,1.4117)` indicates:
  - Page 1
  - Bounding box with corners at (1.265, 1.0836), (2.4972, 1.0816), (2.4964, 1.4117), and (1.2645, 1.4117)
  - All coordinates are in inches (since `DocumentContent.Unit` is "inch")

  The source can be used to trace back to the exact location where the value was found in the original document. For more information, see the [Source documentation][source-docs].
- **Spans**: A list of `ContentSpan` objects that indicate the position of the field value in the markdown content. Each span contains:
  - `Offset`: The starting position (0-indexed) in characters
  - `Length`: The length of the text in characters

These metadata properties are available on all field types (`StringField`, `NumberField`, `DateField`, `ObjectField`, `ArrayField`, etc.).

## Understanding analyzer schemas

The `prebuilt-invoice` analyzer contains many more fields than what is shown in the code snippet above. To get the complete schema of any analyzer, including all available fields and their types, use the `GetAnalyzerAsync` method. This works for both prebuilt analyzers (like `prebuilt-invoice`) and custom analyzers.

See [Sample 06: Get analyzer information][sample06] to learn how to retrieve and understand the field schemas provided by any prebuilt or custom analyzer.

### Document unit

The `DocumentContent.Unit` property indicates the measurement system used for coordinates in the `Source` field. For US documents, this is typically "inch", meaning all bounding box coordinates in the source field are measured in inches. This allows you to precisely locate extracted values in the original document.

For more details about `DocumentContent` and all available document elements (pages, paragraphs, tables, figures, etc.), see the [Document elements documentation][document-elements-docs].

## Next steps

- [Sample 04: Create a custom analyzer][sample04] - Learn how to create custom analyzers
- [Sample 05: Create and use a classifier][sample05] - Learn about classifiers

## Learn more

- [Document elements documentation][document-elements-docs] - Detailed information about `DocumentContent` and all available document elements (pages, paragraphs, tables, figures, etc.)
- [Prebuilt analyzers documentation][prebuilt-analyzers-docs] - Complete list of 70+ and growing prebuilt analyzers
- [Financial documents][financial-docs] - Overview of financial document analyzers

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample02]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample02_AnalyzeUrl.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample05]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample05_CreateClassifier.md
[sample06]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample06_GetAnalyzer.md
[document-elements-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/elements
[prebuilt-analyzers-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers
[financial-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers#financial-documents
[source-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/elements#source

