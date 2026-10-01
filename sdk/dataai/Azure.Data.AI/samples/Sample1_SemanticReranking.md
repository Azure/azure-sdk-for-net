# Semantic reranking

Create a client using the service endpoint and API key:

```C# Snippet:SemanticReranker_CreateClient
Uri endpoint = new Uri("<semantic-reranker-endpoint>");
AzureKeyCredential credential = new AzureKeyCredential("<api-key>");
InferenceClient client = new InferenceClient(endpoint, credential);
```

Submit a query and documents:

```C#
var request = new SemanticRerankingInferenceContent(
    "What is the capital of France?",
    new[]
    {
        "Paris is the capital of France.",
        "Berlin is the capital of Germany."
    })
{
    TopK = 1,
    ReturnDocuments = true
};

Response<SemanticRerankingInferenceResult> response = await client.SemanticRerankAsync(request);
```
