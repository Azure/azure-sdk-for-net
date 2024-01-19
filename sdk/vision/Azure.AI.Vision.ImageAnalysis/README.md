# Azure Image Analysis client library for .NET

The Azure.AI.Vision.ImageAnalysis client library provides AI algorithms for processing images and returning information about their content. It enables you to extract one or more visual features from an image simultaneously, including getting a caption for the image, extracting text shown in the image (OCR), and detecting objects. For more information on the service and the supported visual features, see [Image Analysis overview][image_analysis_overview], and the [Concepts][image_analysis_concepts] page.

Use the Image Analysis client library to:
* Authenticate against the service
* Select which features you would like to extract
* Upload an image for analysis, or provide an image URL
* Get the analysis result

[Product documentation][image_analysis_overview] 
| [Samples](https://aka.ms/azsdk/image-analysis/samples/csharp)
| [Vision Studio][vision_studio]
| [API reference documentation](https://aka.ms/azsdk/image-analysis/ref-docs/csharp)
| [Package (NuGet)](https://aka.ms/azsdk/image-analysis/package/nuget)
| [SDK source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/vision/Azure.AI.Vision.ImageAnalysis)

## Getting started

### Prerequisites

* An [Azure subscription](https://azure.microsoft.com/free/dotnet/).
* A [Computer Vision resource](https://portal.azure.com/#create/Microsoft.CognitiveServicesComputerVision) in your Azure subscription.
  * You will need the key and endpoint from this resource to authenticate against the service.
  * You can use the free pricing tier (`F0`) to try the service, and upgrade later to a paid tier for production.
  * Note that in order to run Image Analysis with the `Caption` or `Dense Captions` features, the Azure resource needs to be from a GPU-supported region. See the note [here](https://learn.microsoft.com/azure/ai-services/computer-vision/concept-describe-images-40) for a list of supported regions.

### Install the package

```dotnetcli
dotnet add package Azure.AI.Vision.ImageAnalysis --prerelease
```

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

## Key concepts

Once you've initialized an `ImageAnalysisClient`, you need to select one or more visual features to analyze. The options are specified by the enum class `VisualFeatures`. The following features are supported:

1. `VisualFeatures.Caption` ([Examples](#generate-an-image-caption-for-an-image-file) | [Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/Sample01_HellowWorld.md)): Generate a human-readable sentence that describes the content of an image.
1. `VisualFeatures.Read` ([Examples](#extract-text-from-the-image-file) | [Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/README.md)): Also known as Optical Character Recognition (OCR). Extract printed or handwritten text from images.
1. `VisualFeatures.DenseCaptions` ([Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/Sample02_DenseCaptions.md)): Dense Captions provides more details by generating one-sentence captions for up to 10 different regions in the image, including one for the whole image. 
1. `VisualFeatures.Tags` ([Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/Sample03_Tags.md)): Extract content tags for thousands of recognizable objects, living beings, scenery, and actions that appear in images.
1. `VisualFeatures.Objects` ([Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/Sample04_Objects.md)): Object detection. This is similar to tagging, but focused on detecting physical objects in the image and returning their location.
1. `VisualFeatures.SmartCrops` ([Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/Sample05_SmartCrops.md)): Used to find a representative sub-region of the image for thumbnail generation, with priority given to include faces.
1. `VisualFeatures.People` ([Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/Sample06_People.md)): Locate people in the image and return their location.

For more information about these features, see [Image Analysis overview][image_analysis_overview], and the [Concepts][image_analysis_concepts] page.

### Analyze from image buffer or URL

The `ImageAnalysisClient` contains an `Analyze` method that has two overloads:
* `Analyze (BinaryData ...`: Analyze an image from an input [BinaryData](https://learn.microsoft.com/dotnet/api/system.binarydata) object. The client will upload the image to the service as part of the REST request. 
* `Analyze (Uri ...)`: Analyze an image from a publicly-accessible URL, via the `Uri` object. The client will send the image URL to the service. The service will download the image.

The examples below demonstrate both. The `Analyze` examples populate the input [BinaryData](https://learn.microsoft.com/dotnet/api/system.binarydata) object by loading an image from a file from disk.

### Supported image formats

Image Analysis works on images that meet the following requirements:
* The image must be presented in JPEG, PNG, GIF, BMP, WEBP, ICO, TIFF, or MPO format
* The file size of the image must be less than 20 megabytes (MB)
* The dimensions of the image must be greater than 50 x 50 pixels and less than 16,000 x 16,000 pixels

## Examples

The following sections provide code snippets covering these common Image Analysis scenarios:

* [Generate an image caption for an image file](#generate-an-image-caption-for-an-image-file)
* [Generate an image caption for an image URL](#generate-an-image-caption-for-an-image-url)
* [Extract text (OCR) from an image file](#extract-text-from-an-image-file)
* [Extract text (OCR) from an image URL](#extract-text-from-an-image-url)

These snippets use the `client` from [Create and authenticate the client](#create-and-authenticate-the-client).

See the [Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/README.md) folder for fully working samples for all visual features, including asynchronous calls.

### Generate an image caption for an image file

This example demonstrates how to generate a one-sentence caption for the image file [sample.jpg](https://aka.ms/azsdk/image-analysis/sample.jpg) using the `ImageAnalysisClient`. The synchronous  `Analyze` method call returns a `CaptionResult` object, which contains the generated caption and its confidence score in the range [0, 1]. By default, the caption may contain gender terms (for example: "man", "woman", "boy", "girl"). You have the option to request gender-neutral terms (for example: "person", "child") by setting `genderNeutralCaption = True` when calling `Analyze`.

Notes:
* Caption is only available in some Azure regions. See [Prerequisites](#prerequisites).
* Caption is only supported in English at the moment.

```C# Snippet:ImageAnalysisGenerateCaptionFromFile
// Use a file stream to pass the image data to the analyze call
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Get a caption for the image.
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.Caption,
    new ImageAnalysisOptions { GenderNeutralCaption = true });

// Print caption results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Caption:");
Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
```

### Generate an image caption for an image URL

This example is similar to the above, expect it calls the `Analyze` method and provides a [publicly accessible image URL](https://aka.ms/azsdk/image-analysis/sample.jpg) instead of a file name.

```C# Snippet:ImageAnalysisGenerateCaptionFromUrl
// Get a caption for the image.
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
    VisualFeatures.Caption,
    new ImageAnalysisOptions { GenderNeutralCaption = true });

// Print caption results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Caption:");
Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");
```

### Extract text from an image file

This example demonstrates how to extract printed or hand-written text for the image file [sample.jpg](https://aka.ms/azsdk/image-analysis/sample.jpg) using the `ImageAnalysisClient`. The synchronous (blocking) `Analyze` method call returns a `ReadResult` object. This object includes a list of text lines and a bounding polygon surrounding each text line. For each line, it also returns a list of words in the text line and a bounding polygon surrounding each word.

```C# Snippet:ImageAnalysisExtractTextFromFile
// Load image to analyze into a stream
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Extract text (OCR) from an image stream.
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.Read);

// Print text (OCR) analysis results to the console
Console.WriteLine("Image analysis results:");
Console.WriteLine(" Read:");

foreach (DetectedTextBlock block in result.Read.Blocks)
    foreach (DetectedTextLine line in block.Lines)
    {
        Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
        foreach (DetectedTextWord word in line.Words)
        {
            Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
        }
    }
```

### Extract text from an image URL

This example demonstrates how to extract printed or hand-written text for a [publicly accessible image URL](https://aka.ms/azsdk/image-analysis/sample.jpg).

```C# Snippet:ImageAnalysisExtractTextFromUrl
// Extract text (OCR) from an image stream.
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azsdk/image-analysis/sample.jpg"),
    VisualFeatures.Read);

// Print text (OCR) analysis results to the console
Console.WriteLine("Image analysis results:");
Console.WriteLine(" Read:");

foreach (DetectedTextBlock block in result.Read.Blocks)
    foreach (DetectedTextLine line in block.Lines)
    {
        Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
        foreach (DetectedTextWord word in line.Words)
        {
            Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
        }
    }
```
## Troubleshooting

### Common errors

When you interact with Image Analysis using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests. For example, if you try to analyze an image that is not accessible due to a broken URL, a `400` status is returned, indicating a bad request.

### Handling exceptions

In the following snippet, the error is handled gracefully by catching the exception and displaying additional information about the error.

```C# Snippet:ImageAnalysisException
var imageUrl = new Uri("https://aka.ms.invalid/azai/vision/image-analysis-sample.jpg");

try
{
    var result = client.Analyze(imageUrl, VisualFeatures.Caption);
}
catch (RequestFailedException e)
{
    if (e.Status == 400)
    {
        Console.WriteLine("Error analyzing image.");
        Console.WriteLine($"HTTP status code {e.Status}: {e.Message}");
    }
    else
    {
        throw;
    }
}
```
You can learn more about how to enable SDK logging [here](https://learn.microsoft.com/dotnet/azure/sdk/logging).

## Next steps

Beyond the introductory scenarios discussed, the Azure Image Analysis client library offers support for additional scenarios to help take advantage of the full feature set of the Azure Image Analysis service. In order to help explore some of these scenarios, the Image Analysis client library offers a project of samples to serve as an illustration for common scenarios. Please see the [samples README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/README.md) for details.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.png)

<!-- LINKS -->
[image_analysis_overview]: https://learn.microsoft.com/azure/ai-services/computer-vision/overview-image-analysis?tabs=4-0
[image_analysis_concepts]: https://learn.microsoft.com/azure/ai-services/computer-vision/concept-tag-images-40
[vision_studio]: https://aka.ms/vision-studio/image-analysis
[imageanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src/Generated/ImageAnalysisClient.cs
