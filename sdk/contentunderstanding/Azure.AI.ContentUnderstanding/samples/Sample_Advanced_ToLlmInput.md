# Convert analysis results to LLM-friendly text

This sample demonstrates advanced usage of `.ToLlmInput()`. For a basic introduction to `ToLlmInput`, see [Sample 01: Analyze binary][sample01-analyze-binary] (document analysis), [Sample 03: Analyze invoice][sample03-analyze-invoice] (field extraction), and [Sample 05: Create classifier][sample05-create-classifier] (classification).

## About `ToLlmInput`

The `.ToLlmInput` method converts a CU `AnalysisResult` into a formatted text string (YAML front matter + markdown body) suitable for injecting into LLM prompts, storing in vector databases, or returning as tool output in agentic workflows.

When using Content Understanding with large language models, you typically need to convert the structured `AnalysisResult` into a text format that an LLM can consume. The `ToLlmInput` helper handles this conversion automatically:

- **YAML front matter** with content type, extracted fields, page numbers, and optional metadata
- **Markdown body** with the document content and page markers (e.g., `<!-- page 1 -->`)

The helper supports all content types (documents, images, audio, video) and handles multi-segment results (e.g., video with multiple scenes) by rendering each segment with its time range. For classification results, it automatically skips the parent document and renders each categorized child with its category label.

### Scenarios demonstrated

1. **Output options** — Fields-only, markdown-only, and custom metadata
2. **Multi-page PDF with ContentRange** — Analyze specific pages and verify page markers
3. **Multi-segment video** — Analyze a video with multiple segments and time ranges
4. **Audio with ContentRange** — Analyze a specific time range of an audio file

For classification results, see [Sample 05: Create classifier][sample05-create-classifier].

## Prerequisites

To get started you'll need a **Microsoft Foundry resource**. See [Sample 00: Configure model deployment defaults][sample00] for setup guidance.

## Creating a `ContentUnderstandingClient`

For full client setup details, see [Sample 00: Configure model deployment defaults][sample00].

```C# Snippet:CreateContentUnderstandingClient
// Example: https://your-foundry.services.ai.azure.com/
string endpoint = "<endpoint>";
var credential = new DefaultAzureCredential();
var client = new ContentUnderstandingClient(new Uri(endpoint), credential);
```

## Basic usage

Analyze a document and convert the result to LLM-ready text:

```C# Snippet:ContentUnderstandingToLlmInput
// Analyze an invoice to get a result we can demonstrate options with.
Uri invoiceUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf");

Operation<AnalysisResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-invoice",
    inputs: new[] { new AnalysisInput { Uri = invoiceUrl } });

AnalysisResult result = operation.Value;

// Convert to LLM-ready text (YAML front matter + markdown)
string text = result.ToLlmInput();
Console.WriteLine("Default output (fields + markdown):");
Console.WriteLine(text);
```

## Output options

Control what's included in the output:

```C# Snippet:ContentUnderstandingToLlmInputOptions
// Fields-only mode — smaller token footprint when you only need structured data.
// Useful for agentic workflows where the LLM only needs extracted values.
string fieldsOnly = result.ToLlmInput(options: new LlmInputOptions { IncludeMarkdown = false });
Console.WriteLine("\n--- Fields only (includeMarkdown: false) ---");
Console.WriteLine(fieldsOnly);

// Markdown-only mode — when you only need the document text.
// Useful for summarization or when fields are not relevant.
string markdownOnly = result.ToLlmInput(options: new LlmInputOptions { IncludeFields = false });
Console.WriteLine("\n--- Markdown only (includeFields: false) ---");
Console.WriteLine(markdownOnly);

// Custom metadata — add your own key-value pairs to the YAML front matter.
// Useful for RAG pipelines to track document source, department, batch, etc.
string withMetadata = result.ToLlmInput(
    new Dictionary<string, object>
    {
        ["source"] = "invoice.pdf",
        ["department"] = "finance"
    });
Console.WriteLine("\n--- With metadata ---");
Console.WriteLine(withMetadata);
```

