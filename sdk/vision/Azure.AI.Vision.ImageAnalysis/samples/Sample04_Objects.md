# Objects

The Azure AI Vision ImageAnalysis Objects feature enables the detection of objects within images. It focuses on detecting physical objects in an image and returning their locations. This library offers an easy way to extract object information from images using the Azure Computer Vision service.

This sample demonstrates how to get Objects in an image. To get started you'll need a URL for a Computer Vision endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md) for links and instructions.

## Examples

The following sections provide code snippets using ImageAnalysis to detect objects in an image:

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

### Detect objects in an image file

This example demonstrates how to detect objects in the image file [sample.jpg](https://aka.ms/azsdk/image-analysis/sample.jpg) using the `ImageAnalysisClient`. The synchronous `Analyze` method call returns an `ImageAnalysisResult` object, which contains the detected objects and their locations in the form of bounding boxes.

```C# Snippet:ImageAnalysisObjectsFromFile
// Use a file stream to pass the image data to the analyze call
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Detect objects in the image.
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.Objects);

// Print object detection results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Objects:");
foreach (DetectedObject detectedObject in result.Objects.Values)
{
    Console.WriteLine($"   Object: '{detectedObject.Tags.First().Name}', Bounding box {detectedObject.BoundingBox.ToString()}");
}
```

### Detect objects in an image URL

This example is similar to the above, except it calls the `Analyze` method and provides a [publicly accessible image URL](https://aka.ms/azsdk/image-analysis/sample.jpg) instead of a file name.

```C# Snippet:ImageAnalysisObjectsFromUrl
// Detect objects in the image.
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
    VisualFeatures.Objects);

// Print object detection results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Objects:");
foreach (DetectedObject detectedObject in result.Objects.Values)
{
    Console.WriteLine($"   Object: '{detectedObject.Tags.First().Name}', Bounding box {detectedObject.BoundingBox.ToString()}");
}
```

[imageanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src/Custom/ImageAnalysisClient.cs