# Create and use a classifier

This sample demonstrates how to create a classifier analyzer to categorize documents and use it to analyze documents with and without automatic segmentation.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 00: Configure model deployment defaults][sample00] - Required setup before creating custom analyzers
- [Sample 04: Create a custom analyzer][sample04] - Basic custom analyzer concepts

## About classifiers

Classifiers are a type of custom analyzer that categorize documents into predefined categories. They're useful for:
- **Document routing**: Automatically route documents to the right processing pipeline based on category
- **Content organization**: Organize large document collections by type
- **Multi-document processing**: Process files containing multiple document types by automatically segmenting them

Classifiers use **content categories** to define the types of documents they can identify. Each category has a description that helps the analyzer understand what documents belong to that category.

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## Create a classifier

Create a classifier analyzer with content categories:

```C# Snippet:ContentUnderstandingCreateClassifier
// Define content categories for classification
var categories = new Dictionary<string, ContentCategory>
{
    ["Loan_Application"] = new ContentCategory
    {
        Description = "Documents submitted by individuals or businesses to request funding, typically including personal or business details, financial history, loan amount, purpose, and supporting documentation."
    },
    ["Invoice"] = new ContentCategory
    {
        Description = "Billing documents issued by sellers or service providers to request payment for goods or services, detailing items, prices, taxes, totals, and payment terms."
    },
    ["Bank_Statement"] = new ContentCategory
    {
        Description = "Official statements issued by banks that summarize account activity over a period, including deposits, withdrawals, fees, and balances."
    }
};

// Create analyzer configuration
var config = new ContentAnalyzerConfig
{
    ReturnDetails = true,
    EnableSegment = true // Enable automatic segmentation by category
};

// Add categories to config
foreach (var kvp in categories)
{
    config.ContentCategories.Add(kvp.Key, kvp.Value);
}

// Create the classifier analyzer
var classifier = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Custom classifier for financial document categorization",
    Config = config
};
classifier.Models.Add("completion", "gpt-4.1");

// Create the classifier
string analyzerId = $"my_classifier_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
var operation = await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    classifier);

ContentAnalyzer result = operation.Value;
Console.WriteLine($"Classifier '{analyzerId}' created successfully!");
```

## Analyze documents without segmentation

When `EnableSegment` is `false`, the entire document is classified as a single unit without splitting. For example, consider a multi-page PDF file like [`mixed_financial_docs.pdf`][mixed-docs-example] that contains:
- **Invoice**: page 1
- **Bank Statement**: pages 2-3
- **Loan Application**: page 4

With `EnableSegment = false`, the entire 4-page document will be classified as one category (e.g., "Invoice" or "Bank Statement") without splitting the document into separate segments:

```C# Snippet:ContentUnderstandingAnalyzeCategory
// Analyze a document (EnableSegment=false means entire document is one category)
AnalyzeResultOperation analyzeOperation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    analyzerId,
    "application/pdf",
    BinaryData.FromBytes(fileBytes));

var analyzeResult = analyzeOperation.Value;

// Display classification results
if (analyzeResult.Contents?.FirstOrDefault() is DocumentContent docContent)
{
    Console.WriteLine($"Pages: {docContent.StartPageNumber}-{docContent.EndPageNumber}");

    // With EnableSegment=false, the document is classified as a single unit
    if (docContent.Segments != null && docContent.Segments.Count > 0)
    {
        foreach (var segment in docContent.Segments)
        {
            Console.WriteLine($"Category: {segment.Category ?? "(unknown)"}");
            Console.WriteLine($"Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
        }
    }
}
```

## Analyze documents with segmentation

When `EnableSegment` is `true`, the analyzer automatically splits multi-document files into segments by category. For example, with [`mixed_financial_docs.pdf`][mixed-docs-example] that contains:
- **Invoice**: page 1
- **Bank Statement**: pages 2-3
- **Loan Application**: page 4

With `EnableSegment = true`, the analyzer will segment the document and return classification for each segment:
- Segment 1: Category "Invoice", Pages 1-1
- Segment 2: Category "Bank Statement", Pages 2-3
- Segment 3: Category "Loan Application", Page 4

```C# Snippet:ContentUnderstandingAnalyzeCategoryWithSegments
// Analyze a document (EnableSegment=true automatically segments by category)
AnalyzeResultOperation analyzeOperation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    analyzerId,
    "application/pdf",
    BinaryData.FromBytes(fileBytes));

var analyzeResult = analyzeOperation.Value;

// Display classification results with automatic segmentation
if (analyzeResult.Contents?.FirstOrDefault() is DocumentContent docContent)
{
    if (docContent.Segments != null && docContent.Segments.Count > 0)
    {
        Console.WriteLine($"Found {docContent.Segments.Count} segment(s):");
        foreach (var segment in docContent.Segments)
        {
            Console.WriteLine($"  Category: {segment.Category ?? "(unknown)"}");
            Console.WriteLine($"  Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
            Console.WriteLine($"  Segment ID: {segment.SegmentId ?? "(not available)"}");
        }
    }
}
```

## Segmentation behavior

The `EnableSegment` property controls how multi-document files are processed:

- **`EnableSegment = false`**: The entire document is classified as one category without splitting. For example, with [`mixed_financial_docs.pdf`][mixed-docs-example] (4 pages containing invoice, bank statement, and loan application), the entire document will be classified as a single category. Useful when you know each file contains only one document type.

- **`EnableSegment = true`**: The analyzer automatically splits the document into segments, with each segment having its own category. For example, with [`mixed_financial_docs.pdf`][mixed-docs-example], the analyzer will return three segments:
  - Segment 1: "Invoice" (page 1)
  - Segment 2: "Bank Statement" (pages 2-3)
  - Segment 3: "Loan Application" (page 4)

  Useful for processing files that contain multiple document types.

## Delete the classifier (optional)

**Note:** In production code, you typically keep classifiers and reuse them for multiple analyses. Deletion is mainly useful for:
- Testing and development cleanup
- Removing classifiers that are no longer needed
- Managing resource quotas

If you need to delete a classifier (for example, in test cleanup), you can do so as follows:

```C# Snippet:ContentUnderstandingDeleteClassifier
// Clean up: delete the classifier (for testing purposes only)
// In production, classifiers are typically kept and reused
await client.DeleteAnalyzerAsync(analyzerId);
Console.WriteLine($"Classifier '{analyzerId}' deleted successfully.");
```

## Next Steps

- [Sample 06: Get analyzer information][sample06] - Learn how to retrieve analyzer details
- [Sample 07: List analyzers][sample07] - Learn how to list all analyzers
- [Sample 08: Update analyzer][sample08] - Learn how to update an existing analyzer

## Learn More

- [Content Understanding Documentation][cu-docs]
- [Classifiers Documentation][classifier-docs]

[sample00]: Sample00_ConfigureDefaults.md
[sample01]: Sample01_AnalyzeBinary.md
[sample04]: Sample04_CreateAnalyzer.md
[sample06]: Sample06_GetAnalyzer.md
[sample07]: Sample07_ListAnalyzers.md
[sample08]: Sample08_UpdateAnalyzer.md
[cu-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/
[classifier-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/concepts/classifier
[mixed-docs-example]: https://github.com/Azure-Samples/azure-ai-content-understanding-dotnet/blob/main/ContentUnderstanding.Common/data/mixed_financial_docs.pdf

