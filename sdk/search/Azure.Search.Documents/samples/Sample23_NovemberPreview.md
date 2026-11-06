# Graph and retrieval options (2026-11-01-preview)

These APIs require a service and index configured for the corresponding preview
capabilities. The preview package defaults to `2026-11-01-preview`; applications
can still explicitly select an older supported service version.

Use the endpoint and credential setup from the [getting started guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/README.md#getting-started).
The examples use these namespaces:

```csharp
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
```

## Query a graph index

```csharp
var client = new SearchClient(endpoint, graphIndexName, credential);
Response<GraphQueryResult> response = await client.GraphAsync(
    "MATCH (n) RETURN n.name AS name",
    includeDiagnostics: true,
    includeStatistics: true);

foreach (GraphQueryRow row in response.Value.Value)
{
    Console.WriteLine(row.AdditionalProperties["name"].ToObjectFromJson<string>());
}
foreach (GraphQueryDiagnostic diagnostic in response.Value.Diagnostics)
{
    Console.WriteLine($"{diagnostic.Code}: {diagnostic.Message}");
}
```

Use diagnostic codes rather than parsing human-readable messages. Explain plans
are diagnostic representations, not executable query contracts.

## Topic-graph vector retrieval

```csharp
var query = new VectorizedQuery(embedding)
{
    KNearestNeighborsCount = 10,
    Fields = { "contentVector" },
    TopicGraph = new BalancedVectorQueryTopicGraph { MinDiversityPoolSize = 1000 }
};
var options = new SearchOptions
{
    VectorSearch = new VectorSearchOptions { Queries = { query } }
};
Response<SearchResults<SearchDocument>> results =
    await client.SearchAsync<SearchDocument>(null, options);
```

`NoneVectorQueryTopicGraph` disables topic-graph sampling.
`DiverseVectorQueryTopicGraph` favors diversity; `BalancedVectorQueryTopicGraph`
balances diversity with relevance. Configure a topic-graph profile on the vector
search index before using diversity-aware retrieval.

## Automatically ground a stored filter hint

```csharp
var hint = new SearchIndexKnowledgeSourceFilterHint("category")
{
    AutoConfiguration = new SearchIndexKnowledgeSourceFilterHintAutoConfiguration
    {
        CacheTtl = 300,
        MaxFacetValueCount = 32
    }
};
```

Add the hint to a search-index knowledge source's stored
`QueryHints.Filters`. The field must be both filterable and facetable.
Do not combine `AutoConfiguration` with explicit `FieldValues`, or use it in
request-time overrides. Auto-configuration is not supported on indexes with
document-level permissions or Purview sensitivity labels.

## Seeded random ordering

```csharp
var profile = new ScoringProfile("random-order")
{
    Functions =
    {
        new RandomScoringFunction
        {
            Parameters = new RandomScoringParameters("seed")
        }
    }
};
var options = new SearchOptions
{
    ScoringProfile = "random-order",
    ScoringParameters = { "seed-42" }
};
```

Add the profile to the index first. A random profile cannot contain text weights
or other scoring functions. Random scoring replaces query and vector similarity
scores; omit parameters for request-scoped random ordering.
