# Analyze content from URLs across modalities

Another great value of Content Understanding is its rich set of prebuilt analyzers. Great examples of these are the RAG analyzers that work for all modalities (`prebuilt-documentSearch`, `prebuilt-imageSearch`, `prebuilt-audioSearch`, and `prebuilt-videoSearch`). For brief descriptions of these RAG analyzers, see the [Prebuilt analyzers section in Sample 01][sample01-analyze-binary]. This sample demonstrates these RAG analyzers. Many more prebuilt analyzers are available (for example, `prebuilt-invoice`); see the invoice sample or the prebuilt analyzer documentation to explore the full list.

## About analyzing URLs across modalities

Content Understanding supports both local binary inputs (see [Sample01_AnalyzeBinary][sample01-analyze-binary]) and URL inputs across all modalities. This sample focuses on prebuilt RAG analyzers (the `prebuilt-*Search` analyzers, such as `prebuilt-documentSearch`) with URL inputs.

**Important**: For URL inputs, use `AnalyzeAsync()` with `AnalyzeInput` objects that wrap the URL. For binary data (local files), use `AnalyzeBinaryAsync()` instead. This sample demonstrates `AnalyzeAsync()` with URL inputs.

Documents, HTML, and images with text are returned as `DocumentContent` (derived from `MediaContent`), while audio and video are returned as `AudioVisualContent` (also derived from `MediaContent`). These prebuilt RAG analyzers return markdown and a one-paragraph `Summary` for each content item; `prebuilt-videoSearch` can return multiple segments, so iterate over all contents rather than just the first.

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

## Document from a URL

Use the `prebuilt-documentSearch` analyzer with a public document URL. Note that for URL inputs, use `AnalyzeAsync()` with `AnalyzeInput` objects (as shown below). For binary data from local files, use `AnalyzeBinaryAsync()` instead (see [Sample01_AnalyzeBinary][sample01-analyze-binary]).

> Content Understanding operations are long-running; the SDK handles polling when using `WaitUntil.Completed`.

For a list of supported document types for `prebuilt-documentSearch`, see [Service limits][cu-service-limits].

Use `AnalyzeAsync()` with `AnalyzeInput` objects that wrap the URL. The result contains `MediaContent` items that expose markdown and detailed properties. For documents, cast to `DocumentContent` to access document-specific properties such as pages and tables.

```C# Snippet:ContentUnderstandingAnalyzeUrlAsync
// You can replace this URL with your own publicly accessible document URL.
Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf");

Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    inputs: new[] { new AnalyzeInput { Url = uriSource } });

AnalyzeResult result = operation.Value;
MediaContent content = result.Contents!.First();
Console.WriteLine("Markdown:");
Console.WriteLine(content.Markdown);

// Cast MediaContent to DocumentContent to access document-specific properties
// DocumentContent derives from MediaContent and provides additional properties
// to access full information about document, including Pages, Tables and many others
DocumentContent documentContent = (DocumentContent)content;
Console.WriteLine($"Pages: {documentContent.StartPageNumber} - {documentContent.EndPageNumber}");

// Check for pages
if (documentContent.Pages != null && documentContent.Pages.Count > 0)
{
    Console.WriteLine($"Number of pages: {documentContent.Pages.Count}");
    foreach (var page in documentContent.Pages)
    {
        var unit = documentContent.Unit?.ToString() ?? "units";
        Console.WriteLine($"  Page {page.PageNumber}: {page.Width} x {page.Height} {unit}");
    }
}
```

## Video from a URL

Analyze video content (with transcript, shots, and segments enabled) using `prebuilt-videoSearch`. Markdown output follows the video markdown schema described in [Video markdown][cu-video-markdown]. The analyzer divides the video into topic- or scene-based segments rather than returning one long segment.

For video content, cast `MediaContent` to `AudioVisualContent` to access video-specific properties such as timing information, transcript phrases, and frame dimensions. Iterate through all segments as `prebuilt-videoSearch` can return multiple segments.

```C# Snippet:ContentUnderstandingAnalyzeVideoUrlAsync
Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/videos/sdk_samples/FlightSimulator.mp4");
Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-videoSearch",
    inputs: new[] { new AnalyzeInput { Url = uriSource } });

AnalyzeResult result = operation.Value;

// prebuilt-videoSearch can detect video segments, so we should iterate through all segments
int segmentIndex = 1;
foreach (MediaContent media in result.Contents!)
{
    // Cast MediaContent to AudioVisualContent to access audio/visual-specific properties
    // AudioVisualContent derives from MediaContent and provides additional properties
    // to access full information about audio/video, including timing, transcript phrases, and many others
    AudioVisualContent videoContent = (AudioVisualContent)media;
    Console.WriteLine($"--- Segment {segmentIndex} ---");
    Console.WriteLine("Markdown:");
    Console.WriteLine(videoContent.Markdown);

    string summary = videoContent.Fields["Summary"].Value?.ToString() ?? string.Empty;
    Console.WriteLine($"Summary: {summary}");

    Console.WriteLine($"Start: {videoContent.StartTimeMs} ms, End: {videoContent.EndTimeMs} ms");
    Console.WriteLine($"Frame size: {videoContent.Width} x {videoContent.Height}");

    Console.WriteLine("---------------------");
    segmentIndex++;
}
```

