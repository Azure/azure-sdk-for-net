# Get a Dense Caption for an image

The Azure AI Vision ImageAnalysis Dense Caption feature generates detailed captions for up to 10 different regions in an image, including one for the whole image. It provides a more comprehensive understanding of the image content without the need to view the image itself. This library offers an easy way to extract dense captions from images using the Azure Computer Vision service.

This sample demonstrates how to get Dense Captions for an image. To get started you'll need a URL for a Computer Vision endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md) for links and instructions.

## Examples

The following sections provide code snippets using the `client` created above, using ImageAnalysis to generate dense captions for an image:

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

### Generate dense captions for an image file

This example demonstrates how to generate dense captions for the image file [sample.jpg](https://aka.ms/azsdk/image-analysis/sample.jpg) using the `ImageAnalysisClient`. The `Analyze` method call returns an `ImageAnalysisResult` object, which contains the generated dense captions and their confidence scores in the range [0, 1]. By default, the captions may contain gender terms (for example: "man", "woman", "boy", "girl"). You have the option to request gender-neutral terms (for example: "person", "child") by setting `genderNeutralCaption = True` when calling `Analyze`.

Notes:

* Dense Caption is only available in some Azure regions. See [Prerequisites](#prerequisites).
* Dense Caption is only supported in English at the moment.

```C# Snippet:ImageAnalysisDenseCaptionFromFile
// Use a file stream to pass the image data to the analyze call
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Get dense captions for the image.
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.DenseCaptions,
    new ImageAnalysisOptions { GenderNeutralCaption = true });

// Print dense caption results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Dense Captions:");
foreach (DenseCaption denseCaption in result.DenseCaptions.Values)
{
    Console.WriteLine($"   Region: '{denseCaption.Text}', Confidence {denseCaption.Confidence:F4}, Bounding box {denseCaption.BoundingBox}");
}
```

### Generate dense captions for an image URL

This example is similar to the above, except it calls the `Analyze` method and provides a [publicly accessible image URL](https://aka.ms/azsdk/image-analysis/sample.jpg) instead of a file name.

```C# Snippet:ImageAnalysisDenseCaptionFromUrl
// Get dense captions for the image.
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
    VisualFeatures.DenseCaptions,
    new ImageAnalysisOptions { GenderNeutralCaption = true });

// Print dense caption results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Dense Captions:");
foreach (DenseCaption denseCaption in result.DenseCaptions.Values)
{
    Console.WriteLine($"   Region: '{denseCaption.Text}', Confidence {denseCaption.Confidence:F4}, Bounding box {denseCaption.BoundingBox}");
}
```
[imageanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src/Custom/ImageAnalysisClient.cs