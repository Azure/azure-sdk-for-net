# Analyze a URL input inline without polling

This sample shows `AnalyzeInlineAsync` for URL-based inputs. This API is **available only** in service API version `2026-06-01-preview`.

> **Preview only:** Configure the client with `new ContentUnderstandingClientOptions(ContentUnderstandingClientOptions.ServiceVersion.V2026_06_01_Preview)`.

By default, `AnalyzeAsync` is a long-running operation (LRO): the client starts analysis and polls until the result is ready. `AnalyzeInlineAsync` completes analysis in a single call and returns `AnalysisResult` without polling, which can reduce latency for small files with supported analyzers.

## How to choose

Use `AnalyzeAsync` / `AnalyzeBinaryAsync` (LRO) when:
- You need larger files or more pages (see [document limits](https://aka.ms/cu-doc-limits)).
- You need broader analyzer coverage.
- You want results retained for up to **24 hours** (or until you delete them) and operation lifecycle APIs (`Operation-Location` / operation ID).

Use `AnalyzeInlineAsync` (available only in `2026-06-01-preview`) when:
- You want a single request/response call with no polling.
- You want faster results for smaller inputs — with no polling and no wait tied to a polling interval, the inline path is faster than the corresponding `Analyze*` LRO APIs under the inline size/analyzer limits.
- Your analyzer is in the supported inline set below (no field schema / field extraction).

For current limits, see https://aka.ms/cu-doc-limits.

## Supported inline analyzers (2026-06-01-preview only)

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
