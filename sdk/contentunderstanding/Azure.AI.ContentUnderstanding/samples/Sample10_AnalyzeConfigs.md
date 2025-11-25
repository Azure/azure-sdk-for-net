# Analyze documents with configs

This sample demonstrates how to extract additional features from documents such as charts, hyperlinks, formulas, and annotations using the `prebuilt-documentSearch` analyzer, which has formulas, layout, and OCR enabled by default.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 01: Analyze a document from binary data][sample01] - Basic analysis concepts

## About analysis configs

The `prebuilt-documentSearch` analyzer has the following configurations enabled by default:
- **EnableFormula**: Extracts mathematical formulas from documents
- **EnableLayout**: Extracts layout information (tables, figures, etc.)
- **EnableOcr**: Performs OCR on documents

These configs enable extraction of:
- **Charts**: Chart figures with Chart.js configuration
- **Hyperlinks**: URLs and links found in the document
- **Formulas**: Mathematical formulas in LaTeX format
- **Annotations**: PDF annotations, comments, and markup

For custom analyzers, you can configure these options in `ContentAnalyzerConfig` when creating the analyzer.

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## Analyze with configs

Analyze a document using `prebuilt-documentSearch` which has formulas, layout, and OCR enabled:

```C# Snippet:ContentUnderstandingAnalyzeWithConfigs
string filePath = "<filePath>";
byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
BinaryData binaryData = BinaryData.FromBytes(fileBytes);

// Analyze with prebuilt-documentSearch which has formulas, layout, and OCR enabled
// These configs enable extraction of charts, annotations, hyperlinks, and formulas
AnalyzeResultOperation operation = await client.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    "application/pdf",
    binaryData);

AnalyzeResult result = operation.Value;
```

## Extract charts

Extract chart figures from the document:

```C# Snippet:ContentUnderstandingExtractCharts
// Extract charts from document content
if (result.Contents?.FirstOrDefault() is DocumentContent documentContent)
{
    if (documentContent.Figures != null && documentContent.Figures.Count > 0)
    {
        var chartFigures = documentContent.Figures
            .Where(f => f is DocumentChartFigure)
            .Cast<DocumentChartFigure>()
            .ToList();

        Console.WriteLine($"Found {chartFigures.Count} chart(s)");
        foreach (var chart in chartFigures)
        {
            Console.WriteLine($"  Chart ID: {chart.Id}");
            if (!string.IsNullOrEmpty(chart.Description))
            {
                Console.WriteLine($"    Description: {chart.Description}");
            }
            if (chart.Caption != null && !string.IsNullOrEmpty(chart.Caption.Content))
            {
                Console.WriteLine($"    Caption: {chart.Caption.Content}");
            }
        }
    }
}
```

## Extract hyperlinks

Extract hyperlinks from the document:

```C# Snippet:ContentUnderstandingExtractHyperlinks
// Extract hyperlinks from document content
if (result.Contents?.FirstOrDefault() is DocumentContent docContent)
{
    if (docContent.Hyperlinks != null && docContent.Hyperlinks.Count > 0)
    {
        Console.WriteLine($"Found {docContent.Hyperlinks.Count} hyperlink(s)");
        foreach (var hyperlink in docContent.Hyperlinks)
        {
            Console.WriteLine($"  URL: {hyperlink.Url ?? "(not available)"}");
            Console.WriteLine($"    Content: {hyperlink.Content ?? "(not available)"}");
        }
    }
}
```

## Extract formulas

Extract mathematical formulas from document pages:

```C# Snippet:ContentUnderstandingExtractFormulas
// Extract formulas from document pages
if (result.Contents?.FirstOrDefault() is DocumentContent content)
{
    var allFormulas = new System.Collections.Generic.List<DocumentFormula>();
    if (content.Pages != null)
    {
        foreach (var page in content.Pages)
        {
            if (page.Formulas != null)
            {
                allFormulas.AddRange(page.Formulas);
            }
        }
    }

    if (allFormulas.Count > 0)
    {
        Console.WriteLine($"Found {allFormulas.Count} formula(s)");
        foreach (var formula in allFormulas)
        {
            Console.WriteLine($"  Formula Kind: {formula.Kind}");
            Console.WriteLine($"    LaTeX: {formula.Value ?? "(not available)"}");
            if (formula.Confidence.HasValue)
            {
                Console.WriteLine($"    Confidence: {formula.Confidence.Value:F2}");
            }
        }
    }
}
```

## Extract annotations

Extract PDF annotations from the document:

```C# Snippet:ContentUnderstandingExtractAnnotations
// Extract annotations from document content
if (result.Contents?.FirstOrDefault() is DocumentContent document)
{
    if (document.Annotations != null && document.Annotations.Count > 0)
    {
        Console.WriteLine($"Found {document.Annotations.Count} annotation(s)");
        foreach (var annotation in document.Annotations)
        {
            Console.WriteLine($"  Annotation ID: {annotation.Id}");
            Console.WriteLine($"    Kind: {annotation.Kind}");
            if (!string.IsNullOrEmpty(annotation.Author))
            {
                Console.WriteLine($"    Author: {annotation.Author}");
            }
            if (annotation.Comments != null && annotation.Comments.Count > 0)
            {
                Console.WriteLine($"    Comments: {annotation.Comments.Count}");
                foreach (var comment in annotation.Comments)
                {
                    Console.WriteLine($"      - {comment.Message}");
                }
            }
        }
    }
}
```

## Next Steps

- [Sample 04: Create a custom analyzer][sample04] - Learn how to configure analysis options for custom analyzers
- [Sample 01: Analyze binary][sample01] - Learn more about basic document analysis

## Learn More

- [Content Understanding Documentation][cu-docs]
- [Document Elements Documentation][document-elements-docs] - Detailed information about document elements (pages, figures, annotations, etc.)

[sample00]: Sample00_ConfigureDefaults.md
[sample01]: Sample01_AnalyzeBinary.md
[sample04]: Sample04_CreateAnalyzer.md
[cu-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/
[document-elements-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/document/elements

