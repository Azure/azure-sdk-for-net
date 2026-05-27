# Freshness-Aware Retrieval for Knowledge Sources

This sample demonstrates how to use freshness-aware retrieval with ingestion-type Knowledge Sources. Freshness biases Retrieval-Augmented Generation (RAG) search results toward newer documents while preserving existing relevance signals (lexical, semantic, and vector similarity).

Key concepts:
- **FreshnessPolicy** on `KnowledgeSourceIngestionParameters` — configures how strongly recency influences ranking via `BoostingDuration` (ISO 8601 duration, e.g., `"P90D"` = 90 days).
- **EnableFreshness** on `KnowledgeSourceReference` — opt-in per source when attaching to a Knowledge Base.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create a Knowledge Source with Freshness Policy

Create an Azure Blob knowledge source with a `FreshnessPolicy` that configures a freshness scoring profile. Documents modified within the `BoostingDuration` window receive the highest boost, which decays linearly over time. This influences L1 ranking so newer documents are more likely to be selected for semantic reranking.

```C# Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_CreateSourceWithPolicy
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Configure ingestion parameters with a freshness policy.
// The freshnessPolicy enables freshness-aware retrieval, biasing
// results toward newer documents during RAG scenarios.
// BoostingDuration uses ISO 8601 duration format (e.g., "P90D" = 90 days).
// Documents modified within this window receive the highest freshness boost.
string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");

string blobSourceName = "my-blob-source";

string storageConnectionString = Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING");
string containerName = Environment.GetEnvironmentVariable("STORAGE_CONTAINER_NAME");

AzureBlobKnowledgeSource blobSource = new AzureBlobKnowledgeSource(
    blobSourceName,
    new AzureBlobKnowledgeSourceParameters(
        storageConnectionString,
        containerName)
    {
        IngestionParameters = new KnowledgeSourceIngestionParameters
        {
            FreshnessPolicy = new FreshnessPolicy
            {
                // Documents modified within the last 90 days get the highest boost.
                // The boost decays linearly over this window.
                BoostingDuration = "P90D"
            },
            EmbeddingModel = new KnowledgeSourceAzureOpenAIVectorizer
            {
                AzureOpenAIParameters = new AzureOpenAIVectorizerParameters
                {
                    ResourceUri = new Uri(openAIEndpoint),
                    ApiKey = openAIKey,
                    DeploymentName = "text-embedding-3-large",
                    ModelName = "text-embedding-3-large"
                }
            }
        }
    })
{
    Description = "Blob source with freshness-aware retrieval"
};

KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(blobSource);
Console.WriteLine($"Created knowledge source '{createdSource.Name}' with freshness policy");
```

## Create a Knowledge Base with Freshness Enabled

Create a knowledge base that references multiple knowledge sources. Use `EnableFreshness` on each `KnowledgeSourceReference` to selectively enable or disable freshness-aware retrieval per source.

```C# Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_CreateKBWithFreshness
// Create a knowledge base and enable freshness per knowledge source.
// enableFreshness = true activates the freshness scoring profile for
// that source during retrieval, biasing results toward newer documents.
// Sources without freshness enabled use standard relevance ranking.
string knowledgeBaseName = "my-freshness-kb";
KnowledgeBase knowledgeBase = new KnowledgeBase(
    knowledgeBaseName,
    knowledgeSources: new[]
    {
        new KnowledgeSourceReference(blobSourceName)
        {
            // Enable freshness-aware retrieval for the blob source
            EnableFreshness = true
        },
        new KnowledgeSourceReference(searchSourceName)
        {
            // Freshness not enabled for this source — standard ranking applies
            EnableFreshness = false
        }
    })
{
    Description = "KB with selective freshness-aware retrieval",
    OutputMode = KnowledgeRetrievalOutputMode.ExtractiveData,
    RetrievalReasoningEffort = new KnowledgeRetrievalMinimalReasoningEffort()
};


KnowledgeBase createdBase = await indexClient.CreateKnowledgeBaseAsync(knowledgeBase);
Console.WriteLine($"Created knowledge base '{createdBase.Name}'");

// Verify freshness settings on the knowledge source references
foreach (KnowledgeSourceReference ksRef in createdBase.KnowledgeSources)
{
    Console.WriteLine($"  Source '{ksRef.Name}': freshness = {ksRef.EnableFreshness}");
}
```

## Retrieve with Freshness-Aware Ranking

Retrieve from the knowledge base. Sources with `EnableFreshness = true` automatically apply the freshness scoring profile, boosting newer documents in the results.

```C# Snippet:Azure_Search_Tests_Samples_Sample16_Freshness_Retrieve
// Retrieve from the knowledge base. The blob source will use
// freshness-aware ranking (newer documents boosted), while the
// search index source uses standard relevance ranking.
KnowledgeBaseRetrievalClient retrievalClient = new KnowledgeBaseRetrievalClient(
    endpoint, knowledgeBaseName, credential);

KnowledgeBaseRetrievalRequest request = new KnowledgeBaseRetrievalRequest
{
    IncludeActivity = true
};
request.Intents.Add(new KnowledgeRetrievalSemanticIntent("What are the latest updates?"));

Response<KnowledgeBaseRetrievalResponse> response = await retrievalClient.RetrieveAsync(request);
KnowledgeBaseRetrievalResponse retrievalResponse = response.Value;

foreach (KnowledgeBaseMessage message in retrievalResponse.Response)
{
    foreach (KnowledgeBaseMessageContent content in message.Content)
    {
        if (content is KnowledgeBaseMessageTextContent textContent)
        {
            Console.WriteLine($"Response: {textContent.Text}");
        }
    }
}

foreach (KnowledgeBaseReference reference in retrievalResponse.References)
{
    Console.WriteLine($"Reference ID: {reference.Id}");
}
```