## Multi-page PDF with content range

Analyze specific pages and see original page numbers in the output:

```C# Snippet:ContentUnderstandingToLlmInputContentRange
Uri multiPageUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/mixed_financial_invoices.pdf");

// Analyze specific pages using ContentRange.
// Page markers in the output will use the original document page numbers,
// so even though we only requested pages 2-3 and 5, the markers will say
// <!-- page 2 -->, <!-- page 3 -->, <!-- page 5 --> (not 1, 2, 3).
Operation<AnalysisResult> multiPageOperation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    inputs: new[]
    {
        new AnalysisInput
        {
            Uri = multiPageUrl,
            ContentRange = new ContentRange("2-3,5")
        }
    });

AnalysisResult multiPageResult = multiPageOperation.Value;
string multiPageText = multiPageResult.ToLlmInput();
Console.WriteLine("\n--- Multi-page PDF with content range ---");
Console.WriteLine(multiPageText);
```

## Multi-segment video

Analyze a video — each segment gets its own front matter with a time range:

```C# Snippet:ContentUnderstandingToLlmInputVideo
Uri videoUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/videos/sdk_samples/FlightSimulator.mp4");

// Analyze a video — the result may contain multiple segments.
// LlmInputHelper renders each segment with its time range in the front matter
// (e.g., timeRange: 00:00 – 00:15) and separates segments with ***** dividers.
Operation<AnalysisResult> videoOperation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-videoSearch",
    inputs: new[] { new AnalysisInput { Uri = videoUrl } });

AnalysisResult videoResult = videoOperation.Value;
string videoText = videoResult.ToLlmInput();
Console.WriteLine($"\nVideo produced {videoResult.Contents!.Count} segment(s)");
Console.WriteLine("\n--- Multi-segment video ---");
Console.WriteLine(videoText);
```

## Audio with content range

Analyze a specific time range of an audio file with metadata:

```C# Snippet:ContentUnderstandingToLlmInputAudio
Uri audioUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/audio/callCenterRecording.mp3");

// Analyze a specific time range of an audio file (first 10 seconds).
// For audio, ContentRange uses milliseconds: "0-10000" means 0s to 10s.
Operation<AnalysisResult> audioOperation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-audioSearch",
    inputs: new[]
    {
        new AnalysisInput
        {
            Uri = audioUrl,
            ContentRange = new ContentRange("0-10000")
        }
    });

AnalysisResult audioResult = audioOperation.Value;

// Include metadata to track the source file in RAG pipelines
string audioText = audioResult.ToLlmInput(
    new Dictionary<string, object> { ["source"] = "callCenterRecording.mp3" });
Console.WriteLine("\n--- Audio with content range and metadata ---");
Console.WriteLine(audioText);
```

## Next steps

- [Sample 01: Analyze binary][sample01-analyze-binary] — Basic document analysis with `ToLlmInput`
- [Sample 03: Analyze invoice][sample03-analyze-invoice] — Invoice field extraction with `ToLlmInput`
- [Sample 05: Create classifier][sample05-create-classifier] — Classification results with `ToLlmInput`
- Explore more scenarios in the [samples directory][samples-directory]

## Learn more

- **[Content Understanding overview][cu-overview]** — Service capabilities and scenarios
- **[Document markdown][cu-document-markdown]** — Markdown format and structure for document content
- **[Prebuilt analyzers][prebuilt-analyzers-docs]** — Complete list of prebuilt analyzers

[sample00]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01-analyze-binary]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample03-analyze-invoice]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample03_AnalyzeInvoice.md
[sample05-create-classifier]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample05_CreateClassifier.md
[samples-directory]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples
[cu-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/overview
[cu-document-markdown]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/markdown
[prebuilt-analyzers-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers
