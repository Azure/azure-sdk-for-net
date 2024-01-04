# Azure AI Vision ImageAnalysis Dense Caption client library for .NET

The Azure AI Vision ImageAnalysis Dense Caption feature generates detailed captions for up to 10 different regions in an image, including one for the whole image. It provides a more comprehensive understanding of the image content without the need to view the image itself. This library offers an easy way to extract dense captions from images using the Azure Computer Vision service.

Use the ImageAnalysis client library to:

- Authenticate against the ImageAnalysis service
- Upload an image for analysis
- Get the generated dense captions

[Product documentation][image_analysis_overview] | [Samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples) | [API reference documentation](https://docs.microsoft.com/dotnet/api/azure.ai.vision.imageanalysis) | [Package (NuGet)](https://www.nuget.org/packages/Azure.AI.Vision.ImageAnalysis/) | [SDK source code](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/vision/Azure.AI.Vision.ImageAnalysis)

## Getting started

### Prerequisites

* An [Azure subscription][azure_sub].
* An existing Azure Computer Vision resource. If you need to create an Azure Computer Vision resource, you can use the Azure Portal, [Azure CLI][azure_cli], or another Azure Resource Management client library.

### Install the package

Install the Azure AI Vision ImageAnalysis client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.Vision.ImageAnalysis
```
### Authenticate the client

In order to interact with Azure Image Analysis, you'll need to create an instance of the [ImageAnalysisClient][imageanalysis_client_class]
class. To configure a client for use with Azure Image Analysis, provide a valid endpoint URI to an Azure Computer Vision resource
along with a corresponding key credential authorized to use the Azure Computer Vison resource.

```C# Snippet:ImageAnalysisAuth
string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT");
string key = Environment.GetEnvironmentVariable("VISION_KEY");

// Create an Image Analysis client.
ImageAnalysisClient client = new ImageAnalysisClient(new Uri(endpoint), new AzureKeyCredential(key));
```

Here we are using environment variables to hold the endpoint and key for the Computer Vision Resource.

## Key concepts

### ImageAnalysisClient

An `ImageAnalysisClient` provides both synchronous and asynchronous operations in the SDK, allowing for the selection of a client based on an application's use case. Once you've initialized an `ImageAnalysisClient`, you can interact with the Dense Caption feature in Azure AI Vision ImageAnalysis.

### DenseCaption

A `DenseCaption` is part of the result of the dense caption analysis. It contains the generated one-sentence caption for a specific region in the image, its confidence score in the range [0, 1], and the bounding box coordinates of the region. The higher the confidence score, the more accurate the generated caption is likely to be.

## Examples

The following sections provide code snippets using the `client` created above, covering using ImageAnalysis to generate dense captions for an image:

### Generate dense captions for an image file

This example demonstrates how to generate dense captions for the image file [sample.jpg](https://aka.ms/azai/vision/image-analysis-sample.jpg) using the `ImageAnalysisClient`. The synchronous `Analyze` method call returns an `ImageAnalysisResult` object, which contains the generated dense captions and their confidence scores in the range [0, 1]. By default, the captions may contain gender terms (for example: "man", "woman", "boy", "girl"). You have the option to request gender-neutral terms (for example: "person", "child") by setting `genderNeutralCaption = True` when calling `Analyze`.

Notes:

* Dense Caption is only available in some Azure regions. See [Prerequisites](#prerequisites).
* Dense Caption is only supported in English at the moment.

```C# Snippet:ImageAnalysisDenseCaptionFromFile
// Use a file stream to pass the image data to the analyze call
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Get dense captions for the image. This will be a synchronously (blocking) call.
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.DenseCaptions,
    new ImageAnalysisOptions { genderNeutralCaption = true }); // Optional (default is false)

// Print dense caption results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Dense Captions:");
foreach (DenseCaption denseCaption in result.DenseCaptions.Values)
{
    Console.WriteLine($"   Region: '{denseCaption.Text}', Confidence {denseCaption.Confidence:F4}, Bounding box {denseCaption.BoundingBox}");
}
```

### Generate dense captions for an image URL

This example is similar to the above, except it calls the `Analyze` method and provides a [publicly accessible image URL](https://aka.ms/azai/vision/image-analysis-sample.jpg) instead of a file name.

```C# Snippet:ImageAnalysisDenseCaptionFromUrl
// Get dense captions for the image. This will be a synchronously (blocking) call.
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"),
    VisualFeatures.DenseCaptions,
    new ImageAnalysisOptions { genderNeutralCaption = true }); // Optional (default is false)

// Print dense caption results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" Dense Captions:");
foreach (DenseCaption denseCaption in result.DenseCaptions.Values)
{
    Console.WriteLine($"   Region: '{denseCaption.Text}', Confidence {denseCaption.Confidence:F4}, Bounding box {denseCaption.BoundingBox}");
}
```

## Troubleshooting
### Common errors
When you interact with Image Analysis using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for REST API requests. For example, if you try to analyze an image that is not accessible due to a broken URL, a `400` error is returned, indicating a bad request.

### Logging
You can learn more about how to enable SDK logging [here](https://learn.microsoft.com/dotnet/azure/sdk/logging).

### General

When you interact with the Azure Computer Vision service using the .NET SDK, errors returned by the service correspond to the same HTTP status codes returned for [REST API][keyvault_rest] requests.

For example, if you try to analyze an image that is not accessible due to a broken URL, a `400` error is returned, indicating a bad request.

### Handling exceptions

In the following snippet, the error is handled gracefully by catching the exception and displaying additional information about the error.

```C# Snippet:ImageAnalysisDenseCaptionException
var imageUrl = new Uri("https://aka.ms.invalid/azai/vision/image-analysis-sample.jpg");

try
{
    var result = client.Analyze(imageUrl, VisualFeatures.DenseCaptions);
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

You will notice that additional information is logged, like the Client Request ID of the operation.

## Next steps

Several Azure AI Vision ImageAnalysis client library samples are available to you in this GitHub repository. These samples provide example code for additional scenarios commonly encountered while working with Azure AI Vision ImageAnalysis:

* [Image Analysis README][image_analysis_readme] - A comprehensive guide covering various features of the Azure AI Vision ImageAnalysis service and their usage with the .NET SDK.

<!-- LINKS -->
[image_analysis_overview]: https://learn.microsoft.com/azure/ai-services/computer-vision/overview-image-analysis?tabs=4-0
[image_analysis_concepts]: https://learn.microsoft.com/azure/ai-services/computer-vision/concept-tag-images-40
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_cli]: https://learn.microsoft.com/cli/azure
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[image_analysis_readme]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md
[imageanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src/Generated/ImageAnalysisClient.cs
[nuget]: https://www.nuget.org/
[keyvault_rest]: https://learn.microsoft.com/rest/api/keyvault/