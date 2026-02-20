# Analyze documents with configs

This sample demonstrates how to extract additional features from documents such as charts, hyperlinks, formulas, and annotations using the `prebuilt-documentSearch` analyzer, which has formulas, layout, and OCR enabled by default.

## About analysis configs

The `prebuilt-documentSearch` analyzer has the following configurations enabled by default:
- **ReturnDetails**: `true` - Returns detailed information about document elements
- **EnableOcr**: `true` - Performs OCR on documents
- **EnableLayout**: `true` - Extracts layout information (tables, figures, hyperlinks, annotations)
- **EnableFormula**: `true` - Extracts mathematical formulas from documents
- **EnableFigureDescription**: `true` - Generates descriptions for figures
- **EnableFigureAnalysis**: `true` - Analyzes figures including charts
- **ChartFormat**: `"chartjs"` - Chart figures are returned in Chart.js format
- **TableFormat**: `"html"` - Tables are returned in HTML format
- **AnnotationFormat**: `"markdown"` - Annotations are returned in markdown format

The following code snippets demonstrate extraction of features enabled by these configs:
- **Charts**: Enabled by `EnableFigureAnalysis` - Chart figures with Chart.js configuration
- **Hyperlinks**: Enabled by `EnableLayout` - URLs and links found in the document
- **Formulas**: Enabled by `EnableFormula` - Mathematical formulas in LaTeX format
- **Annotations**: Enabled by `EnableLayout` - PDF annotations, comments, and markup

For custom analyzers, you can configure these options in `ContentAnalyzerConfig` when creating the analyzer.

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

## Analyze with configs

Analyze a document using `prebuilt-documentSearch` which has formulas, layout, and OCR enabled:

```C# Snippet:ContentUnderstandingAnalyzeWithConfigs
string filePath = "<filePath>";
byte[] fileBytes = File.ReadAllBytes(filePath);
BinaryData binaryData = BinaryData.FromBytes(fileBytes);

// Analyze with prebuilt-documentSearch which has formulas, layout, and OCR enabled
// These configs enable extraction of charts, annotations, hyperlinks, and formulas
Operation<AnalyzeResult> operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    binaryData);

AnalyzeResult result = operation.Value;
```

## Extract charts

Extract chart figures from the document:

```C# Snippet:ContentUnderstandingExtractCharts
// Extract charts from document content (enabled by EnableFigureAnalysis config)
DocumentContent documentContent = (DocumentContent)result.Contents!.First();
if (documentContent.Figures != null)
{
    foreach (DocumentFigure figure in documentContent.Figures)
    {
        if (figure is DocumentChartFigure chart)
        {
            Console.WriteLine($"  Chart ID: {chart.Id}");
            Console.WriteLine($"    Description: {chart.Description ?? "(not available)"}");
            Console.WriteLine($"    Caption: {chart.Caption?.Content ?? "(not available)"}");
        }
    }
}
```

## Extract hyperlinks

Extract hyperlinks from the document:

```C# Snippet:ContentUnderstandingExtractHyperlinks
// Extract hyperlinks from document content (enabled by EnableLayout config)
DocumentContent docContent = (DocumentContent)result.Contents!.First();
Console.WriteLine($"Found {docContent.Hyperlinks?.Count ?? 0} hyperlink(s)");
foreach (var hyperlink in docContent.Hyperlinks ?? Enumerable.Empty<DocumentHyperlink>())
{
    Console.WriteLine($"  URL: {hyperlink.Url ?? "(not available)"}");
    Console.WriteLine($"    Content: {hyperlink.Content ?? "(not available)"}");
}
```

## Extract formulas

Extract mathematical formulas from document pages:

```C# Snippet:ContentUnderstandingExtractFormulas
// Extract formulas from document pages (enabled by EnableFormula config)
DocumentContent content = (DocumentContent)result.Contents!.First();
var allFormulas = new List<DocumentFormula>();
foreach (var page in content.Pages ?? Enumerable.Empty<DocumentPage>())
{
    allFormulas.AddRange(page.Formulas ?? Enumerable.Empty<DocumentFormula>());
}

Console.WriteLine($"Found {allFormulas.Count} formula(s)");
foreach (var formula in allFormulas)
{
    Console.WriteLine($"  Formula Kind: {formula.Kind}");
    Console.WriteLine($"    LaTeX: {formula.Value ?? "(not available)"}");
    Console.WriteLine($"    Confidence: {formula.Confidence?.ToString("F2") ?? "N/A"}");
}
```

## Extract annotations

Extract PDF annotations from the document:

```C# Snippet:ContentUnderstandingExtractAnnotations
// Extract annotations from document content (enabled by EnableLayout config)
DocumentContent document = (DocumentContent)result.Contents!.First();
Console.WriteLine($"Found {document.Annotations?.Count ?? 0} annotation(s)");
foreach (var annotation in document.Annotations ?? Enumerable.Empty<DocumentAnnotation>())
{
    Console.WriteLine($"  Annotation ID: {annotation.Id}");
    Console.WriteLine($"    Kind: {annotation.Kind}");
    Console.WriteLine($"    Author: {annotation.Author ?? "(not available)"}");
    Console.WriteLine($"    Comments: {annotation.Comments?.Count ?? 0}");
    foreach (var comment in annotation.Comments ?? Enumerable.Empty<DocumentAnnotationComment>())
    {
        Console.WriteLine($"      - {comment.Message}");
    }
}
```

## Next steps

- [Sample 04: Create a custom analyzer][sample04] - Learn how to configure analysis options for custom analyzers
- [Sample 01: Analyze binary][sample01] - Learn more about basic document analysis

## Learn more

- [Content Understanding documentation][cu-docs]
- [Document elements documentation][document-elements-docs] - Detailed information about document elements (pages, figures, annotations, etc.)

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample04]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample04_CreateAnalyzer.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[document-elements-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/elements

