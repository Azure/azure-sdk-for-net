# Create and use a classifier

This sample demonstrates how to create a classifier analyzer to categorize documents and use it to analyze documents with and without automatic segmentation.

Alternatively, you can create classification workflows using [Content Understanding Studio][content-understanding-studio-classification-docs], a web-based UI that provides a convenient way to build and test classification workflows in the same interface. Content Understanding Studio allows you to create custom categories and routing rules that route your data to specific analyzers, ensuring your data is always routed to the best analyzer for processing.

## About classifiers

Classifiers are a type of custom analyzer that create classification workflows to categorize documents into predefined custom categories using `ContentCategories`. They allow you to perform classification and content extraction as part of a single API call. Classifiers are useful for:
- **Content organization**: Organize large document collections by type through categorization
- **Data routing (optional)**: Optionally route your data to specific custom analyzers based on category, ensuring your data is routed to the best analyzer for processing when needed
- **Multi-document processing**: Process files containing multiple document types by automatically segmenting them

Classifiers use **custom categories** to define the types of documents they can identify. Each category has a `Description` that helps the AI model understand what documents belong to that category. You can define up to 200 category names and descriptions. You can include an `"other"` category to handle unmatched content; otherwise, all files are forced to be classified into one of your defined categories.

The `EnableSegment` property in the analyzer configuration controls whether multi-document files are split into segments:
- **`EnableSegment = false`**: Classifies the entire file as a single category (classify only)
- **`EnableSegment = true`**: Automatically splits the file into segments by category (classify and segment)

For detailed information about classifiers, see the [Classifier documentation][classifier-docs].

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

## Create a classifier

Like custom analyzers, classifiers are created using `ContentAnalyzer` and passed to `ContentUnderstandingClient.CreateAnalyzerAsync()`.

To define a classifier, it requires:
- A `BaseAnalyzerId` (see [baseAnalyzerId][baseanalyzerid-docs] for details). Supported base analyzers include:
  - `prebuilt-document` - for document-based classifiers
  - `prebuilt-audio` - for audio-based classifiers
  - `prebuilt-video` - for video-based classifiers
  - `prebuilt-image` - for image-based classifiers

  For the complete and up-to-date list of supported base analyzers, see the [Analyzer reference documentation][analyzer-reference-docs].
- A unique analyzer ID inside an AI Foundry resource (passed as a separate parameter to `CreateAnalyzerAsync`)
- Optional `Name` and `Description` (description is used as context by the AI model, so clear descriptions improve classification accuracy)
- Required: Define `ContentCategories` in the analyzer configuration (defines the categories for classification)
- Required: Define the configuration (controls how content is processed, including optional `EnableSegment` property for segmentation)
- Required: Define supported large language models using model names (not model deployments)

For detailed information about classifier configuration, see the [Classifier documentation][classifier-docs].

Create a classifier analyzer with content categories:

```C# Snippet:ContentUnderstandingCreateClassifier
// Define content categories for classification
var categories = new Dictionary<string, ContentCategoryDefinition>
{
    ["Loan_Application"] = new ContentCategoryDefinition
    {
        Description = "Documents submitted by individuals or businesses to request funding, typically including personal or business details, financial history, loan amount, purpose, and supporting documentation."
    },
    ["Invoice"] = new ContentCategoryDefinition
    {
        Description = "Billing documents issued by sellers or service providers to request payment for goods or services, detailing items, prices, taxes, totals, and payment terms."
    },
    ["Bank_Statement"] = new ContentCategoryDefinition
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
classifier.Models["completion"] = "gpt-4.1";

// Create the classifier
string analyzerId = $"my_classifier_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}";
var operation = await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    classifier);

ContentAnalyzer result = operation.Value;
Console.WriteLine($"Classifier '{analyzerId}' created successfully!");
```

## Analyze documents with segmentation

Use `AnalyzeBinaryAsync()` to analyze a document file with the classifier. When `EnableSegment` is `true`, the analyzer automatically splits multi-document files into segments by category. The result contains multiple segments in the `Segments` property of `DocumentContent`, each with its own category classification.

For example, with [`mixed_financial_docs.pdf`][mixed-docs-example] that contains invoice (page 1), bank statement (pages 2-3), and loan application (page 4), the analyzer will return three segments:
- Segment 1: Category "Invoice", Pages 1-1
- Segment 2: Category "Bank Statement", Pages 2-3
- Segment 3: Category "Loan Application", Page 4

```C# Snippet:ContentUnderstandingAnalyzeCategoryWithSegments
// Analyze a document (EnableSegment=true automatically segments by category)
string filePath = "<file_path>";
byte[] fileBytes = File.ReadAllBytes(filePath);
Operation<AnalyzeResult> analyzeOperation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    analyzerId,
    BinaryData.FromBytes(fileBytes));

var analyzeResult = analyzeOperation.Value;

// Display classification results with automatic segmentation
DocumentContent docContent = (DocumentContent)analyzeResult.Contents!.First();
Console.WriteLine($"Found {docContent.Segments?.Count ?? 0} segment(s):");
foreach (var segment in docContent.Segments ?? Enumerable.Empty<DocumentContentSegment>())
{
    Console.WriteLine($"  Category: {segment.Category ?? "(unknown)"}");
    Console.WriteLine($"  Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
    Console.WriteLine($"  Segment ID: {segment.SegmentId ?? "(not available)"}");
}
```

## Analyze documents without segmentation

If `EnableSegment` is set to `false` (the default), the entire document will be classified as a single unit without splitting. Use `AnalyzeBinaryAsync()` with the classifier, and the result will contain classification information in the `Segments` property of `DocumentContent` for the entire document as one category.

For example, with a multi-page PDF file like [`mixed_financial_docs.pdf`][mixed-docs-example] that contains invoice (page 1), bank statement (pages 2-3), and loan application (page 4), the entire 4-page document will be classified as one category (e.g., "Invoice" or "Bank Statement") without splitting into separate segments.

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

## Next steps

- [Sample 06: Get analyzer information][sample06] - Learn how to retrieve analyzer details
- [Sample 07: List analyzers][sample07] - Learn how to list all analyzers
- [Sample 08: Update analyzer][sample08] - Learn how to update an existing analyzer

## Learn more

- [Content Understanding documentation][cu-docs]
- [Classify and route your data using Content Understanding Studio][content-understanding-studio-classification-docs] - Learn how to create classification workflows using the web-based UI with custom categories and routing rules
- [Content Understanding Studio Portal][content-understanding-studio-portal] - Access the web-based UI to create and manage classification workflows
- [Classifiers documentation][classifier-docs]

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[sample06]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample06_GetAnalyzer.md
[sample07]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample07_ListAnalyzers.md
[sample08]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample08_UpdateAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[content-understanding-studio-classification-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/how-to/classification-content-understanding-studio?tabs=portal
[content-understanding-studio-portal]: https://contentunderstanding.ai.azure.com/home
[classifier-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/classifier
[analyzer-reference-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#analyzer-configuration-structure
[baseanalyzerid-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/analyzer-reference#baseanalyzerid
[mixed-docs-example]: https://github.com/Azure-Samples/azure-ai-content-understanding-dotnet/blob/main/ContentUnderstanding.Common/data/mixed_financial_docs.pdf

