# Graph and retrieval options (2026-11-01-preview)

These APIs require a service and index configured for the corresponding preview
capabilities. The preview package defaults to `2026-11-01-preview`; applications
can still explicitly select an older supported service version.

For an application, install this preview package explicitly; the stable package
in the getting-started guide does not contain these preview APIs:

```powershell
dotnet add package Azure.Search.Documents --version 12.2.0-beta.1
```

## End-to-end walkthroughs

These samples create uniquely named Search resources, use a small synthetic hotel
corpus, and clean up only resources successfully created by their run. They never
provision model deployments, grant permissions, change existing service settings,
or upload/delete shared Blob or OneLake fixture files.

| Walkthrough | Integrated operations |
|---|---|
| [Random scoring](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample24_RandomScoringPreview.md) | Create an index, upload documents, seed and rotate ordering, page and filter results |
| [Agentic search, Microsoft Retriever, tools and hints](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample25_AgenticAndToolsPreview.md) | Search with usage/debugging; create sources and KBs; retrieve with tools or grounded filters |
| [Topic Graph](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample26_TopicGraphPreview.md) | Create corpus and sidecar, generate real embeddings, compare modes, retrieve through a KB |
| [Graph index](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample27_GraphIndexPreview.md) | Define graph/provenance indexes, upload assertions, inspect a query plan and execute relationships |
| [File ingestion operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample28_FileIngestionLroPreview.md) | Start/poll upload and replacement operations, inspect retained operations, retrieve the replacement |
| [Compatible chat and native GPT-6](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample29_ModelProvidersPreview.md) | Use existing models with a newly created index/source/KB and inspect actual seeded references |
| [Compatible embeddings and ingestion](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample31_CompatibleEmbeddingsPreview.md) | Compare provider-vectorized text with real control embeddings; ingest an approved Blob folder |
| [Managed graph extraction](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample30_GraphExtractionPreview.md) | Configure ontology/cache, wait for synchronization, inspect status, query and retrieve the extracted graph |
| [Chat completion skill](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/Sample32_ChatCompletionSkillPreview.md) | Run a skillset/indexer over approved synthetic text and inspect indexed model output |

### Run the compiled samples

The complete executable samples are the `NovemberPreviewSamples` partial fixture
in [`tests/Samples`](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/search/Azure.Search.Documents/tests/Samples), including
[`Sample23_NovemberPreviewSupport.cs`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/tests/Samples/Sample23_NovemberPreviewSupport.cs).
They run in both synchronous and asynchronous client modes. These timing-sensitive,
model-dependent walkthroughs are live-only; a playback skip is not a live pass.
Coordinate an exclusive testing window before using a shared service.

In the repository test harness, set `AZURE_TEST_MODE=Live`,
`AZURE_DISABLE_AUTO_RECORDING=true`, and `AZURE_DISABLE_BOOTSTRAPPING=true`.
Set `SEARCH_SEARCH_SERVICE_NAME`, `SEARCH_SEARCH_ADMIN_API_KEY`, and
`SEARCH_SEARCH_ENDPOINT_SUFFIX` for the intended service, plus
`SEARCH_PREVIEW_EXPECTED_ENDPOINT` to its exact HTTPS endpoint. The latter is
checked against the effective test configuration before Search clients are created.
The `SEARCH_`-prefixed settings take precedence over values in the encrypted test
environment file; setting only unprefixed values might not override that file.
Do not edit shared environment files to target a temporary run.

Run one flow first, for example:

```powershell
dotnet test .\sdk\search\Azure.Search.Documents\tests\Azure.Search.Documents.Tests.csproj `
    --framework net10.0 `
    --filter "FullyQualifiedName~NovemberPreviewSamples&Name=RandomScoringEndToEnd"
```

Each walkthrough lists its additional existing-resource prerequisites. Missing
fixture approval explicitly skips Blob/OneLake examples; it does not demonstrate
that feature. Search resources are removed in reverse dependency order even when
an assertion fails. Interrupting the test host prevents `finally` cleanup, so keep
the run's resource names and before/after inventories for exact owned-resource
recovery. Never use service-wide cleanup on a shared service.

### Supply your own resources and sample data

Use your own Search endpoint, credentials, model deployments and storage
configuration. No walkthrough requires access to the environment used to validate
these samples. The common hotel records are embedded below; the Blob examples use
the bundled, entirely fictional [`data/hotel_graph.txt`](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/samples/data/hotel_graph.txt).

For Blob examples, upload that file to a new dedicated prefix in a container you
own, for example `preview-hotels/hotel_graph.txt`. Keep only this file under that
prefix: the chat-skill example expects exactly one input document. Configure the
documented connection string, container and folder settings with your own values,
using `preview-hotels/` as the folder in this example. Ensure the required existing
permissions and feature-specific storage settings are in place before setting a
fixture approval variable. The samples read source blobs but do not upload them
or change permissions for you.

You may use different data, but then adapt the ontology, queries and expected
hotel facts in the executable examples. Never use private or production content
merely to satisfy a sample assertion.

### Common setup and helper methods

