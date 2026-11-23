# Agentic search, Microsoft Retriever, KB tools and automatic filter hints

Start with the [common hotel setup](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample23_NovemberPreview.md) and a service
supporting these November preview capabilities. The complete three test methods
are in [`Sample25_AgenticAndToolsPreview.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/tests/Samples/Sample25_AgenticAndToolsPreview.cs).
Each creates and cleans up its own index, source and knowledge base.

## Agentic search and model-free minimal retrieval

`AgenticSearchAndMicrosoftRetriever` first queries the seeded index and inspects
termination, subqueries and `reasoningTokens`. Usage is shared accounting, not an
additional amount to add a second time.

```C# Snippet:Azure_Search_Documents_Sample25_AgenticSearch
SearchResults<SearchDocument> search = await searchClient.SearchAsync<SearchDocument>(
    "Find hotel guest benefits including complimentary wireless internet and breakfast.",
    new SearchOptions
    {
        QueryType = SearchQueryType.Agentic,
        Debug = QueryDebugMode.Agentic,
        SemanticSearch = new SemanticSearchOptions { SemanticConfigurationName = "hotels" },
        AgenticOptions = new AgenticSearchOptions { MaxRuntimeInSeconds = 30 },
        Select = { "id", "title", "content" },
        Size = 3
    });
await foreach (SearchResult<SearchDocument> hit in search.GetResultsAsync())
{
    Console.WriteLine(hit.Document["title"]);
}
AgenticSearchDebugInfo debug = search.DebugInfo.Agentic;
Console.WriteLine($"Termination: {debug.TerminationReason}");
Console.WriteLine($"Planning tokens: {debug.Usage.AgenticPlanningTokens}; reasoning tokens: {debug.Usage.ReasoningTokens}");
// Usage includes work on candidates that were not returned; do not add it again as separate billing.
```

The same flow creates a search-index source and a minimal Microsoft Retriever 1
KB, then checks retrieved references against the uploaded document keys. No
customer OpenAI deployment is required for this minimal flow.

```C# Snippet:Azure_Search_Documents_Sample25_MicrosoftRetriever
await indexClient.CreateKnowledgeSourceAsync(new SearchIndexKnowledgeSource(
    sourceName, new SearchIndexKnowledgeSourceParameters(indexName)));
await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(
    baseName, new[] { new KnowledgeSourceReference(sourceName) })
{
    Models = { new KnowledgeBaseMicrosoftRetriever1Model() },
    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort(),
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData
});
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
KnowledgeBaseRetrievalResponse retrieved = await retrievalClient.RetrieveAsync(new KnowledgeBaseRetrievalRequest
{
    Intents = { new KnowledgeRetrievalSemanticIntent("hotel guest benefits") },
    IncludeActivity = true
});
foreach (KnowledgeBaseSearchIndexReference reference in retrieved.References.OfType<KnowledgeBaseSearchIndexReference>())
{
    Console.WriteLine($"Retrieved hotel: {reference.DocKey}");
}
```

## Configure and select a tool

`KnowledgeBaseToolsSelectAndClear` creates the source over the seeded hotel index,
persists a Canada-only tool, and selects it using singular `ToolName`.

```C# Snippet:Azure_Search_Documents_Sample25_KnowledgeBaseTools
KnowledgeBase knowledgeBase = new KnowledgeBase(baseName, new[] { new KnowledgeSourceReference(sourceName) })
{
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort(),
    Tools =
    {
        new KnowledgeBaseTool("canada-hotels", "Find hotel guest benefits in Canada.",
            new[]
            {
                new KnowledgeBaseToolKnowledgeSourceReference(sourceName)
                {
                    FilterAddOn = "country eq 'Canada'",
                    AlwaysQuerySource = true,
                    FailOnError = true
                }
            })
        {
            RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort(),
            RetrieveDefaults = new KnowledgeBaseRetrieveDefaults { MaxOutputDocuments = 10 }
        }
    }
};
await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    Intents = { new KnowledgeRetrievalSemanticIntent("hotel guest benefits") },
    ToolName = "canada-hotels",
    IncludeActivity = true
};
KnowledgeBaseRetrievalResponse selected = await retrievalClient.RetrieveAsync(request);
foreach (KnowledgeBaseSearchIndexReference reference in selected.References.OfType<KnowledgeBaseSearchIndexReference>())
{
    Console.WriteLine($"Tool-scoped hotel: {reference.DocKey}");
}
```

The full executable sample verifies exactly the two Canadian references, reads
the KB, clears `Tools`, saves with `onlyIfUnchanged: true`, and verifies ordinary
KB-wide retrieval again includes the third hotel. Clearing configuration is an
update operation, not a local-only collection change.

## Ground model-generated filters in actual facets

`QueryHintsAutomaticallyGroundFacetValues` also requires the existing native chat
deployment described in the common setup. Its `model` is a
`KnowledgeBaseAzureOpenAIModel`. It stores automatic configuration on the source
and lets query planning resolve the country from actual index facets.

```C# Snippet:Azure_Search_Documents_Sample25_QueryHintsAutoConfiguration
SearchResults<SearchDocument> facets = await searchClient.SearchAsync<SearchDocument>("*",
    new SearchOptions { Facets = { "country,count:16" }, Size = 0 });
Console.WriteLine($"Available countries: {string.Join(", ", facets.Facets["country"].Select(facet => facet.Value))}");
SearchIndexKnowledgeSource source = new SearchIndexKnowledgeSource(
    sourceName, new SearchIndexKnowledgeSourceParameters(indexName)
    {
        QueryHints = new SearchIndexKnowledgeSourceQueryHints
        {
            Filters =
            {
                new SearchIndexKnowledgeSourceFilterHint("country")
                {
                    AutoConfiguration = new SearchIndexKnowledgeSourceFilterHintAutoConfiguration
                    {
                        CacheTtl = 60,
                        MaxFacetValueCount = 16
                    },
                    FilterInstructions = "When a country is specified, filter country using the exact resolved facet value."
                }
            }
        }
    });
await indexClient.CreateKnowledgeSourceAsync(source);
await indexClient.CreateKnowledgeBaseAsync(new KnowledgeBase(
    baseName, new[] { new KnowledgeSourceReference(sourceName) })
{
    Models = { model },
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
    RetrievalReasoningEffort = new KnowledgeRetrievalLowReasoningEffort()
});
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(endpoint, baseName, credential);
// No explicit field values or request filter forces the result.
KnowledgeBaseRetrievalResponse response = await retrievalClient.RetrieveAsync(new KnowledgeBaseRetrievalRequest
{
    Messages =
    {
        new KnowledgeBaseMessage(new[]
        {
            new KnowledgeBaseMessageTextContent("Find hotel guest benefits for hotels in Canada only.")
        })
        {
            Role = "user"
        }
    },
    IncludeActivity = true
});
foreach (KnowledgeBaseSearchIndexActivityRecord activity in response.Activity.OfType<KnowledgeBaseSearchIndexActivityRecord>())
{
    Console.WriteLine($"Generated filter: {activity.QueryHintProcessing?.GeneratedFilter}");
}
```

No explicit `FieldValues`, request filter, or tool filter forces a Canadian
result. The executable sample checks the generated activity filter and exact
seeded references. The field must be filterable and facetable. Do not combine
automatic configuration with explicit field values or request-time overrides,
document permissions, or sensitivity labels. TTL is at least 60 seconds and the
maximum facet-value count is 64.
