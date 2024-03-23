
# Tags

The Azure AI Vision ImageAnalysis Tags feature extracts content tags for thousands of recognizable objects, living beings, scenery, and actions that appear in images. It can provide additional context about the image content and can be used for searching, filtering, and organizing images based on their content. This library offers an easy way to extract tags from images using the Azure Computer Vision service.

This sample demonstrates how to get a Tags for an image. To get started you'll need a URL for a Computer Vision endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md) for links and instructions.

## Examples

The following sections provide code snippets using ImageAnalysis to extract tags from an image:

### Authenticate the client

In order to interact with Azure Image Analysis, you'll need to create an instance of the [ImageAnalysisClient][imageanalysis_client_class]
class. To configure a client for use with Azure Image Analysis, provide a valid endpoint URI to an Azure Computer Vision resource
along with a corresponding key credential authorized to use the Azure Computer Vision resource.

```C# Snippet:ImageAnalysisUsing
using Azure;
using Azure.AI.Vision.ImageAnalysis;
using System;
using System.IO;
```
```C# Snippet:ImageAnalysisAuth
string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT");
string key = Environment.GetEnvironmentVariable("VISION_KEY");

// Create an Image Analysis client.
ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));
```

Here we are using environment variables to hold the endpoint and key for the Computer Vision Resource.

### Extract tags from an image file

This example demonstrates how to extract tags for the image file [sample.jpg](https://aka.ms/azsdk/image-analysis/sample.jpg) using the `ImageAnalysisClient`. The synchronous `Analyze` method call returns an `ImageAnalysisResult` object, which contains the extracted tags and their confidence scores in the range [0, 1].

```C# Snippet:ImageAnalysisTagsFromFile
// Use a file stream to pass the image data to the analyze call
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Get the tags for the image.
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.Tags);

// Print tags results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Tags:");
foreach (DetectedTag tag in result.Tags.Values)
{
    Console.WriteLine($"   '{tag.Name}', Confidence {tag.Confidence:F4}");
}
```

### Extract tags from an image URL

This example is similar to the above, except it calls the `Analyze` method and provides a [publicly accessible image URL](https://aka.ms/azsdk/image-analysis/sample.jpg) instead of a file name.

```C# Snippet:ImageAnalysisTagsFromUrl
// Get the tags for the image.
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
    VisualFeatures.Tags);

// Print tags results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Tags:");
foreach (DetectedTag tag in result.Tags.Values)
{
    Console.WriteLine($"   '{tag.Name}', Confidence {tag.Confidence:F4}");
}
```
[imageanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src/Custom/ImageAnalysisClient.cs