# SmartCrops

The Azure AI Vision ImageAnalysis SmartCrops feature creates intuitive image thumbnails that include the most important regions of an image, with priority given to any detected faces. The generated thumbnails maintain the aspect ratio and focus on the essential content of the image. This library offers an easy way to generate smart-cropped thumbnails from images using the Azure Computer Vision service.

This sample demonstrates how to get a SmartCrops for an image. To get started you'll need a URL for a Computer Vision endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md) for links and instructions.

### Authenticate the client

In order to interact with Azure ImageAnalysis, you'll need to create an instance of the [ImageAnalysisClient][imageanalysis_client_class]
class. To configure a client for use with Azure ImageAnalysis, provide a valid endpoint URI to an Azure Computer Vision resource
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

An `ImageAnalysisClient` provides both synchronous and asynchronous operations in the SDK, allowing for the selection of a client based on an application's use case. Once you've initialized an `ImageAnalysisClient`, you can interact with the SmartCrops feature in Azure AI Vision ImageAnalysis.

### SmartCropsResult

A `SmartCropsResult` is the result of the smart-cropping analysis. It contains a list of `CropRegion` objects, each representing a region of the image identified for smart-cropping. Each `CropRegion` has an aspect ratio and a bounding box that defines the region in the image.

## Examples

The following sections provide code snippets using the `client` created above, covering using ImageAnalysis to generate smart-cropped thumbnails from an image:

### Generate smart-cropped thumbnails for an image file

This example demonstrates how to generate smart-cropped thumbnails for the image file [sample.jpg](https://aka.ms/azai/vision/image-analysis-sample.jpg) using the `ImageAnalysisClient`. The synchronous `Analyze` method call returns an `ImageAnalysisResult` object, which contains a list of `CropRegion` objects representing the regions identified for smart-cropping. Each `CropRegion` has an aspect ratio and a bounding box that defines the region in the image. You can then crop and return the image using those coordinates.

```C# Snippet:ImageAnalysisSmartCropsFromFile
// Use a file stream to pass the image data to the analyze call
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Get the smart-cropped thumbnails for the image. 
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.SmartCrops);

// Print smart-crops analysis results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" SmartCrops:");
foreach (CropRegion cropRegion in result.SmartCrops.Values)
{
    Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
}
```

### Generate smart-cropped thumbnails for an image URL

This example is similar to the above, except it calls the `Analyze` method and provides a [publicly accessible image URL](https://aka.ms/azai/vision/image-analysis-sample.jpg) instead of a file name.

```C# Snippet:ImageAnalysisSmartCropsFromUrl
// Get the smart-cropped thumbnails for the image. 
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"),
    VisualFeatures.SmartCrops);

// Print smart-crops analysis results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" SmartCrops:");
foreach (CropRegion cropRegion in result.SmartCrops.Values)
{
    Console.WriteLine($"   Aspect ratio: {cropRegion.AspectRatio}, Bounding box: {cropRegion.BoundingBox}");
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

```C# Snippet:ImageAnalysisSmartCropsException
var imageUrl = new Uri("https://aka.ms.invalid/azai/vision/image-analysis-sample.jpg");

try
{
    var result = client.Analyze(imageUrl, VisualFeatures.SmartCrops);
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

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fvision%2FAzure.AI.Vision.ImageAnalysis%2FREADME.png)

<!-- LINKS -->
[image_analysis_overview]: https://learn.microsoft.com/azure/ai-services/computer-vision/overview-image-analysis?tabs=4-0
[azure_sub]: https://azure.microsoft.com/free/dotnet/