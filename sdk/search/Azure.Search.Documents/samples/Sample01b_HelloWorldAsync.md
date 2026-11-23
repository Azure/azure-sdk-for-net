# Azure.Search.Documents Samples - Hello World (async)

## Import the namespaces

```C# Snippet:Azure_Search_Tests_Samples_Namespaces
using Azure.Identity;
using Azure.Core;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
```

## Create a client

Create a `SearchServiceClient` and send a request.

```C# Snippet:Azure_Search_Tests_Samples_CreateClientAsync
// Get the service endpoint and authenticate with Microsoft Entra ID
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();

// Create a new SearchIndexClient
SearchIndexClient indexClient = new SearchIndexClient(endpoint, credential);

// Perform an operation
Response<SearchServiceStatistics> stats = await indexClient.GetServiceStatisticsAsync();
Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} indexes.");
```

## Handle Errors

All Search operations will throw a RequestFailedException on failure.

```C# Snippet:Azure_Search_Tests_Samples_HandleErrorsAsync
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
TokenCredential credential = new DefaultAzureCredential();

// Create an invalid SearchClient
string fakeIndexName = "doesnotexist";
SearchClient searchClient = new SearchClient(endpoint, fakeIndexName, credential);
try
{
    await searchClient.GetDocumentCountAsync();
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("Index wasn't found.");
}
```
