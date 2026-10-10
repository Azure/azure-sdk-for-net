# Analyze a URL input inline without polling

> **Supported service API version:** `2026-06-01-preview`

This sample shows `AnalyzeInlineAsync` for URL-based inputs.

## Inline vs. long-running operation analysis

Content Understanding provides two analysis patterns:

**Long-running operation (LRO):** `AnalyzeAsync` starts an operation and polls until the result is ready. Choose this mode for larger files or more pages (see [document limits](https://aka.ms/cu-doc-limits)), broader analyzer coverage, or results retained for up to **24 hours** (or until you delete them) with operation lifecycle APIs (`Operation-Location` / operation ID).

**Inline:** `AnalyzeInlineAsync` completes analysis in one HTTP call and returns the result without polling. Choose this mode for smaller inputs within the inline size and page limits when using one of the supported inline analyzers below (no field schema / field extraction). With no polling or wait tied to a polling interval, inline analysis is faster than the corresponding LRO API under these limits. Inline results are not persisted, and a non-succeeded status throws `RequestFailedException`.

For current limits, see https://aka.ms/cu-doc-limits.

## Supported inline analyzers

Inline analysis supports only document analyzers without a field schema:

- `prebuilt-digitalParse`
- `prebuilt-read`
- `prebuilt-layout`
- Custom document analyzers without fields

For binary inline input, see [Sample 19][sample19].

## Example

```C# Snippet:ContentUnderstandingAnalyzeInlineAsync
// Inline analysis returns AnalysisResult directly (HTTP 200) with no polling.
// Non-Succeeded inline operation status values throw RequestFailedException, like a failed LRO.
Response<AnalysisResult> inlineResponse = await client.AnalyzeInlineAsync(
    "prebuilt-layout",
    inputs: new[]
    {
        new AnalysisInput
        {
            Uri = uriSource
        }
    });

AnalysisResult inlineResult = inlineResponse.Value;
```

Read usage from the same inline response. `GetUsageDetails()` returns generated `UsageDetails`, matching [Sample 03][sample03].

Inline analyze reports `DocumentPages*Inline` meters. For which meter applies to a given analyzer and input, see the [Content Understanding pricing explainer][pricing-explainer].

```C# Snippet:ContentUnderstandingAnalyzeInlineGetUsageDetails
// Inline analyze reports DocumentPages*Inline meters (see pricing docs for which
// meter applies). This sample prints the standard inline page meter.
UsageDetails? usage = inlineResponse.GetUsageDetails();
if (usage != null)
{
    Console.WriteLine($"Document pages (standard inline): {usage.DocumentPagesStandardInline}");
    Console.WriteLine($"Contextualization tokens: {usage.ContextualizationTokens}");
}
```

[sample03]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample03_AnalyzeInvoice.md
[sample19]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample19_AnalyzeBinaryInline.md
[pricing-explainer]: https://learn.microsoft.com/azure/ai-services/content-understanding/pricing-explainer
