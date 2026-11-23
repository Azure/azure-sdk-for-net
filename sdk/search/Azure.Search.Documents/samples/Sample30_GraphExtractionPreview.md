# Managed graph extraction, enrichment cache, status and KB retrieval

Use the [common preview setup](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample23_NovemberPreview.md). The full
`ManagedGraphExtractionCacheStatusAndRetrieval` example is in
[`Sample30_GraphExtractionPreview.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/tests/Samples/Sample30_GraphExtractionPreview.cs).

## Existing-resource prerequisites

Use an explicitly approved nonempty synthetic Blob prefix ending in `/`.
`AZURE_STORAGE_CONNECTION_STRING`, `AZURE_STORAGE_CONTAINER` and
`AZURE_STORAGE_FOLDER` identify it; set `SEARCH_GRAPH_SOURCE_APPROVED=true` only
after verifying its contents. The sample reads, but never uploads/deletes, source
blobs. Upload the bundled fictional [`data/hotel_graph.txt`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/data/hotel_graph.txt)
to a dedicated prefix in your own container as described in the
[sample-data setup](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample23_NovemberPreview.md#supply-your-own-resources-and-sample-data).
It contains Historic Harbor Hotel operated by Contoso Hospitality, and Mountain
View Inn operated by Alpine Hospitality. No access to the sample authors' storage
is needed.

Native Blob soft delete must already be enabled. ADLS Gen2, permission ingestion
and sensitivity-label ingestion are not supported for this flow. Existing native
chat and embedding deployments must be reachable and authorized. Use
`SEARCH_GRAPH_CACHE_CONNECTION_STRING` for an existing GPv2 account with Blob and
Table endpoints. Resource-ID connections require Search's identity to have source
read permissions and cache Blob/Table write permissions. Do not change settings
or grant roles just to run a sample.

Choose unique `sourceName`/`baseName`, `graphName="hotels"`, and the native `chat`
model, endpoint/key and embedding deployment/profile from the common setup.

## Supply the ontology and configure graph extraction

```C# Snippet:Azure_Search_Documents_Sample30_Ontology
string ontology = """
    {
      "@context": {
        "owl": "http://www.w3.org/2002/07/owl#",
        "rdfs": "http://www.w3.org/2000/01/rdf-schema#",
        "ekg": "https://schema.search.azure.com/graph-extraction#"
      },
      "@graph": [
        { "@id": "ekg:Hotel", "@type": "owl:Class",
          "rdfs:comment": "A hotel property, distinct from its operating organization." },
        { "@id": "ekg:Organization", "@type": "owl:Class",
          "rdfs:comment": "An organization operating hotel properties." },
        { "@id": "ekg:operatedBy", "@type": "owl:ObjectProperty",
          "rdfs:domain": { "@id": "ekg:Hotel" }, "rdfs:range": { "@id": "ekg:Organization" },
          "rdfs:comment": "The organization operating the hotel." }
      ]
    }
    """;
```

```C# Snippet:Azure_Search_Documents_Sample30_GraphExtraction
AzureBlobKnowledgeSource source = new AzureBlobKnowledgeSource(sourceName,
    new AzureBlobKnowledgeSourceParameters(
        RequiredPreviewSetting("AZURE_STORAGE_CONNECTION_STRING"),
        RequiredPreviewSetting("AZURE_STORAGE_CONTAINER"))
    {
        FolderPath = folder,
        IsADLSGen2 = false,
        GraphExtraction = new KnowledgeSourceGraphExtractionParameters(graphName)
        {
            Ontology = new KnowledgeSourceGraphOntology("inline", ontology) { Name = "hotel-relationships" }
        },
        IngestionParameters = new KnowledgeSourceIngestionParameters
        {
            EmbeddingModel = new KnowledgeSourceAzureOpenAIVectorizer
            {
                AzureOpenAIParameters = new AzureOpenAIVectorizerParameters
                {
                    ResourceUri = new Uri(openAIEndpoint),
                    ApiKey = openAIKey,
                    DeploymentName = embeddingDeployment,
                    ModelName = embeddingModel
                }
            },
            ChatCompletionModel = chat,
            ContentExtractionMode = KnowledgeSourceContentExtractionMode.Minimal,
            DisableImageVerbalization = true,
            Cache = new KnowledgeSourceCache(RequiredPreviewSetting("SEARCH_GRAPH_CACHE_CONNECTION_STRING"))
            {
                EnableReprocessing = true
            }
        }
    });
await indexClient.CreateKnowledgeSourceAsync(source);
await WaitForPreviewSourceAsync(indexClient, sourceName);
AzureBlobKnowledgeSource stored = (AzureBlobKnowledgeSource)(await indexClient.GetKnowledgeSourceAsync(sourceName)).Value;
// Read only generated names returned by this newly created source; never guess shared names.
string indexerName = OwnedPreviewGeneratedResource(stored, "indexer");
string graphIndexName = OwnedPreviewGeneratedResource(stored, "graphIndex");
string chunksIndexName = OwnedPreviewGeneratedResource(stored, "index");
string dataSourceName = OwnedPreviewGeneratedResource(stored, "datasource");
SearchIndexerDataSourceConnection dataSource = await indexerClient.GetDataSourceConnectionAsync(dataSourceName);
if (dataSource.Container.Query != folder)
{
    throw new InvalidOperationException("The generated data source changed the approved Blob folder scope.");
}
CompletedSynchronizationState completed = await WaitForPreviewIngestionAsync(
    indexClient, indexerClient, sourceName, indexerName);
Console.WriteLine($"Written graph triples in this synchronization: {completed.GraphStatistics?.TriplesWritten}");
// A successful ingestion or unchanged chunk count does not establish a cache hit.
```

`GraphExtraction` belongs under the Blob parameters, not an old draft
`ingestionParameters.graphParameters`. The cache connection string is write-only.
Once configured, the cache cannot be removed or rebound; reprocessing must stay
enabled. Inspect actual execution telemetry before claiming cache reuse. A
successful synchronization, unchanged chunks, or `TriplesWritten` is not a cache
hit measurement; triples are per synchronization, not total graph size.
Search-owned generated resources are deleted with this run's source. Do not
delete shared storage or unrelated cache data.

These helpers validate returned resource ownership and wait for actual successful
synchronization rather than fixed sleeps:

```C# Snippet:Azure_Search_Documents_Sample30_GeneratedResource
private static string OwnedPreviewGeneratedResource(AzureBlobKnowledgeSource source, string kind)
{
    if (source.AzureBlobParameters.CreatedResources?.AdditionalProperties.TryGetValue(kind, out string name) != true ||
        !name.StartsWith(source.Name + "-", StringComparison.Ordinal))
    {
        throw new InvalidOperationException("The newly created source did not return a run-owned generated resource.");
    }
    return name;
}
```

```C# Snippet:Azure_Search_Documents_Sample30_WaitForIngestion
private static async Task WaitForPreviewSourceAsync(SearchIndexClient indexes, string sourceName)
{
    for (int attempt = 0; attempt < 60; attempt++)
    {
        KnowledgeSourceStatus status = await indexes.GetKnowledgeSourceStatusAsync(sourceName);
        if (status.SynchronizationStatus.ToString() == "active")
        {
            return;
        }
        if (status.SynchronizationStatus.ToString().IndexOf("failed", StringComparison.OrdinalIgnoreCase) >= 0)
        {
            throw new InvalidOperationException("The run-owned knowledge source failed to initialize.");
        }
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
    throw new TimeoutException("The run-owned knowledge source did not become active within five minutes.");
}

private static async Task<CompletedSynchronizationState> WaitForPreviewIngestionAsync(
    SearchIndexClient indexes, SearchIndexerClient indexers, string sourceName, string indexerName)
{
    for (int attempt = 0; attempt < 60; attempt++)
    {
        KnowledgeSourceStatus status = await indexes.GetKnowledgeSourceStatusAsync(sourceName);
        SearchIndexerStatus indexerStatus = await indexers.GetIndexerStatusAsync(indexerName);
        IndexerExecutionResult execution = indexerStatus.LastResult;
        if (indexerStatus.Status == IndexerStatus.Error ||
            execution?.Status == IndexerExecutionStatus.TransientFailure)
        {
            throw new InvalidOperationException("Run-owned ingestion failed; inspect dependency permissions and indexer errors.");
        }
        if (status.CurrentSynchronizationState == null && status.LastSynchronizationState != null &&
            execution?.Status == IndexerExecutionStatus.Success)
        {
            if (execution.FailedItemCount != 0 || status.LastSynchronizationState.ItemsUpdatesFailed != 0)
            {
                throw new InvalidOperationException("Ingestion completed with failed source documents.");
            }
            return status.LastSynchronizationState;
        }
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
    throw new TimeoutException("Run-owned ingestion did not complete successfully within five minutes.");
}
```

## Query the extracted relationship and retrieve through a KB

```C# Snippet:Azure_Search_Documents_Sample30_GraphRetrieval
SearchIndex graphIndex = await indexClient.GetIndexAsync(graphIndexName);
string graphFilter = $"{graphIndex.GraphProfile.Fields.GraphNameField} eq '{graphName}'";
SearchClient graphClient = new SearchClient(endpoint, graphIndexName, credential);
GraphQueryResult relationships = await graphClient.GraphAsync(
    "MATCH (h:Hotel)-[r:operatedBy]->(o:Organization) RETURN h.name AS hotel, o.name AS organization LIMIT 10",
    filter: graphFilter,
    provenance: new GraphQueryProvenanceParameters(GraphQueryProvenanceKind.Ids) { MaxEvidencePerRow = 5 },
    includeDiagnostics: true, includeStatistics: true);
foreach (GraphQueryRow row in relationships.Value)
{
    Console.WriteLine($"{row.AdditionalProperties["hotel"]}: {row.AdditionalProperties["organization"]}");
}
await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(baseName,
    new[] { new KnowledgeSourceReference(sourceName) })
{
    Models = { chat },
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort(),
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
});
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(
    new KnowledgeBaseRetrievalRequest
    {
        Messages =
        {
            new KnowledgeBaseMessage(new[]
            {
                new KnowledgeBaseMessageTextContent("Using the knowledge graph, which organizations operate the hotels?")
            }) { Role = "user" }
        },
        IncludeActivity = true,
        KnowledgeSourceParams =
        {
            new AzureBlobKnowledgeSourceParams(sourceName)
            {
                IncludeReferences = true,
                IncludeReferenceSourceData = true,
                GraphParameters = new AgentRuntimeGraphParams { IncludeQuery = true }
            }
        }
    });
foreach (KnowledgeBaseGraphSearchActivityRecord activity in response.Activity.OfType<KnowledgeBaseGraphSearchActivityRecord>())
{
    Console.WriteLine($"Generated GQL: {activity.GraphSearchArguments?.Gql}");
}
```

The full sample checks the generated graph's provenance-index binding, known
hotel/operator evidence, graph references, generated GQL and activity errors.
This is distinct from [manually uploading an edge-list graph](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample27_GraphIndexPreview.md).
