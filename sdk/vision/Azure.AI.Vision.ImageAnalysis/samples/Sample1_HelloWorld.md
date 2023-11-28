# Azure AI Vision Image Analysis client library for .NET

The Image Analysis client library allows you to extract a wide variety of visual features from your images using the Azure AI Vision Image Analysis service.

This sample demonstrates basic operations with the `ImageAnalysisClient`. It walks through the steps of creating an `ImageAnalysisClient`, analyzing an image to get a caption, and other visual features.

To get started, you'll need an endpoint URL and an API key for the Azure AI Vision Image Analysis service. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/README.md) for links and instructions.

## Create an ImageAnalysisClient

To interact with Azure AI Vision Image Analysis, you need to instantiate an `ImageAnalysisClient`. You can use either an endpoint URL and an [`AzureKeyCredential`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#authentication) or a connection string.

For the sample below, you can set `endpointString` and `keyString` in an environment variable, a configuration setting, or any way that works for your application. The endpoint URL and API key are available from the Azure AI Vision Image Analysis Access Keys view in the Azure Portal.

```C# Snippet:CreateImageAnalysisClient
// Replace the endpoint and API key with your own
string endpointString = Environment.GetEnvironmentVariable("VISION_ENDPOINT");
string keyString = Environment.GetEnvironmentVariable("VISION_KEY");

Uri endpoint = new Uri(endpointString);
AzureKeyCredential credential = new AzureKeyCredential(keyString);

// Create ImageAnalysisClient
ImageAnalysisClient client = new ImageAnalysisClient(endpoint, credential);
```

## Analyze an image to get a caption

Once you've created an `ImageAnalysisClient`, you can analyze an image to get a caption and other visual features.

```C# Snippet:GetCaptionForImage
// Read image file content
Uri imagePath = new Uri("https://url/to/your/image.jpg");
// Analyze the image and get caption
var result = client.Analyze(imagePath, VisualFeatures.Caption);

// Print the caption
Console.WriteLine("Caption: " + result.Value.Caption.Text);
```

For more samples, please see the [samples](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/vision/Azure.AI.Vision.ImageAnalysis/samples) in the Azure.AI.Vision.ImageAnalysis repository.
