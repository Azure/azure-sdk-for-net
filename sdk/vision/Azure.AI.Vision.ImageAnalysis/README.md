# Azure AI Vision Image Analysis client library for .NET

Azure AI Vision Image Analysis is a service that can extract a wide variety of visual features from your images.

Use the client library for Image Analysis to:

* Generate human-readable captions and descriptions of image contents
* Detect objects and people within images
* Perform OCR to extract text from images

[Source code](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src) | [Package (NuGet)](https://www.nuget.org/packages/Azure.AI.Vision.ImageAnalysis) | [API reference documentation](https://azure.github.io/azure-sdk-for-net/Azure.AI.Vision.ImageAnalysis.html) | [Product documentation](https://docs.microsoft.com/azure/cognitive-services/image-analysis)

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.AI.Vision.ImageAnalysis --prerelease
```

### Prerequisites

* You must have an [Azure subscription](https://azure.microsoft.com/free/dotnet/)

* Once you have your Azure subscription, [create a Computer Vision resource](https://portal.azure.com/#create/Microsoft.CognitiveServicesComputerVision) in the Azure portal to get your key and endpoint. After it deploys, click `Go to resource`.
  * You will need the key and endpoint from the resource you create to connect your application to the Computer Vision service.
  * You can use the free pricing tier (`F0`) to try the service, and upgrade later to a paid tier for production.
  * Note that in order to run Image Analysis with the `Caption` or `Dense Captions` features, the Azure resource needs to be from one of the following GPU-supported regions: East US, France Central, Korea Central, North Europe, Southeast Asia, West Europe, West US.
  
### Authenticate the client

To authenticate the `ImageAnalysisClient`, you will need the endpoint and key for your Azure AI Vision Image Analysis account. You can find these details in the [Azure Portal](https://portal.azure.com).

```csharp
using Azure.AI.Vision.ImageAnalysis;
using Azure.Core;

string endpoint = "https://<your-account-name>.cognitiveservices.azure.com/";
string key = "<your-account-key>";

Uri endpointUri = new Uri(endpoint);
AzureKeyCredential credential = new AzureKeyCredential(key);

var client = new ImageAnalysisClient(endpointUri, credential);
```

## Key concepts

Once you've initialized an `ImageAnalysisClient`, you can perform various operations to analyze images, such as:

* Image tagging: returns content tags for thousands of recognizable objects, living beings, scenery, and actions that appear in images.
* Image categorization: returns the taxonomy-based categories detected in an image.
* Image descriptions: generates a human-readable phrase that describes the contents of an image.
* Object detection: returns the bounding box coordinates (in pixels) for each object found in the image.
* Smart-cropped thumbnails: creates intuitive image thumbnails that include the most important regions of an image with priority given to any detected faces.
* Image captions: generates one-sentence descriptions for image contents.
* OCR for images: extracts printed or handwritten text from images.
* People detection: detects people appearing in images and returns their bounding box coordinates along with a confidence score.

For more information about these features, see the [Azure AI Vision Image Analysis documentation](https://docs.microsoft.com/azure/cognitive-services/image-analysis).

## Examples

The following sections provide several code snippets covering some of the most common Image Analysis tasks, including:

* [Analyze an image](#analyze-an-image)
* [Generate an image caption](#generate-an-image-caption)
* [Extract text from an image](#extract-text-from-an-image)
* [Detect people in an image](#detect-people-in-an-image)

### Analyze an image

This example demonstrates how to analyze an image using the `ImageAnalysisClient`. The `Analyze` method returns various visual features, such as tags and categories, based on the objects, living beings, and actions identified in the image.

```csharp
using Azure.AI.Vision.ImageAnalysis;
using System;

var imageUrl = new ImageUrl(new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"));

// Analyze visual features from the image
var visualFeatures = new VisualFeatures[] { VisualFeatures.Tags, VisualFeatures.Categories };
var result = client.Analyze(imageUrl, visualFeatures);

// Print the tags and categories found in the image
Console.WriteLine("Tags:");
foreach (var tag in result.TagsResult.Values)
{
    Console.WriteLine($"   \"{tag.Name}\", Confidence {tag.Confidence:F4}");
}

Console.WriteLine("Categories:");
foreach (var category in result.Categories)
{
    Console.WriteLine($"   \"{category.Name}\", Confidence {category.Score:F4}");
}
```

### Generate an image caption

This example demonstrates how to generate a human-readable caption for an image using the `ImageAnalysisClient`. The `Analyze` method returns a `CaptionResult` object, which contains the generated caption and its confidence score.

```csharp
using Azure.AI.Vision.ImageAnalysis;
using System;

var imageUrl = new ImageUrl(new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"));

// Generate a caption for the image
var visualFeatures = new VisualFeatures[] { VisualFeatures.Caption };
var result = client.Analyze(imageUrl, visualFeatures);

// Print the generated caption and its confidence score
Console.WriteLine($"Caption: \"{result.CaptionResult.Text}\", Confidence {result.CaptionResult.Confidence:F4}");
```

### Extract text from an image

This example demonstrates how to extract text from an image using the `ImageAnalysisClient`. The `Analyze` method returns a `ReadResult` object, which contains the extracted text and additional information, such as the bounding box coordinates of the text.

```csharp
using Azure.AI.Vision.ImageAnalysis;
using System;

var imageUrl = new ImageUrl(new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"));

// Extract text from the image
var visualFeatures = new VisualFeatures[] { VisualFeatures.Read };
var result = client.Analyze(imageUrl, visualFeatures);

// Print the extracted text and its bounding box coordinates
Console.WriteLine("Extracted text:");
foreach (var line in result.ReadResult.Lines)
{
    Console.WriteLine($"   \"{line.Content}\"");
    Console.WriteLine($"      Bounding box: {string.Join(", ", line.BoundingBox)}");
}
```

### Detect people in an image

This example demonstrates how to detect people in an image using the `ImageAnalysisClient`. The `Analyze` method returns a `PeopleResult` object, which contains the bounding box coordinates and confidence scores for each detected person in the image.

```csharp
using Azure.AI.Vision.ImageAnalysis;
using System;

var imageUrl = new ImageUrl(new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"));

// Detect people in the image
var visualFeatures = new VisualFeatures[] { VisualFeatures.People };
var result = client.Analyze(imageUrl, visualFeatures);

// Print the bounding box coordinates and confidence scores for each detected person
Console.WriteLine("Detected people:");
foreach (var person in result.PeopleResult.Values)
{
    Console.WriteLine($"   Bounding box: {person.BoundingBox.X}, {person.BoundingBox.Y}, {person.BoundingBox.W}, {person.BoundingBox.H}");
    Console.WriteLine($"      Confidence: {person.Confidence:F4}");
}
```

## Troubleshooting

### Common errors

When you interact with Image Analysis using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests. For example, if you try to analyze an image that is not accessible due to a broken URL, a `400` error is returned, indicating a bad request.

### Handling exceptions

In the following snippet, the error is handled gracefully by catching the exception and displaying additional information about the error.

```csharp
try
{
    var result = client.Analyze(imageUrl, visualFeatures);
}
catch (RequestFailedException e)
{
    if (e.Status == 400)
    {
        Console.WriteLine("Error analyzing image.");
        Console.WriteLine("HTTP status code 400: The request is invalid or malformed.");
    }
    else
    {
        throw;
    }
}
```

### Logging

Enable logging to help debug issues with your application. You can configure logging to log only specific events, or log all events to get more detailed information. For more information on using logging with the Azure SDK for .NET, see the [logging guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md).

## Next steps

### More sample code

Several Image Analysis .NET SDK samples are available to you in the SDK's GitHub repository. These samples provide example code for additional scenarios commonly encountered while working with Image Analysis:

* [`AnalyzeFromUrl`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/Sample1_AnalyzeFromUrl.cs) - Analyze visual features from an image URL.
* [`AnalyzeFromStream`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples/Sample2_AnalyzeFromStream.cs) - Analyze visual features from an image stream.

### Additional documentation

For more extensive documentation on the Image Analysis service, see the [Azure AI Vision Image Analysis documentation](https://docs.microsoft.com/azure/cognitive-services/image-analysis) on docs.microsoft.com.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
