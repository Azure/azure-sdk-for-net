## Migrate from `Azure.AI.Inference` to `OpenAI`

Following the `2025-05-01-preview` service API version, Model Inference has converged its capabilities with OpenAI-compatible API surfaces available with Azure AI Foundry. As part of this convergence, the `Azure.AI.Inference` library is discontinued in favor of support via the official `OpenAI` library.

This document describes the migration steps from common model inference scenarios to equivalent OpenAI operations.

## Client configuration

**Before, using `Azure.AI.Inference`:**

```csharp
using Azure.AI.Inference;

Uri endpoint = new(Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
AzureKeyCredential credential = new(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));

// Chat
ChatCompletionsClient client = new(endpoint, credential);

// Embeddings
EmbeddingsClient embeddingsClient = new(endpoint, credential, new AzureAIInferenceClientOptions());
```

**After, using `OpenAI`:**

```csharp
using OpenAI.Chat;

Uri endpoint = new($"{Environment.GetEnvironmentVariable("AI_FOUNDRY_ENDPOINT")}/openai/v1"));
ApiKeyCredential credential = new(Environment.GetEnvironmentVariable("AI_FOUNDRY_API_KEY"));
OpenAIClient openAIClient = new(
    credential,
    new OpenAIClientOptions()
    {
        Endpoint = endpoint,
    });

// Chat
ChatClient client = openAIClient.GetChatClient(Environment.GetEnvironmentVariable("AI_FOUNDRY_MODEL_DEPLOYMENT"));

// Embeddings
EmbeddingClient embeddingClient = openAIClient.GetEmbeddingClient(Environment.GetEnvironmentVariable("AI_FOUNDRY_MODEL_DEPLOYMENT"));
```

## Use Chat Completions

**Before, with `Azure.AI.Inference`:**

```csharp
Response<ChatCompletions> response = client.Complete(
    new ChatCompletionsOptions()
    {
        Messages =
        {
            new ChatRequestSystemMessage("You are a helpful assistant."),
            new ChatRequestUserMessage("How many feet are in a mile?"),
        }
    });
Console.WriteLine(response.Value.Content);
```

**After, with `OpenAI`:**

```csharp
ChatCompletion completion = client.CompleteChat(
    [
        new SystemChatMessage("You are a helpful assistant."),
        new UserChatMessage("How many feet are in a mile?"),
    ]);
Console.WriteLine(completion.Content[0].Text);
```

## Use Text Embeddings

**Before, with `Azure.AI.Inference`:**

```csharp
EmbeddingsOptions options = new(
    new List<string> { "King", "Queen", "Jack", "Page" });
Response<EmbeddingsResult> response = client.Embed(options);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```

**After, with `OpenAI`:**

```csharp
OpenAIEmbedding embedding = client.GenerateEmbedding(["King", "Queen", "Jack", "Page"]);

foreach (float embeddingValue in embedding.ToFloats())
{
    Console.WriteLine(embeddingValue);
}
```