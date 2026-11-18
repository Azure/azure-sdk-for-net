# Topic Graph: build the corpus, sidecar and retrieval flow

Use the [common preview setup and hotel helpers](Sample23_NovemberPreview.md).
`TopicGraphSetupSearchAndRetrieve` in
[`Sample26_TopicGraphPreview.cs`](../tests/Samples/Sample26_TopicGraphPreview.cs)
is the complete executable example. It requires existing native
`text-embedding-3-small` or `text-embedding-3-large` embeddings, with matching
dimensions (1536 or 3072). Add `Azure.AI.OpenAI`, `OpenAI.Embeddings`, LINQ and
`System.Globalization` namespaces used by the full source.

Set unique `indexName`, `sidecarName`, `sourceName` and `baseName`; `dimensions`
must match the deployment. The sidecar is created first, and the referencing
corpus is deleted first during cleanup.

## Define both indexes and bind profiles

```C# Snippet:Azure_Search_Documents_Sample26_TopicGraph_Indexes
SearchIndex corpus = PreviewHotelIndex(indexName);
corpus.Fields.Add(new SimpleField("topic", SearchFieldDataType.String) { IsFilterable = true, IsFacetable = true });
corpus.Fields.Add(new SearchField("content_vector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
{
    IsSearchable = true,
    IsHidden = true,
    IsStored = true,
    VectorSearchDimensions = dimensions,
    VectorSearchProfileName = "vectors"
});
corpus.VectorSearch = new Azure.Search.Documents.Indexes.Models.VectorSearch
{
    Algorithms = { new HnswAlgorithmConfiguration("cosine") { Parameters = new HnswParameters { Metric = VectorSearchAlgorithmMetric.Cosine } } },
    Profiles = { new VectorSearchProfile("vectors", "cosine") { VectorizerName = "embeddings" } },
    Vectorizers =
    {
        new AzureOpenAIVectorizer("embeddings")
        {
            Parameters = new AzureOpenAIVectorizerParameters
            {
                ResourceUri = new Uri(openAIEndpoint),
                ApiKey = openAIKey,
                DeploymentName = embeddingDeployment,
                ModelName = embeddingModel
            }
        }
    }
};
SearchIndex sidecar = new SearchIndex(sidecarName)
{
    Fields =
    {
        new SimpleField("id", SearchFieldDataType.String) { IsKey = true },
        new SimpleField("subject_id", SearchFieldDataType.String),
        new SearchField("object_vector", SearchFieldDataType.Collection(SearchFieldDataType.Single))
        {
            IsSearchable = true,
            IsStored = true,
            VectorSearchDimensions = dimensions,
            VectorSearchProfileName = "centroids"
        }
    },
    VectorSearch = new Azure.Search.Documents.Indexes.Models.VectorSearch
    {
        Algorithms = { new HnswAlgorithmConfiguration("cosine") { Parameters = new HnswParameters { Metric = VectorSearchAlgorithmMetric.Cosine } } },
        Profiles = { new VectorSearchProfile("centroids", "cosine") }
    }
};
await indexClient.CreateIndexAsync(sidecar);
await indexClient.CreateIndexAsync(corpus);
corpus = await indexClient.GetIndexAsync(indexName);
corpus.VectorSearch.TopicGraphProfiles.Add(
    new VectorSearchTopicGraphProfile("hotel-topics", sidecarName, VectorSearchTopicGraphKind.Balanced)
    {
        DefaultMinDiversityPoolSize = 1000
    });
corpus.Fields.Single(field => field.Name == "content_vector").TopicGraphProfile = "hotel-topics";
await indexClient.CreateOrUpdateIndexAsync(corpus, onlyIfUnchanged: true);
```

## Generate real document/query embeddings and upload representatives

```C# Snippet:Azure_Search_Documents_Sample26_TopicGraph_Data
string[] topics = { "wellness", "dining", "adventure" };
string[] descriptions =
{
    "Relax in the hotel spa with a heated pool, a sauna and quiet gardens.",
    "Enjoy regional hotel dining, rooftop restaurants, local wine and cooking classes.",
    "Explore mountain trails, guided kayaking, rafting and outdoor adventures near the hotel."
};
SearchDocument[] documents = Enumerable.Range(0, 9).Select(number => new SearchDocument
{
    ["id"] = "hotel-" + number.ToString(CultureInfo.InvariantCulture),
    ["title"] = topics[number / 3] + " hotel " + number.ToString(CultureInfo.InvariantCulture),
    ["content"] = descriptions[number / 3] + " Guest room " + number.ToString(CultureInfo.InvariantCulture) + ".",
    ["topic"] = topics[number / 3],
    ["country"] = "Canada",
    ["rating"] = 4
}).ToArray();
string query = "Which hotels offer relaxation, interesting dining, and outdoor adventures?";
EmbeddingClient embeddingClient = new AzureOpenAIClient(new Uri(openAIEndpoint), new AzureKeyCredential(openAIKey))
    .GetEmbeddingClient(embeddingDeployment);
var embeddings = (await embeddingClient.GenerateEmbeddingsAsync(
    documents.Select(document => (string)document["content"]).Concat(new[] { query }),
    new EmbeddingGenerationOptions { Dimensions = dimensions })).Value;
float[][] vectors = embeddings.OrderBy(embedding => embedding.Index)
    .Select(embedding => embedding.ToFloats().ToArray()).ToArray();
for (int number = 0; number < documents.Length; number++)
{
    documents[number]["content_vector"] = vectors[number];
}
// These sampled document vectors are toy representatives, not production topic discovery or computed centroids.
SearchDocument[] representatives = new[] { 0, 3, 6 }.Select(number => new SearchDocument
{
    ["id"] = "topic-" + topics[number / 3],
    ["subject_id"] = topics[number / 3],
    ["object_vector"] = vectors[number]
}).ToArray();
SearchClient searchClient = new SearchClient(endpoint, indexName, credential);
SearchClient sidecarClient = new SearchClient(endpoint, sidecarName, credential);
await UploadPreviewDocumentsAsync(searchClient, documents);
await UploadPreviewDocumentsAsync(sidecarClient, representatives);
```

