# Analyze binary input inline without long-running operation polling

> **Supported service API version:** `2026-06-01-preview`

This sample shows `AnalyzeBinaryInlineAsync` for local binary input.

## Inline vs. long-running operation analysis

Content Understanding provides two analysis patterns:

**Long-running operation (LRO):** `AnalyzeBinaryAsync` starts an operation and polls until the result is ready. Choose this mode for larger files or more pages (see [document limits](https://aka.ms/cu-doc-limits)), broader analyzer coverage, or results retained for up to **24 hours** (or until you delete them) with operation lifecycle APIs.

**Inline:** `AnalyzeBinaryInlineAsync` completes analysis in one HTTP call and returns the result without polling. Choose this mode for smaller inputs within the inline size and page limits when using one of the supported inline analyzers below (no field schema / field extraction). With no polling or wait tied to a polling interval, inline analysis is faster than the corresponding LRO API under these limits. Inline results are not persisted, and a non-succeeded status throws `RequestFailedException`.

For current limits, see https://aka.ms/cu-doc-limits.

## Supported inline analyzers

Inline analysis supports only document analyzers without a field schema:

- `prebuilt-digitalParse`
- `prebuilt-read`
- `prebuilt-layout`
- Custom document analyzers without fields

For URL inline input, see [Sample 18][sample18].

## Example

```C# Snippet:ContentUnderstandingAnalyzeBinaryInlineAsync
Response<AnalysisResult> inlineResponse = await client.AnalyzeBinaryInlineAsync(
    "prebuilt-layout",
    binaryData);

AnalysisResult inlineResult = inlineResponse.Value;
```

Read usage from the inline response with `GetUsageDetails()`, matching [Sample 03][sample03]. Inline analyze reports `DocumentPages*Inline` meters — see the [Content Understanding pricing explainer][pricing-explainer] for which meter applies.

```C# Snippet:ContentUnderstandingAnalyzeBinaryInlineGetUsageDetails
// Inline analyze reports DocumentPages*Inline meters (see pricing docs for which
// meter applies). This sample prints the standard inline page meter.
UsageDetails? usage = inlineResponse.GetUsageDetails();
if (usage != null)
{
    Console.WriteLine($"Document pages (standard inline): {usage.DocumentPagesStandardInline}");
    Console.WriteLine($"Contextualization tokens: {usage.ContextualizationTokens}");
}
```

Select a specific page window with the `contentRange:` overload (inline supports at most 5 pages):

```C# Snippet:ContentUnderstandingAnalyzeBinaryInlineWithContentRangeAsync
Response<AnalysisResult> rangeResponse = await client.AnalyzeBinaryInlineAsync(
    "prebuilt-layout",
    binaryData,
    contentRange: ContentRange.Pages(1, 3));

DocumentContent rangeDocument = (DocumentContent)rangeResponse.Value.Contents!.First();
Console.WriteLine($"Inline pages: {rangeDocument.StartPageNumber}-{rangeDocument.EndPageNumber} ({rangeDocument.Pages!.Count} pages)");
```

## Example with AnalyzeBinaryOptions

Use the options bag when you need content type, processing location, or other binary options:

```C# Snippet:ContentUnderstandingAnalyzeBinaryInlineWithOptionsAsync
Response<AnalysisResult> optionsResponse = await client.AnalyzeBinaryInlineAsync(
    new AnalyzeBinaryOptions("prebuilt-layout", binaryData)
    {
        ContentType = "application/pdf"
    });

AnalysisResult optionsResult = optionsResponse.Value;
```

[sample18]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample18_AnalyzeInline.md
[sample03]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample03_AnalyzeInvoice.md
[pricing-explainer]: https://learn.microsoft.com/azure/ai-services/content-understanding/pricing-explainer
