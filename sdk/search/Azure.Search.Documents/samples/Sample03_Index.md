# Azure.Search.Documents Samples - Index Operations

## Get Count
Retrieve a count of the number of documents in this search index.
```C# Snippet:Azure_Search_Tests_Samples_GetCountAsync
// Create a SearchIndexClient
Uri endpoint = new Uri(Environment.GetEnvironmentVariable("SEARCH_ENDPOINT"));
AzureKeyCredential credential = new AzureKeyCredential(
    Environment.GetEnvironmentVariable("SEARCH_API_KEY"));
string indexName = Environment.GetEnvironmentVariable("SEARCH_INDEX");
SearchIndexClient index = new SearchIndexClient(endpoint, indexName, credential);

// Get and report the number of documents in the index
Response<long> count = await index.GetDocumentCountAsync();
Console.WriteLine($"Search index {indexName} has {count.Value} documents.");
```
