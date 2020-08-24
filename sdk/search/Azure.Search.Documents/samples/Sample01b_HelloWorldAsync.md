# Azure.Search.Documents Samples - Hello World (async)

## Import the namespaces

```C# Snippet:Azure_Search_Tests_Samples_Namespaces
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;
```

## Create a client

Create a `SearchServiceClient` and send a request.

```C# Snippet:Azure_Search_Tests_Samples_CreateClientAsync
// Get the service endpoint and API key from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

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
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

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
