# Simple Embeddings

This sample demonstrates how to get embeddings for a provided image. Here we use the service default of returning embeddings as a list of floating point values.

This sample assumes the AI model is hosted on a Serverless API or Managed Compute endpoint. For GitHub Models or Azure OpenAI endpoints, the client constructor needs to be modified. See package documentation for details.

## Usage

Set these two environment variables before running the sample:

1. AZURE_AI_IMAGE_EMBEDDINGS_ENDPOINT - Your endpoint URL, in the form `https://your-deployment-name.your-azure-region.inference.ai.azure.com` where `your-deployment-name` is your unique AI Model deployment name, and `your-azure-region` is the Azure region where your model is deployed.

2. AZURE_AI_IMAGE_EMBEDDINGS_KEY - Your model key. Keep it secret.

```C# Snippet:Azure_AI_Inference_BasicImageEmbedding
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_KEY"));

var client = new ImageEmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());

List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
{
    ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
};

var requestOptions = new ImageEmbeddingsOptions(input);

Response<EmbeddingsResult> response = client.Embed(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```

An `async` option is also available.

```C# Snippet:Azure_AI_Inference_BasicImageEmbeddingAsync
var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_ENDPOINT"));
var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_IMAGE_EMBEDDINGS_KEY"));

var client = new ImageEmbeddingsClient(endpoint, credential, new AzureAIInferenceClientOptions());

List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
{
    ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
};

var requestOptions = new ImageEmbeddingsOptions(input);

Response<EmbeddingsResult> response = await client.EmbedAsync(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    List<float> embedding = item.Embedding.ToObjectFromJson<List<float>>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{string.Join(", ", embedding)}>");
}
```

### Alternative Response Type

It is also possible to request embeddings as base64 encoded strings, instead of the service default of lists of floats.

```C# Snippet:Azure_AI_Inference_Base64ImageEmbedding
List<ImageEmbeddingInput> input = new List<ImageEmbeddingInput>
{
    ImageEmbeddingInput.Load(imageFilePath:"sampleImage.png", imageFormat:"png")
};

var requestOptions = new ImageEmbeddingsOptions(input)
{
    EncodingFormat = EmbeddingEncodingFormat.Base64,
};

Response<EmbeddingsResult> response = client.Embed(requestOptions);
foreach (EmbeddingItem item in response.Value.Data)
{
    string embedding = item.Embedding.ToObjectFromJson<string>();
    Console.WriteLine($"Index: {item.Index}, Embedding: <{embedding}>");
}
```
