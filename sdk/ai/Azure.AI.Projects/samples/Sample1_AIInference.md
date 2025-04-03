# Sample for Azure.AI.Projects inference and Embedding extensions

`ChatCompletionsClient` and `EmbeddingsClient` can be used to perform the inference and embedding tasks on `Serverless` models. To make the next samples work, please create the Serverless connection in the workspace, which supports embedding and chat completion models.

## Inference extensions

Set these two environment variables before running the sample:
1. PROJECT_CONNECTION_STRING - The connection string taken from the Overview section of Azure AI Foundry.
2. MODEL_DEPLOYMENT_NAME - The model's name to be used for the inferencing.

The inferencing can be called synchronously and asynchronously.

Synchronous sample:
```C# Snippet:ExtensionsChatClientSync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(connectionString);
ChatCompletionsClient chatClient = client.GetChatCompletionsClient();

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        },
    Model = modelDeploymentName
};
Response<ChatCompletions> response = chatClient.Complete(requestOptions);
Console.WriteLine(response.Value.Content);
```

Asynchronous sample:
```C# Snippet:ExtensionsChatClientAsync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new(connectionString);
ChatCompletionsClient chatClient = client.GetChatCompletionsClient();

var requestOptions = new ChatCompletionsOptions()
{
    Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        },
    Model = modelDeploymentName
};
Response<ChatCompletions> response = await chatClient.CompleteAsync(requestOptions);
Console.WriteLine(response.Value.Content);
```

## Embeddings extensions

Set these two environment variables before running the sample:
1. PROJECT_CONNECTION_STRING - The connection string taken from the Overview section of Azure AI Foundry.
2. EMBEDDING_MODEL_DEPLOYMENT_NAME - The model's name to be used for embedding generation.

Embedding also can be called synchronously and asynchronously.

Synchronous sample:
```C# Snippet:ExtensionsEmbeddingSync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(connectionString);
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

Asynchronous sample:
```C# Snippet:ExtensionsEmbeddingAsync
var connectionString = System.Environment.GetEnvironmentVariable("PROJECT_CONNECTION_STRING");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_MODEL_DEPLOYMENT_NAME");
AIProjectClient client = new AIProjectClient(connectionString);
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
