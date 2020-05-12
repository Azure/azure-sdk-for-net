# Azure.Search.Documents Samples - Service Operations

## Get Statistics
Gets service level statistics for a Search Service.

This operation returns the number and type of objects in your service, the
maximum allowed for each object type given the service tier, actual and maximum
storage, and other limits that vary by tier.  This request pulls information
from the service so that you don't have to look up or calculate service limits.

Statistics on document count and storage size are collected every few minutes,
not in real time.  Therefore, the statistics returned by this API may not
reflect changes caused by recent indexing operations.

```C# Snippet:Azure_Search_Tests_Samples_GetStatisticsAsync
// Create a new SearchServiceClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
SearchServiceClient search = new SearchServiceClient(endpoint, credential);

// Get and report the Search Service statistics
Response<SearchServiceStatistics> stats = await search.GetStatisticsAsync();
Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} of {stats.Value.Counters.IndexCounter.Quota} indexes.");
```
