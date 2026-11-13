# Azure Data AI client library for .NET

Azure.Data.AI provides semantic reranking and multimodal embedding operations for .NET applications.

Version `1.1.0-beta.1` is a preview release that defaults to service API version `2026-11-01-preview`.
For semantic reranking against the stable API, configure `InferenceClientOptions.ServiceVersion.V2026_10_30`.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Data.AI --prerelease
```

To select only stable package versions, omit `--prerelease`:

```dotnetcli
dotnet add package Azure.Data.AI
```

### Prerequisites

- `Azure.Core` version 1.64.0 or later. This dependency is installed automatically; if your application references `Azure.Core` directly or pins it through central package management, update that reference to at least 1.64.0.
- You must have a [Microsoft Azure subscription](https://azure.microsoft.com/free/dotnet/).
- A Semantic Reranker endpoint.
- Either an API key or a Microsoft Entra identity assigned the **Semantic Reranker User** role on the `Microsoft.InferenceService/inferenceAccounts` resource.

### Authenticate the client

Create a client with an API key:

```C# Snippet:SemanticReranker_CreateClient
Uri endpoint = new Uri("<semantic-reranker-endpoint>");
AzureKeyCredential credential = new AzureKeyCredential("<api-key>");
InferenceClient client = new InferenceClient(endpoint, credential);
```

Or authenticate with a `TokenCredential`, such as `DefaultAzureCredential` from
[`Azure.Identity`](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme):

```C#
Uri endpoint = new Uri("<semantic-reranker-endpoint>");
InferenceClient client = new InferenceClient(endpoint, new DefaultAzureCredential());
```

The generated bearer-token policy requests the `https://dbinference.azure.com/.default` scope.

## Key concepts

Use `InferenceClient.SemanticRerank` or `SemanticRerankAsync` to rerank documents directly.
Pass a `SemanticRerankingContent` instance and read the scores and `Metadata` from
the returned `SemanticRerankingResult`. For JSON documents, set `DocumentType` to
`SemanticRerankingDocumentType.Json` and add up to 100 property paths to the
`TargetPaths` collection; the client serializes them as a comma-separated string.
The API contract specifies a maximum of 100 paths.

Use `InferenceClient.GetEmbeddings` or `GetEmbeddingsAsync` to embed text, queries, or document images.
Request settings are named method arguments; no request options object is required.
Embedding model availability and image input support depend on the endpoint.

## Examples

### Multimodal embeddings with anonymous inputs

The .NET overloads accept anonymous objects or dictionaries using the JSON property names
`kind`, `id`, `content`, `url`, and `sasToken`. Omit `kind` for text, or set it to `query` or `image`.
Anonymous members and dictionary keys can also use PascalCase, and `kind` accepts
`EmbeddingContentKind` values. Unknown or duplicate properties are rejected before sending.
`JsonElement` inputs must use the exact JSON property names.
Settings stay as named arguments and the response is typed.
For image inputs, authenticate `client` with Microsoft Entra ID and provide a caller-signed
user-delegation SAS for the image blob.

```C# Snippet:Inference_GetMultimodalEmbeddings
Response<EmbeddingResult> response = await client.GetEmbeddingsAsync(
    inputs: new object[]
    {
        new
        {
            id = "map-question",
            kind = "query",
            content = "Which walking route follows the lake?"
        },
        new
        {
            id = "trail-map",
            kind = "image",
            url = imageBlobUrl,
            sasToken = imageSasToken
        }
    },
    model: "microsoft-embedding-1-large",
    modelVersion: "<supported-model-version>",
    dimensions: 2560,
    delivery: EmbeddingDelivery.Inline);

EmbeddingResult result = response.Value;
```

Use a model version and dimension supported by your endpoint. Omit `dimensions` to use the
model's native width. Each input produces a separate embedding, not a fused query/image embedding.
Anonymous inputs use reflection-based JSON serialization; trimmed or Native AOT applications
should use the typed `EmbeddingInput` overloads instead. These inputs have a parameterless
constructor and optional `ContentKind`, so text inputs only need `Content`. `EmbeddingResult` exposes generic
`EmbeddingItem` and `EmbeddingUsage` bases; cast to the concrete multimodal models to access their
vector payloads and modality-specific metadata.

See [Semantic reranking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/dataai/Azure.Data.AI/samples/Sample1_SemanticReranking.md).

## Troubleshooting

Service operations throw `RequestFailedException` when the service returns a non-success status code.

## Next steps

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (for example, label, comment). Follow the instructions provided by the bot. You'll only need to do this action once across all repositories using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information, see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any other questions or comments.