## Audio from a URL

Analyze audio content with `prebuilt-audioSearch`. The returned markdown captures transcript and structure similar to video markdown, and you can read summaries.

For audio content, cast `MediaContent` to `AudioVisualContent` to access audio-specific properties such as transcript phrases with speaker diarization and timing information.

```C# Snippet:ContentUnderstandingAnalyzeAudioUrlAsync
Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/audio/callCenterRecording.mp3");
Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-audioSearch",
    inputs: new[] { new AnalyzeInput { Url = uriSource } });

AnalyzeResult result = operation.Value;

// Cast MediaContent to AudioVisualContent to access audio/visual-specific properties
// AudioVisualContent derives from MediaContent and provides additional properties
// to access full information about audio/video, including timing, transcript phrases, and many others
AudioVisualContent audioContent = (AudioVisualContent)result.Contents!.First();
Console.WriteLine("Markdown:");
Console.WriteLine(audioContent.Markdown);

string summary = audioContent.Fields["Summary"].Value?.ToString() ?? string.Empty;
Console.WriteLine($"Summary: {summary}");

// Example: Access an additional field in AudioVisualContent (transcript phrases)
if (audioContent.TranscriptPhrases != null && audioContent.TranscriptPhrases.Count > 0)
{
    Console.WriteLine("Transcript (first two phrases):");
    foreach (TranscriptPhrase phrase in audioContent.TranscriptPhrases.Take(2))
    {
        Console.WriteLine($"  [{phrase.Speaker}] {phrase.StartTimeMs} ms: {phrase.Text}");
    }
}
```

## Image from a URL

Analyze images with `prebuilt-imageSearch`. As described in [prebuilt analyzers][cu-prebuilt-analyzers], this analyzer returns a one-paragraph `Summary` of the image content. For images that contain text (including hand-written text), use `prebuilt-documentSearch`.

Access the `Summary` field from the `Fields` dictionary to get the image description.

```C# Snippet:ContentUnderstandingAnalyzeImageUrlAsync
Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/image/pieChart.jpg");
Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-imageSearch",
    inputs: new[] { new AnalyzeInput { Url = uriSource } });

AnalyzeResult result = operation.Value;

MediaContent content = result.Contents!.First();
Console.WriteLine("Markdown:");
Console.WriteLine(content.Markdown);

string summary = content.Fields["Summary"].Value?.ToString() ?? string.Empty;
Console.WriteLine($"Summary: {summary}");
```

## Next steps

- **[Sample 03: Analyze an invoice using prebuilt analyzer][sample03]** - Learn about domain-specific prebuilt analyzers
- Explore more scenarios in the [samples directory][samples-directory]

## Learn more

- **[Content Understanding overview][cu-overview]** - Service capabilities and scenarios
- **[Document markdown][cu-document-markdown]** - Markdown format for documents
- **[Document elements][cu-document-elements]** - Detailed document extraction reference
- **[Video overview][cu-video-overview]** - Video analysis capabilities and markdown structure
- **[Video elements][cu-video-elements]** - Audio/visual result schema (segments, timing, key frames)
- **[Audio overview][cu-audio-overview]** - Audio analysis capabilities
- **[Image overview][cu-image-overview]** - Image analysis capabilities
- **[Prebuilt analyzers][cu-prebuilt-analyzers]** - What `prebuilt-documentSearch`, `prebuilt-videoSearch`, `prebuilt-audioSearch`, and many other ready-to-use analyzers
- **[Sample01_AnalyzeBinary][sample01-analyze-binary]** - Basics of analysis and result processing

[sample01-analyze-binary]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample03]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample03_AnalyzeInvoice.md
[samples-directory]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples
[cu-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/overview
[cu-document-markdown]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/markdown
[cu-video-markdown]: https://learn.microsoft.com/azure/ai-services/content-understanding/video/markdown
[cu-image-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/image/overview
[cu-document-elements]: https://learn.microsoft.com/azure/ai-services/content-understanding/document/elements
[cu-video-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/video/overview
[cu-audio-overview]: https://learn.microsoft.com/azure/ai-services/content-understanding/audio/overview
[cu-video-elements]: https://learn.microsoft.com/azure/ai-services/content-understanding/video/elements
[cu-prebuilt-analyzers]: https://learn.microsoft.com/azure/ai-services/content-understanding/concepts/prebuilt-analyzers
[cu-service-limits]: https://learn.microsoft.com/azure/ai-services/content-understanding/service-limits#document-and-text
[sample00]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
