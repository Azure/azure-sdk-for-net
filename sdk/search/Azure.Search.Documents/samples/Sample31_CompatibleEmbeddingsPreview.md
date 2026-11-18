# Compatible embeddings for index queries and managed ingestion

Use the [common preview setup](Sample23_NovemberPreview.md) and the existing,
authorized provider. The executable methods are in
[`Sample31_CompatibleEmbeddingsPreview.cs`](../tests/Samples/Sample31_CompatibleEmbeddingsPreview.cs).
Add `Azure.AI.OpenAI`, `OpenAI.Embeddings`, `System.Globalization` and
`System.Text.Json` namespaces used by the full source.

## Configure the complete embedding route and authentication

Set `AZURE_SEARCH_COMPATIBLE_EMBEDDING_URI`, `_MODEL` and `_DIMENSIONS`, plus exactly
one of `_HEADERS_JSON` or `_MI_AUDIENCE` with the same prefix. The complete HTTPS
URI selects the actual model; Search appends neither a path nor an API version,
and omits `model` from the outbound embedding body. Match model and dimensions to
the indexed vectors. Credentials must match this exact endpoint binding.

```C# Snippet:Azure_Search_Documents_Sample31_EmbeddingParameters
private static OpenAICompatibleVectorizerParameters PreviewCompatibleEmbeddingParameters()
{
    OpenAICompatibleVectorizerParameters parameters = new OpenAICompatibleVectorizerParameters(
        new Uri(RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_EMBEDDING_URI")),
        RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_EMBEDDING_MODEL"))
    {
        Dimensions = int.Parse(RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_EMBEDDING_DIMENSIONS"), CultureInfo.InvariantCulture)
    };
    string headers = Environment.GetEnvironmentVariable("AZURE_SEARCH_COMPATIBLE_EMBEDDING_HEADERS_JSON");
    string audience = Environment.GetEnvironmentVariable("AZURE_SEARCH_COMPATIBLE_EMBEDDING_MI_AUDIENCE");
    if (!string.IsNullOrWhiteSpace(headers) == !string.IsNullOrWhiteSpace(audience))
    {
        throw new InvalidOperationException("Configure exactly one compatible embeddings authentication method.");
    }
    if (!string.IsNullOrWhiteSpace(audience))
    {
        parameters.ManagedIdentityAudience = audience;
    }
    else
    {
        foreach (KeyValuePair<string, string> header in JsonSerializer.Deserialize<Dictionary<string, string>>(headers))
        {
            parameters.Headers.Add(header.Key, header.Value);
        }
    }
    return parameters;
}
```

## Compare query vectorization with real control embeddings

`CompatibleIndexVectorizerMatchesRealEmbeddingControl` starts with
`parameters = PreviewCompatibleEmbeddingParameters()` and the common hotel
`index`, adding a searchable `content_vector` collection with
`VectorSearchDimensions=parameters.Dimensions` and
`VectorSearchProfileName="compatible"`.
The existing native control deployment must be the same model behind the
configured compatible route, not a different embedding space.

```C# Snippet:Azure_Search_Documents_Sample31_CompatibleIndexVectorizer
index.VectorSearch = new Azure.Search.Documents.Indexes.Models.VectorSearch
{
    Algorithms = { new ExhaustiveKnnAlgorithmConfiguration("exact") },
    Profiles = { new VectorSearchProfile("compatible", "exact") { VectorizerName = "provider" } },
    Vectorizers = { new OpenAICompatibleVectorizer("provider", parameters) }
};
await indexClient.CreateIndexAsync(index);
// Generate real control vectors using the existing native deployment behind the compatible route.
string[] texts =
{
    "Relaxing hotel with a pool and spa treatments.",
    "Airport hotel with shuttle buses for early flights.",
    "Downtown business hotel with meeting rooms and conference facilities."
};
EmbeddingClient embeddingClient = new AzureOpenAIClient(
    new Uri(openAIEndpoint), new AzureKeyCredential(openAIKey))
    .GetEmbeddingClient(embeddingDeployment);
var embeddings = (await embeddingClient.GenerateEmbeddingsAsync(texts,
    new EmbeddingGenerationOptions { Dimensions = parameters.Dimensions })).Value;
string[] keys = { "spa", "airport", "business" };
SearchDocument[] documents = texts.Select((text, position) => new SearchDocument
{
    ["id"] = keys[position],
    ["title"] = keys[position],
    ["content"] = text,
    ["content_vector"] = embeddings[position].ToFloats().ToArray()
}).ToArray();
SearchClient searchClient = new SearchClient(endpoint, indexName, credential);
await UploadPreviewDocumentsAsync(searchClient, documents);
SearchResults<SearchDocument> control = await searchClient.SearchAsync<SearchDocument>(null,
    new SearchOptions
    {
        VectorSearch = new VectorSearchOptions
        {
            Queries = { new VectorizedQuery(embeddings[0].ToFloats())
                { Fields = { "content_vector" }, KNearestNeighborsCount = 3, Exhaustive = true } }
        },
        Select = { "id", "content" }
    });
SearchResults<SearchDocument> generated = await searchClient.SearchAsync<SearchDocument>(null,
    new SearchOptions
    {
        VectorSearch = new VectorSearchOptions
        {
            Queries = { new VectorizableTextQuery(texts[0])
                { Fields = { "content_vector" }, KNearestNeighborsCount = 3, Exhaustive = true } }
        },
        Select = { "id", "content" }
    });
```

