# Analyze an Image with All Visual Features

This sample demonstrates how to analyze an image using all visual features provided by Azure AI Vision ImageAnalysis. This includes the features Caption, Dense Captions, Tags, Objects, SmartCrops, People, and Read. To get started you'll need a URL for a Computer Vision endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md) for links and instructions.

## Examples

The following sections provide code snippets using ImageAnalysis to analyze an image with all features:

### Authenticate the client

In order to interact with Azure Image Analysis, you'll need to create an instance of the [ImageAnalysisClient][imageanalysis_client_class] class. To configure a client for use with Azure Image Analysis, provide a valid endpoint URI to an Azure Computer Vision resource along with a corresponding key credential authorized to use the Azure Computer Vision resource.

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

### Analyze an image file with all features

This example demonstrates how to analyze an image file using all visual features. The `Analyze` method call returns an `ImageAnalysisResult` object, which contains the results for each visual feature.

```C# Snippet:ImageAnalysisAllFromFile
// Use a file stream to pass the image data to the analyze call
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Analyze the image with all visual features.
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.Caption |
    VisualFeatures.DenseCaptions |
    VisualFeatures.Tags |
    VisualFeatures.Objects |
    VisualFeatures.SmartCrops |
    VisualFeatures.People |
    VisualFeatures.Read
    );

// Print the results for each visual feature
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Caption: {result.Caption.Text}, Confidence: {result.Caption.Confidence:F4}");
Console.WriteLine($" Dense Captions:");
foreach (DenseCaption denseCaption in result.DenseCaptions.Values)
{
    Console.WriteLine($"   Region: '{denseCaption.Text}', Confidence: {denseCaption.Confidence:F4}, Bounding box: {denseCaption.BoundingBox}");
}
Console.WriteLine($" Tags:");
foreach (DetectedTag tag in result.Tags.Values)
{
    Console.WriteLine($"   '{tag.Name}', Confidence: {tag.Confidence:F4}");
}
Console.WriteLine($" Objects:");
foreach (DetectedObject detectedObject in result.Objects.Values)
{
    Console.WriteLine($"   Object: '{detectedObject.Tags.First().Name}', Bounding box: {detectedObject.BoundingBox.ToString()}");
}
Console.WriteLine($" SmartCrops:");
foreach (CropRegion cropRegion in result.SmartCrops.Values)
{
    Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
}
Console.WriteLine($" People:");
foreach (DetectedPerson person in result.People.Values)
{
    Console.WriteLine($"   Person: Bounding box {person.BoundingBox.ToString()}, Confidence: {person.Confidence:F4}");
}
Console.WriteLine($" Read:");
foreach (var line in result.Read.Blocks.SelectMany(block => block.Lines))
{
    Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
    foreach (DetectedTextWord word in line.Words)
    {
        Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
    }
}
```

### Analyze an image URL with all features

This example demonstrates how to analyze an image URL using all visual features. The `Analyze` method call returns an `ImageAnalysisResult` object, which contains the results for each visual feature.

```C# Snippet:ImageAnalysisAllFromUrl
// Analyze the image with all visual features.
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
    VisualFeatures.Caption |
    VisualFeatures.DenseCaptions |
    VisualFeatures.Tags |
    VisualFeatures.Objects |
    VisualFeatures.SmartCrops |
    VisualFeatures.People |
    VisualFeatures.Read
    );

// Print the results for each visual feature
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Caption: {result.Caption.Text}, Confidence: {result.Caption.Confidence:F4}");
Console.WriteLine($" Dense Captions:");
foreach (DenseCaption denseCaption in result.DenseCaptions.Values)
{
    Console.WriteLine($"   Region: '{denseCaption.Text}', Confidence: {denseCaption.Confidence:F4}, Bounding box: {denseCaption.BoundingBox}");
}
Console.WriteLine($" Tags:");
foreach (DetectedTag tag in result.Tags.Values)
{
    Console.WriteLine($"   '{tag.Name}', Confidence: {tag.Confidence:F4}");
}
Console.WriteLine($" Objects:");
foreach (DetectedObject detectedObject in result.Objects.Values)
{
    Console.WriteLine($"   Object: '{detectedObject.Tags.First().Name}', Bounding box: {detectedObject.BoundingBox.ToString()}");
}
Console.WriteLine($" SmartCrops:");
foreach (CropRegion cropRegion in result.SmartCrops.Values)
{
    Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
}
Console.WriteLine($" People:");
foreach (DetectedPerson person in result.People.Values)
{
    Console.WriteLine($"   Person: Bounding box {person.BoundingBox.ToString()}, Confidence: {person.Confidence:F4}");
}
Console.WriteLine($" Read:");
foreach (var line in result.Read.Blocks.SelectMany(block => block.Lines))
{
    Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
    foreach (DetectedTextWord word in line.Words)
    {
        Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
    }
}
```

[imageanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src/Custom/ImageAnalysisClient.cs