# Get result files from analysis

This sample demonstrates how to retrieve result files (such as keyframe images) from a video analysis operation using the `GetResultFile` API.

## Before you begin

This sample builds on concepts introduced in previous samples:
- [Sample 01: Analyze a document from binary data][sample01] - Basic analysis concepts

## About result files

When analyzing video content, the Content Understanding service can generate result files such as:
- **Keyframe images**: Extracted frames from the video at specific timestamps
- **Other result files**: Additional files generated during analysis

The `GetResultFile` API allows you to retrieve these files using:
- **Operation ID**: Extracted from the analysis operation
- **File path**: The path to the specific result file (e.g., `"keyframes/{frameTimeMs}"` for keyframe images)

## Prerequisites

To get started you'll need a **Microsoft Foundry resource** with model deployments configured. See [Sample 00][sample00] for setup instructions.

## Creating a `ContentUnderstandingClient`

See [Sample 01][sample01] for authentication examples using `DefaultAzureCredential` or API key.

## Analyze video for result files

Analyze a video to generate result files:

```C# Snippet:ContentUnderstandingAnalyzeVideoForResultFiles
Uri videoUrl = new Uri("<videoUrl>");

// Analyze a video to generate result files (keyframes)
// Note: Video analysis may take several minutes to complete
var analyzeOperation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-videoSearch",
    inputs: new[] { new AnalyzeInput { Url = videoUrl } });

AnalyzeResult result = analyzeOperation.Value;

// Get the operation ID from the operation
// The operation ID is needed to retrieve result files
string operationId = analyzeOperation.GetOperationId() ?? throw new InvalidOperationException("Could not extract operation ID from operation");
Console.WriteLine($"Operation ID: {operationId}");
```

## Get result file

Retrieve a result file (keyframe image) using the operation ID and file path:

```C# Snippet:ContentUnderstandingGetResultFile
// Find keyframes in the analysis result
var videoContent = result.Contents?.FirstOrDefault(c => c is AudioVisualContent) as AudioVisualContent;
if (videoContent?.KeyFrameTimesMs != null && videoContent.KeyFrameTimesMs.Count > 0)
{
    // Get the first keyframe as an example
    long frameTimeMs = videoContent.KeyFrameTimesMs[0];
    string framePath = $"keyframes/{frameTimeMs}";

    Console.WriteLine($"Getting result file: {framePath}");

    // Get the result file (keyframe image)
    Response<BinaryData> fileResponse = await client.GetResultFileAsync(
        operationId,
        framePath);

    byte[] imageBytes = fileResponse.Value.ToArray();
    Console.WriteLine($"Retrieved keyframe image ({imageBytes.Length:N0} bytes)");

    // The image bytes can be saved to a file or processed as needed
    // Example: await File.WriteAllBytesAsync("keyframe.jpg", imageBytes);
}
else
{
    Console.WriteLine("No keyframes found in the analysis result.");
    Console.WriteLine("Note: Keyframes may not be generated for all video analyses.");
    Console.WriteLine("      This sample demonstrates the GetResultFile API usage.");
}
```

## Next Steps

- [Sample 13: Delete result][sample13] - Learn how to delete analysis results
- [Sample 01: Analyze binary][sample01] - Learn more about basic document analysis

## Learn More

- [Content Understanding Documentation][cu-docs]
- [Video Analysis][video-docs] - Learn about video analysis capabilities

[sample00]: Sample00_ConfigureDefaults.md
[sample01]: Sample01_AnalyzeBinary.md
[sample13]: Sample13_DeleteResult.md
[cu-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/
[video-docs]: https://learn.microsoft.com/en-us/azure/ai-services/content-understanding/video/overview

