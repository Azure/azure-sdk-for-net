# Knowledge Source Operations

This sample demonstrates CRUD (Create, Read, Update, Delete) operations for knowledge sources in Azure AI Search. Knowledge sources define where a knowledge base retrieves its data from.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Documents_Tests_Samples_Sample11_KnowledgeSource_Namespaces
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
        }
    })
{
    Description = "Hotels search index knowledge source"
};

KnowledgeSource createdSource = await indexClient.CreateKnowledgeSourceAsync(searchIndexSource);
Console.WriteLine($"Created knowledge source '{createdSource.Name}'");
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

// List all knowledge sources
await foreach (KnowledgeSource source in indexClient.GetKnowledgeSourcesAsync())
{
    Console.WriteLine($"Knowledge source: {source.Name} ({source.GetType().Name})");
}
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
