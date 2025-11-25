# Analyze an invoice using prebuilt analyzer

This sample demonstrates how to analyze an invoice from a URL using the `prebuilt-invoice` analyzer and extract structured fields from the result.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 00: Configure model deployment defaults][sample00] - Required setup before using prebuilt analyzers
- [Sample 02: Analyze a document from URL][sample02] - Basic URL-based analysis

## About prebuilt analyzers

Content Understanding provides **70+ production-ready prebuilt analyzers** that are ready to use without any training or configuration. These analyzers are powered by rich knowledge bases of thousands of real-world document examples, enabling them to understand document structure and adapt to variations in format and content.

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

For a complete list of available prebuilt analyzers, see the [Prebuilt Analyzers documentation][prebuilt-analyzers-docs].

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## Analyze invoice from URL

Analyze an invoice from a URL using the `prebuilt-invoice` analyzer:

```C# Snippet:ContentUnderstandingAnalyzeInvoice
Uri invoiceUrl = new Uri("<invoiceUrl>");
Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-invoice",
    inputs: new[] { new AnalyzeInput { Url = invoiceUrl } });

AnalyzeResult result = operation.Value;
```

## Extract invoice fields

The `prebuilt-invoice` analyzer returns structured fields that you can access type-safely. Each field includes metadata such as confidence scores and source information:

```C# Snippet:ContentUnderstandingExtractInvoiceFields
// Get the document content (invoices are documents)
if (result.Contents?.FirstOrDefault() is DocumentContent documentContent)
{
    // Print document unit information
    // The unit indicates the measurement system used for coordinates in the source field
    Console.WriteLine($"Document unit: {documentContent.Unit ?? "unknown"}");
    Console.WriteLine($"Pages: {documentContent.StartPageNumber} to {documentContent.EndPageNumber}");
    Console.WriteLine();

    // Extract simple string fields
    var customerNameField = documentContent["CustomerName"];
    var invoiceDateField = documentContent["InvoiceDate"];

    var customerName = customerNameField?.Value?.ToString();
    var invoiceDate = invoiceDateField?.Value?.ToString();

    Console.WriteLine($"Customer Name: {customerName ?? "(None)"}");
    if (customerNameField != null)
    {
        Console.WriteLine($"  Confidence: {customerNameField.Confidence?.ToString("F2") ?? "N/A"}");
        // Source is an encoded identifier containing bounding box coordinates
        // Format: D(pageNumber, x1, y1, x2, y2, x3, y3, x4, y4)
        // Coordinates are in the document's unit (e.g., inches for US documents)
        Console.WriteLine($"  Source: {customerNameField.Source ?? "N/A"}");
        if (customerNameField.Spans != null && customerNameField.Spans.Count > 0)
        {
            var span = customerNameField.Spans[0];
            Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
        }
    }

    Console.WriteLine($"Invoice Date: {invoiceDate ?? "(None)"}");
    if (invoiceDateField != null)
    {
        Console.WriteLine($"  Confidence: {invoiceDateField.Confidence?.ToString("F2") ?? "N/A"}");
        Console.WriteLine($"  Source: {invoiceDateField.Source ?? "N/A"}");
        if (invoiceDateField.Spans != null && invoiceDateField.Spans.Count > 0)
        {
            var span = invoiceDateField.Spans[0];
            Console.WriteLine($"  Position in markdown: offset={span.Offset}, length={span.Length}");
        }
    }

    // Extract object fields (nested structures)
    if (documentContent["TotalAmount"] is ObjectField totalAmountObj)
    {
        var amount = totalAmountObj["Amount"]?.Value as double?;
        var currency = totalAmountObj["CurrencyCode"]?.Value?.ToString();
        Console.WriteLine($"Total: {currency ?? "$"}{amount?.ToString("F2") ?? "(None)"}");
        if (totalAmountObj.Confidence.HasValue)
        {
            Console.WriteLine($"  Confidence: {totalAmountObj.Confidence.Value:F2}");
        }
        if (!string.IsNullOrEmpty(totalAmountObj.Source))
        {
            Console.WriteLine($"  Source: {totalAmountObj.Source}");
        }
    }

    // Extract array fields (collections like line items)
    if (documentContent["LineItems"] is ArrayField lineItems)
    {
        Console.WriteLine($"Line Items ({lineItems.Count}):");
        for (int i = 0; i < lineItems.Count; i++)
        {
            if (lineItems[i] is ObjectField item)
            {
                var description = item["Description"]?.Value?.ToString();
                var quantity = item["Quantity"]?.Value as double?;
                Console.WriteLine($"  Item {i + 1}: {description ?? "N/A"} (Qty: {quantity?.ToString() ?? "N/A"})");
                if (item.Confidence.HasValue)
                {
                    Console.WriteLine($"    Confidence: {item.Confidence.Value:F2}");
                }
            }
        }
    }
}
```

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

### Document unit

The `DocumentContent.Unit` property indicates the measurement system used for coordinates in the `Source` field. For US documents, this is typically "inch", meaning all bounding box coordinates in the source field are measured in inches. This allows you to precisely locate extracted values in the original document.

For more details about `DocumentContent` and all available document elements (pages, paragraphs, tables, figures, etc.), see the [Document Elements documentation][document-elements-docs].

## Next Steps

- [Sample 04: Create a custom analyzer][sample04] - Learn how to create custom analyzers
- [Sample 05: Create and use a classifier][sample05] - Learn about classifiers

## Learn More

- [Content Understanding Documentation][cu-docs]
- [Document Elements Documentation][document-elements-docs] - Detailed information about `DocumentContent` and all available document elements (pages, paragraphs, tables, figures, etc.)
- [Prebuilt Analyzers Documentation][prebuilt-analyzers-docs] - Complete list of 70+ prebuilt analyzers
- [Financial Documents][financial-docs] - Overview of financial document analyzers

[sample00]: Sample00_ConfigureDefaults.md
[sample01]: Sample01_AnalyzeBinary.md
[sample02]: Sample02_AnalyzeUrl.md
[sample04]: Sample04_CreateAnalyzer.md
[sample05]: Sample05_CreateClassifier.md
[cu-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/
[document-elements-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/elements
[prebuilt-analyzers-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/concepts/prebuilt-analyzers
[financial-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/concepts/prebuilt-analyzers#financial-documents
[source-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/elements#source

