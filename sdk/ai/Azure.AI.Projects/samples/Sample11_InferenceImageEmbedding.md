# Sample using `Image Embeddings` in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `GetImageEmbeddingsClient()` method.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the embeddings deployment to retrieve.

## Synchronous Sample

```C# Snippet:AI_Projects_ImageEmbeddingSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ImageEmbeddingsClient imageEmbeddingsClient = client.GetImageEmbeddingsClient();

List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
{
    ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
};

var requestOptions = new ImageEmbeddingsOptions(input)
{
    Model = modelDeploymentName
};

Response<EmbeddingsResult> response = imageEmbeddingsClient.Embed(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```
## Asynchronous Sample

```C# Snippet:AI_Projects_ImageEmbeddingAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
ImageEmbeddingsClient imageEmbeddingsClient = client.GetImageEmbeddingsClient();

List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
{
    ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
};

var requestOptions = new ImageEmbeddingsOptions(input)
{
    Model = modelDeploymentName
};

Response<EmbeddingsResult> response = await imageEmbeddingsClient.EmbedAsync(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```
