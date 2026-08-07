# Analyze binary input inline (no LRO polling)

This sample shows `AnalyzeBinaryInlineAsync` for local binary input. This API is **available only** in service API version `2026-06-01-preview`.

> **Preview only:** Configure the client with `new ContentUnderstandingClientOptions(ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)`.

By default, `AnalyzeBinaryAsync` is a long-running operation (LRO): the client starts analysis and polls until the result is ready. `AnalyzeBinaryInlineAsync` completes analysis in a single call and returns `AnalysisResult` without polling, which can reduce latency for small files with supported analyzers.

## How to choose

Use `AnalyzeBinaryAsync` (LRO) when:
- You need larger files or more pages (see [document limits](https://aka.ms/cu-doc-limits)).
- You need broader analyzer coverage.
- You want results retained for up to **24 hours** (or until you delete them) and operation lifecycle APIs.

Use `AnalyzeBinaryInlineAsync` (available only in `2026-06-01-preview`) when:
- You want a single call with no polling.
- You want faster results for smaller inputs — with no polling and no wait tied to a polling interval, the inline path is faster than the corresponding `Analyze*` LRO APIs under the inline size/analyzer limits.
- Your analyzer is in the supported inline set below (no field schema / field extraction).

For current limits, see https://aka.ms/cu-doc-limits.

## Supported inline analyzers (2026-06-01-preview only)

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
