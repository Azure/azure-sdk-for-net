# Knowledge Source Operations

This sample demonstrates CRUD (Create, Read, Update, Delete) operations for knowledge sources in Azure AI Search. Knowledge sources define where a knowledge base retrieves its data from.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Namespaces
using System.IO;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.KnowledgeBases.Models;
```

## Create a Search Index Knowledge Source

Create a knowledge source backed by a search index, with specific fields included in citation references.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_CreateSearchIndex
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a knowledge source that references a search index
string knowledgeSourceName = "my-search-index-source";
SearchIndexKnowledgeSource searchIndexSource = new SearchIndexKnowledgeSource(
    knowledgeSourceName,
    new SearchIndexKnowledgeSourceParameters(indexName)
    {
        // Specify which fields to include in citation references
        SourceDataFields =
        {
            new SearchIndexFieldReference("hotelId"),
            new SearchIndexFieldReference("hotelName"),
        },

        // Guide query planning toward useful filters and boosts.
        QueryHints = new SearchIndexKnowledgeSourceQueryHints
        {
            Filters =
            {
                new SearchIndexKnowledgeSourceFilterHint(
                    "category",
                    new[] { "Luxury", "Budget" })
                {
                    FilterInstructions = "Use this field when the user specifies a hotel category."
                }
            },
            Boosts =
            {
                new SearchIndexKnowledgeSourceFieldValueBoost("category", 2.0)
                {
                    FieldValues = { "Luxury" },
                    BoostInstructions = "Boost luxury hotels when premium amenities are requested."
                }
            }
        }
    })
{
    Description = "Hotels search index knowledge source"
};

KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(searchIndexSource);
Console.WriteLine($"Created knowledge source '{createdSource.Name}'");
```

## Create a Private Blob Knowledge Source and Inspect Its Analyzer

This live-only scenario requires a supported indexed Blob source, private connectivity from the Search service to its dependencies, an attached AI Services resource, and an embedding deployment. `NetworkAccessMode.Private` is a create-time ingestion setting. With minimal extraction and AI Services attached, the service detects language and selects an analyzer on the generated index; analyzer selection is not a query-time option. Services must define and test their unsupported-language fallback behavior separately.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_PrivateBlob
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

string knowledgeSourceName = "my-private-blob-source";
string storageConnectionString = Environment.GetEnvironmentVariable("STORAGE_CONNECTION_STRING");
string containerName = Environment.GetEnvironmentVariable("STORAGE_CONTAINER_NAME");
string aiServicesEndpoint = Environment.GetEnvironmentVariable("AI_SERVICES_ENDPOINT");
string aiServicesKey = Environment.GetEnvironmentVariable("AI_SERVICES_KEY");
string openAIEndpoint = Environment.GetEnvironmentVariable("OPENAI_ENDPOINT");
string openAIKey = Environment.GetEnvironmentVariable("OPENAI_KEY");

