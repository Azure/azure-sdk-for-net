# Convert analysis results to LLM-friendly text

This sample demonstrates advanced usage of `.ToLlmInput()`. For a basic introduction to `ToLlmInput`, see [Sample 01: Analyze binary][sample01-analyze-binary] (document analysis), [Sample 03: Analyze invoice][sample03-analyze-invoice] (field extraction), and [Sample 05: Create classifier][sample05-create-classifier] (classification).

## About `ToLlmInput`

The `.ToLlmInput` method converts a CU `AnalysisResult` into a formatted text string (YAML front matter + markdown body) suitable for injecting into LLM prompts, storing in vector databases, or returning as tool output in agentic workflows.

When using Content Understanding with large language models, you typically need to convert the structured `AnalysisResult` into a text format that an LLM can consume. The `ToLlmInput` helper handles this conversion automatically:

- **YAML front matter** with content type, extracted fields, page numbers, and optional metadata
- **Markdown body** with the document content and page markers (e.g., `<!-- InputPageNumber: 1 -->`)

The helper supports all content types (documents, images, audio, video) and handles multi-segment results (e.g., video with multiple scenes) by rendering each segment with its time range. For classification results, it automatically skips the parent document and renders each categorized child with its category label.

### Scenarios demonstrated

1. **Output options** — Fields-only, markdown-only, and caller `customMetadata`
2. **Preview metadata from analysis result** — Analyze a sample PDF with embedded metadata and include it in `ToLlmInput` output
3. **Multi-page PDF with ContentRange** — Analyze specific pages and verify page markers
4. **Multi-segment video** — Analyze a video with multiple segments and time ranges
5. **Audio with ContentRange** — Analyze a specific time range of an audio file

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

// Custom metadata — nested under customMetadata: so it never collides with
// helper-owned keys (mimeType, fields, metadata, …). Useful for RAG pipelines
// to track document source, department, batch, etc.
string withCustomMetadata = result.ToLlmInput(
    new Dictionary<string, object>
    {
        ["source"] = "invoice.pdf",
        ["department"] = "finance"
    });
Console.WriteLine("\n--- With customMetadata ---");
Console.WriteLine(withCustomMetadata);
```

Example front matter showing the nested `customMetadata` block (fields/markdown omitted for brevity):

```text
---
mimeType: application/pdf
customMetadata:
  source: invoice.pdf
  department: finance
pages: 1
---
```

## Preview API: metadata from analysis result

> **Preview-only:** This scenario requires service API version `2026-06-01-preview`.
> Metadata shape and availability can change in future preview versions.

Analyze a PDF with embedded metadata and convert the result to LLM input.
The snippet assumes `previewClient` was created with service version `V2026_06_01_Preview`:

```C# Snippet:ContentUnderstandingToLlmInputMetadataFromAnalysisResultPreview
// This scenario requires preview API version 2026-06-01-preview.
string metadataPdfPath = "<path-to-pdf-with-embedded-metadata>";
BinaryData metadataPdfData = BinaryData.FromBytes(File.ReadAllBytes(metadataPdfPath));

Operation<AnalysisResult> metadataOperation = await previewClient.AnalyzeBinaryAsync(
    WaitUntil.Completed,
    "prebuilt-layout",
    metadataPdfData);

// ToLlmInput includes AnalysisContent.Metadata under the "metadata" block.
string metadataText = metadataOperation.Value.ToLlmInput();
Console.WriteLine("\n--- Preview metadata from analysis result ---");
Console.WriteLine(metadataText);
```

Example output from the sample metadata PDF:

```text
---
mimeType: application/pdf
metadata:
  author: Contoso Metadata Team
  contentType: application/pdf
  language: en-US
  pageCount: '1'
  title: Contoso Metadata Extraction Sample
pages: 1
---
```

## Multi-page PDF with content range

Analyze specific pages and see original page numbers in the output:

```C# Snippet:ContentUnderstandingToLlmInputContentRange
Uri multiPageUrl = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/mixed_financial_invoices.pdf");

// Analyze specific pages using ContentRange.
// Page markers in the output will use the original document page numbers,
// so markers will say <!-- InputPageNumber: 2 -->, <!-- InputPageNumber: 3 -->,
// <!-- InputPageNumber: 5 --> (not renumbered 1, 2, 3).
Operation<AnalysisResult> multiPageOperation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    inputs: new[]
    {
        new AnalysisInput
        {
            Uri = multiPageUrl,
            ContentRange = ContentRange.Combine(ContentRange.Pages(2, 3), ContentRange.Page(5))
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

// Include customMetadata to track the source file in RAG pipelines
string audioText = audioResult.ToLlmInput(
    new Dictionary<string, object> { ["source"] = "callCenterRecording.mp3" });
Console.WriteLine("\n--- Audio with content range and customMetadata ---");
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
