# Classify multiple documents within one page

> **Supported service API version:** `2026-06-01-preview`

By default, document segmentation uses page boundaries. Set
`AllowInPageSegments` together with `EnableSegment` when distinct documents can
appear on the same page — for example, separating individual **supplemental
statements** that are often appended after the main form in a K-1 tax package.
See the [Content Understanding classifier overview][classifier-docs] for
supported scenarios and Studio guidance.

This sample uses a simplified synthetic one-page PDF containing an invoice in
the upper half and an account statement in the lower half.

## Create and run an in-page classifier

Define the categories, enable in-page segmentation, create the analyzer, and
submit the PDF:

```C# Snippet:ContentUnderstandingClassifyInPageSegments
var config = new ContentAnalyzerConfig
{
    // Return full content details (markdown, spans, sources, and per-segment
    // metadata) in the result. Required to inspect the segments below.
    ShouldReturnDetails = true,
    // Enable classification-based segmentation: the input is split into segments,
    // each classified against the ContentCategories defined below.
    EnableSegment = true,
    // Allow a segment to cover only part of a page, so multiple documents that
    // share one page can be separated. When false (the default), segments break
    // on whole-page boundaries only.
    AllowInPageSegments = true,
    // Return grounding source and confidence for extracted fields.
    EstimateFieldSourceAndConfidence = true
};
config.ContentCategories.Add("Invoice", new ContentCategoryDefinition
{
    Description = "An invoice requesting payment for goods or services, with line items, totals, and payment terms."
});
config.ContentCategories.Add("BankStatement", new ContentCategoryDefinition
{
    Description = "A bank account statement listing balances, deposits, withdrawals, fees, and transactions."
});

var classifier = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-document",
    Description = "Classify financial documents that may share a page.",
    Config = config
};
string completionModel = "<completion-model-name>";
classifier.Models["completion"] = completionModel;

await client.CreateAnalyzerAsync(
    WaitUntil.Completed,
    analyzerId,
    classifier);

try
{
    string filePath = "<path-to-pdf-with-multiple-documents-on-one-page>";
    BinaryData documentData = BinaryData.FromBytes(File.ReadAllBytes(filePath));

    Operation<AnalysisResult> operation = await client.AnalyzeBinaryAsync(
        WaitUntil.Completed,
        analyzerId,
        documentData);

    DocumentContent document = operation.Value.Contents
        .OfType<DocumentContent>()
        .First();

    foreach (DocumentContentSegment segment in document.Segments)
    {
        Console.WriteLine($"Category: {segment.Category}");
        Console.WriteLine($"  Pages: {segment.StartPageNumber}-{segment.EndPageNumber}");
        Console.WriteLine($"  Confidence: {segment.Confidence:P1}");
        Console.WriteLine($"  Source: {segment.Source}");
        Console.WriteLine($"  Span: offset={segment.Span.Offset}, length={segment.Span.Length}");
    }

}
finally
{
    await client.DeleteAnalyzerAsync(analyzerId);
}
```

Both segments report page range `1-1`, while their distinct `Span` and `Source`
values locate each document within that page. `Confidence` represents the
combined confidence of segmentation and category classification.

[classifier-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/classifier
