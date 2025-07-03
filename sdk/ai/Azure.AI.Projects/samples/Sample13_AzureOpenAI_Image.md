# Sample using `Azure.AI.OpenAI` Image Extension in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `Azure OpenAI` image generation methods.

## Prerequisites

- Install the Azure.AI.Projects and Azure.AI.OpenAI package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the deployment to retrieve.
  - `CONNECTION_NAME`: (Optional) The name of the Azure OpenAI connection to use.

## Synchronous Sample

```C# Snippet:AI_Projects_AzureOpenAIImageSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI image client");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ImageClient imageClient = projectClient.GetAzureOpenAIImageClient(deploymentName: modelDeploymentName, connectionName: connectionName, apiVersion: null);

Console.WriteLine("Generate an image");
GeneratedImage result = imageClient.GenerateImage("A sunset over a mountain range");

Console.WriteLine("Save the image to a file");
byte[] imageData = result.ImageBytes.ToArray();
System.IO.File.WriteAllBytes("sunset.png", imageData);
Console.WriteLine($"Image saved as sunset.png ({imageData.Length} bytes)");
```

## Asynchronous Sample
```C# Snippet:AI_Projects_AzureOpenAIImageAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI image client");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ImageClient imageClient = projectClient.GetAzureOpenAIImageClient(deploymentName: modelDeploymentName, connectionName: connectionName, apiVersion: null);

Console.WriteLine("Generate an image");
GeneratedImage result = await imageClient.GenerateImageAsync("A sunset over a mountain range");

Console.WriteLine("Save the image to a file");
byte[] imageData = result.ImageBytes.ToArray();
System.IO.File.WriteAllBytes("sunset.png", imageData);
Console.WriteLine($"Image saved as sunset.png ({imageData.Length} bytes)");
```
