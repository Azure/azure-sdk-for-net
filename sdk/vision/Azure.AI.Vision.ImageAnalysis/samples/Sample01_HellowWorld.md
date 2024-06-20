# Get An Image Caption

This sample demonstrates how to get a caption for an image. To get started you'll need a URL for a Computer Vision endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md) for links and instructions.

## Examples

The following sections provide code snippets using ImageAnalysis to caption an image:

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

### Generate an image caption for an image file

This example demonstrates how to generate a one-sentence caption for the image file [sample.jpg](https://aka.ms/azsdk/image-analysis/sample.jpg) using the `ImageAnalysisClient`. The synchronous `Analyze` method call returns an `ImageAnalysisResult` object, which contains the generated caption and its confidence score in the range [0, 1]. By default, the caption may contain gender terms (for example: "man", "woman", "boy", "girl"). You have the option to request gender-neutral terms (for example: "person", "child") by setting `genderNeutralCaption = True` when calling `Analyze`.

Notes:

* Caption is only available in some Azure regions. See [Prerequisites](#prerequisites).
* Caption is only supported in English at the moment.

```C# Snippet:ImageAnalysisCaptionFromFile
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.Caption,
    new ImageAnalysisOptions { GenderNeutralCaption = true });

Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Caption:");
Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
```

### Generate an image caption for an image URL

This example is similar to the above, except it calls the `Analyze` method and provides a [publicly accessible image URL](https://aka.ms/azsdk/image-analysis/sample.jpg) instead of a file name.

```C# Snippet:ImageAnalysisCaptionFromUrl
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
    VisualFeatures.Caption,
    new ImageAnalysisOptions { GenderNeutralCaption = true });

Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Metadata: Model: {result.ModelVersion} Image dimensions: {result.Metadata.Width} x {result.Metadata.Height}");
Console.WriteLine($" Caption:");
Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
```
[imageanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src/Custom/ImageAnalysisClient.cs