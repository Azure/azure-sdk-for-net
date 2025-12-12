# Analyze content from URLs across modalities

This sample demonstrates analyzing accessible URLs with the prebuilt analyzers (`prebuilt-documentSearch`, `prebuilt-videoSearch`, `prebuilt-audioSearch`, and `prebuilt-imageSearch`). Content Understanding supports both local binary inputs (see [Sample01_AnalyzeBinary][sample01-analyze-binary]) and URL inputs across all modalities; these prebuilt analyzers return markdown, a one-paragraph `Summary`, and many other properties per content item.

## Document from a URL

Use the `prebuilt-documentSearch` analyzer with a public document URL.

> Content Understanding operations are long-running; the SDK handles polling when using `WaitUntil.Completed`.

```C# Snippet:ContentUnderstandingAnalyzeUrlAsync
// You can replace this URL with your own publicly accessible document URL.
// For a list of supported document types for prebuilt-documentSearch, see:
// https://learn.microsoft.com/azure/ai-services/content-understanding/service-limits#document-and-text
Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf");
Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-documentSearch",
    inputs: new[] { new AnalyzeInput { Url = uriSource } });

AnalyzeResult result = operation.Value;

MediaContent content = result.Contents!.First();
Console.WriteLine("Markdown:");
Console.WriteLine(content.Markdown);

DocumentContent documentContent = (DocumentContent)content;
Console.WriteLine($"MIME type: {documentContent.MimeType}");
Console.WriteLine($"Pages: {documentContent.StartPageNumber} - {documentContent.EndPageNumber}");
Console.WriteLine($"Tables found: {documentContent.Tables?.Count ?? 0}");
```

## Video from a URL

Analyze video content (with transcript, shots, and segments enabled) using `prebuilt-videoSearch`. Markdown output follows the video markdown schema described in [Video markdown][cu-video-markdown]. The analyzer divides the video into topic- or scene-based segments rather than returning one long segment.

```C# Snippet:ContentUnderstandingAnalyzeVideoUrlAsync
Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/videos/sdk_samples/FlightSimulator.mp4");
Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-videoSearch",
    inputs: new[] { new AnalyzeInput { Url = uriSource } });

AnalyzeResult result = operation.Value;

int segmentIndex = 1;
foreach (MediaContent media in result.Contents!)
{
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

```C# Snippet:ContentUnderstandingAnalyzeAudioUrlAsync
Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/audio/callCenterRecording.mp3");
Operation<AnalyzeResult> operation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-audioSearch",
    inputs: new[] { new AnalyzeInput { Url = uriSource } });

AnalyzeResult result = operation.Value;

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

Analyze images with `prebuilt-imageSearch`. As described in [prebuilt analyzers][cu-prebuilt-analyzers], this analyzer returns markdown plus a one-paragraph description of the image content.

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

- Explore more scenarios in the [samples directory][samples-directory]
- Learn about creating custom analyzers and classifiers

## Learn more

- **[Content Understanding overview][cu-overview]** - Service capabilities and scenarios
- **[Document markdown][cu-document-markdown]** - Markdown format for documents
- **[Video overview][cu-video-overview]** - Video analysis capabilities and markdown structure
- **[Video elements][cu-video-elements]** - Audio/visual result schema (segments, timing, key frames)
- **[Audio overview][cu-audio-overview]** - Audio analysis capabilities
- **[Image overview][cu-image-overview]** - Image analysis capabilities
- **[Document elements][cu-document-elements]** - Detailed document extraction reference
- **[Prebuilt analyzers][cu-prebuilt-analyzers]** - What `prebuilt-documentSearch`, `prebuilt-videoSearch`, `prebuilt-audioSearch`, and many other ready-to-use analyzers
- **[Sample01_AnalyzeBinary][sample01-analyze-binary]** - Basics of analysis and result processing

[sample01-analyze-binary]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
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
