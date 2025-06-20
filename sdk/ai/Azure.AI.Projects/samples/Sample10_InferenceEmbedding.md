# Sample using `Embeddings` in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `GetEmbeddingsClient()` method.

## Prerequisites

- Install the Azure.AI.Projects package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the embeddings deployment to retrieve.

## Synchronous Sample

```C# Snippet:AI_Projects_EmbeddingSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
EmbeddingsClient embeddingsClient = client.GetEmbeddingsClient();

var input = new List<string> { "first phrase", "second phrase", "third phrase" };
var requestOptions = new EmbeddingsOptions(input)
{
    Model = modelDeploymentName
};

Response<EmbeddingsResult> response = embeddingsClient.Embed(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```
## Asynchronous Sample

```C# Snippet:AI_Projects_EmbeddingAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
EmbeddingsClient embeddingsClient = client.GetEmbeddingsClient();

var input = new List<string> { "first phrase", "second phrase", "third phrase" };
var requestOptions = new EmbeddingsOptions(input)
{
    Model = modelDeploymentName
};

Response<EmbeddingsResult> response = await embeddingsClient.EmbedAsync(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```