KnowledgeSourceIngestionParameters ingestion = new KnowledgeSourceIngestionParameters
{
    // Private is a create-time setting for supported indexed sources.
    NetworkAccessMode = KnowledgeSourceNetworkAccessMode.Private,
    ContentExtractionMode = KnowledgeSourceContentExtractionMode.Minimal,
    AiServices = new AIServices(new Uri(aiServicesEndpoint))
    {
        ApiKey = aiServicesKey
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
};

AzureBlobKnowledgeSource blobSource = new AzureBlobKnowledgeSource(
    knowledgeSourceName,
    new AzureBlobKnowledgeSourceParameters(storageConnectionString, containerName)
    {
        IngestionParameters = ingestion
    });

await indexClient.CreateKnowledgeSourceAsync(blobSource);

// Wait for the service to report the generated index. Creation is asynchronous.
AzureBlobKnowledgeSource persisted = null;
for (int attempt = 0; attempt < 12; attempt++)
{
    persisted = (AzureBlobKnowledgeSource)await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
    if (persisted.AzureBlobParameters.CreatedResources?.AdditionalProperties.ContainsKey("index") == true)
    {
        break;
    }
    await Task.Delay(TimeSpan.FromSeconds(5));
}

KnowledgeSourceStatus status = await indexClient.GetKnowledgeSourceStatusAsync(knowledgeSourceName);

Console.WriteLine($"Synchronization status: {status.SynchronizationStatus}");
if (persisted?.AzureBlobParameters.CreatedResources is null)
{
    throw new InvalidOperationException("The service did not report generated resources.");
}
foreach (KeyValuePair<string, string> resource in persisted.AzureBlobParameters.CreatedResources.AdditionalProperties)
{
    Console.WriteLine($"Generated {resource.Key}: {resource.Value}");
}

if (!persisted.AzureBlobParameters.CreatedResources.AdditionalProperties.TryGetValue(
    "index",
    out string generatedIndexName))
{
    throw new InvalidOperationException("The service did not report a generated index.");
}

SearchIndex generatedIndex = await indexClient.GetIndexAsync(generatedIndexName);
SearchField microsoftAnalyzerField = generatedIndex.Fields.FirstOrDefault(
    field => field.AnalyzerName == LexicalAnalyzerName.EnMicrosoft);
Console.WriteLine($"Service-selected analyzer: {microsoftAnalyzerField?.AnalyzerName}");
```

## Create a Web Knowledge Source

Create a web knowledge source with allowed and blocked domain lists.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_CreateWeb
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Create a web knowledge source with allowed and blocked domains
string knowledgeSourceName = "my-web-source";
WebKnowledgeSource webSource = new WebKnowledgeSource(knowledgeSourceName)
{
    Description = "Web knowledge source for documentation",
    WebParameters = new WebKnowledgeSourceParameters
    {
        Domains = new WebKnowledgeSourceDomains()
    }
};
webSource.WebParameters.Domains.AllowedDomains.Add(
    new WebKnowledgeSourceDomain("learn.microsoft.com") { IncludeSubpages = true });
webSource.WebParameters.Domains.BlockedDomains.Add(
    new WebKnowledgeSourceDomain("internal.example.com"));

KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(webSource);
Console.WriteLine($"Created web knowledge source '{createdSource.Name}'");
```

## Get a Knowledge Source

Retrieve a specific knowledge source by name.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Get
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get a specific knowledge source by name
KnowledgeSource knowledgeSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);
Console.WriteLine($"Knowledge source '{knowledgeSource.Name}' of type {knowledgeSource.GetType().Name}");

if (knowledgeSource is SearchIndexKnowledgeSource searchIndexSource)
{
    Console.WriteLine($"  References index: {searchIndexSource.SearchIndexParameters.SearchIndexName}");
}
```

## List Knowledge Sources

Enumerate all knowledge sources in a search service.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_List
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Request small pages and let AsyncPageable follow opaque continuation
// state internally. Do not parse or modify continuation tokens.
HashSet<string> sourceNames = new HashSet<string>();
await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync(pageSize: 1))
{
    if (!sourceNames.Add(source.Name))
    {
        throw new InvalidDataException($"Duplicate knowledge source '{source.Name}' was returned.");
    }
    Console.WriteLine($"Knowledge source: {source.Name} ({source.GetType().Name})");
}
Console.WriteLine($"Listed {sourceNames.Count} unique knowledge sources.");
```

## Update a Knowledge Source

Get an existing knowledge source, modify it, and save the changes back.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Update
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get the existing knowledge source
KnowledgeSource existingSource = await indexClient.GetKnowledgeSourceAsync(knowledgeSourceName);

// Update its description
existingSource.Description = "Updated description for the knowledge source";

KnowledgeSource updatedSource = await indexClient.CreateOrUpdateKnowledgeSourceAsync(existingSource);
Console.WriteLine($"Updated knowledge source '{updatedSource.Name}': {updatedSource.Description}");
```

## Delete a Knowledge Source

Delete a knowledge source by name.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Delete
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Delete a knowledge source by name
await indexClient.DeleteKnowledgeSourceAsync(knowledgeSourceName);
Console.WriteLine($"Deleted knowledge source '{knowledgeSourceName}'");
```

## Get Knowledge Source Status

Retrieve the synchronization status and history of a knowledge source.

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_GetStatus
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string knowledgeSourceName = Environment.GetEnvironmentVariable("KNOWLEDGE_SOURCE_NAME");

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get the status of a knowledge source
KnowledgeSourceStatus status = await indexClient.GetKnowledgeSourceStatusAsync(knowledgeSourceName);
Console.WriteLine($"Knowledge source kind: {status.Kind}");
Console.WriteLine($"Synchronization status: {status.SynchronizationStatus}");
Console.WriteLine($"Synchronization interval: {status.SynchronizationInterval}");

if (status.LastSynchronizationState != null)
{
    Console.WriteLine($"Last sync started: {status.LastSynchronizationState.StartTime}");
    Console.WriteLine($"Last sync ended: {status.LastSynchronizationState.EndTime}");
}

if (status.Statistics != null)
{
    Console.WriteLine($"Total synchronizations: {status.Statistics.TotalSynchronization}");
}
```
