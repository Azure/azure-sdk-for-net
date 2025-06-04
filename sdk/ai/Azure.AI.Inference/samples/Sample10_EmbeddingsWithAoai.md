# Simple Embeddings Using Azure OpenAI

This sample demonstrates how to get text embeddings for a list of sentences using a synchronous client, with an Azure OpenAI (AOAI) endpoint. Two types of authentications are shown: key authentication and Entra ID authentication.

## Usage

Set these two environment variables before running the sample:

1. AZURE_OPENAI_EMBEDDINGS_ENDPOINT - Your endpoint URL, in the form `https://your-deployment-name.your-azure-region.inference.ai.azure.com` where `your-deployment-name` is your unique AI Model deployment name, and `your-azure-region` is the Azure region where your model is deployed.

2. AZURE_OPENAI_EMBEDDINGS_KEY - Your model key. Keep it secret.

In order to target AOAI, the auth key must currently be provided as a separate header. This can be done by creating a `HttpPipelinePolicy` like below:

```C# Snippet:Azure_AI_Inference_AoaiAuthHeaderPolicy
private class AddAoaiAuthHeaderPolicy : HttpPipelinePolicy
{
    public string AoaiKey { get; }

    public AddAoaiAuthHeaderPolicy(string key)
    {
        AoaiKey = key;
    }

    public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        // Add your desired header name and value
        message.Request.Headers.Add("api-key", AoaiKey);

        ProcessNext(message, pipeline);
    }

    public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
    {
        // Add your desired header name and value
        message.Request.Headers.Add("api-key", AoaiKey);

        return ProcessNextAsync(message, pipeline);
    }
}
```

The policy can then be added to the `AzureAIInferenceClientOptions` object, to configure the client to add the header at runtime.

```C# Snippet:Azure_AI_Inference_BasicEmbeddingAoaiScenarioClientCreate
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_EMBEDDINGS_ENDPOINT"));
var key = System.Environment.GetEnvironmentVariable("AZURE_OPENAI_EMBEDDINGS_KEY");

// For AOAI, currently the key is passed via a different header not directly handled by the client, however
// the credential object is still required. So create with a dummy value.
var credential = new AzureKeyCredential("foo");

AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(key), HttpPipelinePosition.PerCall);

var client = new EmbeddingsClient(endpoint, credential, clientOptions);
```

Alternatively, you can use EntraId to authenticate. This does not require the header policy, but it does currently require a separate built-in policy, `BearerTokenAuthenticationPolicy`, to apply the correct token scope.

```C# Snippet:Azure_AI_Inference_EmbeddingWithEntraIdClientCreate
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_OPENAI_EMBEDDINGS_ENDPOINT"));
var credential = new DefaultAzureCredential(includeInteractiveCredentials: true);
AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();

BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(credential, new string[] { "https://cognitiveservices.azure.com/.default" });
clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

var client = new EmbeddingsClient(endpoint, credential, clientOptions);
```

After the client is created, you can make completion requests with it as shown

```C# Snippet:Azure_AI_Inference_BasicEmbeddingAoai
var input = new List<string> { "King", "Queen", "Jack", "Page" };
var requestOptions = new EmbeddingsOptions(input);

Response<EmbeddingsResult> response = client.Embed(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```

An `async` option is also available.

```C# Snippet:Azure_AI_Inference_BasicEmbeddingAoaiAsync
var input = new List<string> { "King", "Queen", "Jack", "Page" };
var requestOptions = new EmbeddingsOptions(input);

Response<EmbeddingsResult> response = await client.EmbedAsync(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```

### Alternative Response Type

It is also possible to request embeddings as base64 encoded strings, instead of the service default of lists of floats.

```C# Snippet:Azure_AI_Inference_Base64Embedding
var input = new List<string> { "King", "Queen", "Jack", "Page" };
var requestOptions = new EmbeddingsOptions(input)
{
    EncodingFormat = EmbeddingEncodingFormat.Base64,
};

Response<EmbeddingsResult> response = client.Embed(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    string embedding = item.Embedding.ToObjectFromJson<string>();
    Console.WriteLine($"Index: {item.Index}, Embedding: {embedding}");
}
```
