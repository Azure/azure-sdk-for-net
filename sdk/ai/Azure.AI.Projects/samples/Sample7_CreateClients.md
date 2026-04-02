# Sample demonstrating how to create instances of various LLM clients in Azure.AI.Projects

**Note:** The Azure AI Model Inference API and its associated SDK clients are no longer in active development.
Consider [migrating to parity OpenAI API and SDK](https://learn.microsoft.com/azure/foundry/how-to/model-inference-to-openai-migration?tabs=openai&pivots=programming-language-dotnet) use for access to the latest models and features.

## Prerequisites

- Install the `Azure.AI.Projects` package.
- For `ChatCompletionsClient` and `EmbeddingsClient` install `Azure.AI.Inference` package.
- For `ChatClient` and `EmbeddingClient` install `Azure.AI.OpenAI` package.
- Set the following environment variables:
  - `FOUNDRY_PROJECT_ENDPOINT`: The Azure AI Project endpoint, as found in the overview page of your Azure AI Foundry project.
  - `FOUNDRY_MODEL_NAME`: The name of the deployment to retrieve (only for chat models).
  - `EMBEDDING_FOUNDRY_MODEL_NAME`: The name of the embeddings deployment to retrieve (only for embedding models).

## Samples
Using the synchronous and asynchronous `GetChatCompletionsClient()` method.

### `ChatCompletionsClient`

#### Synchronous Sample

```C# Snippet:AI_Projects_ChatClientSync
var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT"));
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

var credential = new DefaultAzureCredential();
BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

ChatCompletionsClient chatClient = new ChatCompletionsClient(new Uri(inferenceEndpoint), credential, clientOptions);

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

#### Asynchronous Sample

```C# Snippet:AI_Projects_ChatClientAsync
var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT"));
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

var credential = new DefaultAzureCredential();
BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

ChatCompletionsClient chatClient = new ChatCompletionsClient(new Uri(inferenceEndpoint), credential, clientOptions);

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

### `EmbeddingsClient`

Using synchronous and asynchronous `GetEmbeddingsClient()` method.

#### Synchronous Sample

```C# Snippet:AI_Projects_EmbeddingSync
var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT"));
var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_FOUNDRY_MODEL_NAME");
var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

var credential = new DefaultAzureCredential();
BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

EmbeddingsClient embeddingsClient = new EmbeddingsClient(new Uri(inferenceEndpoint), credential, clientOptions);

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

#### Asynchronous Sample

```C# Snippet:AI_Projects_EmbeddingAsync
var projectEndpoint = new Uri(System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT"));
var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_FOUNDRY_MODEL_NAME");
var inferenceEndpoint = $"{projectEndpoint.GetLeftPart(UriPartial.Authority)}/models";

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

var credential = new DefaultAzureCredential();
BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://ai.azure.com/.default" });
clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

EmbeddingsClient embeddingsClient = new EmbeddingsClient(new Uri(inferenceEndpoint), credential, clientOptions);

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

### `ChatClient`

Using synchronous and asynchronous `Azure OpenAI` chat completion methods.

#### Synchronous Sample

```C# Snippet:AI_Projects_AzureOpenAIChatSync
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI chat client");
var credential = new DefaultAzureCredential();
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), credential);

ClientConnection connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);

if (!connection.TryGetLocatorAsUri(out Uri uri) || uri is null)
{
    throw new InvalidOperationException("Invalid URI.");
}
uri = new Uri($"https://{uri.Host}");

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(uri, credential);
ChatClient chatClient = azureOpenAIClient.GetChatClient(deploymentName: modelDeploymentName);

Console.WriteLine("Complete a chat");
ChatCompletion result = chatClient.CompleteChat("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```

#### Asynchronous Sample
```C# Snippet:AI_Projects_AzureOpenAIChatAsync
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI chat client");
var credential = new DefaultAzureCredential();
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), credential);

ClientConnection connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);

if (!connection.TryGetLocatorAsUri(out Uri uri) || uri is null)
{
    throw new InvalidOperationException("Invalid URI.");
}
uri = new Uri($"https://{uri.Host}");

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(uri, credential);
ChatClient chatClient = azureOpenAIClient.GetChatClient(deploymentName: modelDeploymentName);

Console.WriteLine("Complete a chat");
ChatCompletion result = await chatClient.CompleteChatAsync("List all the rainbow colors");
Console.WriteLine(result.Content[0].Text);
```

### `EmbeddingClient`

Using synchronous and asynchronous `Azure OpenAI` embedding methods.

#### Synchronous Sample

```C# Snippet:AI_Projects_AzureOpenAIEmbeddingsSync
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_FOUNDRY_MODEL_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI embedding client");
var credential = new DefaultAzureCredential();
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), credential);

ClientConnection connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);

if (!connection.TryGetLocatorAsUri(out Uri uri) || uri is null)
{
    throw new InvalidOperationException("Invalid URI.");
}
uri = new Uri($"https://{uri.Host}");

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(uri, credential);
EmbeddingClient embeddingsClient = azureOpenAIClient.GetEmbeddingClient(deploymentName: modelDeploymentName);

Console.WriteLine("Generate an embedding");
OpenAIEmbedding result = embeddingsClient.GenerateEmbedding("List all the rainbow colors");
Console.WriteLine($"Generated embedding with {result.ToFloats().Length} dimensions");
```

#### Asynchronous Sample
```C# Snippet:AI_Projects_AzureOpenAIEmbeddingsAsync
var endpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
var modelDeploymentName = System.Environment.GetEnvironmentVariable("EMBEDDING_FOUNDRY_MODEL_NAME");
var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
Console.WriteLine("Create the Azure OpenAI embedding client");
var credential = new DefaultAzureCredential();
AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), credential);

ClientConnection connection = projectClient.GetConnection(typeof(AzureOpenAIClient).FullName!);

if (!connection.TryGetLocatorAsUri(out Uri uri) || uri is null)
{
    throw new InvalidOperationException("Invalid URI.");
}
uri = new Uri($"https://{uri.Host}");

AzureOpenAIClient azureOpenAIClient = new AzureOpenAIClient(uri, credential);
EmbeddingClient embeddingsClient = azureOpenAIClient.GetEmbeddingClient(deploymentName: modelDeploymentName);

Console.WriteLine("Generate an embedding");
OpenAIEmbedding result = await embeddingsClient.GenerateEmbeddingAsync("List all the rainbow colors");
Console.WriteLine($"Generated embedding with {result.ToFloats().Length} dimensions");
```
