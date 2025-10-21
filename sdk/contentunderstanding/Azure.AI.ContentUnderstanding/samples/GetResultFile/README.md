# Get Result File Sample

This sample demonstrates how to retrieve result files (such as keyframe images) from an analysis operation using the Azure AI Content Understanding SDK for .NET.

## What This Sample Does

This sample shows how to:

1. **Authenticate** with Azure AI Content Understanding using either an API key or DefaultAzureCredential
2. **Create a video analyzer** using the prebuilt video analyzer
3. **Analyze a video file** to generate keyframes
4. **Extract the operation ID** from the analysis poller
5. **Retrieve result files** (keyframe images) using the operation ID
6. **Save keyframe images** to local files
7. **Clean up resources** by deleting the created analyzer

## Prerequisites

- .NET 8.0 SDK or later
- Azure AI Content Understanding resource

## Configuration

### Option 1: Using appsettings.json

Create or update `appsettings.json` in the parent `samples` directory:

```json
{
  "AzureContentUnderstanding": {
    "Endpoint": "https://your-resource.services.ai.azure.com/",
    "Key": "your-api-key-here"
  }
}
```

### Option 2: Using Environment Variables

Set the following environment variables:

```bash
export AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource.services.ai.azure.com/"
export AZURE_CONTENT_UNDERSTANDING_KEY="your-api-key-here"  # Optional - will use DefaultAzureCredential if not set
```

**Note:** Environment variables take precedence over appsettings.json values.

## Running the Sample

1. Navigate to the sample directory:
   ```bash
   cd samples/GetResultFile
   ```

2. Restore dependencies:
   ```bash
   dotnet restore
   ```

3. Run the sample:
   ```bash
   dotnet run
   ```

## Expected Output

```
🔧 Creating marketing video analyzer 'sdk-sample-video-20251016-153045-abc12345'...
📋 Extracted creation operation ID: xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
⏳ Waiting for analyzer creation to complete...
✅ Analyzer 'sdk-sample-video-20251016-153045-abc12345' created successfully!
📹 Using video file from URL: https://github.com/Azure-Samples/azure-ai-content-understanding-assets/raw/refs/heads/main/videos/sdk_samples/FlightSimulator.mp4
🎬 Starting video analysis with analyzer 'sdk-sample-video-20251016-153045-abc12345'...
⏳ Waiting for video analysis to complete...
✅ Video analysis completed successfully!
📋 Extracted analysis operation ID: yyyyyyyy-yyyy-yyyy-yyyy-yyyyyyyyyyyy
🔍 Using analysis result to find available files...
✅ Analysis result contains 1 contents
KeyFrameTimesMs: 0, 5000, 10000, 15000, 20000, 25000, 30000
📹 Found 7 keyframes in video content
🖼️  Found 7 keyframe times in milliseconds
📥 Downloading 3 keyframe images as examples: [keyFrame.0, keyFrame.15000, keyFrame.30000]
📥 Getting result file: keyFrame.0
✅ Retrieved image file for keyFrame.0 (45678 bytes)
💾 Keyframe image saved to: test_output/GetResultFile/sdk-sample-video-20251016-153045-abc12345/keyFrame.0.jpg
📥 Getting result file: keyFrame.15000
✅ Retrieved image file for keyFrame.15000 (47890 bytes)
💾 Keyframe image saved to: test_output/GetResultFile/sdk-sample-video-20251016-153045-abc12345/keyFrame.15000.jpg
📥 Getting result file: keyFrame.30000
✅ Retrieved image file for keyFrame.30000 (46234 bytes)
💾 Keyframe image saved to: test_output/GetResultFile/sdk-sample-video-20251016-153045-abc12345/keyFrame.30000.jpg

🗑️  Deleting analyzer 'sdk-sample-video-20251016-153045-abc12345' (demo cleanup)...
✅ Analyzer 'sdk-sample-video-20251016-153045-abc12345' deleted successfully!

💡 Next steps:
   - To analyze content from URL: see AnalyzeUrl sample
   - To analyze binary files: see AnalyzeBinary sample
   - To create a custom analyzer: see CreateOrReplaceAnalyzer sample
```

