# Azure.Search.Documents Samples - Hello World (sync)

## Import the namespaces
```C# Snippet:Azure_Search_Tests_Samples_Namespaces
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
```

## Create a client
Create a `SearchServiceClient` and send a request.
```C# Snippet:Azure_Search_Tests_Samples_CreateClient
// Get the service endpoint and API key from the environment
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

// Create a new SearchServiceClient
SearchServiceClient search = new SearchServiceClient(endpoint, credential);

// Perform an operation
Response<SearchServiceStatistics> stats = search.GetStatistics();
Console.WriteLine($"You are using {stats.Value.Counters.IndexCounter.Usage} indexes.");
```

## Handle Errors
All Search operations will throw a RequestFailedException on failure.
```C# Snippet:Azure_Search_Tests_Samples_HandleErrors
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));

// Create an invalid SearchIndexClientClient
string fakeIndexName = "doesnotexist";
SearchIndexClient index = new SearchIndexClient(endpoint, fakeIndexName, credential);
try
{
    index.GetCount();
}
catch (RequestFailedException ex) when (ex.Status == 404)
{
    Console.WriteLine("Index wasn't found.");
}
```