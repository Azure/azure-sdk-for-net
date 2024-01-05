# People Detection

The Azure AI Vision ImageAnalysis People Detection feature detects people appearing in images. The Azure Computer Vision service provides AI algorithms for processing images and returning bounding box coordinates for each detected person, along with a confidence score. This library offers an easy way to extract people detection information from images using the Azure Computer Vision service.

This sample demonstrates how to get a detect people in an image. To get started you'll need a URL for a Computer Vision endpoint. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md) for links and instructions.

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

An `ImageAnalysisClient` provides both synchronous and asynchronous operations in the SDK, allowing for the selection of a client based on an application's use case. Once you've initialized an `ImageAnalysisClient`, you can interact with the People Detection feature in Azure AI Vision ImageAnalysis.

### People Detection Result

A `PeopleResult` is the result of the people detection analysis. It contains a list of detected people, each with their bounding box coordinates and a confidence score in the range [0, 1]. The higher the confidence score, the more accurate the detected person is likely to be.

## Examples

The following sections provide code snippets using the `client` created above, covering using ImageAnalysis to detect people in an image:

### Detect people in an image file

This example demonstrates how to detect people in the image file [sample.jpg](https://aka.ms/azai/vision/image-analysis-sample.jpg) using the `ImageAnalysisClient`. The synchronous `Analyze` method call returns an `ImageAnalysisResult` object, which contains the detected people along with their bounding box coordinates and confidence scores.

```C# Snippet:ImageAnalysisPeopleFromFile
// Use a file stream to pass the image data to the analyze call
using FileStream stream = new FileStream("image-analysis-sample.jpg", FileMode.Open);

// Detect people in the image.
ImageAnalysisResult result = client.Analyze(
    BinaryData.FromStream(stream),
    VisualFeatures.People);

// Print people detection results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" People:");
foreach (DetectedPerson person in result.People.Values)
{
    Console.WriteLine($"   Person: Bounding box {person.BoundingBox.ToString()}, Confidence {person.Confidence:F4}");
}
```

### Detect people in an image URL

This example is similar to the above, except it calls the `Analyze` method and provides a [publicly accessible image URL](https://aka.ms/azai/vision/image-analysis-sample.jpg) instead of a file name.

```C# Snippet:ImageAnalysisPeopleFromUrl
// Detect people in the image.
ImageAnalysisResult result = client.Analyze(
    new Uri("https://aka.ms/azai/vision/image-analysis-sample.jpg"),
    VisualFeatures.People);

// Print people detection results to the console
Console.WriteLine($"Image analysis results:");
Console.WriteLine($" People:");
foreach (DetectedPerson person in result.People.Values)
{
    Console.WriteLine($"   Person: Bounding box {person.BoundingBox.ToString()}, Confidence {person.Confidence:F4}");
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

```C# Snippet:ImageAnalysisPeopleException
var imageUrl = new Uri("https://aka.ms.invalid/azai/vision/image-analysis-sample.jpg");

try
{
    var result = client.Analyze(imageUrl, VisualFeatures.People);
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
[image_analysis_concepts]: https://learn.microsoft.com/azure/ai-services/computer-vision/concept-tag-images-40
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_cli]: https://learn.microsoft.com/cli/azure
[DefaultAzureCredential]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/identity/Azure.Identity/README.md#defaultazurecredential
[azure_identity]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity
[image_analysis_readme]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md
[imageanalysis_client_class]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/src/Generated/ImageAnalysisClient.cs
[nuget]: https://www.nuget.org/
[keyvault_rest]: https://learn.microsoft.com/rest/api/keyvault/