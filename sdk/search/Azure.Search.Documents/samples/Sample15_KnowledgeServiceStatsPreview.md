# Knowledge Retrieval Service Statistics

This sample demonstrates how to retrieve service statistics that include knowledge base and knowledge source counters. These counters show usage and quota for knowledge retrieval resources on your search service.

For more information, see the [agentic retrieval documentation](https://learn.microsoft.com/azure/search/agentic-retrieval-overview).

## Required Namespaces

```C# Snippet:Azure_Search_Tests_Samples_Sample15_ServiceStats_Namespaces
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
```

## Get Service Statistics with Knowledge Counts

Retrieve service statistics and inspect the knowledge base and knowledge source counters.

```C# Snippet:Azure_Search_Tests_Samples_Sample15_ServiceStats_KnowledgeCounts
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Get service statistics including knowledge retrieval counters
SearchServiceStatistics stats = await indexClient.GetServiceStatisticsAsync();
SearchServiceCounters counters = stats.Counters;

// Display the new knowledge retrieval counters
Console.WriteLine("=== Knowledge Retrieval Service Statistics ===");
Console.WriteLine($"Knowledge Bases: {counters.KnowledgeBaseCounter.Usage} / {counters.KnowledgeBaseCounter.Quota}");
Console.WriteLine($"Knowledge Sources: {counters.KnowledgeSourceCounter.Usage} / {counters.KnowledgeSourceCounter.Quota}");

// Display other service counters for context
Console.WriteLine($"\nIndexes: {counters.IndexCounter.Usage} / {counters.IndexCounter.Quota}");
Console.WriteLine($"Documents: {counters.DocumentCounter.Usage}");
Console.WriteLine($"Storage size (bytes): {counters.StorageSizeCounter.Usage}");
```