Both a real stored vector and provider-vectorized text must rank the spa hotel
first. No random/zero vectors or fabricated embedding fixture can establish this.
This flow also checks stored authentication headers are not returned.

## Ingest an approved Blob folder with compatible models

`CompatibleManagedBlobIngestionAndRetrieval` additionally requires
`AZURE_SEARCH_COMPATIBLE_BLOB_CONNECTION_STRING`, `_CONTAINER`, `_FOLDER`, and
`_SOURCE_APPROVED=true`. Use only the approved synthetic fixture described in the
[graph walkthrough](Sample30_GraphExtractionPreview.md), never a container root.
The [bundled fictional file](data/hotel_graph.txt) must be uploaded to your own
container; do not point at the sample authors' storage.
Select `chat` using the [compatible chat configuration](Sample29_ModelProvidersPreview.md).

```C# Snippet:Azure_Search_Documents_Sample31_CompatibleManagedIngestion
await indexClient.CreateKnowledgeSourceAsync(new AzureBlobKnowledgeSource(sourceName,
    new AzureBlobKnowledgeSourceParameters(
        RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_BLOB_CONNECTION_STRING"),
        RequiredPreviewSetting("AZURE_SEARCH_COMPATIBLE_BLOB_CONTAINER"))
    {
        FolderPath = folder,
        IngestionParameters = new KnowledgeSourceIngestionParameters
        {
            EmbeddingModel = new KnowledgeSourceOpenAICompatibleVectorizer(parameters),
            ChatCompletionModel = chat,
            ContentExtractionMode = KnowledgeSourceContentExtractionMode.Minimal,
            DisableImageVerbalization = false
        }
    }));
await WaitForPreviewSourceAsync(indexClient, sourceName);
var stored = (AzureBlobKnowledgeSource)(await indexClient.GetKnowledgeSourceAsync(sourceName)).Value;
string generatedIndexName = OwnedPreviewGeneratedResource(stored, "index");
string indexerName = OwnedPreviewGeneratedResource(stored, "indexer");
SearchIndexerDataSourceConnection dataSource = await indexerClient.GetDataSourceConnectionAsync(
    OwnedPreviewGeneratedResource(stored, "datasource"));
if (dataSource.Container.Query != folder)
{
    throw new InvalidOperationException("The generated data source changed the approved Blob folder scope.");
}
await WaitForPreviewIngestionAsync(indexClient, indexerClient, sourceName, indexerName);
SearchIndex generatedIndex = await indexClient.GetIndexAsync(generatedIndexName);
string vectorField = generatedIndex.Fields.First(field => field.VectorSearchDimensions != null).Name;
SearchClient searchClient = new SearchClient(endpoint, generatedIndexName, credential);
SearchResults<SearchDocument> matches = await searchClient.SearchAsync<SearchDocument>(null, new SearchOptions
{
    VectorSearch = new VectorSearchOptions
    {
        Queries = { new VectorizableTextQuery("Which organizations operate the hotels?")
                { Fields = { vectorField }, KNearestNeighborsCount = 3 } }
    }
});
await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName,
    new[] { new KnowledgeSourceReference(sourceName) })
{
    Models = { chat },
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
});
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(new KnowledgeBaseRetrievalRequest
{
    Messages =
    {
        new KnowledgeBaseMessage(new[]
        {
            new KnowledgeBaseMessageTextContent("Which organizations operate the hotels?")
        }) { Role = "user" }
    },
    IncludeActivity = true
});
```

The sample validates the generated data-source scope, waits for ingestion,
executes generated-index text vectorization, and retrieves through a KB.
Outside graph extraction, supplying a chat model with
`DisableImageVerbalization=true` is invalid. The synthetic text fixture verifies
embedding ingestion/querying, not image verbalization. A dedicated image fixture
and provider telemetry are needed to prove that separate processing path.

Changing the managed source's embedding model kind requires recreating and
reindexing the source; URI/model/dimensions are not mutable after creation.
Readiness/resource-ownership helpers are in the graph walkthrough. Direct
Azure OpenAI-backed compatibility is not evidence that an APIM gateway was tested.

The full executable sample deletes the KB and then the source. Compatible-source
cascading deletion can partially succeed and report a skillset-cleanup failure.
Only for that exact failure, the example removes the verified orphaned skillset
through the ordinary authorized SDK operation, then retries source deletion.
Never delete managed dependencies before their parent or bypass an ownership lock.
Use only names returned by this run's source and verified to have its unique prefix;
never delete similarly named shared resources or modify an existing source.
