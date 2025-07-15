# Sample using `Azure.AI.OpenAI` Embeddings Extension in Azure.AI.Projects

This sample demonstrates how to use the synchronous and asynchronous `Azure OpenAI` embeddings methods.

## Prerequisites

- Install the Azure.AI.Projects and Azure.AI.OpenAI package.
- Set the following environment variables:
  - `PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `MODEL_DEPLOYMENT_NAME`: The name of the deployment to retrieve.
  - `CONNECTION_NAME`: (Optional) The name of the Azure OpenAI connection to use.

## Synchronous Sample

```C# Snippet:AI_Projects_AzureOpenAIEmbeddingsSync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI embedding client");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
EmbeddingClient embeddingsClient = projectClient.GetAzureOpenAIEmbeddingClient(deploymentName: modelDeploymentName, connectionName: connectionName, apiVersion: null);

Console.WriteLine("Generate an embedding");
OpenAIEmbedding result = embeddingsClient.GenerateEmbedding("List all the rainbow colors");
Console.WriteLine($"Generated embedding with {result.ToFloats().Length} dimensions");
```

## Asynchronous Sample
```C# Snippet:AI_Projects_AzureOpenAIEmbeddingsAsync
var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDINGS_MODEL_DEPLOYMENT_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI embedding client");
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
EmbeddingClient embeddingsClient = projectClient.GetAzureOpenAIEmbeddingClient(deploymentName: modelDeploymentName, connectionName: connectionName, apiVersion: null);

Console.WriteLine("Generate an embedding");
OpenAIEmbedding result = await embeddingsClient.GenerateEmbeddingAsync("List all the rainbow colors");
Console.WriteLine($"Generated embedding with {result.ToFloats().Length} dimensions");
```
