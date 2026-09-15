# Semantic reranking

Create a client using the service endpoint and API key:

```C# Snippet:SemanticReranker_CreateClient
Uri endpoint = new Uri("<semantic-reranker-endpoint>");
AzureKeyCredential credential = new AzureKeyCredential("<api-key>");
InferenceServiceClient client = new InferenceServiceClient(endpoint, credential);
```

Submit a query and documents:

```C#
DataInference inference = client.GetDataInferenceClient();
var request = new SemanticRerankingInferenceRequest(
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

Response<SemanticRerankingResult> response = await inference.SemanticRerankAsync(request);
```