For an application, construct `endpoint`, `credential`, and clients using the
getting-started guide rather than the test harness. The snippets use `indexClient`
(`SearchIndexClient`), `searchClient` (`SearchClient`, bound to the new index),
`indexers`/`indexerClient` (`SearchIndexerClient`), and unique index/source/KB names.
Create the hotel index with `PreviewHotelIndex`, then call
`UploadPreviewDocumentsAsync(searchClient, PreviewHotels())` before retrieval.
The following ordinary SDK/BCL helper methods are shared by the excerpts; include
them as members of your example class.

```C# Snippet:Azure_Search_Documents_Sample23_RequiredSetting
private static string RequiredPreviewSetting(string name) =>
    Environment.GetEnvironmentVariable(name) is string value && !string.IsNullOrWhiteSpace(value)
        ? value : throw new InvalidOperationException($"Set {name} before running this live sample.");
```

```C# Snippet:Azure_Search_Documents_Sample23_HotelFixture
private static SearchIndex PreviewHotelIndex(string indexName) => new SearchIndex(indexName)
{
    Fields =
    {
        new SimpleField("id", SearchFieldDataType.String) { IsKey = true, IsFilterable = true, IsSortable = true },
        new SearchableField("title"),
        new SearchableField("content"),
        new SimpleField("country", SearchFieldDataType.String) { IsFilterable = true, IsFacetable = true },
        new SimpleField("rating", SearchFieldDataType.Int32) { IsFilterable = true }
    },
    SemanticSearch = new Azure.Search.Documents.Indexes.Models.SemanticSearch
    {
        DefaultConfigurationName = "hotels",
        Configurations =
        {
            new SemanticConfiguration("hotels", new SemanticPrioritizedFields
            {
                TitleField = new SemanticField("title"),
                ContentFields = { new SemanticField("content") }
            })
        }
    }
};

private static SearchDocument[] PreviewHotels() => new[]
{
    new SearchDocument { ["id"] = "hotel-ca-1", ["title"] = "Harbor Hotel", ["country"] = "Canada",
        ["content"] = "Hotel guest benefits include complimentary wireless internet and breakfast.", ["rating"] = 5 },
    new SearchDocument { ["id"] = "hotel-ca-2", ["title"] = "Mountain Inn", ["country"] = "Canada",
        ["content"] = "Hotel guest benefits include complimentary wireless internet, breakfast and parking.", ["rating"] = 4 },
    new SearchDocument { ["id"] = "hotel-us-1", ["title"] = "Garden Hotel", ["country"] = "United States",
        ["content"] = "Hotel guest benefits include complimentary wireless internet and breakfast.", ["rating"] = 3 }
};
```

```C# Snippet:Azure_Search_Documents_Sample23_UploadDocuments
private static async Task UploadPreviewDocumentsAsync(SearchClient client, IEnumerable<SearchDocument> documents)
{
    SearchDocument[] batch = documents.ToArray();
    IndexDocumentsResult uploaded = await client.UploadDocumentsAsync(batch);
    if (uploaded.Results.Any(result => !result.Succeeded))
    {
        throw new InvalidOperationException("Some sample documents could not be uploaded.");
    }
    await WaitForPreviewDocumentCountAsync(client, batch.Length);
}

private static async Task WaitForPreviewDocumentCountAsync(SearchClient client, int expectedCount)
{
    for (int attempt = 0; attempt < 30; attempt++)
    {
        if ((await client.GetDocumentCountAsync()).Value == expectedCount)
        {
            return;
        }
        await Task.Delay(TimeSpan.FromSeconds(2));
    }
    throw new TimeoutException("Uploaded sample documents did not become searchable within 60 seconds.");
}
```

```C# Snippet:Azure_Search_Documents_Sample23_SemanticIntent
private static KnowledgeBaseRetrievalRequest PreviewIntent(string search) => new KnowledgeBaseRetrievalRequest
{
    Intents = { new KnowledgeRetrievalSemanticIntent(search) },
    IncludeActivity = true,
    MaxRuntimeInSeconds = 60,
    MaxOutputDocuments = 10
};
```

```C# Snippet:Azure_Search_Documents_Sample24_ReadResults
private static async Task<List<SearchResult<SearchDocument>>> ReadPreviewResultsAsync(SearchResults<SearchDocument> response)
{
    List<SearchResult<SearchDocument>> results = new List<SearchResult<SearchDocument>>();
    await foreach (SearchResult<SearchDocument> result in response.GetResultsAsync())
    {
        results.Add(result);
    }
    return results;
}
```

For native model examples, `openAIEndpoint` is an existing Azure OpenAI resource
root, `openAIKey` is its matching key, and `embeddingDeployment`/`embeddingModel`
identify its existing deployment and supported model. In the harness, supply
`SEARCH_OPENAI_ENDPOINT` and `SEARCH_OPENAI_KEY` to override encrypted settings;
the chat deployment/profile use `SEARCH_OPENAI_DEPLOYMENT_NAME` and
`SEARCH_OPENAI_MODEL_NAME`. Embedding examples use
`AZURE_OPENAI_EMBEDDING_DEPLOYMENT`/`AZURE_OPENAI_EMBEDDING_MODEL`; the file sample
uses `SEARCH_OPENAI_EMBEDDING_DEPLOYMENT_NAME`/`SEARCH_OPENAI_EMBEDDING_MODEL_NAME`.

Use the endpoint and credential setup from the [getting started guide](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/Azure.Search.Documents/README.md#getting-started).
The examples use these namespaces:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
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
        CacheTimeToLiveInSeconds = 300,
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
