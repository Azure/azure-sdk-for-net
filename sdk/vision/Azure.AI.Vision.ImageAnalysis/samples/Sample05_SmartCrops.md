# SmartCrops

The Azure AI Vision ImageAnalysis SmartCrops feature creates intuitive image thumbnails that include the most important regions of an image, with priority given to any detected faces. The generated thumbnails maintain the aspect ratio and focus on the essential content of the image. This library offers an easy way to generate smart-cropped thumbnails from images using the Azure Computer Vision service.

This sample demonstrates how to get a SmartCrops for an image. To get started you'll need a URL for a Computer Vision endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md) for links and instructions.

## Examples

The following sections provide code snippets using ImageAnalysis to generate smart-cropped thumbnails from an image:

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

### Generate smart-cropped thumbnails for an image file

This example demonstrates how to generate smart-cropped thumbnails for the image file [sample.jpg](https://aka.ms/azsdk/image-analysis/sample.jpg) using the `ImageAnalysisClient`. The synchronous `Analyze` method call returns an `ImageAnalysisResult` object, which contains a list of `CropRegion` objects representing the regions identified for smart-cropping. Each `CropRegion` has an aspect ratio and a bounding box that defines the region in the image. You can then crop and return the image using those coordinates.

```C# Snippet:ImageAnalysisSmartCropsFromFile
// Use a file stream to pass the image data to the analyze call
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Get the smart-cropped thumbnails for the image.
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.SmartCrops,
    new ImageAnalysisOptions { SmartCropsAspectRatios = new float[] { 0.9F, 1.33F } });

// Print smart-crops analysis results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" SmartCrops:");
foreach (CropRegion cropRegion in result.SmartCrops.Values)
{
    Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
}
```

### Generate smart-cropped thumbnails for an image URL

This example is similar to the above, except it calls the `Analyze` method and provides a [publicly accessible image URL](https://aka.ms/azsdk/image-analysis/sample.jpg) instead of a file name.

```C# Snippet:ImageAnalysisSmartCropsFromUrl
// Get the smart-cropped thumbnails for the image.
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
    VisualFeatures.SmartCrops,
    new ImageAnalysisOptions { SmartCropsAspectRatios = new float[] { 0.9F, 1.33F } });

// Print smart-crops analysis results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" SmartCrops:");
foreach (CropRegion cropRegion in result.SmartCrops.Values)
{
    Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
}
```

[imageanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src/Custom/ImageAnalysisClient.cs