## Key Concepts

### Get Result File API

The GetResultFile operation retrieves binary files generated during analysis:

```csharp
var response = await client.GetContentAnalyzersClient()
    .GetResultFileAsync(
        operationId: analysisOperationId,
        path: keyframeId);

BinaryData imageContent = response.Value;
byte[] imageBytes = imageContent.ToArray();
```

### Extracting Operation IDs

Operation IDs are needed to retrieve result files. You can extract them from operations:

```csharp
private static string? ExtractOperationId(Operation operation)
{
    if (!string.IsNullOrEmpty(operation.Id))
    {
        // The ID might be a full URL or just the operation ID
        // Example: "https://endpoint/operations/12345" -> "12345"
        string[] parts = operation.Id.Split('/');
        if (parts.Length > 0)
        {
            return parts[parts.Length - 1];
        }
    }
    return null;
}
```

### Handling Binary Data

The result file API returns binary data as `BinaryData`:

```csharp
BinaryData imageContent = response.Value;
byte[] imageBytes = imageContent.ToArray();
await File.WriteAllBytesAsync(outputPath, imageBytes);
```

### Video Analysis

Video analysis generates keyframes that can be retrieved as result files:

```csharp
// Create video analyzer
var videoAnalyzer = new ContentAnalyzer
{
    BaseAnalyzerId = "prebuilt-videoAnalyzer",
    Config = new ContentAnalyzerConfig
    {
        ReturnDetails = true
    }
};

// Analyze video
var analysisOperation = await client.GetContentAnalyzersClient()
    .AnalyzeAsync(
        waitUntil: WaitUntil.Completed,
        analyzerId: analyzerId,
        url: new Uri(videoFileUrl));
```

### AudioVisualContent

Keyframe information is available in the `AudioVisualContent` type:

```csharp
foreach (var content in analysisResult.Contents)
{
    if (content is AudioVisualContent videoContent)
    {
        var keyframeTimesMs = videoContent.KeyFrameTimesMs;
        // Process keyframe times
    }
}
```

### Keyframe File Names

Keyframe files are named using the format `keyFrame.{time_ms}` where `time_ms` is the timestamp in milliseconds:

```csharp
var keyframeFiles = keyframeTimesMs.Select(time => $"keyFrame.{time}").ToList();
```

## Related Samples

- **AnalyzeUrl** - Analyze content from a URL
- **AnalyzeBinary** - Analyze local files
- **CreateOrReplaceAnalyzer** - Create or replace a custom analyzer
- **GetAnalyzer** - Retrieve details of an existing analyzer

## Troubleshooting

### Authentication Errors

If you see authentication errors:
- Verify your endpoint URL is correct
- Check that your API key is valid (if using key-based authentication)
- Ensure you're logged in with `az login` (if using DefaultAzureCredential)

### Operation ID Not Found

If the get result file operation fails:
- Verify the operation ID is correct
- Check that the analysis operation completed successfully
- Ensure the file path (keyframe name) is valid
- Verify the operation hasn't expired (result files are typically available for a limited time)

### No Keyframes Generated

If no keyframes are found:
- Verify the video file is accessible at the provided URL
- Check that the video format is supported
- Ensure the analyzer is configured for video analysis (using prebuilt-videoAnalyzer)
- Try a different video file

### File Save Errors

If saving files fails:
- Verify you have write permissions in the output directory
- Check that the output path is valid
- Ensure there's enough disk space

### Permission Denied

If you see permission errors:
- Verify your credentials have the necessary permissions
- Check that you're using the correct Azure subscription
- Ensure the analyzer and operations are in your resource

## Additional Resources

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [.NET SDK Documentation](https://learn.microsoft.com/dotnet/api/overview/azure/ai.contentunderstanding-readme)
- [Video Analysis Overview](https://learn.microsoft.com/azure/ai-services/content-understanding/overview#video-analysis)
















