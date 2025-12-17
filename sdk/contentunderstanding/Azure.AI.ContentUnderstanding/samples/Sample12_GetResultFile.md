# Get result files from analysis

This sample demonstrates how to retrieve result files (such as keyframe images) from a video analysis operation using the `GetResultFile` API.

## About result files

When analyzing video content, the Content Understanding service can generate result files such as:
- **Keyframe images**: Extracted frames from the video at specific timestamps
- **Other result files**: Additional files generated during analysis

The `GetResultFile` API allows you to retrieve these files using:
- **Operation ID**: Extracted from the analysis operation
- **File path**: The path to the specific result file. In the recording, keyframes were accessed with paths like `keyframes/733` and `keyframes/9000`, following the `keyframes/{frameTimeMs}` pattern.

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

## Analyze video for result files

Analyze a video to generate result files:

> **Note**: The following code uses `WaitUntil.Completed` to wait for the analysis to finish. If you need to get the operation ID earlier (for example, to track the operation or retrieve result files while it's still running), use `WaitUntil.Started` instead. The operation ID is available immediately after the operation starts.

```C# Snippet:ContentUnderstandingAnalyzeVideoForResultFiles
// For testing, use a video URL to get keyframes for GetResultFile testing
// You can replace this with your own video file URL
Uri videoUrl = new Uri("https://github.com/Azure-Samples/azure-ai-content-understanding-assets/raw/refs/heads/main/videos/sdk_samples/FlightSimulator.mp4");
// Analyze and wait for completion
var analyzeOperation = await client.AnalyzeAsync(
    WaitUntil.Completed,
    "prebuilt-videoSearch",
    inputs: new[] { new AnalyzeInput { Url = videoUrl } });

// Get the operation ID - this is needed to retrieve result files later
string operationId = analyzeOperation.Id;
Console.WriteLine($"Operation ID: {operationId}");
AnalyzeResult result = analyzeOperation.Value;
```

## Get result file

Retrieve a result file (keyframe image) using the operation ID and file path:

```C# Snippet:ContentUnderstandingGetResultFile
// GetResultFile is used to retrieve result files (like keyframe images) from video analysis
// The path format is: "keyframes/{frameTimeMs}" where frameTimeMs is the timestamp in milliseconds

// Example: Get a keyframe image (if available)
// Note: This example demonstrates the API pattern. In production, you would:
// 1. Analyze a video to get keyframe timestamps
// 2. Use those timestamps to construct paths like "keyframes/1000" for the frame at 1000ms
// 3. Call GetResultFileAsync with the operation ID and path

// For video analysis, keyframes would be found in AudioVisualContent.KeyFrameTimesMs
// Cast MediaContent to AudioVisualContent to access video-specific properties
AudioVisualContent videoContent = (AudioVisualContent)result.Contents!.First();
// Print keyframe information
int totalKeyframes = videoContent.KeyFrameTimesMs!.Count;
long firstFrameTimeMs = videoContent.KeyFrameTimesMs[0];
Console.WriteLine($"Total keyframes: {totalKeyframes}");
Console.WriteLine($"First keyframe time: {firstFrameTimeMs} ms");

// Get the first keyframe as an example
string framePath = $"keyframes/{firstFrameTimeMs}";

Console.WriteLine($"Getting result file: {framePath}");

// Get the result file (keyframe image) using the operation ID obtained from Operation<T>.Id
Response<BinaryData> fileResponse = await client.GetResultFileAsync(
    operationId,
    framePath);

byte[] imageBytes = fileResponse.Value.ToArray();
Console.WriteLine($"Retrieved keyframe image ({imageBytes.Length:N0} bytes)");

// Save the keyframe image to sample_output directory
string outputDir = Path.Combine(AppContext.BaseDirectory, "sample_output");
Directory.CreateDirectory(outputDir);
string outputFileName = $"keyframe_{firstFrameTimeMs}.jpg";
string outputPath = Path.Combine(outputDir, outputFileName);
File.WriteAllBytes(outputPath, imageBytes);

Console.WriteLine($"Keyframe image saved to: {outputPath}");
```

## Next steps

- [Sample 13: Delete result][sample13] - Learn how to delete analysis results
- [Sample 01: Analyze binary][sample01] - Learn more about basic document analysis

## Learn more

- [Content Understanding documentation][cu-docs]
- [Video analysis][video-docs] - Learn about video analysis capabilities

[sample00]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample00_UpdateDefaults.md
[sample01]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample01_AnalyzeBinary.md
[sample13]:  https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/contentunderstanding/Azure.AI.ContentUnderstanding/samples/Sample13_DeleteResult.md
[cu-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/
[video-docs]: https://learn.microsoft.com/azure/ai-services/content-understanding/video/overview

