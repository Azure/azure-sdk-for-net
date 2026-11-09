# Semantic reranking

Create a client using the service endpoint and API key:

```C# Snippet:SemanticReranker_CreateClient
Uri endpoint = new Uri("<semantic-reranker-endpoint>");
AzureKeyCredential credential = new AzureKeyCredential("<api-key>");
InferenceClient client = new InferenceClient(endpoint, credential);
```

Submit a query and documents:

```C# Snippet:SemanticReranker_RerankDocuments
var request = new SemanticRerankingOptions(
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

Response<SemanticRerankingResult> response = await client.SemanticRerankAsync(request);
SemanticRerankingMetadata metadata = response.Value.Metadata;
```

For JSON documents, add up to 100 property paths to `TargetPaths`. The client sends
the collection as the comma-separated string expected by the service. The API
contract specifies a maximum of 100 paths:

```C# Snippet:SemanticReranker_RerankJsonDocuments
var request = new SemanticRerankingOptions(
    "What is the capital of France?",
    new[] { "{\"id\":\"france\",\"meta\":{\"content\":\"Paris is the capital of France.\"}}" })
{
    DocumentType = SemanticRerankingDocumentType.Json,
    TargetPaths = { "meta.content", "id" }
};

Response<SemanticRerankingResult> response = await client.SemanticRerankAsync(request);
```
