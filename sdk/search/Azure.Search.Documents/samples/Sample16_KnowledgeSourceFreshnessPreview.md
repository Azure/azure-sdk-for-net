# Knowledge Source Defaults and Base Filter

This sample demonstrates how to use `BaseFilter` on a `SearchIndexKnowledgeSourceParameters` to set a persistent default filter, and how to compose it with `FilterAddOn` at retrieve time using `SearchIndexKnowledgeSourceParams`. It also shows KB-level defaults for output mode and reasoning effort.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create a Knowledge Source with Base Filter

Create a search index knowledge source with a `BaseFilter` that is automatically applied at retrieve time. This acts as a persistent default filter for the source.

```C# Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_CreateSourceWithDefaults
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a search index knowledge source with a base filter.
// The base filter is applied at retrieval time by default and can
// be combined with a filterAddOn at query time using AND logic.
string searchSourceName = "my-hotels-search-source";
SearchIndexKnowledgeSource searchSource = new SearchIndexKnowledgeSource(
    searchSourceName,
    new SearchIndexKnowledgeSourceParameters(indexName)
    {
        // Set a base filter that is always applied to this source at retrieve time.
        // This acts as a persistent "default" filter for the knowledge source.
        BaseFilter = "category eq 'Luxury'",
        SourceDataFields =
        {
            new SearchIndexFieldReference("hotelId"),
            new SearchIndexFieldReference("hotelName"),
            new SearchIndexFieldReference("description"),
        }
    })
{
    Description = "Hotels search index source with base filter"
};

await indexClient.CreateKnowledgeSourceAsync(searchSource);
Console.WriteLine($"Created search index knowledge source '{searchSourceName}'");
```

## Create a Knowledge Base with Defaults

Create a knowledge base with KB-level defaults for output mode and reasoning effort. These defaults apply to every retrieve call unless overridden at request time.

```C# Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_CreateKBWithDefaults
// Create a knowledge base with persisted retrieval defaults.
// These defaults apply to every retrieve call unless overridden at request time.
string knowledgeBaseName = "my-freshness-kb";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(searchSourceName)
    })
{
    Description = "KB with persisted defaults and base filter",

    // KB-level defaults for output mode and reasoning effort
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort()
};

KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Created knowledge base '{createdBase.Name}'");
Console.WriteLine($"  Output mode default: {createdBase.OutputMode}");
```

## Retrieve with FilterAddOn

Retrieve from the knowledge base, composing the source's `BaseFilter` with a `FilterAddOn` at runtime. The effective filter becomes `(baseFilter) AND (filterAddOn)`.

```C# Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_RetrieveWithDefaults
// Retrieve using the KB's persisted defaults and compose a filterAddOn
// with the source's baseFilter. The baseFilter ("category eq 'Luxury'") is
// automatically applied, and the filterAddOn is combined with AND.
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

// The request inherits the KB-level defaults (outputMode, reasoning effort).
// Use knowledgeSourceParams to add a filterAddOn that composes with the
// source's baseFilter using AND logic.
KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the best luxury hotels?"));

// Add per-source runtime parameters with filterAddOn.
// At retrieval time the effective filter becomes:
//   (category eq 'Luxury') AND (rating ge 4)
request.KnowledgeSourceParams.Add(
    new SearchIndexKnowledgeSourceParams(searchSourceName)
    {
        FilterAddOn = "rating ge 4",
        IncludeReferences = true,
        IncludeReferenceSourceData = true
    });

Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

// Display references and their source data
foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}, Score: {reference.RerankerScore}");
    foreach (var kvp in reference.SourceData)
    {
        Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
    }
}

// Activity records show the retrieval flow
foreach (KnowledgeBaseActivityRecord activity in retrievalResponse.Activity)
{
    Console.WriteLine($"Activity ID: {activity.Id}, Elapsed: {activity.ElapsedMs}ms");
}
```