This tiny demonstration samples three actual document vectors as **toy topic
representatives**. It does not implement production clustering or topic
discovery, and is not a retrieval-quality benchmark. A real ingestion pipeline
must produce the appropriate topic representatives and keep the sidecar current.

## Compare all supported modes

```C# Snippet:Azure_Search_Documents_Sample26_TopicGraph_Search
VectorQueryTopicGraph[] modes =
{
    new NoneVectorQueryTopicGraph(),
    new DiverseVectorQueryTopicGraph { DiversityFactor = 0.2f, MinDiversityPoolSize = 1000 },
    new BalancedVectorQueryTopicGraph { MinDiversityPoolSize = 1000 }
};
foreach (VectorQueryTopicGraph mode in modes)
{
    SearchResults<SearchDocument> response = await searchClient.SearchAsync<SearchDocument>(new SearchOptions
    {
        VectorSearch = new VectorSearchOptions
        {
            Queries = { new VectorizedQuery(vectors[9]) { Fields = { "content_vector" }, KNearestNeighborsCount = 6, TopicGraph = mode } }
        },
        Select = { "id", "title", "topic" },
        Size = 6
    });
    var hits = await ReadPreviewResultsAsync(response);
    Console.WriteLine($"{mode.GetType().Name}: {string.Join(", ", hits.Select(hit => hit.Document["topic"]))}");
}
// Omitting TopicGraph inherits the field's balanced profile.
SearchResults<SearchDocument> inherited = await searchClient.SearchAsync<SearchDocument>(new SearchOptions
{
    VectorSearch = new VectorSearchOptions
    {
        Queries = { new VectorizableTextQuery(query) { Fields = { "content_vector" }, KNearestNeighborsCount = 6 } }
    },
    Size = 6
});
```

The profile defaults to balanced mode. `none` disables sampling; `diverse`
accepts diversity factor and pool size; `balanced` accepts pool size, not diversity
factor. The minimum diversity pool used here is 1000.

## Retrieve through a KB with stored and runtime settings

```C# Snippet:Azure_Search_Documents_Sample26_TopicGraph_Retrieve
await indexClient.CreateKnowledgeSourceAsync(new SearchIndexKnowledgeSource(
    sourceName, new SearchIndexKnowledgeSourceParameters(indexName)
    {
        SemanticConfigurationName = "hotels",
        SearchFields = { new SearchIndexFieldReference("title"), new SearchIndexFieldReference("content"), new SearchIndexFieldReference("content_vector") },
        SourceDataFields = { new SearchIndexFieldReference("id"), new SearchIndexFieldReference("title"), new SearchIndexFieldReference("topic") },
        TopicGraph = new DiverseVectorQueryTopicGraph { DiversityFactor = 0.2f, MinDiversityPoolSize = 1000 }
    }));
await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName, new[] { new KnowledgeSourceReference(sourceName) })
{
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort()
});
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
foreach (VectorQueryTopicGraph mode in new VectorQueryTopicGraph[] { null }.Concat(modes))
{
    KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
    {
        Intents = { new KnowledgeRetrievalSemanticIntent(query) },
        IncludeActivity = true,
        MaxOutputDocuments = 6,
        KnowledgeSourceParams =
        {
            new SearchIndexKnowledgeSourceParams(sourceName)
            {
                AlwaysQuerySource = true,
                FailOnError = true,
                IncludeReferences = true,
                IncludeReferenceSourceData = true,
                TopicGraph = mode
            }
        }
    };
    KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(request);
    Console.WriteLine($"{mode?.GetType().Name ?? "stored diverse"}: {response.References.Count} references");
}
```

The complete sample checks inherited text vectorization, stored source defaults,
each runtime override, real returned document keys and activity errors. Merely
constructing a topic-graph query does not validate the sidecar/profile binding.
